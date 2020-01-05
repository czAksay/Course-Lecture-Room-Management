using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectK.Presenter
{
    interface IMainPresenter
    {
        void CheckUserName();
        void RefreshComputers();
        void ComputerSelected(Computer computer, ComputerExplorer computerExplorer1, RichTextBox rtbPcInfo);
    }
}
