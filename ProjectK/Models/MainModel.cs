using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectK.Core;
using System.Drawing;

namespace ProjectK.Models
{
    class MainModel
    {
        internal string CheckUserName()
        {
            if (User.Role == UserRole.Guest)
            {
                String auto_mode = User.Autonom ? " (offline)" : "";
                return "Здравствуйте, Гость" + auto_mode + ".";
            }
            else
                return $"Здравствуйте, {User.Name} ({User.Role})";
        }

        internal List<Computer> RefreshComputers()
        {
            if (User.Autonom)
            {
                MessageBox.Show(User.AutonomWarning, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return Pgs.GetNetworkComputerList();
        }

        internal void ComputerSelected(Computer computer, ComputerExplorer computerExplorer1, RichTextBox rtbPcInfo)
        {
            if (computerExplorer1.SelectedComputer != computer)
            {
                computerExplorer1.SetComputer(computer);
                String[] titles = { "Имя:", "IP:", "MAC:", "Номер аудитории:" };
                rtbPcInfo.Text = $"{titles[0]} {computer._Name}\n{titles[1]} {computer._Ip}\n{titles[2]} {computer._MAC}\n{titles[3]} {computer._AuditNumber}";

                foreach (string title in titles)
                {
                    rtbPcInfo.SelectionStart = rtbPcInfo.Text.IndexOf(title);
                    rtbPcInfo.SelectionLength = title.Length;
                    rtbPcInfo.SelectionFont = new Font(rtbPcInfo.Font, FontStyle.Bold);
                }
                rtbPcInfo.SelectionLength = 0;
            }
        }
    }
}
