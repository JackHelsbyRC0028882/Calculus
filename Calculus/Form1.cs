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
namespace Calculus
{
    public partial class Form1 : Form
    {
        class row
        {
            public double time;
            public double voltage;
            public double current; 
        }
        List<row> table = new List<row>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = "";
            openFileDialog2.Filter = "CSV Files|*.csv";
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog2.FileName))
                    {
                        string line = sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            table.Add(new row());
                            string[] l = sr.ReadLine().Split(',');
                            table.Last().time = double.Parse(l[0]);
                            table.Last().voltage = double.Parse(l[1]);
                            table.Last().current = double.Parse(l[2]);

                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show(openFileDialog2.FileName + " failed to open.");
                }
                catch (FormatException)
                {
                    MessageBox.Show(openFileDialog2.FileName + " is not in the required format.");
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show(openFileDialog2.FileName + " is not in the required format");
                }
            }
        }
    }
}
