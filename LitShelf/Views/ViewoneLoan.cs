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
    public partial class ViewoneLoan : Form
    {
        public ViewoneLoan()
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

        private void ViewoneLoan_Activated(object sender, EventArgs e)
        {
            //Réinitialise le formulaire
            dtmpLoandate.Value = DateTime.Now;
            dtmpBackdate.Value = DateTime.Now;
            cmboxBook.Text = "";
            cmboxClient.Text = "";

            // Attribue les bonne valeurs aux datetimepickers.
            dtmpLoandate.Value = Convert.ToDateTime(Controller.GetcurrentLoan()[1]);
            dtmpBackdate.Value = Convert.ToDateTime(Controller.GetcurrentLoan()[2]);

            // Rend unitulisable le datetimepicker
            dtmpLoandate.Enabled = false;

            // Remplie les champs texte avec les bonnes information
            cmboxClient.Text = $"{Controller.GetcurrentLoan()[7]} {Controller.GetcurrentLoan()[6]}";
            cmboxBook.Text = $"{Controller.GetcurrentLoan()[5]}";

            // Récupère les données auteur
            Controller.SetclientData();

            // Récupère les livre empruntable
            Controller.SetbookBorrowabledata();

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
        private void btnUpdateloan_Click(object sender, EventArgs e)
        {
            string idClient = "";
            string idBook = "";

            // vérifie que les deux champs sont vides
            if (cmboxBook.Text == string.Empty || cmboxClient.Text == string.Empty)
            {
                MessageBox.Show("L'un des champs est vide !"); // Message pour non respect des regex
            }
            //Vérifie que la date retour n'est pas plus peit que la date d'emprunt
            else if (dtmpBackdate.Value < dtmpLoandate.Value)
            {
                MessageBox.Show("La date de retour ne peut pas être avant la date d'emprunt");
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

                // Vérifie si le client est le même
                if (cmboxClient.Text == $"{Controller.GetcurrentLoan()[7]} {Controller.GetcurrentLoan()[6]}")
                {
                    // Charge la valeur de la clé dans "idClient"
                    idClient = Controller.GetcurrentLoan()[3];
                }
                // Vérifie si le client est le même
                if (cmboxBook.Text == $"{Controller.GetcurrentLoan()[5]}")
                {
                    // Charge la valeur de la clé dans "idBook"
                    idBook = Controller.GetcurrentLoan()[4];
                }

                DateTime dateTime = dtmpBackdate.Value.Date;

                // Affiche un message d'avertissement et récupère la réponse de l'utilisateur
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifîer cet emprunt ?", "Attention, Modification", MessageBoxButtons.YesNo);

                // Vérifie si l'utilisateur a cliqué sur "Yes"
                if (result == DialogResult.Yes)
                {
                    // Créer un nouvel emprunt avec les information nécessaire
                    Controller.Updateloan(Controller.GetcurrentLoan()[0], dateTime.ToString("yyyy.MM.dd"), idClient, idBook);

                    Controller.changeView("Viewloan", FindForm());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteloan_Click(object sender, EventArgs e)
        {
            // Affiche un message d'avertissement et récupère la réponse de l'utilisateur
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir retourner cet emprunt ?", "Attention, Retour", MessageBoxButtons.YesNo);

            // Vérifie si l'utilisateur a cliqué sur "Yes"
            if (result == DialogResult.Yes)
            {
                // Appelle la méthode dans le contrôleur pour supprimer le livre.
                Controller.Deleteloan();

                // Affiche la vue client  
                Controller.changeView("Viewloan", FindForm());
            }
        }
    }
}
