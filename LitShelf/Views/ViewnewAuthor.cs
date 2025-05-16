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
    public partial class ViewnewAuthor : Form
    {
        public ViewnewAuthor()
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
        private void btnValidnewAuthor_Click(object sender, EventArgs e)
        {
            // vérifie que les deux champs sont vides
            if (txtboxFirstname.Text == string.Empty && txtboxName.Text == string.Empty)
            {
                MessageBox.Show("Les champs sont vides !!!"); // Message pour non respect des regex
            }

            // vérifie que l'un des deux champs est vides
            if (txtboxFirstname.Text == string.Empty && txtboxName.Text != string.Empty)
            {
                Controller.CreatenewAuthor(null, txtboxName.Text); // Créer un nouvel auteur sans prénom
                Controller.changeView("Viewauthor", FindForm());
            }

            // vérifie que l'un des deux champs est vides
            if (txtboxFirstname.Text != string.Empty && txtboxName.Text == string.Empty)
            {
                Controller.CreatenewAuthor(txtboxFirstname.Text, null); // Créer un nouvel auteur sans nom
                Controller.changeView("Viewauthor", FindForm());
            }

            // vérifie que lees deux champs sont remplies
            if (txtboxFirstname.Text != string.Empty && txtboxName.Text != string.Empty)
            {
                Controller.CreatenewAuthor(txtboxFirstname.Text, txtboxName.Text); // Créer un nouvel auteur avec nom et prénom
                Controller.changeView("Viewauthor", FindForm());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewnewAuthor_Activated(object sender, EventArgs e)
        {
            // Réinitialise le label titre et les champs textes.
            txtboxFirstname.Text = "";
            txtboxName.Text = "";
        }
    }
}
