namespace LitShelf
{
    partial class Viewbook
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmboxAuthor = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblNumberpages = new System.Windows.Forms.Label();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnNewbook = new System.Windows.Forms.Button();
            this.pnlBookbutton = new System.Windows.Forms.Panel();
            this.btnClientmenu = new System.Windows.Forms.Button();
            this.btnLoanmenu = new System.Windows.Forms.Button();
            this.btnAuthormenu = new System.Windows.Forms.Button();
            this.btnBookmenu = new System.Windows.Forms.Button();
            this.lblBook = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmboxAuthor
            // 
            this.cmboxAuthor.FormattingEnabled = true;
            this.cmboxAuthor.Location = new System.Drawing.Point(220, 73);
            this.cmboxAuthor.Name = "cmboxAuthor";
            this.cmboxAuthor.Size = new System.Drawing.Size(169, 23);
            this.cmboxAuthor.TabIndex = 58;
            this.cmboxAuthor.Text = "Auteur";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(395, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 23);
            this.btnSearch.TabIndex = 59;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblNumberpages
            // 
            this.lblNumberpages.AutoSize = true;
            this.lblNumberpages.Location = new System.Drawing.Point(689, 419);
            this.lblNumberpages.Name = "lblNumberpages";
            this.lblNumberpages.Size = new System.Drawing.Size(13, 15);
            this.lblNumberpages.TabIndex = 63;
            this.lblNumberpages.Text = "1";
            // 
            // btnMinus
            // 
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinus.Location = new System.Drawing.Point(664, 415);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(20, 23);
            this.btnMinus.TabIndex = 61;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnUp
            // 
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUp.Location = new System.Drawing.Point(709, 415);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(20, 23);
            this.btnUp.TabIndex = 62;
            this.btnUp.Text = "+";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnNewbook
            // 
            this.btnNewbook.Location = new System.Drawing.Point(622, 72);
            this.btnNewbook.Name = "btnNewbook";
            this.btnNewbook.Size = new System.Drawing.Size(105, 23);
            this.btnNewbook.TabIndex = 60;
            this.btnNewbook.Text = "Nouveau livre";
            this.btnNewbook.UseVisualStyleBackColor = true;
            this.btnNewbook.Click += new System.EventHandler(this.btnNewbook_Click);
            // 
            // pnlBookbutton
            // 
            this.pnlBookbutton.Location = new System.Drawing.Point(220, 106);
            this.pnlBookbutton.Name = "pnlBookbutton";
            this.pnlBookbutton.Size = new System.Drawing.Size(507, 299);
            this.pnlBookbutton.TabIndex = 59;
            // 
            // btnClientmenu
            // 
            this.btnClientmenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClientmenu.Location = new System.Drawing.Point(26, 368);
            this.btnClientmenu.Name = "btnClientmenu";
            this.btnClientmenu.Size = new System.Drawing.Size(107, 52);
            this.btnClientmenu.TabIndex = 57;
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
            this.btnLoanmenu.TabIndex = 56;
            this.btnLoanmenu.Text = "Emprunt";
            this.btnLoanmenu.UseVisualStyleBackColor = true;
            this.btnLoanmenu.Click += new System.EventHandler(this.btnLoanmenu_Click);
            // 
            // btnAuthormenu
            // 
            this.btnAuthormenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAuthormenu.Location = new System.Drawing.Point(26, 165);
            this.btnAuthormenu.Name = "btnAuthormenu";
            this.btnAuthormenu.Size = new System.Drawing.Size(107, 52);
            this.btnAuthormenu.TabIndex = 55;
            this.btnAuthormenu.Text = "Auteur";
            this.btnAuthormenu.UseVisualStyleBackColor = true;
            this.btnAuthormenu.Click += new System.EventHandler(this.btnAuthormenu_Click);
            // 
            // btnBookmenu
            // 
            this.btnBookmenu.Enabled = false;
            this.btnBookmenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBookmenu.Location = new System.Drawing.Point(26, 73);
            this.btnBookmenu.Name = "btnBookmenu";
            this.btnBookmenu.Size = new System.Drawing.Size(107, 52);
            this.btnBookmenu.TabIndex = 54;
            this.btnBookmenu.Text = "Livre";
            this.btnBookmenu.UseVisualStyleBackColor = true;
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBook.Location = new System.Drawing.Point(416, 7);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(53, 28);
            this.lblBook.TabIndex = 53;
            this.lblBook.Text = "Livre";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMenu.Location = new System.Drawing.Point(45, 7);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(62, 28);
            this.lblMenu.TabIndex = 52;
            this.lblMenu.Text = "Menu";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(157, -8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 467);
            this.label2.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 5);
            this.label1.TabIndex = 50;
            // 
            // Viewbook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmboxAuthor);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblNumberpages);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnNewbook);
            this.Controls.Add(this.pnlBookbutton);
            this.Controls.Add(this.btnClientmenu);
            this.Controls.Add(this.btnLoanmenu);
            this.Controls.Add(this.btnAuthormenu);
            this.Controls.Add(this.btnBookmenu);
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Viewbook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LitShelf";
            this.Activated += new System.EventHandler(this.Viewbook_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmboxAuthor;
        private Button btnSearch;
        private Label lblNumberpages;
        private Button btnMinus;
        private Button btnUp;
        private Button btnNewbook;
        private Panel pnlBookbutton;
        private Button btnClientmenu;
        private Button btnLoanmenu;
        private Button btnAuthormenu;
        private Button btnBookmenu;
        private Label lblBook;
        private Label lblMenu;
        private Label label2;
        private Label label1;
    }
}