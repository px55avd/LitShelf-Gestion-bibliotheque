namespace LitShelf.Views
{
    partial class Viewauthor
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
            this.lblNumberpages = new System.Windows.Forms.Label();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnNewauthor = new System.Windows.Forms.Button();
            this.pnlAuthorbutton = new System.Windows.Forms.Panel();
            this.btnClientmenu = new System.Windows.Forms.Button();
            this.btnLoanmenu = new System.Windows.Forms.Button();
            this.btnAuthormenu = new System.Windows.Forms.Button();
            this.btnBookmenu = new System.Windows.Forms.Button();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumberpages
            // 
            this.lblNumberpages.AutoSize = true;
            this.lblNumberpages.Location = new System.Drawing.Point(689, 419);
            this.lblNumberpages.Name = "lblNumberpages";
            this.lblNumberpages.Size = new System.Drawing.Size(13, 15);
            this.lblNumberpages.TabIndex = 78;
            this.lblNumberpages.Text = "1";
            // 
            // btnMinus
            // 
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinus.Location = new System.Drawing.Point(664, 415);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(20, 23);
            this.btnMinus.TabIndex = 77;
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
            this.btnUp.TabIndex = 79;
            this.btnUp.Text = "+";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnNewauthor
            // 
            this.btnNewauthor.Location = new System.Drawing.Point(683, 73);
            this.btnNewauthor.Name = "btnNewauthor";
            this.btnNewauthor.Size = new System.Drawing.Size(105, 27);
            this.btnNewauthor.TabIndex = 74;
            this.btnNewauthor.Text = "Nouvel auteur";
            this.btnNewauthor.UseVisualStyleBackColor = true;
            this.btnNewauthor.Click += new System.EventHandler(this.btnNewauthor_Click);
            // 
            // pnlAuthorbutton
            // 
            this.pnlAuthorbutton.Location = new System.Drawing.Point(220, 106);
            this.pnlAuthorbutton.Name = "pnlAuthorbutton";
            this.pnlAuthorbutton.Size = new System.Drawing.Size(507, 299);
            this.pnlAuthorbutton.TabIndex = 74;
            // 
            // btnClientmenu
            // 
            this.btnClientmenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClientmenu.Location = new System.Drawing.Point(26, 368);
            this.btnClientmenu.Name = "btnClientmenu";
            this.btnClientmenu.Size = new System.Drawing.Size(107, 52);
            this.btnClientmenu.TabIndex = 73;
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
            this.btnLoanmenu.TabIndex = 72;
            this.btnLoanmenu.Text = "Emprunt";
            this.btnLoanmenu.UseVisualStyleBackColor = true;
            this.btnLoanmenu.Click += new System.EventHandler(this.btnLoanmenu_Click);
            // 
            // btnAuthormenu
            // 
            this.btnAuthormenu.Enabled = false;
            this.btnAuthormenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAuthormenu.Location = new System.Drawing.Point(26, 165);
            this.btnAuthormenu.Name = "btnAuthormenu";
            this.btnAuthormenu.Size = new System.Drawing.Size(107, 52);
            this.btnAuthormenu.TabIndex = 71;
            this.btnAuthormenu.Text = "Auteur";
            this.btnAuthormenu.UseVisualStyleBackColor = true;
            // 
            // btnBookmenu
            // 
            this.btnBookmenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBookmenu.Location = new System.Drawing.Point(26, 73);
            this.btnBookmenu.Name = "btnBookmenu";
            this.btnBookmenu.Size = new System.Drawing.Size(107, 52);
            this.btnBookmenu.TabIndex = 70;
            this.btnBookmenu.Text = "Livre";
            this.btnBookmenu.UseVisualStyleBackColor = true;
            this.btnBookmenu.Click += new System.EventHandler(this.btnBookmenu_Click);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAuthor.Location = new System.Drawing.Point(416, 7);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(71, 28);
            this.lblAuthor.TabIndex = 69;
            this.lblAuthor.Text = "Auteur";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMenu.Location = new System.Drawing.Point(45, 7);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(62, 28);
            this.lblMenu.TabIndex = 68;
            this.lblMenu.Text = "Menu";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(157, -8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 467);
            this.label2.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 5);
            this.label1.TabIndex = 66;
            // 
            // Viewauthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNumberpages);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnNewauthor);
            this.Controls.Add(this.pnlAuthorbutton);
            this.Controls.Add(this.btnClientmenu);
            this.Controls.Add(this.btnLoanmenu);
            this.Controls.Add(this.btnAuthormenu);
            this.Controls.Add(this.btnBookmenu);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Viewauthor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LitShelf";
            this.Activated += new System.EventHandler(this.Viewauthor_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblNumberpages;
        private Button btnMinus;
        private Button btnUp;
        private Button btnNewauthor;
        private Panel pnlAuthorbutton;
        private Button btnClientmenu;
        private Button btnLoanmenu;
        private Button btnAuthormenu;
        private Button btnBookmenu;
        private Label lblAuthor;
        private Label lblMenu;
        private Label label2;
        private Label label1;
    }
}