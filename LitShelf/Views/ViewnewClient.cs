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
    public partial class ViewnewClient : Form
    {
        public ViewnewClient()
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
        private void btnAuthormenu_Click(object sender, EventArgs e)
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
        private void btnBack_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewclient", FindForm());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValidnewClient_Click(object sender, EventArgs e)
        {
            // vérifie que les deux champs sont vides
            if (txtboxFirstname.Text == string.Empty || txtboxName.Text == string.Empty)
            {
                MessageBox.Show("L'un des champs est vide !"); // Message pour non respect des regex
            }

            // vérifie que lees deux champs sont remplies
            if (txtboxFirstname.Text != string.Empty && txtboxName.Text != string.Empty)
            {
                Controller.CreatenewClient(txtboxFirstname.Text, txtboxName.Text); // Créer un nouveau client avec nom et prénom

                Controller.changeView("Viewclient", FindForm());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewnewClient_Activated(object sender, EventArgs e)
        {
            // Réinitialise le label titre et les champs textes.
            txtboxFirstname.Text = "";
            txtboxName.Text = "";
        }
    }
}
