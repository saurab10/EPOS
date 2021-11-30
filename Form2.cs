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

namespace Assignment_4
{
    public partial class Form2 : Form
    {
        public string JoiningDate;
        //Form1.
        readonly static string[] CakeName = Form1.CakeNames;
            //{ "Chocolate               ", "Vanilla                     ", "Strawberry     ", "Pineapple      ", "Blackforest    ", "Red Velvet     ", "New York Cheese", "Choco Lava     ", "Fruit Cake     ", "Lemon Coconut  ", "Mousse         ", "Blueberry      ", "Banana         ", "Caramel        " };
        public string[] ReadFile = new string[6];
        List<string> CakeNames1 = new List<string>();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DateTime CurrentTime = DateTime.Now;
            JoiningDate = CurrentTime.ToShortDateString();
            textBox1.Text = "Trading Day" + "  " + JoiningDate + " , " + "Generation Time" + " " + DateTime.Now.ToShortTimeString() + Environment.NewLine;
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("\n"+"Stock Available" + Environment.NewLine);
            //textBox1.AppendText("                            " + "  Slice   , Personal ,  Small  ,   Medium  ,   Large  " + Environment.NewLine);

            //try
            //{
            //    StreamReader InputFile = File.OpenText("stock.txt");

            //    for (int row = 0; row < 14; row++)
            //    {
            //        textBox1.AppendText(CakeNames[row] + " ");
            //        for (int col = 0; col < 5; col++)
            //        {
            //            textBox1.AppendText(""+InputFile.ReadLine() + "            ");
            //            //stocknumbers[row, col] = int.Parse(InputFile.ReadLine());
            //        }
            //        textBox1.AppendText(Environment.NewLine);
            //    }
            //    InputFile.Close();
            //}
            //catch (Exception ex)
            //{
            //    //Display an Error Message
            //    MessageBox.Show(ex.Message);
            //}
            try
            {
                StreamReader InputFile = File.OpenText("stock.txt");

                for (int row = 0; row < 14; row++)
                {
                    ReadFile[0] = ((CakeName[row]));
                    for (int col = 1; col < 6; col++)
                    {
                        ReadFile[col] = (InputFile.ReadLine());
                        //stocknumbers[row, col] = int.Parse(InputFile.ReadLine());
                    }
                    ListViewItem item = new ListViewItem(ReadFile);
                    listView1.Items.Add(item);
                    //listView1.GridLines = true;
                    textBox1.AppendText(Environment.NewLine);
                }
                InputFile.Close();
            }
            catch (Exception ex)
            {
                //Display an Error Message
                MessageBox.Show(ex.Message);
            }




        }
    }
}
