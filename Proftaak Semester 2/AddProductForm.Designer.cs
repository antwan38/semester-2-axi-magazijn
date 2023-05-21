namespace Proftaak_Semester_2
{
    partial class AddProductForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxBarcode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnToevoegen = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.nupAmount = new System.Windows.Forms.NumericUpDown();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.tbxLocatie = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.nupCapacity = new System.Windows.Forms.NumericUpDown();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(66, 122);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(126, 46);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Naam";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxName.Location = new System.Drawing.Point(279, 126);
            this.tbxName.Margin = new System.Windows.Forms.Padding(2);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(540, 45);
            this.tbxName.TabIndex = 1;
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxBarcode.Location = new System.Drawing.Point(279, 184);
            this.tbxBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.Size = new System.Drawing.Size(540, 45);
            this.tbxBarcode.TabIndex = 3;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.Location = new System.Drawing.Point(66, 180);
            this.lblBarcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(170, 46);
            this.lblBarcode.TabIndex = 2;
            this.lblBarcode.Text = "Barcode";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(66, 232);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(193, 46);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Categorie";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(66, 340);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(133, 46);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Aantal";
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToevoegen.Location = new System.Drawing.Point(567, 465);
            this.btnToevoegen.Margin = new System.Windows.Forms.Padding(2);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(251, 67);
            this.btnToevoegen.TabIndex = 7;
            this.btnToevoegen.Text = "Toevoegen";
            this.btnToevoegen.UseVisualStyleBackColor = true;
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "this",
            "category",
            "does",
            "not",
            "exist"});
            this.cmbCategory.Location = new System.Drawing.Point(279, 239);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(540, 44);
            this.cmbCategory.TabIndex = 8;
            // 
            // nupAmount
            // 
            this.nupAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupAmount.Location = new System.Drawing.Point(279, 349);
            this.nupAmount.Margin = new System.Windows.Forms.Padding(2);
            this.nupAmount.Name = "nupAmount";
            this.nupAmount.Size = new System.Drawing.Size(539, 41);
            this.nupAmount.TabIndex = 10;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(75, 51);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(135, 38);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "<- Terug";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(66, 287);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(150, 46);
            this.lblLocation.TabIndex = 12;
            this.lblLocation.Text = "Locatie";
            // 
            // tbxLocatie
            // 
            this.tbxLocatie.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLocatie.Location = new System.Drawing.Point(279, 291);
            this.tbxLocatie.Margin = new System.Windows.Forms.Padding(2);
            this.tbxLocatie.Name = "tbxLocatie";
            this.tbxLocatie.Size = new System.Drawing.Size(233, 45);
            this.tbxLocatie.TabIndex = 13;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.Location = new System.Drawing.Point(515, 287);
            this.lblCapacity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(123, 58);
            this.lblCapacity.TabIndex = 14;
            this.lblCapacity.Text = "Max.\r\nProducten";
            // 
            // nupCapacity
            // 
            this.nupCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupCapacity.Location = new System.Drawing.Point(665, 295);
            this.nupCapacity.Margin = new System.Windows.Forms.Padding(2);
            this.nupCapacity.Name = "nupCapacity";
            this.nupCapacity.Size = new System.Drawing.Size(153, 41);
            this.nupCapacity.TabIndex = 15;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(867, 51);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 38);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 631);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.nupCapacity);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.tbxLocatie);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.nupAmount);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnToevoegen);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.tbxBarcode);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lblName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddProductForm";
            this.Text = "Add New Product";
            ((System.ComponentModel.ISupportInitialize)(this.nupAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnToevoegen;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.NumericUpDown nupAmount;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox tbxLocatie;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.NumericUpDown nupCapacity;
        private System.Windows.Forms.Button btnExit;
    }
}