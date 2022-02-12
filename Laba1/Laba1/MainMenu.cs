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
    public partial class MainMenu : Form
    {
        private UserForm _userForm;
        private JudgeForm _judgeForm;

        public MainMenu()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _userForm = new UserForm(this);
            this.Hide();
            _userForm.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _judgeForm = new JudgeForm(this);
            this.Hide();
            _judgeForm.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] temp;
            List<Member> listOfMembers = new List<Member>();
            
            Member myMember = new Member();
            try
            {
                using (StreamReader file = new StreamReader(Member.PathForResults))
                {
                    while (!file.EndOfStream)
                    {
                        temp = file.ReadLine().Split(' ');
                        myMember.Name = temp[0];
                        myMember.Surname = temp[1];
                        temp = file.ReadLine().Split(' ');
                        myMember.TimeStart = new TimeSpan(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[2]));
                        temp = file.ReadLine().Split(' ');
                        myMember.TimeFinish = new TimeSpan(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[2]));
                        listOfMembers.Add((Member)myMember.Clone());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            listOfMembers.Sort();
            MessageBox.Show("Бронзу отримав: "+listOfMembers[2].Surname+" "+ listOfMembers[2].Name);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            button3.Hide();
        }
    }
}
