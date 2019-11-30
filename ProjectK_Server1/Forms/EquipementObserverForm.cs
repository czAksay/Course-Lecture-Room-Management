using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectK.Core;

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
            int broken = 0;
            foreach (String[] eq in equips)
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
                broken = FillEquips(eq);
            }

            if (broken == 0)
                return;

            Label l3 = new Label()
            {
                Text = "Вышедшее из строя оборудование",
                AutoSize = true,
                Font = new Font("Arial", 13, FontStyle.Bold),
                Margin = new Padding(2, 4, 2, 4)
            };

            flpEquips.Controls.Add(l3);
            foreach (var eq in equips)
            {
                if (!bool.Parse(eq[5]))
                    FillEquips(eq);
            }
        }

        private int FillEquips(string[] eq)
        {
            int i = -1;
            int broken_count = 0;
            foreach (String e in eq)
            {
                Label l2 = new Label();
                l2.AutoSize = true;
                l2.Font = new Font("Arial", 12);
                l2.Margin = new Padding(15, 3, 3, 3);
                i++;
                if (i == 0)
                {
                    l2.Text = "Название: " + eq[0];
                }
                else if (i == 2)
                {
                    l2.Text = "Тип: " + eq[2];
                }
                else if (i == 3)
                {
                    l2.Text = "Количество: " + eq[3];
                }
                else if (i == 4)
                {
                    l2.Text = "Цена: " + eq[4] + "$";
                }
                else if (i == 5)
                {
                    l2.Text = "Статус: " + (bool.Parse(eq[5]) ? "Рабочий" : "Сломано");
                    if (bool.Parse(eq[5]))
                        broken_count++;
                    l2.Margin = new Padding(15, 3, 3, 15);
                }
                else
                    continue;
                flpEquips.Controls.Add(l2);
            }
            return broken_count;
        }
    }
}
