namespace ChildrenContest
{
    partial class OfficeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.challenges_dataGridView = new System.Windows.Forms.DataGridView();
            this.operations_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.challengeName_textBox = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.groupAge_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.childCNP_textBox = new System.Windows.Forms.TextBox();
            this.childAge_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.chooseChallenge_comboBox = new System.Windows.Forms.ComboBox();
            this.enrollChild_button = new System.Windows.Forms.Button();
            this.childName_textBox = new System.Windows.Forms.TextBox();
            this.children_dataGridView = new System.Windows.Forms.DataGridView();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.challenges_dataGridView)).BeginInit();
            this.operations_flowLayoutPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.childAge_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.children_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.challenges_dataGridView);
            this.mainPanel.Controls.Add(this.operations_flowLayoutPanel);
            this.mainPanel.Controls.Add(this.children_dataGridView);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(1278, 565);
            this.mainPanel.TabIndex = 0;
            // 
            // challenges_dataGridView
            // 
            this.challenges_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.challenges_dataGridView.Location = new System.Drawing.Point(23, 23);
            this.challenges_dataGridView.Name = "challenges_dataGridView";
            this.challenges_dataGridView.RowHeadersWidth = 51;
            this.challenges_dataGridView.RowTemplate.Height = 24;
            this.challenges_dataGridView.Size = new System.Drawing.Size(445, 514);
            this.challenges_dataGridView.TabIndex = 0;
            // 
            // operations_flowLayoutPanel
            // 
            this.operations_flowLayoutPanel.Controls.Add(this.groupBox1);
            this.operations_flowLayoutPanel.Controls.Add(this.groupBox2);
            this.operations_flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.operations_flowLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operations_flowLayoutPanel.Location = new System.Drawing.Point(474, 23);
            this.operations_flowLayoutPanel.Name = "operations_flowLayoutPanel";
            this.operations_flowLayoutPanel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.operations_flowLayoutPanel.Size = new System.Drawing.Size(407, 454);
            this.operations_flowLayoutPanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.challengeName_textBox);
            this.groupBox1.Controls.Add(this.search_button);
            this.groupBox1.Controls.Add(this.groupAge_comboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 153);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Group age";
            // 
            // challengeName_textBox
            // 
            this.challengeName_textBox.Location = new System.Drawing.Point(138, 11);
            this.challengeName_textBox.Name = "challengeName_textBox";
            this.challengeName_textBox.Size = new System.Drawing.Size(144, 24);
            this.challengeName_textBox.TabIndex = 0;
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(138, 102);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(144, 45);
            this.search_button.TabIndex = 2;
            this.search_button.Text = "Search enrolled children";
            this.search_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // groupAge_comboBox
            // 
            this.groupAge_comboBox.FormattingEnabled = true;
            this.groupAge_comboBox.Location = new System.Drawing.Point(138, 44);
            this.groupAge_comboBox.Name = "groupAge_comboBox";
            this.groupAge_comboBox.Size = new System.Drawing.Size(144, 26);
            this.groupAge_comboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Challenge name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.childCNP_textBox);
            this.groupBox2.Controls.Add(this.childAge_numericUpDown);
            this.groupBox2.Controls.Add(this.chooseChallenge_comboBox);
            this.groupBox2.Controls.Add(this.enrollChild_button);
            this.groupBox2.Controls.Add(this.childName_textBox);
            this.groupBox2.Location = new System.Drawing.Point(23, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 223);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Challenge name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Age";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Child CNP";
            // 
            // childCNP_textBox
            // 
            this.childCNP_textBox.Location = new System.Drawing.Point(138, 15);
            this.childCNP_textBox.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.childCNP_textBox.Name = "childCNP_textBox";
            this.childCNP_textBox.Size = new System.Drawing.Size(144, 24);
            this.childCNP_textBox.TabIndex = 3;
            // 
            // childAge_numericUpDown
            // 
            this.childAge_numericUpDown.Location = new System.Drawing.Point(138, 75);
            this.childAge_numericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.childAge_numericUpDown.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.childAge_numericUpDown.Name = "childAge_numericUpDown";
            this.childAge_numericUpDown.Size = new System.Drawing.Size(144, 24);
            this.childAge_numericUpDown.TabIndex = 5;
            this.childAge_numericUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // chooseChallenge_comboBox
            // 
            this.chooseChallenge_comboBox.FormattingEnabled = true;
            this.chooseChallenge_comboBox.Location = new System.Drawing.Point(138, 105);
            this.chooseChallenge_comboBox.Name = "chooseChallenge_comboBox";
            this.chooseChallenge_comboBox.Size = new System.Drawing.Size(145, 26);
            this.chooseChallenge_comboBox.TabIndex = 6;
            // 
            // enrollChild_button
            // 
            this.enrollChild_button.Location = new System.Drawing.Point(138, 169);
            this.enrollChild_button.Name = "enrollChild_button";
            this.enrollChild_button.Size = new System.Drawing.Size(145, 23);
            this.enrollChild_button.TabIndex = 7;
            this.enrollChild_button.Text = "Enroll child";
            this.enrollChild_button.UseVisualStyleBackColor = true;
            this.enrollChild_button.Click += new System.EventHandler(this.enrollChild_button_Click);
            // 
            // childName_textBox
            // 
            this.childName_textBox.Location = new System.Drawing.Point(138, 45);
            this.childName_textBox.Name = "childName_textBox";
            this.childName_textBox.Size = new System.Drawing.Size(144, 24);
            this.childName_textBox.TabIndex = 4;
            // 
            // children_dataGridView
            // 
            this.children_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.children_dataGridView.Location = new System.Drawing.Point(887, 23);
            this.children_dataGridView.Name = "children_dataGridView";
            this.children_dataGridView.RowHeadersWidth = 51;
            this.children_dataGridView.RowTemplate.Height = 24;
            this.children_dataGridView.Size = new System.Drawing.Size(365, 514);
            this.children_dataGridView.TabIndex = 2;
            // 
            // OfficeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 593);
            this.Controls.Add(this.mainPanel);
            this.Name = "OfficeView";
            this.Text = "Children contest management system";
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.challenges_dataGridView)).EndInit();
            this.operations_flowLayoutPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.childAge_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.children_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.DataGridView challenges_dataGridView;
        private System.Windows.Forms.FlowLayoutPanel operations_flowLayoutPanel;
        private System.Windows.Forms.DataGridView children_dataGridView;
        private System.Windows.Forms.TextBox challengeName_textBox;
        private System.Windows.Forms.ComboBox groupAge_comboBox;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox childCNP_textBox;
        private System.Windows.Forms.TextBox childName_textBox;
        private System.Windows.Forms.NumericUpDown childAge_numericUpDown;
        private System.Windows.Forms.ComboBox chooseChallenge_comboBox;
        private System.Windows.Forms.Button enrollChild_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}