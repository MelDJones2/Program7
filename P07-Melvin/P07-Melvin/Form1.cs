using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace P07_Melvin
{
    public partial class Form1 : Form
    {
        //Structure for TestScores info
        struct TestScores
        {
            public string Name;
            public int Earned_1;
            public int Earned_2;
            public int Earned_3;
            public int Possible_1;
            public int Possible_2;
            public int Possible_3;
        }

        //Dictionary for TestScores info
        Dictionary<string, TestScores> studentDictionary = new Dictionary<string, TestScores>();

        public Form1()
        {
            InitializeComponent();
        }
        private void ClearTextBoxes()
        {
            txt_Name.Text = "";
            txt_Earned1.Text = "";
            txt_Possible1.Text = "";
            txt_Earned2.Text = "";
            txt_Possible2.Text = "";
            txt_Earned3.Text = "";
            txt_Possible3.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Taking in Add Values ToInt32 to get Intergers from characters
                string name = txt_Name.Text;
                int test1Earned = int.Parse(txt_Earned1.Text);
                int test2Earned = int.Parse(txt_Earned2.Text);
                int test3Earned = int.Parse(txt_Earned3.Text);
                int test1Possible = int.Parse(txt_Possible1.Text);
                int test2Possible = int.Parse(txt_Possible2.Text);
                int test3Possible = int.Parse(txt_Possible3.Text);
                
                TestScores studentData = new TestScores();
                studentData.Name = txt_Name.Text;

                if (test1Earned <= 0 || test1Earned > 100 ||
                    test2Earned <= 0 || test2Earned > 100 ||
                    test3Earned <= 0 || test3Earned > 100 ||
                    test1Possible <= 0 || test1Possible > 100 ||
                    test2Possible <= 0 || test2Possible > 100 ||
                    test3Possible <= 0 || test3Possible > 100)
                {
                    MessageBox.Show("Invalid input for earned scores! Please enter valid integer values between 0 and 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!studentDictionary.ContainsKey(name))
                {
                    //Adding Info
                    TestScores newTestScores;
                    newTestScores.Name = name;
                    newTestScores.Earned_1 = test1Earned;
                    newTestScores.Earned_2 = test2Earned;
                    newTestScores.Earned_3 = test3Earned;
                    newTestScores.Possible_1 = test1Possible;
                    newTestScores.Possible_2 = test2Possible;
                    newTestScores.Possible_3 = test3Possible;

                    studentDictionary.Add(name, newTestScores);

                    ClearTextBoxes();
                }
                else
                {
                    //Error
                    MessageBox.Show("Error: TestScores Already Exists!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txt_Name.Text;

                if (studentDictionary.ContainsKey(name))
                {
                    //Show info
                    TestScores student = studentDictionary[name];
                    txt_Earned1.Text = student.Earned_1.ToString();
                    txt_Possible1.Text = student.Possible_1.ToString();
                    txt_Earned2.Text = student.Earned_2.ToString();
                    txt_Possible2.Text = student.Possible_2.ToString();
                    txt_Earned3.Text = student.Earned_3.ToString();
                    txt_Possible3.Text = student.Possible_3.ToString();
                }
                else
                {
                    //error
                    MessageBox.Show("Error: TestScores Not Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txt_Name.Text;

                if (studentDictionary.ContainsKey(name))
                {
                    //Change Info for Name
                    TestScores updatedTestScores = studentDictionary[name];
                    updatedTestScores.Earned_1 = int.Parse(txt_Earned1.Text);
                    updatedTestScores.Possible_1 = int.Parse(txt_Possible1.Text);
                    updatedTestScores.Earned_2 = int.Parse(txt_Earned2.Text);
                    updatedTestScores.Possible_2 = int.Parse(txt_Possible2.Text);
                    updatedTestScores.Earned_3 = int.Parse(txt_Earned3.Text);
                    updatedTestScores.Possible_3 = int.Parse(txt_Possible3.Text);

                    studentDictionary[name] = updatedTestScores;
                }
                else
                {
                    //Error
                    MessageBox.Show("Error: TestScores Not Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txt_Name.Text;

                //Removing name
                if (studentDictionary.ContainsKey(name))
                {
                    studentDictionary.Remove(name);
                }
                else
                {
                    //Error
                    MessageBox.Show("Error: TestScores Not Found!");
                }

                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
    }
}