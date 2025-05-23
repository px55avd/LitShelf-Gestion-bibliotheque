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
    public partial class ViewoneBook : Form
    {
        public ViewoneBook()
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
        /// Événement déclenché lorsque le formulaire `ViewoneBook` devient actif.
        /// Réinitialise les champs du formaulaire et les remplie avec les informations du livre sélectionné.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
        private void ViewoneBook_Activated(object sender, EventArgs e)
        {


            //Réinitialise les champs
            lblNamebook.Text = "";
            txtboxISBN.Text = "";
            txtboxTitle.Text = "";
            txtboxYearofPublication.Text = "";
            txtboxQuantity.Text = "";
            cmboxAuthor.Text = "";

            //Nettoye le combobox
            cmboxAuthor.Items.Clear();

            // Remplie le formulaire selon le livre sélectionné
            lblNamebook.Text = $"{Controller.GetcurrentBook()[1]}";
            txtboxISBN.Text = Controller.GetcurrentBook()[0];
            txtboxTitle.Text = Controller.GetcurrentBook()[1];
            txtboxYearofPublication.Text = Controller.GetcurrentBook()[2];
            txtboxQuantity.Text = Controller.GetcurrentBook()[3];
            cmboxAuthor.Items.Insert(0, $"{Controller.GetcurrentBook()[5]} {Controller.GetcurrentBook()[6]}");

            // Récupère les données auteur
            Controller.SetauthorData();

            //Empeche la saisie de texte
            cmboxAuthor.DropDownStyle = ComboBoxStyle.DropDownList;

            //Charge le combo box avec les données auteur
            for (int i = 0; i < Controller.GetauthorData().GetLength(0); i++)
            {
                //Vérifie si le auteur à ajouter est déja dans le combobox
                if ($"{Controller.GetcurrentBook()[5]} {Controller.GetcurrentBook()[6]}" != Controller.GetauthorData()[i, 2] + " " + Controller.GetauthorData()[i, 1])
                {
                    cmboxAuthor.Items.Add(Controller.GetauthorData()[i, 2] + " " + Controller.GetauthorData()[i, 1]);
                } 
            }

            cmboxAuthor.SelectedIndex = 0;
            cmboxAuthor.DropDownHeight = 150; // Hauteur en pixels
        }

        /// <summary>
        /// Gère le clic sur le bouton de "Modifier".
        /// Modifie un livre.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
        private void btnUpdatebook_Click(object sender, EventArgs e)
        {
            //Variable pour récupérer les valeur
            int idAuthor = 0;
            string oldISBN = Controller.GetcurrentBook()[0];
            int id_auteur_old = Convert.ToInt32(Controller.GetcurrentBook()[4]);
            string ISBN = txtboxISBN.Text;
            string title = txtboxTitle.Text;
            string yearOfpublication =txtboxYearofPublication.Text;
            string quantity = txtboxQuantity.Text;
            string  nameAuthor = cmboxAuthor.Text;

            // vérifie que les deux champs sont vides
            if (txtboxQuantity.Text == string.Empty || txtboxISBN.Text == string.Empty || txtboxYearofPublication.Text == string.Empty || txtboxTitle.Text == string.Empty)
            {
                MessageBox.Show("L'un des champs est vide !"); // Message pour non respect des regex
            }
            else
            {
                for (int i = 0; i < Controller.GetauthorData().GetLength(0); i++)
                {
                    if (Controller.GetauthorData()[i, 2] + " " + Controller.GetauthorData()[i, 1] == nameAuthor)
                    {
                        idAuthor = Convert.ToInt32(Controller.GetauthorData()[i, 0]);
                    }
                }

                // Affiche un message d'avertissement et récupère la réponse de l'utilisateur
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier ce livre ?", "Attention, Modification", MessageBoxButtons.YesNo);

                // Vérifie si l'utilisateur a cliqué sur "Yes"
                if (result == DialogResult.Yes)
                {
                    // Modifie un nouveau livre avec les information nécessaire
                    Controller.Updatebook(ISBN, title, yearOfpublication, quantity, idAuthor, oldISBN, id_auteur_old);

                    Controller.changeView("Viewbook", FindForm());
                }
            }
        }

        /// <summary>
        /// Gère le clic sur le bouton de "Supprimer".
        /// Supprime un livre.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
        private void btnDeletebook_Click(object sender, EventArgs e)
        {
            // Affiche un message d'avertissement et récupère la réponse de l'utilisateur
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce livre ?", "Attention, Suppréssion", MessageBoxButtons.YesNo);

            // Vérifie si l'utilisateur a cliqué sur "Yes"
            if (result == DialogResult.Yes)
            {
                // Appelle la méthode dans le contrôleur pour supprimer le livre.
                Controller.Deletebook();

                // Affiche la vue client  
                Controller.changeView("Viewbook", FindForm());
            }
        }
    }
}
