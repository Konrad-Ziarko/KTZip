using KTZipPresentation.Model;
using KTZipPresentation.Properties;
using KTZipPresentation.View;
using System.Windows.Forms;
using Be.Windows.Forms;
using System.Threading;
using System.Text;
using System.IO;
using System.Drawing;
using Trinet.Core.IO.Ntfs;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace KTZipPresentation.Control
{
    public class MainControler
    {
        #region DllImports
        [DllImport("shell32.dll", SetLastError = true)]
        static extern int SHMultiFileProperties(IDataObject pdtobj, int flags);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ILCreateFromPath(string path);

        [DllImport("shell32.dll", CharSet = CharSet.None)]
        public static extern void ILFree(IntPtr pidl);

        [DllImport("shell32.dll", CharSet = CharSet.None)]
        public static extern int ILGetSize(IntPtr pidl);

        #region GetFileOrMultipleFilesProperties
        private static MemoryStream CreateShellIDList(StringCollection filenames)
        {
            int pos = 0;
            byte[][] pidls = new byte[filenames.Count][];
            foreach (var filename in filenames)
            {
                IntPtr pidl = ILCreateFromPath(filename);
                int pidlSize = ILGetSize(pidl);
                pidls[pos] = new byte[pidlSize];
                Marshal.Copy(pidl, pidls[pos++], 0, pidlSize);
                ILFree(pidl);
            }
            int pidlOffset = 4 * (filenames.Count + 2);
            var memStream = new MemoryStream();
            var sw = new BinaryWriter(memStream);
            sw.Write(filenames.Count);
            sw.Write(pidlOffset);
            pidlOffset += 4;
            foreach (var pidl in pidls)
            {
                sw.Write(pidlOffset);
                pidlOffset += pidl.Length;
            }
            sw.Write(0);
            foreach (var pidl in pidls) sw.Write(pidl);
            return memStream;
        }
        public static int ShowFilesProperties(IEnumerable<string> Filenames)
        {
            StringCollection Files = new StringCollection();
            foreach (string s in Filenames) Files.Add(s);
            var data = new DataObject();
            data.SetFileDropList(Files);
            data.SetData("Preferred DropEffect", true, new MemoryStream(new byte[] { 5, 0, 0, 0 }));
            data.SetData("Shell IDList Array", true, CreateShellIDList(Files));
            return SHMultiFileProperties(data, 0);
        }
        #endregion

        #endregion

        MainModel theModel;
        MainWindow theView;
        List<string> filesToCut = null;
        List<string> filesToCopy = null;
        public enum OperationType
        {
            FirstLoad,
            LoadNext,
            LoadPrev,
            Reload,
            LoadNew,
            MoveUp,
            NoReload,
        }
        public MainControler(MainWindow theView, MainModel theModel)
        {
            this.theModel = theModel;
            this.theView = theView;

            this.theView.ASendGridTempl += TheView_SendGridTempl;
            this.theView.AReloadContent += TheView_ReloadContent;
            this.theView.ADeleteSelectedFiles += TheView_ADeleteSelectedFiles;
            this.theView.AContentDoubleClick += TheView_AContentDoubleClick1;
            this.theView.AShowProperties += TheView_AShowProperties;
            this.theView.ACutFiles += TheView_ACutFiles;
            this.theView.ACopyFiles += TheView_ACopyFiles;
            this.theView.APasteFiles += TheView_APasteFiles;
        }

        private void TheView_APasteFiles(string path)
        {
            List<string> notSuccessful = new List<string>();
            if (path != null && path != "")
                if (filesToCut != null)
                {
                    notSuccessful = theModel.TheModel_APasteFilesFromCut(filesToCut, path);
                    filesToCut = null;
                    theView.resetCutPaste();
                }
                else
                {
                    notSuccessful = theModel.TheModel_APasteFilesFromCopy(filesToCopy, path);
                    if (notSuccessful.Count > 0)
                    {
                        filesToCopy = null;
                        theView.resetCutPaste();
                    }
                }
            if (notSuccessful.Count > 0)
                new ErrorForm(notSuccessful, "Niestety nie udało się skopiować niektórych plików:").ShowDialog();
        }

        private void TheView_ACopyFiles(DataGridViewSelectedRowCollection files)
        {
            filesToCut = null;
            filesToCopy = new List<string>();
            foreach (DataGridViewRow row in files)
                filesToCopy.Add(Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString());
        }

        private void TheView_ACutFiles(DataGridViewSelectedRowCollection files)
        {
            filesToCopy = null;
            filesToCut = new List<string>();
            foreach (DataGridViewRow row in files)
                filesToCut.Add(Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString());
        }

        private void TheView_AShowProperties(DataGridViewSelectedRowCollection pathToFile)
        {
            List<string> files = new List<string>();
            foreach (DataGridViewRow row in pathToFile)
                files.Add(Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString());
            ShowFilesProperties(files);
        }

        private void TheView_AContentDoubleClick1(string path, string attributes)
        {
            if (attributes == "D")
                TheView_ReloadContent(path, OperationType.LoadNew);
            else if (attributes == "F" || attributes == "A")
            {
                var prevEdit = new PreviewEditForm();
                DynamicFileByteProvider provider = null;
                if (attributes == "F")
                {
                    provider = new DynamicFileByteProvider(path);
                }
                else
                {
                    string[] adsFilePathParts = path.Split(':');
                    string newPath = string.Empty;
                    for (int i = 0; i < adsFilePathParts.Length - 1; i++)
                    {
                        newPath += adsFilePathParts[i] + ':';
                    }
                    newPath = newPath.Remove(newPath.Length - 1);
                    FileInfo fileInfo = new FileInfo(newPath);
                    FileStream fs = fileInfo.GetAlternateDataStream(adsFilePathParts[adsFilePathParts.Length - 1]).OpenRead();
                    provider = new DynamicFileByteProvider(fs);
                }
                using (var hexBox = new HexBox { ByteProvider = provider })
                {
                    hexBox.Dock = DockStyle.Fill;
                    hexBox.VScrollBarVisible = true;
                    hexBox.StringViewVisible = true;
                    hexBox.ShadowSelectionVisible = true;
                    hexBox.LineInfoVisible = true;
                    hexBox.ColumnInfoVisible = true;
                    hexBox.UseFixedBytesPerLine = true;
                    hexBox.Font = new Font("Segoe", 11);
                    hexBox.BackColor = Color.FromArgb(20, 20, 20);
                    hexBox.ForeColor = Color.FromArgb(150, 150, 150);

                    prevEdit.addToPanel(hexBox);
                    prevEdit.Width = hexBox.RequiredWidth + 50;
                    prevEdit.ShowDialog();
                }
                provider.Dispose();
            }
        }

        private void TheView_ADeleteSelectedFiles(DataGridViewSelectedRowCollection rows)
        {
            List<string> result = theModel.DeleteSelectedFiles(rows);
            if (result.Count>0)
                new ErrorForm(result, "Niestety nie udało się usunąć niektórych plików:").ShowDialog();
        }

        private void TheView_ReloadContent(string path, OperationType OpTy)
        {
            theModel.reloadContent(path, OpTy);
            if (theModel.filesGrid.SortedColumn != null)
            {
                DataGridViewColumn col = theModel.filesGrid.SortedColumn;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            theView.SetComboBoxText(Settings.Default.CurrentPath);
        }

        private void TheView_SendGridTempl()
        {
            DataGridView dgv = null;
            theView.GetDataGrid(ref dgv);
            theModel.filesGrid = dgv;
        }
    }
}
