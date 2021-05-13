using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;


namespace uiTestingCsharp
{
    public partial class Form1 : Form
    {
        private void submitInfo(string ans1, string ans2, string ans3, string ans4, string ans5, string ans6)
        {
            string line = ans1 + "ʦ" + ans2 + "ʦ" + ans3 + "ʦ" + ans4 + "ʦ" + ans5 + "ʦ" + ans6;

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string docName = ans1 + ".txt";

            if (numOfPanelsOpen >= 1)
            {
                line = line + "ʦPAN1ʦ¶(" + productAnswer1.Text + "§" + partAnswer1.Text + "§" + quantityAnswer1.Value + "§" + priceAnswer1.Text + ")";
            }
            if (numOfPanelsOpen >= 2)
            {
                line = line + "ʦPAN2ʦ¶(" + productAnswer2.Text + "§" + partAnswer2.Text + "§" + quantityAnswer2.Value + "§" + priceAnswer2.Text + ")";
            }
            if (numOfPanelsOpen >= 3)
            {
                line = line + "ʦPAN3ʦ¶(" + productAnswer3.Text + "§" + partAnswer3.Text + "§" + quantityAnswer3.Value + "§" + priceAnswer3.Text + ")";
            }
            if (numOfPanelsOpen >= 4)
            {
                line = line + "ʦPAN4ʦ¶(" + productAnswer4.Text + "§" + partAnswer4.Text + "§" + quantityAnswer4.Value + "§" + priceAnswer4.Text + ")";
            }
            if (numOfPanelsOpen >= 5)
            {
                line = line + "ʦPAN5ʦ¶(" + productAnswer5.Text + "§" + partAnswer5.Text + "§" + quantityAnswer5.Value + "§" + priceAnswer5.Text + ")";
            }
            if (numOfPanelsOpen >= 6)
            {
                line = line + "ʦPAN6ʦ¶(" + productAnswer6.Text + "§" + partAnswer6.Text + "§" + quantityAnswer6.Value + "§" + priceAnswer6.Text + ")";
            }
            if (laborAnswer.Text != String.Empty)
            {
                line = line + "¤" + laborAnswer.Text;
                if (laborCostAnswer.Text != String.Empty)
                {
                    line = line + "¤" + laborCostAnswer.Text;
                }
            }

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, docName)))
            {
                outputFile.WriteLine(line);
                Console.WriteLine("Written!");
                info.Text = "Successfully written!";
            }
        }
        
        public Form1()
        {
            InitializeComponent();
        }


        private void submit_Click(object sender, EventArgs e)
        {
            q3Answer.Text = q3Answer.Text.Replace(" ", String.Empty);
            q4Answer.Text = q4Answer.Text.Replace(" ", String.Empty);
            q6Answer.Text = q6Answer.Text.Replace(" ", String.Empty);
            if (q1Answer.Text == "" || q2Answer.Text == "" || q3Answer.Text == "" || q4Answer.Text == "" || q5Answer.Text == "" || q6Answer.Text == "")
            {
                info.Text = "Missing Required Information!";
            }
            else if (q3Answer.Text.Length != 10)
            {
                info.Text = "This phone number is incorrect";
            }
            else if (q4Answer.Text.Length != 16)
            {
                info.Text = "This credit card information is incorrect";
            }
            else if (q6Answer.Text.Length != 6)
            {
                info.Text = "This postal code information is incorrect";
            }

            else
            {
                q6Answer.Text.ToUpper();
                q6Answer.Text = q6Answer.Text.Replace(" ", String.Empty);
                char[] az = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
                char[] numberList = "1234567890".ToCharArray();
                if (!az.Contains(q6Answer.Text[0]))
                {
                    Console.WriteLine("1");
                    info.Text = "This postal code information is incorrect";
                }
                else if (!numberList.Contains(q6Answer.Text[1]))
                {
                    Console.WriteLine("2");
                    info.Text = "This postal code information is incorrect";
                }
                else if (!az.Contains(q6Answer.Text[2]))
                {
                    Console.WriteLine("3");
                    info.Text = "This postal code information is incorrect";
                }
                else if (!numberList.Contains(q6Answer.Text[3]))
                {
                    Console.WriteLine("4");
                    info.Text = "This postal code information is incorrect";
                }
                else if (!az.Contains(q6Answer.Text[4]))
                {
                    Console.WriteLine("5");
                    info.Text = "This postal code information is incorrect";
                }
                else if (!numberList.Contains(q6Answer.Text[5]))
                {
                    Console.WriteLine("6");
                    info.Text = "This postal code information is incorrect";
                }
                else
                {
                    submitInfo(q1Answer.Text, q2Answer.Text, q3Answer.Text, q4Answer.Text, q5Answer.Text, q6Answer.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        string[] words = fileContent.Split('ʦ');
                        q1Answer.Text = words[0];
                        q2Answer.Text = words[1];
                        q3Answer.Text = words[2];
                        q4Answer.Text = words[3];
                        q5Answer.Text = words[4];
                        string postalFixed = words[5].Substring(0, 6);
                        q6Answer.Text = postalFixed;
                        string[] fileSplit = fileContent.Split('¶') ;
                        int elementAmount = fileSplit.Count();
                        float totalCost = 0;
                        {
                            if (elementAmount >= 2) // 1
                            {
                                panel1.Visible = true;
                                string newInfo = fileSplit[1];
                                newInfo = newInfo.Replace("(", string.Empty);
                                newInfo = newInfo.Replace(")", string.Empty);
                                string[] infoSplit = newInfo.Split('§');
                                productAnswer1.Text = infoSplit[0];
                                partAnswer1.Text = infoSplit[1];
                                int quantity = Int32.Parse(infoSplit[2]);
                                quantityAnswer1.Value = quantity;
                                string output = Regex.Replace(infoSplit[3], "[^/./,0-9]", "");
                                priceAnswer1.Text = output;
                                numOfPanelsOpen = 1;
                                float priceCost = float.Parse(priceAnswer1.Text);
                                priceCost = (float)Math.Round(priceCost, 2);
                                totalCost += priceCost;
                                priceAnswer1.Text = priceCost.ToString();
                            }
                            if (elementAmount >= 3) // 2    
                            {
                                panel2.Visible = true;
                                string newInfo = fileSplit[2];
                                newInfo = newInfo.Replace("(", string.Empty);
                                newInfo = newInfo.Replace(")", string.Empty);
                                string[] infoSplit = newInfo.Split('§');
                                productAnswer2.Text = infoSplit[0];
                                partAnswer2.Text = infoSplit[1];
                                int quantity = Int32.Parse(infoSplit[2]);
                                quantityAnswer2.Value = quantity;
                                string output = Regex.Replace(infoSplit[3], "[^/./,0-9]", "");
                                priceAnswer2.Text = output;
                                numOfPanelsOpen = 2;
                                float priceCost = float.Parse(priceAnswer2.Text);
                                priceCost = (float)Math.Round(priceCost, 2);
                                totalCost += priceCost;
                                priceAnswer2.Text = priceCost.ToString();
                            }
                            if (elementAmount >= 4) // 3
                            {
                                panel3.Visible = true;
                                string newInfo = fileSplit[3];
                                newInfo = newInfo.Replace("(", string.Empty);
                                newInfo = newInfo.Replace(")", string.Empty);
                                string[] infoSplit = newInfo.Split('§');
                                productAnswer3.Text = infoSplit[0];
                                partAnswer3.Text = infoSplit[1];
                                int quantity = Int32.Parse(infoSplit[2]);
                                quantityAnswer3.Value = quantity;
                                string output = Regex.Replace(infoSplit[3], "[^/./,0-9]", "");
                                priceAnswer3.Text = output;
                                numOfPanelsOpen = 3;
                                float priceCost = float.Parse(priceAnswer3.Text);
                                priceCost = (float)Math.Round(priceCost, 2);
                                totalCost += priceCost;
                                priceAnswer3.Text = priceCost.ToString();
                            }
                            if (elementAmount >= 5) // 4
                            {
                                panel4.Visible = true;
                                string newInfo = fileSplit[4];
                                newInfo = newInfo.Replace("(", string.Empty);
                                newInfo = newInfo.Replace(")", string.Empty);
                                string[] infoSplit = newInfo.Split('§');
                                productAnswer4.Text = infoSplit[0];
                                partAnswer4.Text = infoSplit[1];
                                int quantity = Int32.Parse(infoSplit[2]);
                                quantityAnswer4.Value = quantity;
                                string output = Regex.Replace(infoSplit[3], "[^/./,0-9]", "");
                                numOfPanelsOpen = 4;
                                float priceCost = float.Parse(priceAnswer4.Text);
                                priceCost = (float)Math.Round(priceCost, 2);
                                totalCost += priceCost;
                                priceAnswer4.Text = priceCost.ToString();
                            }
                            if (elementAmount >= 6) // 5
                            {
                                panel5.Visible = true;
                                string newInfo = fileSplit[5];
                                newInfo = newInfo.Replace("(", string.Empty);
                                newInfo = newInfo.Replace(")", string.Empty);
                                string[] infoSplit = newInfo.Split('§');
                                productAnswer5.Text = infoSplit[0];
                                partAnswer5.Text = infoSplit[1];
                                int quantity = Int32.Parse(infoSplit[2]);
                                quantityAnswer5.Value = quantity;
                                string output = Regex.Replace(infoSplit[3], "[^/./,0-9]", "");
                                numOfPanelsOpen = 5;
                                float priceCost = float.Parse(priceAnswer5.Text);
                                priceCost = (float)Math.Round(priceCost, 2);
                                totalCost += priceCost;
                                priceAnswer5.Text = priceCost.ToString();
                            }
                            if (elementAmount >= 7) // 6
                            {
                                panel6.Visible = true;
                                string newInfo = fileSplit[6];
                                newInfo = newInfo.Replace("(", string.Empty);
                                newInfo = newInfo.Replace(")", string.Empty);
                                string[] infoSplit = newInfo.Split('§');
                                productAnswer6.Text = infoSplit[0];
                                partAnswer6.Text = infoSplit[1];
                                int quantity = Int32.Parse(infoSplit[2]);
                                quantityAnswer6.Value = quantity;
                                string output = Regex.Replace(infoSplit[3], "[^/./,0-9]", "");
                                numOfPanelsOpen = 6;
                                float priceCost = float.Parse(priceAnswer6.Text);
                                priceCost = (float)Math.Round(priceCost, 2);
                                totalCost += priceCost;
                                priceAnswer6.Text = priceCost.ToString();
                            }
                            totalLabel.Text = "Total: " + totalCost;
                            string[] laborInfoSplit = fileContent.Split('¤');
                            int laborInfoCount = laborInfoSplit.Count();
                            Console.WriteLine(laborInfoCount);
                            if (laborInfoCount >= 1)
                            {
                                laborAnswer.Text = laborInfoSplit[1];
                            }
                            if (laborInfoCount >= 2) 
                            {
                                laborCostAnswer.Text = laborInfoSplit[2];
                            }

                        }
                    }
                }
            }
        }
        int numOfPanelsOpen = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (numOfPanelsOpen == -1)
            {
                numOfPanelsOpen = 0;
            }
            if (numOfPanelsOpen == 6)
            {
            }
            if (numOfPanelsOpen != 6)
            {
                if (numOfPanelsOpen == 0)
                {
                    panel1.Visible = true;
                }
                if (numOfPanelsOpen == 1)
                {
                    panel2.Visible = true;
                }
                if (numOfPanelsOpen == 2)
                {
                    panel3.Visible = true;
                }
                if (numOfPanelsOpen == 3)
                {
                    panel4.Visible = true;
                }
                if (numOfPanelsOpen == 4)
                {
                    panel5.Visible = true;
                }
                if (numOfPanelsOpen == 5)
                {
                    panel6.Visible = true;
                }
                numOfPanelsOpen = numOfPanelsOpen + 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (numOfPanelsOpen == -1)
            {
            }
            if (numOfPanelsOpen != -1)
            {
                numOfPanelsOpen = numOfPanelsOpen - 1;
                if (numOfPanelsOpen == 0)
                {
                    panel1.Visible = false;
                }
                if (numOfPanelsOpen == 1)
                {
                    panel2.Visible = false;
                }
                if (numOfPanelsOpen == 2)
                {
                    panel3.Visible = false;
                }
                if (numOfPanelsOpen == 3)
                {
                    panel4.Visible = false;
                }
                if (numOfPanelsOpen == 4)
                {
                    panel5.Visible = false;
                }
                if (numOfPanelsOpen == 5)
                {
                    panel6.Visible = false;
                }
            }
        }
    }
}
