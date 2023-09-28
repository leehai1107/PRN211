namespace AutomobileWinApp
{
    partial class frmCarManagement
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
            this.lbCarID = new System.Windows.Forms.Label();
            this.lbCarName = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbManufacturer = new System.Windows.Forms.Label();
            this.lbReleaseYear = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtCarID = new System.Windows.Forms.TextBox();
            this.txtCarName = new System.Windows.Forms.TextBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtReleaseYear = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvCarList = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCarID
            // 
            this.lbCarID.AutoSize = true;
            this.lbCarID.Location = new System.Drawing.Point(54, 37);
            this.lbCarID.Name = "lbCarID";
            this.lbCarID.Size = new System.Drawing.Size(39, 15);
            this.lbCarID.TabIndex = 0;
            this.lbCarID.Text = "Car ID";
            // 
            // lbCarName
            // 
            this.lbCarName.AutoSize = true;
            this.lbCarName.Location = new System.Drawing.Point(54, 88);
            this.lbCarName.Name = "lbCarName";
            this.lbCarName.Size = new System.Drawing.Size(60, 15);
            this.lbCarName.TabIndex = 1;
            this.lbCarName.Text = "Car Name";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(449, 37);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(33, 15);
            this.lbPrice.TabIndex = 2;
            this.lbPrice.Text = "Price";
            // 
            // lbManufacturer
            // 
            this.lbManufacturer.AutoSize = true;
            this.lbManufacturer.Location = new System.Drawing.Point(54, 147);
            this.lbManufacturer.Name = "lbManufacturer";
            this.lbManufacturer.Size = new System.Drawing.Size(79, 15);
            this.lbManufacturer.TabIndex = 3;
            this.lbManufacturer.Text = "Manufacturer";
            // 
            // lbReleaseYear
            // 
            this.lbReleaseYear.AutoSize = true;
            this.lbReleaseYear.Location = new System.Drawing.Point(449, 88);
            this.lbReleaseYear.Name = "lbReleaseYear";
            this.lbReleaseYear.Size = new System.Drawing.Size(71, 15);
            this.lbReleaseYear.TabIndex = 4;
            this.lbReleaseYear.Text = "Release Year";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(83, 202);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(93, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtCarID
            // 
            this.txtCarID.Location = new System.Drawing.Point(164, 34);
            this.txtCarID.Name = "txtCarID";
            this.txtCarID.Size = new System.Drawing.Size(198, 23);
            this.txtCarID.TabIndex = 6;
            // 
            // txtCarName
            // 
            this.txtCarName.Location = new System.Drawing.Point(164, 85);
            this.txtCarName.Name = "txtCarName";
            this.txtCarName.Size = new System.Drawing.Size(198, 23);
            this.txtCarName.TabIndex = 7;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(164, 144);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(198, 23);
            this.txtManufacturer.TabIndex = 8;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(538, 34);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(198, 23);
            this.txtPrice.TabIndex = 9;
            // 
            // txtReleaseYear
            // 
            this.txtReleaseYear.Location = new System.Drawing.Point(538, 85);
            this.txtReleaseYear.Name = "txtReleaseYear";
            this.txtReleaseYear.Size = new System.Drawing.Size(198, 23);
            this.txtReleaseYear.TabIndex = 10;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(316, 202);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(104, 23);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(538, 202);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvCarList
            // 
            this.dgvCarList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarList.Location = new System.Drawing.Point(15, 232);
            this.dgvCarList.Name = "dgvCarList";
            this.dgvCarList.ReadOnly = true;
            this.dgvCarList.RowTemplate.Height = 25;
            this.dgvCarList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarList.Size = new System.Drawing.Size(775, 185);
            this.dgvCarList.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(344, 423);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 24);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCarManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvCarList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtReleaseYear);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.txtCarName);
            this.Controls.Add(this.txtCarID);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lbReleaseYear);
            this.Controls.Add(this.lbManufacturer);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbCarName);
            this.Controls.Add(this.lbCarID);
            this.Name = "frmCarManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Management";
            this.Load += new System.EventHandler(this.frmCarManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbCarID;
        private Label lbCarName;
        private Label lbPrice;
        private Label lbManufacturer;
        private Label lbReleaseYear;
        private Button btnLoad;
        private TextBox txtCarID;
        private TextBox txtCarName;
        private TextBox txtManufacturer;
        private TextBox txtPrice;
        private TextBox txtReleaseYear;
        private Button btnNew;
        private Button btnDelete;
        private DataGridView dgvCarList;
        private Button btnClose;
    }
}