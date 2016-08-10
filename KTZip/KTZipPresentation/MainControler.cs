using KTZipPresentation.Model;
using KTZipPresentation.Properties;
using KTZipPresentation.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTZipPresentation.Control
{
    public class MainControler
    {
        MainModel theModel;
        MainWindow theView;
        public MainControler(MainWindow theView, MainModel theModel)
        {
            this.theModel = theModel;
            this.theView = theView;

            this.theView.SendGridTempl += TheView_SendGridTempl;
            this.theView.ReloadContent += TheView_ReloadContent;
        }

        private void TheView_ReloadContent(string obj, int isForward)
        {
            theModel.reloadContent(obj, isForward);
            theView.SetDataGrid(theModel.filesGrid);
            theView.SetTextBoxText(Settings.Default.CurrentPath);
        }

        private void TheView_SendGridTempl()
        {
            theModel.filesGrid = theView.GetDataGrid();
        }
    }
}
