namespace SomerenUI
{
    partial class UpdateStudentForm
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
            studentFirstNameTextbox = new System.Windows.Forms.TextBox();
            studentLastNameTextbox = new System.Windows.Forms.TextBox();
            studentClasstextbox = new System.Windows.Forms.TextBox();
            studentTelephoneNumberTextbox = new System.Windows.Forms.TextBox();
            studentRoomNumberTextbox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            updateStudentButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // studentFirstNameTextbox
            // 
            studentFirstNameTextbox.Location = new System.Drawing.Point(274, 40);
            studentFirstNameTextbox.Name = "studentFirstNameTextbox";
            studentFirstNameTextbox.Size = new System.Drawing.Size(125, 27);
            studentFirstNameTextbox.TabIndex = 0;
            // 
            // studentLastNameTextbox
            // 
            studentLastNameTextbox.Location = new System.Drawing.Point(274, 99);
            studentLastNameTextbox.Name = "studentLastNameTextbox";
            studentLastNameTextbox.Size = new System.Drawing.Size(125, 27);
            studentLastNameTextbox.TabIndex = 1;
            // 
            // studentClasstextbox
            // 
            studentClasstextbox.Location = new System.Drawing.Point(274, 150);
            studentClasstextbox.Name = "studentClasstextbox";
            studentClasstextbox.Size = new System.Drawing.Size(125, 27);
            studentClasstextbox.TabIndex = 2;
            // 
            // studentTelephoneNumberTextbox
            // 
            studentTelephoneNumberTextbox.Location = new System.Drawing.Point(274, 206);
            studentTelephoneNumberTextbox.Name = "studentTelephoneNumberTextbox";
            studentTelephoneNumberTextbox.Size = new System.Drawing.Size(125, 27);
            studentTelephoneNumberTextbox.TabIndex = 3;
            // 
            // studentRoomNumberTextbox
            // 
            studentRoomNumberTextbox.Location = new System.Drawing.Point(274, 269);
            studentRoomNumberTextbox.Name = "studentRoomNumberTextbox";
            studentRoomNumberTextbox.Size = new System.Drawing.Size(125, 27);
            studentRoomNumberTextbox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(44, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(133, 20);
            label1.TabIndex = 5;
            label1.Text = "Update First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(45, 102);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(132, 20);
            label2.TabIndex = 6;
            label2.Text = "Update Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(45, 153);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(95, 20);
            label3.TabIndex = 7;
            label3.Text = "Update Class";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(45, 209);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(161, 20);
            label4.TabIndex = 8;
            label4.Text = "Update Phone Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(45, 272);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(160, 20);
            label5.TabIndex = 9;
            label5.Text = "Update Room Number";
            // 
            // updateStudentButton
            // 
            updateStudentButton.Location = new System.Drawing.Point(132, 334);
            updateStudentButton.Name = "updateStudentButton";
            updateStudentButton.Size = new System.Drawing.Size(134, 52);
            updateStudentButton.TabIndex = 10;
            updateStudentButton.Text = "Update";
            updateStudentButton.UseVisualStyleBackColor = true;
            updateStudentButton.Click += updateStudentButton_Click;
            // 
            // UpdateStudentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(438, 409);
            Controls.Add(updateStudentButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(studentRoomNumberTextbox);
            Controls.Add(studentTelephoneNumberTextbox);
            Controls.Add(studentClasstextbox);
            Controls.Add(studentLastNameTextbox);
            Controls.Add(studentFirstNameTextbox);
            Name = "UpdateStudentForm";
            Text = "Update Student";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox studentFirstNameTextbox;
        private System.Windows.Forms.TextBox studentLastNameTextbox;
        private System.Windows.Forms.TextBox studentClasstextbox;
        private System.Windows.Forms.TextBox studentTelephoneNumberTextbox;
        private System.Windows.Forms.TextBox studentRoomNumberTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button updateStudentButton;
    }
}