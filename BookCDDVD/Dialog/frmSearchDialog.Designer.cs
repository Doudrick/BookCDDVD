namespace BookCDDVD
{
    partial class frmSearchDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUPC = new System.Windows.Forms.TextBox();
            this.btnSearchSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Enter the UPC of the Product You Are Looking For:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "UPC:";
            // 
            // txtUPC
            // 
            this.txtUPC.Location = new System.Drawing.Point(64, 49);
            this.txtUPC.MaxLength = 5;
            this.txtUPC.Name = "txtUPC";
            this.txtUPC.Size = new System.Drawing.Size(100, 20);
            this.txtUPC.TabIndex = 2;
            this.txtUPC.TextChanged += new System.EventHandler(this.txtUPC_TextChanged);
            // 
            // btnSearchSubmit
            // 
            this.btnSearchSubmit.Enabled = false;
            this.btnSearchSubmit.Location = new System.Drawing.Point(205, 48);
            this.btnSearchSubmit.Name = "btnSearchSubmit";
            this.btnSearchSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSearchSubmit.TabIndex = 3;
            this.btnSearchSubmit.Text = "Submit";
            this.btnSearchSubmit.UseVisualStyleBackColor = true;
            this.btnSearchSubmit.Click += new System.EventHandler(this.btnSearchSubmit_Click);
            // 
            // frmSearchDialog
            // 
            this.AcceptButton = this.btnSearchSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 93);
            this.Controls.Add(this.btnSearchSubmit);
            this.Controls.Add(this.txtUPC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSearchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search UPC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUPC;
        private System.Windows.Forms.Button btnSearchSubmit;
    }
}