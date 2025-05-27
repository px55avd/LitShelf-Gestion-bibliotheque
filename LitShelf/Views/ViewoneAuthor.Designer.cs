namespace LitShelf.Views
{
    partial class ViewoneAuthor
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
            this.btnUpdateauthor = new System.Windows.Forms.Button();
            this.btnDeleteauthor = new System.Windows.Forms.Button();
            this.lblFirstname = new System.Windows.Forms.Label();
            this.txtboxFirstname = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtboxName = new System.Windows.Forms.TextBox();
            this.btnClientmenu = new System.Windows.Forms.Button();
            this.btnLoanmenu = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnBookmenu = new System.Windows.Forms.Button();
            this.lblNameauthor = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdateauthor
            // 
            this.btnUpdateauthor.Location = new System.Drawing.Point(479, 205);
            this.btnUpdateauthor.Name = "btnUpdateauthor";
            this.btnUpdateauthor.Size = new System.Drawing.Size(128, 41);
            this.btnUpdateauthor.TabIndex = 161;
            this.btnUpdateauthor.Text = "Modifier";
            this.btnUpdateauthor.UseVisualStyleBackColor = true;
            this.btnUpdateauthor.Click += new System.EventHandler(this.btnUpdateauthor_Click);
            // 
            // btnDeleteauthor
            // 
            this.btnDeleteauthor.Location = new System.Drawing.Point(333, 205);
            this.btnDeleteauthor.Name = "btnDeleteauthor";
            this.btnDeleteauthor.Size = new System.Drawing.Size(128, 41);
            this.btnDeleteauthor.TabIndex = 160;
            this.btnDeleteauthor.Text = "Supprimer";
            this.btnDeleteauthor.UseVisualStyleBackColor = true;
            this.btnDeleteauthor.Click += new System.EventHandler(this.btnDeleteauthor_Click);
            // 
            // lblFirstname
            // 
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.Location = new System.Drawing.Point(333, 73);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(49, 15);
            this.lblFirstname.TabIndex = 159;
            this.lblFirstname.Text = "Prénom";
            // 
            // txtboxFirstname
            // 
            this.txtboxFirstname.Location = new System.Drawing.Point(333, 91);
            this.txtboxFirstname.Name = "txtboxFirstname";
            this.txtboxFirstname.Size = new System.Drawing.Size(274, 23);
            this.txtboxFirstname.TabIndex = 158;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(333, 131);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(34, 15);
            this.lblName.TabIndex = 157;
            this.lblName.Text = "Nom";
            // 
            // txtboxName
            // 
            this.txtboxName.Location = new System.Drawing.Point(333, 149);
            this.txtboxName.Name = "txtboxName";
            this.txtboxName.Size = new System.Drawing.Size(274, 23);
            this.txtboxName.TabIndex = 159;
            // 
            // btnClientmenu
            // 
            this.btnClientmenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClientmenu.Location = new System.Drawing.Point(26, 368);
            this.btnClientmenu.Name = "btnClientmenu";
            this.btnClientmenu.Size = new System.Drawing.Size(107, 52);
            this.btnClientmenu.TabIndex = 155;
            this.btnClientmenu.Text = "Client";
            this.btnClientmenu.UseVisualStyleBackColor = true;
            this.btnClientmenu.Click += new System.EventHandler(this.btnClientmenu_Click);
            // 
            // btnLoanmenu
            // 
            this.btnLoanmenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoanmenu.Location = new System.Drawing.Point(26, 266);
            this.btnLoanmenu.Name = "btnLoanmenu";
            this.btnLoanmenu.Size = new System.Drawing.Size(107, 52);
            this.btnLoanmenu.TabIndex = 154;
            this.btnLoanmenu.Text = "Emprunt";
            this.btnLoanmenu.UseVisualStyleBackColor = true;
            this.btnLoanmenu.Click += new System.EventHandler(this.btnLoanmenu_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Location = new System.Drawing.Point(26, 165);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(107, 52);
            this.btnBack.TabIndex = 153;
            this.btnBack.Text = "Retour";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnBookmenu
            // 
            this.btnBookmenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBookmenu.Location = new System.Drawing.Point(26, 73);
            this.btnBookmenu.Name = "btnBookmenu";
            this.btnBookmenu.Size = new System.Drawing.Size(107, 52);
            this.btnBookmenu.TabIndex = 152;
            this.btnBookmenu.Text = "Livre";
            this.btnBookmenu.UseVisualStyleBackColor = true;
            this.btnBookmenu.Click += new System.EventHandler(this.btnBookmenu_Click);
            // 
            // lblNameauthor
            // 
            this.lblNameauthor.AutoSize = true;
            this.lblNameauthor.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNameauthor.Location = new System.Drawing.Point(416, 7);
            this.lblNameauthor.Name = "lblNameauthor";
            this.lblNameauthor.Size = new System.Drawing.Size(117, 28);
            this.lblNameauthor.TabIndex = 151;
            this.lblNameauthor.Text = "Nom auteur";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMenu.Location = new System.Drawing.Point(45, 7);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(62, 28);
            this.lblMenu.TabIndex = 150;
            this.lblMenu.Text = "Menu";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(157, -8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 467);
            this.label2.TabIndex = 149;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 5);
            this.label1.TabIndex = 148;
            // 
            // ViewoneAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdateauthor);
            this.Controls.Add(this.btnDeleteauthor);
            this.Controls.Add(this.lblFirstname);
            this.Controls.Add(this.txtboxFirstname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtboxName);
            this.Controls.Add(this.btnClientmenu);
            this.Controls.Add(this.btnLoanmenu);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnBookmenu);
            this.Controls.Add(this.lblNameauthor);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ViewoneAuthor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LitShelf";
            this.Activated += new System.EventHandler(this.ViewoneAuthor_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnUpdateauthor;
        private Button btnDeleteauthor;
        private Label lblFirstname;
        private TextBox txtboxFirstname;
        private Label lblName;
        private TextBox txtboxName;
        private Button btnClientmenu;
        private Button btnLoanmenu;
        private Button btnBack;
        private Button btnBookmenu;
        private Label lblNameauthor;
        private Label lblMenu;
        private Label label2;
        private Label label1;
    }
}