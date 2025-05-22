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
        private void btnAuhormenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewauthor", FindForm());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
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
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
