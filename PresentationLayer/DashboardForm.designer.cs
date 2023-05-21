namespace Proftaak_Semester_2
{
    partial class DashboardForm
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
            this.btnProductenlijst = new System.Windows.Forms.Button();
            this.btnNieuwproduct = new System.Windows.Forms.Button();
            this.btnAantalveranderen = new System.Windows.Forms.Button();
            this.btnProductinfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnProductenlijst
            // 
            this.btnProductenlijst.Location = new System.Drawing.Point(267, 119);
            this.btnProductenlijst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProductenlijst.Name = "btnProductenlijst";
            this.btnProductenlijst.Size = new System.Drawing.Size(181, 30);
            this.btnProductenlijst.TabIndex = 0;
            this.btnProductenlijst.Text = "Productenlijst";
            this.btnProductenlijst.UseVisualStyleBackColor = true;
            this.btnProductenlijst.Click += new System.EventHandler(this.btnProductenlijst_Click);
            // 
            // btnNieuwproduct
            // 
            this.btnNieuwproduct.Location = new System.Drawing.Point(267, 154);
            this.btnNieuwproduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNieuwproduct.Name = "btnNieuwproduct";
            this.btnNieuwproduct.Size = new System.Drawing.Size(181, 34);
            this.btnNieuwproduct.TabIndex = 1;
            this.btnNieuwproduct.Text = "Voeg nieuw product toe";
            this.btnNieuwproduct.UseVisualStyleBackColor = true;
            this.btnNieuwproduct.Click += new System.EventHandler(this.btnNieuwproduct_Click);
            // 
            // btnAantalveranderen
            // 
            this.btnAantalveranderen.Location = new System.Drawing.Point(267, 194);
            this.btnAantalveranderen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAantalveranderen.Name = "btnAantalveranderen";
            this.btnAantalveranderen.Size = new System.Drawing.Size(181, 34);
            this.btnAantalveranderen.TabIndex = 2;
            this.btnAantalveranderen.Text = "Product aantal veranderen";
            this.btnAantalveranderen.UseVisualStyleBackColor = true;
            this.btnAantalveranderen.Click += new System.EventHandler(this.btnAantalveranderen_Click);
            // 
            // btnProductinfo
            // 
            this.btnProductinfo.Location = new System.Drawing.Point(267, 232);
            this.btnProductinfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProductinfo.Name = "btnProductinfo";
            this.btnProductinfo.Size = new System.Drawing.Size(181, 31);
            this.btnProductinfo.TabIndex = 3;
            this.btnProductinfo.Text = "Product verwijderen";
            this.btnProductinfo.UseVisualStyleBackColor = true;
            this.btnProductinfo.Click += new System.EventHandler(this.btnProductinfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(260, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dashboard";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProductinfo);
            this.Controls.Add(this.btnAantalveranderen);
            this.Controls.Add(this.btnNieuwproduct);
            this.Controls.Add(this.btnProductenlijst);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProductenlijst;
        private System.Windows.Forms.Button btnNieuwproduct;
        private System.Windows.Forms.Button btnAantalveranderen;
        private System.Windows.Forms.Button btnProductinfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
    }
}