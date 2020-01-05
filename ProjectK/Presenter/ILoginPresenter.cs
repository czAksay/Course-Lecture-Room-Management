using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK.Presenter
{
    interface ILoginPresenter
    {
        void SetDefaultSettings();
        void SignIn(string Login, string Pass);
        void SetIpPort();
        void CheckConnection(string Ip, string Port);
        void GuestSignIn(string Ip, string Port);
    }
}
