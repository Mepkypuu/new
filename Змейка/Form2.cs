using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace РГР
{
    public partial class Form2 : Form
    {
        Label passedlabel;
        //DateTime date;
        public Form2(Label fromfirst)
        {
            InitializeComponent();
            passedlabel = fromfirst;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.AliceBlue;
            //date = new DateTime();
        }

      
        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                StreamWriter writer = new StreamWriter("file.txt", true);
                writer.WriteLine(textBox1.Text);
                writer.WriteLine(passedlabel.Text);
                writer.WriteLine(DateTime.Now.ToShortDateString());
                writer.Close();

                this.Close();
            }
         
        }
    }
}
