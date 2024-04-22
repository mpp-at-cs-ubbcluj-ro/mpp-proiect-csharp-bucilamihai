using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Client.controller;

namespace Client.views
{
    public partial class OfficeView : Form
    {
        private OfficeController officeController;

        private DataTable challengesTable;
        private DataTable childrenTable;

        public OfficeView(OfficeController officeController)
        {
            this.officeController = officeController;
            challengesTable = new DataTable();
            childrenTable = new DataTable();
            InitializeComponent();
            Initialize();
            LoadData();
        }

        private void Initialize()
        {
            chooseChallenge_comboBox.Items.Add("drawing");
            chooseChallenge_comboBox.Items.Add("treasure hunt");
            chooseChallenge_comboBox.Items.Add("poetry");

            groupAge_comboBox.Items.Add("6-8");
            groupAge_comboBox.Items.Add("9-11");
            groupAge_comboBox.Items.Add("12-15");

            challengesTable.Columns.Add("Name");
            challengesTable.Columns.Add("Group Age");
            challengesTable.Columns.Add("Number of Participants");

            childrenTable.Columns.Add("Name");
            childrenTable.Columns.Add("Age");
        }
        private void LoadData()
        {
            challengesTable.Clear();
            foreach (var challenge in officeController.GetAllChallenges())
                challengesTable.Rows.Add(challenge.name, challenge.groupAge, challenge.numberOfParticipants);
            challenges_dataGridView.DataSource = challengesTable;
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string challengeName = challengeName_textBox.Text;
            string groupAge = groupAge_comboBox.SelectedItem.ToString(); 
            foreach (var child in officeController.GetEnrolledChildren(challengeName, groupAge))
                childrenTable.Rows.Add(child.name, child.age);
            children_dataGridView.DataSource = childrenTable;
        }

        private void enrollChild_button_Click(object sender, EventArgs e)
        {
            long cnp = long.Parse(childCNP_textBox.Text);
            string name = childName_textBox.Text;
            int age = (int)childAge_numericUpDown.Value;
            string challengeName = chooseChallenge_comboBox.SelectedItem.ToString();
            officeController.EnrollChild(cnp, name, age, challengeName);
            LoadData();
        }

        public void userUpdate(object sender, UserEventArgs e)
        {
            if(e.UserEventType == UserEvent.UPDATE_CHALLENGES)
            {
                BeginInvoke(LoadData);
            }
        }
    }
}
