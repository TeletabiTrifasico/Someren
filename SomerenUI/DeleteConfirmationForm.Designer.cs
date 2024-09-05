namespace SomerenUI
{
    partial class DeleteConfirmationForm
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
            DeleteItemMessageLabel = new System.Windows.Forms.Label();
            YesButton = new System.Windows.Forms.Button();
            NoButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // DeleteItemMessageLabel
            // 
            DeleteItemMessageLabel.AutoSize = true;
            DeleteItemMessageLabel.Location = new System.Drawing.Point(11, 22);
            DeleteItemMessageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            DeleteItemMessageLabel.Name = "DeleteItemMessageLabel";
            DeleteItemMessageLabel.Size = new System.Drawing.Size(0, 20);
            DeleteItemMessageLabel.TabIndex = 0;
            // 
            // YesButton
            // 
            YesButton.Location = new System.Drawing.Point(11, 98);
            YesButton.Margin = new System.Windows.Forms.Padding(2);
            YesButton.Name = "YesButton";
            YesButton.Size = new System.Drawing.Size(120, 40);
            YesButton.TabIndex = 1;
            YesButton.Text = "Yes";
            YesButton.UseVisualStyleBackColor = true;
            YesButton.Click += YesButton_Click;
            // 
            // NoButton
            // 
            NoButton.Location = new System.Drawing.Point(276, 98);
            NoButton.Margin = new System.Windows.Forms.Padding(2);
            NoButton.Name = "NoButton";
            NoButton.Size = new System.Drawing.Size(120, 40);
            NoButton.TabIndex = 2;
            NoButton.Text = "No";
            NoButton.UseVisualStyleBackColor = true;
            NoButton.Click += NoButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(51, 41);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(311, 20);
            label1.TabIndex = 3;
            label1.Text = "Are you sure you want to delete this element?";
            // 
            // DeleteCheckForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(407, 149);
            Controls.Add(label1);
            Controls.Add(NoButton);
            Controls.Add(YesButton);
            Controls.Add(DeleteItemMessageLabel);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "DeleteCheckForm";
            Text = "Delete confirmation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label DeleteItemMessageLabel;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.Label label1;
    }
}