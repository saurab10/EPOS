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
    public partial class Form1 : Form
    {
        readonly static string[] Sizes = { "Slice", "Personal" , "Small" , "Medium" , "Large" };
     public static string[] CakeNames { get; private set; } = { "Chocolate", "Vanilla", "Strawberry", "Pineapple", "Blackforest", "Red Velvet", "New York Cheese", "Choco Lava", "Fruit Cake", "Lemon Coconut", "Mousse", "Blueberry", "Banana", "Caramel" };
        readonly static decimal[] SlicePrices = {2m , 4m , 6m , 8m , 10m };
        readonly static decimal[] CakePrices = {7m , 7.2m , 7.5m , 8.5m , 8m , 11m , 11.5m , 10m , 9.5m , 9m , 12.4m , 10.5m , 12.5m , 12m };
        readonly static decimal[,] CakeSliceCost = 
        {
            {9m , 11m , 13m , 15m , 17m },
            {9.2m, 11.2m , 13.2m , 15.2m , 17.2m },
            {9.5m , 11.5m , 13.5m , 15.5m , 17.5m },
            {10.5m , 12.5m, 14.5m, 16.5m ,18.5m },
            {10m , 12m , 14m , 16m , 18m },
            {13m , 15m , 17m , 19m , 21m },
            {13.5m , 15.5m , 17.5m , 19.5m , 21.5m },
            {12m , 14m , 16m , 18m , 20m },
            {11.5m , 13.5m , 15.5m , 17.5m , 19.5m },
            {11m , 13m , 15m , 17m , 19m },
            {14.4m , 16.4m , 18.4m , 20.4m , 22.4m },
            {12.5m , 14.5m , 16.5m , 18.5m , 20.5m },
            {14.5m , 16.5m , 18.5m , 20.5m , 22.5m },
            {14m , 16m , 18m , 20m , 22m }
        };
        //int[,] stocknumbers = 
        //{
        //    {1 , 2 , 3 , 4 , 5 },
        //    {6, 7 , 8 , 9 , 10 },
        //    {11 , 12 , 13 , 14 , 15 },
        //    {16 , 17, 18, 19 ,20 },
        //    {10 , 12 , 14 , 16 , 18 },
        //    {13 , 15 , 17 , 19 , 21 },
        //    {13 , 15 , 17 , 19 , 21 },
        //    {12 , 14 , 16 , 18 , 20 },
        //    {11 , 13 , 15 , 17 , 19 },
        //    {11 , 13 , 15 , 17 , 19 },
        //    {14 , 16 , 18 , 20 , 22 },
        //    {12 , 14 , 16 , 18 , 20 },
        //    {14 , 16 , 18 , 20 , 22 },
        //    {14 , 16 , 18 , 20 , 22 }
        //};
        List<string> CakeNames1 = new List<string>();
        List<string> CakeSize1 = new List<string>();
        List<decimal> CakePrices1 = new List<decimal>();
        List<int> Numbers = new List<int>();
        List<int> Quantity1 = new List<int>();
        int[,] stocknumbers = new int[14, 5];
        public int Quantity;
        public int GeneratedRandomNumber;
        public int InputNumber;
        public int ReciptID;
        public string SearchID;
        public bool CheckingBoolean = false;
        public string CheckingString;
        public string crack;
        public string JoiningDate;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader InputFile = File.OpenText("stock.txt");
                
                for (int row = 0; row < 14; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        
                        stocknumbers[row,col] = int.Parse(InputFile.ReadLine());
                    }
                }
                InputFile.Close();
            }
            catch (Exception ex)
            {
                //Display an Error Message
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal tat = 0;
            CakeNames1.Add(CakeNames[listBox1.SelectedIndex]);
            CakeSize1.Add(Sizes[listBox2.SelectedIndex]);
            CakePrices1.Add(CakeSliceCost[listBox1.SelectedIndex, listBox2.SelectedIndex]);
            Numbers.Add(listBox1.SelectedIndex);
            Numbers.Add(listBox2.SelectedIndex);
            Quantity = int.Parse(textBox1.Text);
            Quantity1.Add(Quantity);
            for (int index = 0; index < Numbers.Count; index++)
            {
                MessageBox.Show(Numbers[index].ToString());
            }
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            //listView1.SubItems.Add(new ListViewItem(new int[] { Numbers }));
            for (int index = 0; index < CakeNames1.Count; index++)
            {
                
                listBox3.Items.Add(CakeNames1[index]);
                
            }
            for (int index = 0; index < CakeSize1.Count; index++)
            {

                listBox4.Items.Add(CakeSize1[index]);
                
            }
            for (int index = 0; index < CakePrices1.Count; index++)
            {

                listBox5.Items.Add(CakePrices1[index].ToString());
                tat =  tat + (CakePrices1[index]*Quantity1[index]);
                

            }
            for (int index = 0; index < Quantity1.Count; index++)
            {

                listBox6.Items.Add(Quantity1[index].ToString());
                
            }
            label3.Text = tat.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                StreamWriter OutputFile;
                OutputFile = File.CreateText("stock.txt");
                for (int row = 0; row < 14; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        
                        OutputFile.WriteLine(stocknumbers[row, col]);
                    }
                }
                OutputFile.Close();
            }
            catch(Exception ex)
            {
                //Display an Error Message
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear_Function1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> OrderSummary = new List<string>();
            decimal Totalsales = 0;
            DateTime CurrentTime = DateTime.Now;
            JoiningDate = CurrentTime.ToShortDateString();
            try
            {
                //Declaring a streamreader , opening the file and getting a streamreader object
                StreamReader InputFile = File.OpenText("Identity.txt");
                //reading the files content
                while (!InputFile.EndOfStream)
                {
                    //generating a random number
                    Random SomeNumber = new Random();
                    GeneratedRandomNumber = SomeNumber.Next(100000, 999999);
                    //taking input from the current line
                    InputNumber = int.Parse(InputFile.ReadLine());
                    //checking whether the ramdomly generated number is already present in the text file
                    if (GeneratedRandomNumber != InputNumber)
                    {
                        //if the randomly generated number is not present
                        ReciptID = GeneratedRandomNumber;
                        break;
                    }
                }
                //close the file
                InputFile.Close();
                //Declare a streamwriter variable
                StreamWriter OutputFile;
                //getting an object and appending a file
                OutputFile = File.AppendText("Identity.txt");
                OutputFile.WriteLine("");
                OutputFile.WriteLine(ReciptID);
                
                OutputFile.Close();
            }
            catch (Exception ex)
            {
                //Display an Error Message
                MessageBox.Show(ex.Message);
            }

            for (int index = 0; index < CakeNames1.Count; index++)
            {
                OrderSummary.Add(CakeNames1[index]);
                OrderSummary.Add(CakeSize1[index]);
                OrderSummary.Add(CakePrices1[index].ToString());
                OrderSummary.Add(Quantity1[index].ToString());
            }
            for (int index = 0; index < CakePrices1.Count; index++)
            {
                Totalsales = Totalsales + (CakePrices1[index]*Quantity1[index]);
            }
            int index1 = 0;
            for (int index = 0; index < Numbers.Count; index++)
            {
                               
                stocknumbers[Numbers[index],Numbers[index+1]] = stocknumbers[Numbers[index], Numbers[index + 1]] - Quantity1[index1];
                index++;
                index1++;
            }
            try
            {
                //opening a file
                StreamWriter OutputFile;
                OutputFile = File.AppendText("OrderSummary.txt");
                //rewriting the already existing the value in the text file
                OutputFile.WriteLine(ReciptID.ToString());
                OutputFile.WriteLine(JoiningDate);
                for (int index = 0; index < OrderSummary.Count; index++)
                {

                    OutputFile.WriteLine(OrderSummary[index]);

                }
                OutputFile.WriteLine(Totalsales);
                OutputFile.WriteLine("False");
                OutputFile.WriteLine(Environment.NewLine);
                OutputFile.Close();
                //closing the file
            }
            catch (Exception ex)
            {
                //Display an Error Message
                MessageBox.Show(ex.Message);
            }

            Clear_Function1(); 

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
    
        
        }

        private void Clear_Function1()
        {
            CakeNames1.Clear();
            CakePrices1.Clear();
            CakeSize1.Clear();
            Numbers.Clear();
            Quantity1.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            label1.Text = "";
            label3.Text = "0";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label1.Text = stocknumbers[listBox1.SelectedIndex, listBox2.SelectedIndex].ToString();
            }
            catch
            {
                //Display an Error Message
               // MessageBox.Show(ex.Message);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label1.Text = stocknumbers[listBox1.SelectedIndex, listBox2.SelectedIndex].ToString();
            }
            catch 
            {
                //Display an Error Message
                //MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SearchID = textBox2.Text;
            //checking whether the user entered a six digit number or not
            if (int.Parse(SearchID) >= 100000 && int.Parse(SearchID) <= 999999)
            {
                //using a try catch to debug possible errors
                try
                {
                    //opening the file
                    StreamReader InputFile = File.OpenText("OrderSummary.txt");
                    //using a while loop to read all the text in the file
                    while (!InputFile.EndOfStream)
                    {
                        //using a variable to store input from the current line
                        CheckingString = InputFile.ReadLine();
                        //checking whether the inputed id is there in the text file
                        if (SearchID == CheckingString)
                        {
                            //displaying the required stuff
                            textBox3.AppendText(CheckingString);
                            textBox3.AppendText(Environment.NewLine);
                            //using a for loop to read the next six lines in the text file
                            crack = InputFile.ReadLine();
                            
                            while (true)
                            {
                                if (crack != "False")
                                {
                                    textBox3.AppendText(crack);
                                    textBox3.AppendText(Environment.NewLine);
                                }
                                else
                                {
                                    break;
                                }
                                //displaying the required information
                                crack = InputFile.ReadLine();
                                
                            }
                            //setting the boolean value to true
                            CheckingBoolean = true;
                            //breaking the while loo;
                            break;
                        }

                    }
                    InputFile.Close();
                    //closing the file
                    if (CheckingBoolean == false)
                    {
                        //letting the user know that the entered id does not exist
                        MessageBox.Show("The Membership ID does not exist");
                    }

                }
                catch (Exception ex)
                {
                    //Display an Error Message
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SearchID = SearchDateTimePicker.Value.ToShortDateString();
            //checking whether the user entered a six digit number or not
            
                //using a try catch to debug possible errors
                try
                {
                    //opening the file
                    StreamReader InputFile = File.OpenText("OrderSummary.txt");
                    //using a while loop to read all the text in the file
                    while (!InputFile.EndOfStream)
                    {
                        //using a variable to store input from the current line
                        CheckingString = InputFile.ReadLine();
                        //checking whether the inputed id is there in the text file
                        if (SearchID == CheckingString)
                        {
                            //displaying the required stuff
                            textBox3.AppendText(CheckingString);
                            textBox3.AppendText(Environment.NewLine);
                            //using a for loop to read the next six lines in the text file
                            crack = InputFile.ReadLine();

                            while (true)
                            {
                                if (crack != "False")
                                {
                                    textBox3.AppendText(crack);
                                    textBox3.AppendText(Environment.NewLine);
                                }
                                else
                                {
                                    break;
                                }
                                //displaying the required information
                                crack = InputFile.ReadLine();

                            }
                            //setting the boolean value to true
                            CheckingBoolean = true;
                            //breaking the while loo;
                            
                        }

                    }
                    InputFile.Close();
                    //closing the file
                    if (CheckingBoolean == false)
                    {
                        //letting the user know that the entered id does not exist
                        MessageBox.Show("The Membership ID does not exist");
                    }

                }
                catch (Exception ex)
                {
                    //Display an Error Message
                    MessageBox.Show(ex.Message);

                }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 MyForm2 = new Form2();
            MyForm2.ShowDialog();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }
    }
}
