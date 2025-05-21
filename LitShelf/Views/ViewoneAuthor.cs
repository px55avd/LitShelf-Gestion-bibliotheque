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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateauthor_Click(object sender, EventArgs e)
        {
            // Récupère les saisies utilisateurs
            string firstname = txtboxFirstname.Text;
            string name = txtboxName.Text;

            // les Affichent lors du clic
            txtboxFirstname.Text = firstname;
            txtboxName.Text = name;

            // Affiche un message d'avertissement et récupère la réponse de l'utilisateur
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier cette auteur ?", "Attention, Modification", MessageBoxButtons.YesNo);

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
