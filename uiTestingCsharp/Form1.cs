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

        private void label1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");   
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (q1Answer.Text == "" || q2Answer.Text == "" || q3Answer.Text == "")
            {
                info.Text = "Missing Required Information!";
            }
            else
            {
                string line = q1Answer.Text + " " + q2Answer.Text + " " + q3Answer.Text;

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

        private void label1_Click_1(object sender, EventArgs e)
        {

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
                        string[] words = fileContent.Split(' ');
                        q1Answer.Text = words[0];
                        q2Answer.Text = words[1];
                        q3Answer.Text = words[2];
                    }
                }
            }
        }
    }
}
