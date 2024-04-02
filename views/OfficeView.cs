using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChildrenContest
{
    internal partial class OfficeView : Form
    {
        private OfficeController officeController;

        public OfficeView(OfficeController officeController)
        {
            this.officeController = officeController;
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
        }
        private void LoadData()
        {
            DataTable challengesTable = new DataTable();
            challengesTable.Columns.Add("Name");
            challengesTable.Columns.Add("Group Age");
            challengesTable.Columns.Add("Number of Participants");
            foreach (var challenge in officeController.GetAllChallenges())
                challengesTable.Rows.Add(challenge.Name, challenge.GroupAge, challenge.NumberOfParticipants);
            challenges_dataGridView.DataSource = challengesTable;
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            String challengeName = challengeName_textBox.Text;
            String groupAge = groupAge_comboBox.SelectedItem.ToString();

            DataTable childrenTable = new DataTable();
            childrenTable.Columns.Add("Name");
            childrenTable.Columns.Add("Age");
            foreach (var child in officeController.GetEnrolledChildren(challengeName, groupAge))
                childrenTable.Rows.Add(child.Name, child.Age);
            children_dataGridView.DataSource = childrenTable;
        }

        private void enrollChild_button_Click(object sender, EventArgs e)
        {
            long cnp = long.Parse(childCNP_textBox.Text);
            String name = childName_textBox.Text;
            int age = (int)childAge_numericUpDown.Value;
            String challengeName = chooseChallenge_comboBox.SelectedItem.ToString();
            officeController.EnrollChild(cnp, name, age, challengeName);
            LoadData();
        }
    }
}
