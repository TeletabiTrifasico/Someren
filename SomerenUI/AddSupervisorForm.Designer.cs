namespace SomerenUI
{
    partial class AddSupervisorForm
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
            AddLecNumtxtBox = new System.Windows.Forms.TextBox();
            AddIdtxtBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            AddSupervisorB = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(55, 52);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Lecturer Id:";
            // 
            // AddLecNumtxtBox
            // 
            AddLecNumtxtBox.Location = new System.Drawing.Point(265, 52);
            AddLecNumtxtBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            AddLecNumtxtBox.Name = "AddLecNumtxtBox";
            AddLecNumtxtBox.Size = new System.Drawing.Size(125, 27);
            AddLecNumtxtBox.TabIndex = 1;
            // 
            // AddIdtxtBox
            // 
            AddIdtxtBox.Location = new System.Drawing.Point(265, 111);
            AddIdtxtBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            AddIdtxtBox.Name = "AddIdtxtBox";
            AddIdtxtBox.Size = new System.Drawing.Size(125, 27);
            AddIdtxtBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(55, 115);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(78, 20);
            label2.TabIndex = 3;
            label2.Text = "Activity id:";
            // 
            // AddSupervisorB
            // 
            AddSupervisorB.Location = new System.Drawing.Point(139, 184);
            AddSupervisorB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            AddSupervisorB.Name = "AddSupervisorB";
            AddSupervisorB.Size = new System.Drawing.Size(154, 29);
            AddSupervisorB.TabIndex = 4;
            AddSupervisorB.Text = "Add Supervisor";
            AddSupervisorB.UseVisualStyleBackColor = true;
            AddSupervisorB.Click += button1_Click;
            // 
            // AddSupervisorForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(456, 281);
            Controls.Add(AddSupervisorB);
            Controls.Add(label2);
            Controls.Add(AddIdtxtBox);
            Controls.Add(AddLecNumtxtBox);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Name = "AddSupervisorForm";
            Text = "AddSupervisorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AddLecNumtxtBox;
        private System.Windows.Forms.TextBox AddIdtxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddSupervisorB;
    }
}