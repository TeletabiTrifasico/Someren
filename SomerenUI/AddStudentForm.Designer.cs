namespace SomerenUI
{
    partial class AddStudentForm
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            addStudentButton = new System.Windows.Forms.Button();
            studentAddNumberTextbox = new System.Windows.Forms.TextBox();
            studentAddFirstNameTextbox = new System.Windows.Forms.TextBox();
            studentAddLastNameTextbox = new System.Windows.Forms.TextBox();
            studentAddClasstextbox = new System.Windows.Forms.TextBox();
            studentAddTelephoneNumberTextbox = new System.Windows.Forms.TextBox();
            studentAddRoomTextbox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(39, 40);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(118, 20);
            label1.TabIndex = 0;
            label1.Text = "Student Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(39, 85);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(80, 20);
            label2.TabIndex = 1;
            label2.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(39, 129);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Last Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(39, 170);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(42, 20);
            label4.TabIndex = 3;
            label4.Text = "Class";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(39, 212);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(108, 20);
            label5.TabIndex = 4;
            label5.Text = "Phone Number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(39, 259);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(107, 20);
            label6.TabIndex = 5;
            label6.Text = "Room Number";
            // 
            // addStudentButton
            // 
            addStudentButton.Location = new System.Drawing.Point(107, 318);
            addStudentButton.Name = "addStudentButton";
            addStudentButton.Size = new System.Drawing.Size(134, 52);
            addStudentButton.TabIndex = 6;
            addStudentButton.Text = "Add Student";
            addStudentButton.UseVisualStyleBackColor = true;
            addStudentButton.Click += addStudentButton_Click;
            // 
            // studentAddNumberTextbox
            // 
            studentAddNumberTextbox.Location = new System.Drawing.Point(203, 37);
            studentAddNumberTextbox.Name = "studentAddNumberTextbox";
            studentAddNumberTextbox.Size = new System.Drawing.Size(125, 27);
            studentAddNumberTextbox.TabIndex = 7;
            // 
            // studentAddFirstNameTextbox
            // 
            studentAddFirstNameTextbox.Location = new System.Drawing.Point(203, 82);
            studentAddFirstNameTextbox.Name = "studentAddFirstNameTextbox";
            studentAddFirstNameTextbox.Size = new System.Drawing.Size(125, 27);
            studentAddFirstNameTextbox.TabIndex = 8;
            // 
            // studentAddLastNameTextbox
            // 
            studentAddLastNameTextbox.Location = new System.Drawing.Point(203, 126);
            studentAddLastNameTextbox.Name = "studentAddLastNameTextbox";
            studentAddLastNameTextbox.Size = new System.Drawing.Size(125, 27);
            studentAddLastNameTextbox.TabIndex = 9;
            // 
            // studentAddClasstextbox
            // 
            studentAddClasstextbox.Location = new System.Drawing.Point(203, 167);
            studentAddClasstextbox.Name = "studentAddClasstextbox";
            studentAddClasstextbox.Size = new System.Drawing.Size(125, 27);
            studentAddClasstextbox.TabIndex = 10;
            // 
            // studentAddTelephoneNumberTextbox
            // 
            studentAddTelephoneNumberTextbox.Location = new System.Drawing.Point(203, 209);
            studentAddTelephoneNumberTextbox.Name = "studentAddTelephoneNumberTextbox";
            studentAddTelephoneNumberTextbox.Size = new System.Drawing.Size(125, 27);
            studentAddTelephoneNumberTextbox.TabIndex = 11;
            // 
            // studentAddRoomTextbox
            // 
            studentAddRoomTextbox.Location = new System.Drawing.Point(203, 256);
            studentAddRoomTextbox.Name = "studentAddRoomTextbox";
            studentAddRoomTextbox.Size = new System.Drawing.Size(125, 27);
            studentAddRoomTextbox.TabIndex = 12;
            // 
            // AddStudentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(395, 382);
            Controls.Add(studentAddRoomTextbox);
            Controls.Add(studentAddTelephoneNumberTextbox);
            Controls.Add(studentAddClasstextbox);
            Controls.Add(studentAddLastNameTextbox);
            Controls.Add(studentAddFirstNameTextbox);
            Controls.Add(studentAddNumberTextbox);
            Controls.Add(addStudentButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddStudentForm";
            Text = "Add Student";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.TextBox studentAddNumberTextbox;
        private System.Windows.Forms.TextBox studentAddFirstNameTextbox;
        private System.Windows.Forms.TextBox studentAddLastNameTextbox;
        private System.Windows.Forms.TextBox studentAddClasstextbox;
        private System.Windows.Forms.TextBox studentAddTelephoneNumberTextbox;
        private System.Windows.Forms.TextBox studentAddRoomTextbox;
    }
}