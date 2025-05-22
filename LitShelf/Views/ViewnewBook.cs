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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
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
        private void btnClientmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewclient", FindForm());
        }

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

                            Controller.changeView("Viewbook", FindForm());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewnewBook_Activated(object sender, EventArgs e)
        {
            //Récupère les données auteur
            Controller.SetauthorData();

            // Nettoye le combobox
            cmboxAuthor.Items.Clear();

            // Attribue les auteurs au combobox
            for (int i = 0; i < Controller.GetauthorData().GetLength(0); i++)
            {
                cmboxAuthor.Items.Add(Controller.GetauthorData()[i, 2] + " " + Controller.GetauthorData()[i, 1]);
            }
        }
    }
}
