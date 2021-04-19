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
using System;
using System.IO;


namespace uiTestingCsharp
{
    public partial class Form1 : Form
    {

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
                Console.WriteLine(q6Answer.Text);
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
                    string line = q1Answer.Text + "ʦ" + q2Answer.Text + "ʦ" + q3Answer.Text + "ʦ" + q4Answer.Text + "ʦ" + q5Answer.Text + "ʦ" + q6Answer.Text;

                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    string docName = q1Answer.Text + ".txt";

                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, docName)))
                    {
                        outputFile.WriteLine(line);
                        Console.WriteLine("Written!");
                        info.Text = "Saved Successfully";
                    }
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
                        q6Answer.Text = words[5];
                    }
                }
            }
        }

        private void q3Answer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
