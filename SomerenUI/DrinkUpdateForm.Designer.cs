namespace SomerenUI
{
    partial class DrinkUpdateForm
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
            txtVat = new System.Windows.Forms.TextBox();
            txtStock = new System.Windows.Forms.TextBox();
            txtPrice = new System.Windows.Forms.TextBox();
            txtName = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            btnUpdate = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // txtVat
            // 
            txtVat.Location = new System.Drawing.Point(247, 189);
            txtVat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            txtVat.Name = "txtVat";
            txtVat.Size = new System.Drawing.Size(125, 27);
            txtVat.TabIndex = 21;
            // 
            // txtStock
            // 
            txtStock.Location = new System.Drawing.Point(247, 140);
            txtStock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            txtStock.Name = "txtStock";
            txtStock.Size = new System.Drawing.Size(125, 27);
            txtStock.TabIndex = 20;
            // 
            // txtPrice
            // 
            txtPrice.Location = new System.Drawing.Point(247, 89);
            txtPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new System.Drawing.Size(125, 27);
            txtPrice.TabIndex = 19;
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(247, 38);
            txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(125, 27);
            txtName.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(47, 189);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(108, 20);
            label5.TabIndex = 17;
            label5.Text = "New drink VAT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(47, 139);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(117, 20);
            label4.TabIndex = 16;
            label4.Text = "New drink stock:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(47, 89);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(116, 20);
            label3.TabIndex = 15;
            label3.Text = "New drink price:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(47, 38);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(120, 20);
            label2.TabIndex = 14;
            label2.Text = "New drink name:";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(136, 242);
            btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(122, 48);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update a drink";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // DrinkUpdateForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(433, 327);
            Controls.Add(txtVat);
            Controls.Add(txtStock);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnUpdate);
            Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Name = "DrinkUpdateForm";
            Text = "UpdateDrink";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtVat;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
    }
}