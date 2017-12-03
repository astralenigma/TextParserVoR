using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileParserForm
{
    public partial class Form1 : Form
    {
        private string location;
        private SearchInterest interest;
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            int size = -1;
            if(fileDialog.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = fileDialog.SafeFileName;
                location =fileDialog.FileName;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (location==null)
            {
                MessageBox.Show("Insert a file!", "No file found!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            button3.Enabled = false;
            interest = SearchParser.startSearch(location, textBox2.Text);
            results.DataSource = new List<string>();
            if (interest==null)
            {
                MessageBox.Show("We couldn't find what you were looking for.","No results found!",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            else
            {
                results.DataSource = interest.getAlias();
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchParser.printResults(interest);
            MessageBox.Show("File: "+interest.getName()+"_Alias has been printed.");
        }
    }
}
