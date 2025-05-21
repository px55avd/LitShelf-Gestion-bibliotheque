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
    public partial class ViewoneClient : Form
    {
        public ViewoneClient()
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
        private void ViewoneClient_Activated(object sender, EventArgs e)
        {
            // Réinitialise le label titre et les champs textes.
            txtboxFirstname.Text = "";
            txtboxName.Text = "";
            lblNameClient.Text = "";

            // Intègre les informations clients dans le formulaire.
            lblNameClient.Text = $"{ Controller.GetcurrentClient()[2]} {Controller.GetcurrentClient()[1]}";
            txtboxFirstname.Text = Controller.GetcurrentClient()[2];
            txtboxName.Text = Controller.GetcurrentClient()[1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateclient_Click(object sender, EventArgs e)
        {
            // Récupère les saisies utilisateurs
            string firstname = txtboxFirstname.Text;
            string name = txtboxName.Text;

            // les Affichent lors du clic
            txtboxFirstname.Text = firstname;
            txtboxName.Text = name;

            // Affiche un message d'avertissement et récupère la réponse de l'utilisateur
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier cet client ?", "Attention, Modification", MessageBoxButtons.YesNo);

            // Vérifie si l'utilisateur a cliqué sur "Yes"
            if (result == DialogResult.Yes)
            {
                // Appelle la méthode dans le contrôleur pour modifier le client
                Controller.Updateclient(firstname, name);

                // Affiche la vue client  
                Controller.changeView("Viewclient", FindForm());
            }
        }

        private void btnDeleteclient_Click(object sender, EventArgs e)
        {
            // Récupère les saisies utilisateurs
            string firstname = txtboxFirstname.Text;
            string name = txtboxName.Text;

            // les Affichent lors du clic
            txtboxFirstname.Text = firstname;
            txtboxName.Text = name;

            // Affiche un message d'avertissement et récupère la réponse de l'utilisateur
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce client ?", "Attention, Suppréssion", MessageBoxButtons.YesNo);

            // Vérifie si l'utilisateur a cliqué sur "Yes"
            if (result == DialogResult.Yes)
            {
                // Appelle la méthode dans le contrôleur pour supprimer le client
                Controller.Deleteclient();

                // Affiche la vue client  
                Controller.changeView("Viewclient", FindForm());
            }
        }
    }
}
