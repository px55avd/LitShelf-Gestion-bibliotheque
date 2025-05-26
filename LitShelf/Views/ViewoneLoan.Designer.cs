namespace LitShelf.Views
{
    partial class ViewoneLoan
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
            this.btnUpdateloan = new System.Windows.Forms.Button();
            this.btnDeleteloan = new System.Windows.Forms.Button();
            this.LblLoandate = new System.Windows.Forms.Label();
            this.lblBook = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblbackdate = new System.Windows.Forms.Label();
            this.btnClientmenu = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAuhormenu = new System.Windows.Forms.Button();
            this.btnBookmenu = new System.Windows.Forms.Button();
            this.lblNameloan = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtmpLoandate = new System.Windows.Forms.DateTimePicker();
            this.dtmpBackdate = new System.Windows.Forms.DateTimePicker();
            this.cmboxClient = new System.Windows.Forms.ComboBox();
            this.cmboxBook = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnUpdateloan
            // 
            this.btnUpdateloan.Location = new System.Drawing.Point(479, 301);
            this.btnUpdateloan.Name = "btnUpdateloan";
            this.btnUpdateloan.Size = new System.Drawing.Size(128, 41);
            this.btnUpdateloan.TabIndex = 133;
            this.btnUpdateloan.Text = "Modifier";
            this.btnUpdateloan.UseVisualStyleBackColor = true;
            this.btnUpdateloan.Click += new System.EventHandler(this.btnUpdateloan_Click);
            // 
            // btnDeleteloan
            // 
            this.btnDeleteloan.Location = new System.Drawing.Point(333, 301);
            this.btnDeleteloan.Name = "btnDeleteloan";
            this.btnDeleteloan.Size = new System.Drawing.Size(128, 41);
            this.btnDeleteloan.TabIndex = 132;
            this.btnDeleteloan.Text = "Retouner";
            this.btnDeleteloan.UseVisualStyleBackColor = true;
            this.btnDeleteloan.Click += new System.EventHandler(this.btnDeleteloan_Click);
            // 
            // LblLoandate
            // 
            this.LblLoandate.AutoSize = true;
            this.LblLoandate.Location = new System.Drawing.Point(333, 73);
            this.LblLoandate.Name = "LblLoandate";
            this.LblLoandate.Size = new System.Drawing.Size(90, 15);
            this.LblLoandate.TabIndex = 128;
            this.LblLoandate.Text = "Date d\'emprunt";
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Location = new System.Drawing.Point(333, 235);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(32, 15);
            this.lblBook.TabIndex = 126;
            this.lblBook.Text = "Livre";
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(333, 181);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(38, 15);
            this.lblClient.TabIndex = 125;
            this.lblClient.Text = "Client";
            // 
            // lblbackdate
            // 
            this.lblbackdate.AutoSize = true;
            this.lblbackdate.Location = new System.Drawing.Point(333, 126);
            this.lblbackdate.Name = "lblbackdate";
            this.lblbackdate.Size = new System.Drawing.Size(66, 15);
            this.lblbackdate.TabIndex = 124;
            this.lblbackdate.Text = "Date retour";
            // 
            // btnClientmenu
            // 
            this.btnClientmenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClientmenu.Location = new System.Drawing.Point(26, 368);
            this.btnClientmenu.Name = "btnClientmenu";
            this.btnClientmenu.Size = new System.Drawing.Size(107, 52);
            this.btnClientmenu.TabIndex = 121;
            this.btnClientmenu.Text = "Client";
            this.btnClientmenu.UseVisualStyleBackColor = true;
            this.btnClientmenu.Click += new System.EventHandler(this.btnClientmenu_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Location = new System.Drawing.Point(26, 266);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(107, 52);
            this.btnBack.TabIndex = 120;
            this.btnBack.Text = "Retour";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAuhormenu
            // 
            this.btnAuhormenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAuhormenu.Location = new System.Drawing.Point(26, 165);
            this.btnAuhormenu.Name = "btnAuhormenu";
            this.btnAuhormenu.Size = new System.Drawing.Size(107, 52);
            this.btnAuhormenu.TabIndex = 119;
            this.btnAuhormenu.Text = "Auteur";
            this.btnAuhormenu.UseVisualStyleBackColor = true;
            this.btnAuhormenu.Click += new System.EventHandler(this.btnAuhormenu_Click);
            // 
            // btnBookmenu
            // 
            this.btnBookmenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBookmenu.Location = new System.Drawing.Point(26, 73);
            this.btnBookmenu.Name = "btnBookmenu";
            this.btnBookmenu.Size = new System.Drawing.Size(107, 52);
            this.btnBookmenu.TabIndex = 118;
            this.btnBookmenu.Text = "Livre";
            this.btnBookmenu.UseVisualStyleBackColor = true;
            this.btnBookmenu.Click += new System.EventHandler(this.btnBookmenu_Click);
            // 
            // lblNameloan
            // 
            this.lblNameloan.AutoSize = true;
            this.lblNameloan.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNameloan.Location = new System.Drawing.Point(382, 7);
            this.lblNameloan.Name = "lblNameloan";
            this.lblNameloan.Size = new System.Drawing.Size(173, 28);
            this.lblNameloan.TabIndex = 117;
            this.lblNameloan.Text = "Nom de l\'emprunt";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMenu.Location = new System.Drawing.Point(45, 7);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(62, 28);
            this.lblMenu.TabIndex = 116;
            this.lblMenu.Text = "Menu";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(157, -8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 467);
            this.label2.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 5);
            this.label1.TabIndex = 114;
            // 
            // dtmpLoandate
            // 
            this.dtmpLoandate.Location = new System.Drawing.Point(333, 91);
            this.dtmpLoandate.Name = "dtmpLoandate";
            this.dtmpLoandate.Size = new System.Drawing.Size(274, 23);
            this.dtmpLoandate.TabIndex = 134;
            // 
            // dtmpBackdate
            // 
            this.dtmpBackdate.Location = new System.Drawing.Point(333, 144);
            this.dtmpBackdate.Name = "dtmpBackdate";
            this.dtmpBackdate.Size = new System.Drawing.Size(274, 23);
            this.dtmpBackdate.TabIndex = 135;
            // 
            // cmboxClient
            // 
            this.cmboxClient.FormattingEnabled = true;
            this.cmboxClient.Location = new System.Drawing.Point(333, 199);
            this.cmboxClient.Name = "cmboxClient";
            this.cmboxClient.Size = new System.Drawing.Size(274, 23);
            this.cmboxClient.TabIndex = 136;
            // 
            // cmboxBook
            // 
            this.cmboxBook.FormattingEnabled = true;
            this.cmboxBook.Location = new System.Drawing.Point(333, 253);
            this.cmboxBook.Name = "cmboxBook";
            this.cmboxBook.Size = new System.Drawing.Size(274, 23);
            this.cmboxBook.TabIndex = 131;
            // 
            // ViewoneLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmboxClient);
            this.Controls.Add(this.dtmpBackdate);
            this.Controls.Add(this.dtmpLoandate);
            this.Controls.Add(this.btnUpdateloan);
            this.Controls.Add(this.btnDeleteloan);
            this.Controls.Add(this.cmboxBook);
            this.Controls.Add(this.LblLoandate);
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblbackdate);
            this.Controls.Add(this.btnClientmenu);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAuhormenu);
            this.Controls.Add(this.btnBookmenu);
            this.Controls.Add(this.lblNameloan);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewoneLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LitShelf";
            this.Activated += new System.EventHandler(this.ViewoneLoan_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnUpdateloan;
        private Button btnDeleteloan;
        private Label LblLoandate;
        private Label lblBook;
        private Label lblClient;
        private Label lblbackdate;
        private Button btnClientmenu;
        private Button btnBack;
        private Button btnAuhormenu;
        private Button btnBookmenu;
        private Label lblNameloan;
        private Label lblMenu;
        private Label label2;
        private Label label1;
        private DateTimePicker dtmpLoandate;
        private DateTimePicker dtmpBackdate;
        private ComboBox cmboxClient;
        private ComboBox cmboxBook;
    }
}