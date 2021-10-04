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

namespace PRG282___Activity___Git_Report
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         try
            {
                List<string> users = ReadFile("UserData.txt");
                listBox1.Items.Add(users);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         public List<string> ReadFile(string filepath)
        {
            FileStream file = new FileStream(filepath, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            List<string> users = new List<string>();
            if (Directory.Exists(filepath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    users.Add(line);
                }
                reader.Close();
                file.Close();
                return users;
            }
            else
                throw new Exception("File \"" + filepath + "\" does not Exist");

        }
    }
}
