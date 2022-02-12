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

namespace Laba1
{
    public partial class JudgeForm : Form
    {
        private MainMenu _mainMenu;
        public JudgeForm(MainMenu menu)
        {
            _mainMenu = menu;
            InitializeComponent();
        }

        private void JudgeForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader file = new StreamReader(Member.PathForMembers))
                {
                    while (!file.EndOfStream)
                        this.comboBox1.Items.Add(file.ReadLine());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.FormClosing += JudgeForm_FromClosing;
        }
        private void JudgeForm_FromClosing(object sender, FormClosingEventArgs e)
        {
            _mainMenu.Visible = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString().Split(' ')[0];
            textBox2.Text = comboBox1.SelectedItem.ToString().Split(' ')[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Заповніть всі поля!");
            }
            else
            {
                Member newMember = new Member(textBox1.Text, textBox2.Text, new TimeSpan(int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text)),
                   new TimeSpan(int.Parse(textBox8.Text), int.Parse(textBox7.Text), int.Parse(textBox6.Text)));
                try
                {
                    using (StreamWriter sw = new StreamWriter(Member.PathForResults, true))
                    {
                        sw.WriteLine(textBox1.Text + " " + textBox2.Text);
                        sw.WriteLine(newMember.TimeStart.Hours + " " + newMember.TimeStart.Minutes + " " + newMember.TimeStart.Seconds);
                        sw.WriteLine(newMember.TimeFinish.Hours + " " + newMember.TimeFinish.Minutes + " " + newMember.TimeFinish.Seconds);
                        MessageBox.Show("Результати учасника додані до файлу!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                if (comboBox1.Items.Count == 0)
                {
                    comboBox1.SelectedIndex = -1;
                    comboBox1.Text = "";
                    comboBox1.Enabled = false;
                    textBox1.Clear();textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear();
                    textBox1.Enabled = false; textBox2.Enabled = false;
                }
                else
                {
                    comboBox1.SelectedIndex += 1;
                }
            }

        }

        private void JudgeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboBox1.Items.Count == 0)
            {
                _mainMenu.button3.Visible = true;
            }
            else
            {
                MessageBox.Show("Ви не добавили всіх учасників до списку, результат виведений не буде!");
            }
        }
    }
}
