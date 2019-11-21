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
    
    public partial class Form3 :  Form
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
            if(_list.Count <10)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    listBox1.Items.Add(i + 1 + ". " + _list[i].name.PadRight(15) + _list[i].c.ToString().PadRight(15) + _list[i].date1.ToString().PadRight(15));
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    listBox1.Items.Add(i + 1 + ". " + _list[i].name.PadRight(15) + _list[i].c.ToString().PadRight(15) + _list[i].date1.ToString().PadRight(15));
                }
            }
           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
