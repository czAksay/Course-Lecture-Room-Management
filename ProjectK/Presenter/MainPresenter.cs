using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectK.Models;
using ProjectK.View;
using System.Windows.Forms;

namespace ProjectK.Presenter
{
    class MainPresenter : IMainPresenter
    {
        MainModel model;
        IMainView view;

        public MainPresenter(IMainView view)
        {
            model = new MainModel();
            this.view = view;
        }

        public void CheckUserName()
        {
            view.SetHelloLabel(model.CheckUserName());
        }

        public void ComputerSelected(Computer computer, ComputerExplorer computerExplorer1, RichTextBox rtbPcInfo)
        {
            model.ComputerSelected(computer, computerExplorer1, rtbPcInfo);
        }

        public void RefreshComputers()
        {
            var computers = model.RefreshComputers();
            if (computers != null)
                view.RefreshComputers(computers);
        }
    }
}
