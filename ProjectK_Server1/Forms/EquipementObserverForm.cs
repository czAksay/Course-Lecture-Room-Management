using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectK_Server1
{
    public partial class EquipementObserverForm : Form
    {
        public EquipementObserverForm()
        {
            InitializeComponent();
            RefreshItems();
        }

        private void RefreshItems()
        {
            List<String[]> equips = Pgs.GetEquipementsGroupedByAuditories();
            String lastAud = "";
            foreach(String[] eq in equips)
            {
                if (lastAud != eq[1])
                {
                    lastAud = eq[1];
                    Label l = new Label()
                    {
                        Text = eq[1],
                        AutoSize = true,
                        Font = new Font("Arial", 13, FontStyle.Bold),
                        Margin = new Padding(2, 4, 2, 4)
                    };
                    flpEquips.Controls.Add(l);
                }
                Label l2 = new Label()
                {
                    Text = eq[0] + " [" + eq[2] + "]",
                    AutoSize = true,
                    Font = new Font("Arial", 12),
                    Margin = new Padding(15, 3, 3, 3)
                };
                flpEquips.Controls.Add(l2);
            }
        }
    }
}
