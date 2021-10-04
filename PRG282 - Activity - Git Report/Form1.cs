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
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = Path.GetDirectoryName(strExeFilePath);
           string userDataFile = Path.Combine(strWorkPath, "..\\UserData.txt");
            try
            {
                List<string> users = ReadFile(userDataFile);
                listBox1.DataSource=users;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         public List<string> ReadFile(string filepath)
        {
            if (Directory.Exists(filepath))
                throw new Exception("File \"" + filepath + "\" does not Exist");

            FileStream file = new FileStream(filepath, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            List<string> users = new List<string>();
            
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    users.Add(line);
                }

          
            reader.Close();
            file.Close();
            return users;

        }
    }
}
