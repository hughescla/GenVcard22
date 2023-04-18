using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenVcard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> names = System.IO.File.ReadAllLines("names.txt").ToList();
            List<string> surNames = System.IO.File.ReadAllLines("surnames.txt").ToList();
            string kodstarni = textBox2.Text;
            string kodoperatora = textBox3.Text;
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            for (int i = 0; i < int.Parse(textBox1.Text); i++)
            {
                string nf = myTI.ToTitleCase(names[rnd.Next(names.Count)].ToLower()) + " " +  myTI.ToTitleCase(surNames[rnd.Next(surNames.Count)].ToLower());
                string randon6Number = rnd.Next(100, 999).ToString()+" "+ rnd.Next(100, 999).ToString();
                richTextBox1.AppendText("BEGIN:VCARD"+Environment.NewLine);
                richTextBox1.AppendText("VERSION:3.0" + Environment.NewLine);
                richTextBox1.AppendText("FN:"+nf + Environment.NewLine);
                richTextBox1.AppendText("N:;"+nf+";;;" + Environment.NewLine);
                richTextBox1.AppendText("item1.TEL:+"+kodstarni+" "+kodoperatora+" "+randon6Number + Environment.NewLine);
                richTextBox1.AppendText("item1.X-ABLabel:" + Environment.NewLine);
                richTextBox1.AppendText("CATEGORIES:myContacts" + Environment.NewLine);
                richTextBox1.AppendText("END:VCARD" + Environment.NewLine);
                /*
                 BEGIN:VCARD
VERSION:3.0
FN:Yura Poland
N:;Yura Poland;;;
item1.TEL:+48 513 524 693
item1.X-ABLabel:
CATEGORIES:myContacts
END:VCARD

                 
                 */
            }
            System.IO.File.WriteAllLines("contacts.vcf",richTextBox1.Lines);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           richTextBox1.AppendText( Guid.NewGuid().ToString().ToLower());
        }
    }
}
