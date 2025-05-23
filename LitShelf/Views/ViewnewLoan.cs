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
    public partial class ViewnewLoan : Form
    {
        public ViewnewLoan()
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
        private void btnAuhormenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewauthor", FindForm());
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton "Retour".
        /// Lorsque l'utilisateur clique sur ce bouton, la vue actuelle est remplacée
        /// par la vue "Viewloan" en appelant la méthode `changeView` du contrôleur.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement (le bouton cliqué).</param>
        /// <param name="e">Les arguments de l'événement de clic.</param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewloan", FindForm());
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
            Controller.changeView("Viewclient", FindForm());
        }

        /// <summary>
        /// Événement déclenché lorsque le formulaire `ViewnewLoan` devient actif.
        /// Réinitialise les champs du formaulaire.
        /// </summary>
        /// <param name="sender">Objet source de l'événement (le formulaire).</param>
        /// <param name="e">Arguments vides.</param>
        private void ViewnewLoan_Activated(object sender, EventArgs e)
        {
            // Récupère les données auteur
            Controller.SetclientData();

            // Récupère les livre empruntable
            Controller.SetbookBorrowabledata();

            //Réinitialise le formulaire
            cmboxBook.Text = "";
            cmboxClient.Text = "";

            //Nettoye les combobox
            cmboxClient.Items.Clear();
            cmboxBook.Items.Clear();

            // Empeche la saisie de texte
            cmboxClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmboxBook.DropDownStyle = ComboBoxStyle.DropDownList;

            //Charge le combobox avec les données auteur
            for (int i = 0; i < Controller.GetclientData().GetLength(0); i++)
            {
                cmboxClient.Items.Add(Controller.GetclientData()[i, 2] + " " + Controller.GetclientData()[i, 1]);
            }

            //Charge le combobox avec les données livre empruntable
            for (int i = 0; i < Controller.GetbookBorrowabledata().GetLength(0); i++)
            {
                cmboxBook.Items.Add(Controller.GetbookBorrowabledata()[i, 1]);
            }

            // Hauteur en pixels
            cmboxClient.DropDownHeight = 200; 
            cmboxBook.DropDownHeight = 200; 
        }

        /// <summary>
        /// Gère le clic sur le bouton de "Valider".
        /// Ajoute un nouvel emprunt.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
        private void btnValidnewLoan_Click(object sender, EventArgs e)
        {
            string idClient = "";
            string idBook = "";

            // vérifie que les deux champs sont vides
            if (cmboxBook.Text == string.Empty || cmboxClient.Text == string.Empty)
            {
                MessageBox.Show("L'un des champs est vide !"); // Message pour non respect des regex
            }
            else
            {
                for (int i = 0; i < Controller.GetclientData().GetLength(0); i++)
                {
                    //Vérifie si le champs texte conrrespond au client dans la DB.
                    if (Controller.GetclientData()[i, 2] + " " + Controller.GetclientData()[i, 1] == cmboxClient.Text)
                    {
                        // Charge la valeur de la clé dans "idClient".
                        idClient = Controller.GetclientData()[i, 0];
                    }
                }

                for (int i = 0; i < Controller.GetbookBorrowabledata().GetLength(0); i++)
                {
                    //Vérifie si le champs texte conrrespond au titre des livre disponible.
                    if (Controller.GetbookBorrowabledata()[i, 1] == cmboxBook.Text)
                    {
                        // Charge la valeur de la clé dans "idBook"
                        idBook = Controller.GetbookBorrowabledata()[i, 3];
                    }

                }

                // Affiche un message d'avertissement et récupère la réponse de l'utilisateur
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir ajouter ce nouvel emprunt ?", "Attention,", MessageBoxButtons.YesNo);

                // Vérifie si l'utilisateur a cliqué sur "Yes"
                if (result == DialogResult.Yes)
                {
                    // Créer un nouvel emprunt avec les information nécessaire
                    Controller.CreatenewLoan(idClient, idBook);

                    Controller.changeView("Viewloan", FindForm());
                }
            }
        }
    }

}
