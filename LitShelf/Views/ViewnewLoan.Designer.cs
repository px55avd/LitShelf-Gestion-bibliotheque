﻿namespace LitShelf.Views
{
    partial class ViewnewLoan
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
            this.cmboxClient = new System.Windows.Forms.ComboBox();
            this.btnValidnewLoan = new System.Windows.Forms.Button();
            this.cmboxBook = new System.Windows.Forms.ComboBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.btnClientmenu = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAuhormenu = new System.Windows.Forms.Button();
            this.btnBookmenu = new System.Windows.Forms.Button();
            this.lblNewloan = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmboxClient
            // 
            this.cmboxClient.FormattingEnabled = true;
            this.cmboxClient.Location = new System.Drawing.Point(321, 91);
            this.cmboxClient.Name = "cmboxClient";
            this.cmboxClient.Size = new System.Drawing.Size(274, 23);
            this.cmboxClient.TabIndex = 145;
            // 
            // btnValidnewLoan
            // 
            this.btnValidnewLoan.Location = new System.Drawing.Point(467, 193);
            this.btnValidnewLoan.Name = "btnValidnewLoan";
            this.btnValidnewLoan.Size = new System.Drawing.Size(128, 41);
            this.btnValidnewLoan.TabIndex = 147;
            this.btnValidnewLoan.Text = "Valider";
            this.btnValidnewLoan.UseVisualStyleBackColor = true;
            this.btnValidnewLoan.Click += new System.EventHandler(this.btnValidnewLoan_Click);
            // 
            // cmboxBook
            // 
            this.cmboxBook.FormattingEnabled = true;
            this.cmboxBook.Location = new System.Drawing.Point(321, 145);
            this.cmboxBook.Name = "cmboxBook";
            this.cmboxBook.Size = new System.Drawing.Size(274, 23);
            this.cmboxBook.TabIndex = 146;
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Location = new System.Drawing.Point(321, 127);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(32, 15);
            this.lblBook.TabIndex = 147;
            this.lblBook.Text = "Livre";
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(321, 73);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(38, 15);
            this.lblClient.TabIndex = 146;
            this.lblClient.Text = "Client";
            // 
            // btnClientmenu
            // 
            this.btnClientmenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClientmenu.Location = new System.Drawing.Point(26, 368);
            this.btnClientmenu.Name = "btnClientmenu";
            this.btnClientmenu.Size = new System.Drawing.Size(107, 52);
            this.btnClientmenu.TabIndex = 144;
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
            this.btnBack.TabIndex = 143;
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
            this.btnAuhormenu.TabIndex = 142;
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
            this.btnBookmenu.TabIndex = 141;
            this.btnBookmenu.Text = "Livre";
            this.btnBookmenu.UseVisualStyleBackColor = true;
            this.btnBookmenu.Click += new System.EventHandler(this.btnBookmenu_Click);
            // 
            // lblNewloan
            // 
            this.lblNewloan.AutoSize = true;
            this.lblNewloan.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNewloan.Location = new System.Drawing.Point(382, 7);
            this.lblNewloan.Name = "lblNewloan";
            this.lblNewloan.Size = new System.Drawing.Size(155, 28);
            this.lblNewloan.TabIndex = 140;
            this.lblNewloan.Text = "Nouvel emprunt";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMenu.Location = new System.Drawing.Point(45, 7);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(62, 28);
            this.lblMenu.TabIndex = 139;
            this.lblMenu.Text = "Menu";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(157, -8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 467);
            this.label2.TabIndex = 138;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 5);
            this.label1.TabIndex = 137;
            // 
            // ViewnewLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmboxClient);
            this.Controls.Add(this.btnValidnewLoan);
            this.Controls.Add(this.cmboxBook);
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.btnClientmenu);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAuhormenu);
            this.Controls.Add(this.btnBookmenu);
            this.Controls.Add(this.lblNewloan);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewnewLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LitShelf";
            this.Activated += new System.EventHandler(this.ViewnewLoan_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmboxClient;
        private Button btnValidnewLoan;
        private ComboBox cmboxBook;
        private Label lblBook;
        private Label lblClient;
        private Button btnClientmenu;
        private Button btnBack;
        private Button btnAuhormenu;
        private Button btnBookmenu;
        private Label lblNewloan;
        private Label lblMenu;
        private Label label2;
        private Label label1;
    }
}