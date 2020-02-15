using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSONizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Record Serializer";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open file dialog for selection of csv file
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string readFile = File.ReadAllText(filename);
            // display full filename in textbox
            filenameTB.Text = filename;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            RecordSerializer cnvrt = new RecordSerializer();
            // get full path of csv file without file extension
            string filePath = Path.Combine(Path.GetDirectoryName(filenameTB.Text), Path.GetFileNameWithoutExtension(filenameTB.Text));
            string jsonresult = cnvrt.Converter(filenameTB.Text);
            // write JSON string to new file in same directory of csv file
            System.IO.File.WriteAllText(filePath + "_JSON.txt", jsonresult);
            jsonTB.Text = jsonresult;
        }
    }
}
