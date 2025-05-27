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
    public partial class ViewnewBook : Form
    {
        public ViewnewBook()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Controller associé à la vue.
        /// </summary>
        public Controller.Controller Controller { get; set; }

        /// <summary>
        /// Gère l'événement de clic sur le bouton "Retour".
        /// Lorsque l'utilisateur clique sur ce bouton, la vue actuelle est remplacée
        /// par la vue "Viewbook" en appelant la méthode `changeView` du contrôleur.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement (le bouton cliqué).</param>
        /// <param name="e">Les arguments de l'événement de clic.</param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Controller.Changeview("Viewbook", FindForm());
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
            Controller.Changeview("Viewauthor", FindForm());
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
            Controller.Changeview("Viewloan", FindForm());
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton "Client".
        /// Lorsque l'utilisateur clique sur ce bouton, la vue actuelle est remplacée
        /// par la vue "Viewclient" en appelant la méthode `changeView` du contrôleur.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement (le bouton cliqué).</param>
        /// <param name="e">Les arguments de l'événement de clic.</param>
        private void btnClientmenu_Click(object sender, EventArgs e)
        {
            Controller.Changeview("Viewclient", FindForm());
        }

        /// <summary>
        /// Gère le clic sur le bouton de "Valider".
        /// Ajoute un nouveau livre.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
        private void btnValidnewBook_Click(object sender, EventArgs e)
        {
            // vérifie que les deux champs sont vides
            if (txtboxQuantity.Text == string.Empty || txtboxISBN.Text == string.Empty || txtboxYearofpublication.Text == string.Empty || txtboxTitle.Text == string.Empty)
            {
                MessageBox.Show("L'un des champs est vide !"); // Message pour non respect des regex
            }
            else 
            {
                for (int i = 0; i < Controller.GetauthorData().GetLength(0); i++)
                {
                    if (Controller.GetauthorData()[i, 2] + " " + Controller.GetauthorData()[i, 1] == cmboxAuthor.Text)
                    {

                        // Affiche un message d'avertissement et récupère la réponse de l'utilisateur
                        DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier ce livre ?", "Attention, Modification", MessageBoxButtons.YesNo);

                        // Vérifie si l'utilisateur a cliqué sur "Yes"
                        if (result == DialogResult.Yes)
                        {
                            // Créer un nouveau livre avec les information nécessaire

                            Controller.CreatenewBook(txtboxISBN.Text, txtboxTitle.Text, txtboxYearofpublication.Text, txtboxQuantity.Text, Convert.ToInt32(Controller.GetauthorData()[i, 0]));

                            Controller.Changeview("Viewbook", FindForm());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Événement déclenché lorsque le formulaire `ViewnewBook` devient actif.
        /// Réinitialise les champs du formaulaire.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
        private void ViewnewBook_Activated(object sender, EventArgs e)
        {
            // Nettoye le combobox
            cmboxAuthor.Items.Clear();

            //Récupère les données auteur
            Controller.SetauthorData();

            //Empeche la saisie de texte
            cmboxAuthor.DropDownStyle = ComboBoxStyle.DropDownList;

            // Attribue les auteurs au combobox
            for (int i = 0; i < Controller.GetauthorData().GetLength(0); i++)
            {
                cmboxAuthor.Items.Add(Controller.GetauthorData()[i, 2] + " " + Controller.GetauthorData()[i, 1]);
            }
 
            cmboxAuthor.DropDownHeight = 200; // Hauteur en pixels
        }
    }
}
