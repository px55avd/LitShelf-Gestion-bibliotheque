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
        /// Gère l'événement de clic sur le bouton "Auteur".
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
        /// Gère l'événement de clic sur le bouton "Retour".
        /// Lorsque l'utilisateur clique sur ce bouton, la vue actuelle est remplacée
        /// par la vue "Viewauthor" en appelant la méthode `changeView` du contrôleur.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement (le bouton cliqué).</param>
        /// <param name="e">Les arguments de l'événement de clic.</param>
        private void btnBack_Click(object sender, EventArgs e)
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
        /// Gère l'événement de clic sur le bouton "¨Client".
        /// Lorsque l'utilisateur clique sur ce bouton, la vue actuelle est remplacée
        /// par la vue "Viewclient" en appelant la méthode `changeView` du contrôleur.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement (le bouton cliqué).</param>
        /// <param name="e">Les arguments de l'événement de clic.</param>
        private void btnClientmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewclient", FindForm());
        }

        /// <summary>
        /// Événement déclenché lorsque le formulaire `ViewoneAuthor` devient actif.
        /// Réinitialise les champs du formaulaire et les remplie avec les informations de l'auteur sélectionné.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
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

        /// <summary>
        /// Gère le clic sur le bouton de "Modifier".
        /// Modifie un auteur.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
        private void btnUpdateauthor_Click(object sender, EventArgs e)
        {
            // Récupère les saisies utilisateurs
            string firstname = txtboxFirstname.Text;
            string name = txtboxName.Text;

            // les Affichent lors du clic
            txtboxFirstname.Text = firstname;
            txtboxName.Text = name;

            // Affiche un message d'avertissement et récupère la réponse de l'utilisateur
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier cet auteur ?", "Attention, Modification", MessageBoxButtons.YesNo);

            // Vérifie si l'utilisateur a cliqué sur "Yes"
            if (result == DialogResult.Yes)
            {
                // vérifie que les deux champs sont vides
                if (firstname == string.Empty && name == string.Empty)
                {
                    MessageBox.Show("Les champs sont vides !!!"); 
                }

                // vérifie que l'un des deux champs est vides
                if (firstname == string.Empty && name != string.Empty)
                {
                    Controller.Updateauthor(null, name); // Appelle la méthode dans le contrôleur pour modifier un auteur avec uniquement un nom
                    Controller.changeView("Viewauthor", FindForm());
                }

                // vérifie que l'un des deux champs est vides
                if (firstname != string.Empty && name == string.Empty)
                {
                    Controller.Updateauthor(firstname, null); // Appelle la méthode dans le contrôleur pour modifier un auteur avec uniquement un prénom
                    Controller.changeView("Viewauthor", FindForm());
                }

                // vérifie que les deux champs sont remplies
                if (firstname != string.Empty && name != string.Empty)
                {
                    Controller.Updateauthor(firstname, name); // Appelle la méthode dans le contrôleur pour modifier un auteur
                    Controller.changeView("Viewauthor", FindForm());
                }
            }
        }

        /// <summary>
        /// Gère le clic sur le bouton de "Supprimer".
        /// Supprime un auteur.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
        private void btnDeleteauthor_Click(object sender, EventArgs e)
        {
            // Récupère les saisies utilisateurs
            string firstname = txtboxFirstname.Text;
            string name = txtboxName.Text;

            // les Affichent lors du clic
            txtboxFirstname.Text = firstname;
            txtboxName.Text = name;

            // Affiche un message d'avertissement et récupère la réponse de l'utilisateur
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet auteur ?", "Attention, Suppréssion", MessageBoxButtons.YesNo);

            // Vérifie si l'utilisateur a cliqué sur "Yes"
            if (result == DialogResult.Yes)
            {
                // Appelle la méthode dans le contrôleur pour supprimer l'auteur.
                Controller.Deleteauthor();

                // Affiche la vue client  
                Controller.changeView("Viewauthor", FindForm());
            }
        }
    }
}
