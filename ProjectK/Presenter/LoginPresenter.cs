using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettingsAP;
using System.Windows.Forms;
using ProjectK.Core;
using ProjectK.Models;
using System.Drawing;

namespace ProjectK.Presenter
{
    class LoginPresenter : ILoginPresenter
    {
        LoginModel model;
        ILoginView view;

        public LoginPresenter(ILoginView view)
        {
            model = new LoginModel();
            this.view = view;
        }

        public void CheckConnection(string Ip, string Port)
        {
            if (model.CheckConnection(Ip, Port))
            {
                view.SetTriggerColor(Color.FromArgb(15, 240, 30));
            }
            else
            {
                view.SetTriggerColor(Color.Red);
            }
        }

        public void GuestSignIn(string Ip, string Port)
        {
            if (model.GuestSignIn(Ip, Port))
            {
                view.SignedIn();
            }
        }

        public void SetDefaultSettings()
        {
            model.SetDefaultSettings();
        }

        public void SetIpPort()
        {
            string ip, port;
            if (!model.SetIpPort(out ip, out port))
            {
                view.SetTriggerBoxRed();
            }
            view.SetTextBoxesIpPort(ip, port);
        }

        public void SignIn(string Login, string Pass)
        {
            if (model.SignIn(Login, Pass))
            {
                view.SignedIn();
            }
        }
    }
}
