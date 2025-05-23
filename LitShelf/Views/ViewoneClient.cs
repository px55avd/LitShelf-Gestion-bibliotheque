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
        /// Gère l'événement de clic sur le bouton "Livre".
        /// Lorsque l'utilisateur clique sur ce bouton, la vue actuelle est remplacée
        /// par la vue "Viewbook" en appelant la méthode `changeView` du contrôleur.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement (le bouton cliqué).</param>
        /// <param name="e">Les arguments de l'événement de clic.</param>
        private void btnBookmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewbook", FindForm());
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton "Auteur".
        /// Lorsque l'utilisateur clique sur ce bouton, la vue actuelle est remplacée
        /// par la vue "Viewauthor" en appelant la méthode `changeView` du contrôleur.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement (le bouton cliqué).</param>
        /// <param name="e">Les arguments de l'événement de clic.</param>
        private void btnAuthormenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewauthor", FindForm());
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton "Emprunt".
        /// Lorsque l'utilisateur clique sur ce bouton, la vue actuelle est remplacée
        /// par la vue "Viewloan" en appelant la méthode `changeView` du contrôleur.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement (le bouton cliqué).</param>
        /// <param name="e">Les arguments de l'événement de clic.</param>
        private void btnLoanmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewloan", FindForm());
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton "Retour".
        /// Lorsque l'utilisateur clique sur ce bouton, la vue actuelle est remplacée
        /// par la vue "Viewclient" en appelant la méthode `changeView` du contrôleur.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement (le bouton cliqué).</param>
        /// <param name="e">Les arguments de l'événement de clic.</param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewclient", FindForm());
        }

        /// <summary>
        /// Événement déclenché lorsque le formulaire `ViewoneClient` devient actif.
        /// Réinitialise les champs du formaulaire et les remplie avec les informations du client sélectionné.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
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
        /// Gère le clic sur le bouton de "Modifier".
        /// Modifie un client.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
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

        /// <summary>
        /// Gère le clic sur le bouton de "Supprimer".
        /// Supprime un client.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
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
