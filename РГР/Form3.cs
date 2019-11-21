using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace РГР
{
    public partial class Form3 : Form
    {
        List<Data> _list = new List<Data>();

        public Form3(List<Data> list)
        {
            InitializeComponent();
            _list.AddRange(list.ToArray());
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < Math.Min(_list.Count, 10); i++)
            {
                listBox1.Items.Add((i + 1).ToString("00").PadLeft(5) + " " + _list[i].name.PadRight(7, ' ') +
                                   _list[i].c.ToString().PadRight(7) +
                                   _list[i].date1.ToString().PadRight(7));
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}