using KTZipPresentation.Model;
using KTZipPresentation.View;
using System;
using System.Collections.Generic;
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

        private void TheView_ReloadContent(string obj)
        {
            theModel.reloadDirs();
            theModel.reloadFiles();
            theView.SetDataGrid(theModel.filesGrid);
        }

        private void TheView_SendGridTempl()
        {
            theModel.filesGrid = theView.GetDataGrid();
        }
    }
}
