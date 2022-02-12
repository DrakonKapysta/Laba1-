using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{
    public partial class UserForm : Form
    {
        private MainMenu _mainMenu;
        public UserForm(MainMenu main)
        {
            _mainMenu = main;
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            this.FormClosing += UserForm_FormClosing;
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainMenu.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FirstnameAndSurname = textBox1.Text + " " + textBox2.Text;
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Member.PathForMembers, true))
                {
                    sw.WriteLine(FirstnameAndSurname);
                    MessageBox.Show("Ваша за'явка прийнята");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}

