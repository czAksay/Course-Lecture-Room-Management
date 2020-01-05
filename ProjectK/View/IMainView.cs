using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK.View
{
    interface IMainView
    {
        void SetHelloLabel(string Text);
        void RefreshComputers(List<Computer> list);
    }
}
