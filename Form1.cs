using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private HashSet<string> allLinesText; 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.InitialDirectory = "C:\\Users\\Alex4\\RiderProj\\Lab4\\bin\\Debug\\TXT_Files\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //txbx_AudioName.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName); //без расширения файла
                textBox1.Text = Path.GetFileName(openFileDialog1.FileName);  //с расширением
            }
            var stopWatch = Stopwatch.StartNew();
            allLinesText = File.ReadAllText(openFileDialog1.InitialDirectory + textBox1.Text).Split(' ', '\n', '\r', ',', ';', ':', '.', '!', '?', '-').ToHashSet();
            stopWatch.Stop();
            label1.Text = "Время исполнения: " + stopWatch.ElapsedMilliseconds.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var stopWatch = Stopwatch.StartNew();
            string resultWord = null;
            string searchWord = textBox2.Text;
            if (allLinesText.Contains(searchWord))
            {
                resultWord = searchWord;
                listBox1.Items.Add(resultWord);
            }
            stopWatch.Stop();

            label2.Text = "Время поиска: " + stopWatch.ElapsedMilliseconds.ToString();
        }
    }
}
    
