using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LitShelf.Views
{
    public partial class ViewoneAuthor : Form
    {
        public ViewoneAuthor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Controller associé à la vue.
        /// </summary>
        public Controller.Controller Controller { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBookmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewbook", FindForm());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewauthor", FindForm());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoanmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewloan", FindForm());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClientmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewclient", FindForm());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewoneAuthor_Activated(object sender, EventArgs e)
        {
            // Réinitialise le label titre et les champs textes.
            txtboxFirstname.Text = "";
            txtboxName.Text = "";
            lblNameauthor.Text = "";

            // Intègre les informations auteurs dans le formulaire.
            lblNameauthor.Text = $"{Controller.GetcurrentAuthor()[2]} {Controller.GetcurrentAuthor()[1]}";
            txtboxFirstname.Text = Controller.GetcurrentAuthor()[2];
            txtboxName.Text = Controller.GetcurrentAuthor()[1];
        }
    }
}
