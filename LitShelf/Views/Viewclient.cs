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
    public partial class Viewclient : Form
    {
        public Viewclient()
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
        private void btnNewclient_Click(object sender, EventArgs e)
        {
            Controller.changeView("ViewnewClient", FindForm());
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
        private void Viewclient_Load(object sender, EventArgs e)
        {
            Controller.SetclientData();
        }

        private void Viewclient_Activated(object sender, EventArgs e)
        {
            Controller.Resetnumberofpage();

            Controller.ShowClientTable(Controller.GetNumberOfPage(), FindForm(), pnlClientbutton);



            if ((Controller.GetNumberOfPage() + 1) * Controller.GetNumberOfClientsByPage() > Controller.GetclientData().GetLength(0))
            {
                btnUp.Hide();
            }
            else
            {
                btnUp.Show();
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (Controller.GetNumberOfPage() > 0)
            {
                Controller.DecrementPageNumber();
                lblNumberpages.Text = Convert.ToString(Controller.GetNumberOfPage() + 1);
                Controller.ShowClientTable(Controller.GetNumberOfPage(), FindForm(), pnlClientbutton);
            }

            if (Controller.GetNumberOfPage() == 0)
            {
                btnMinus.Hide();
            }
            else
            {
                btnMinus.Show();
            }
            if ((Controller.GetNumberOfPage() + 1) * Controller.GetNumberOfClientsByPage() > Controller.GetclientData().GetLength(0))
            {
                btnUp.Hide();
            }
            else
            {
                btnUp.Show();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if ((Controller.GetNumberOfPage()+1) * Controller.GetNumberOfClientsByPage() < Controller.GetclientData().GetLength(0))
            {
                Controller.IncrementPageNumber();
                btnMinus.Show();
                lblNumberpages.Text = Convert.ToString(Controller.GetNumberOfPage() + 1);
                Controller.ShowClientTable(Controller.GetNumberOfPage(), FindForm(), pnlClientbutton);
            }

            if (Controller.GetNumberOfPage() == 0)
            {
                btnMinus.Hide();
            }
            else
            {
                btnMinus.Show();
            }
            if ((Controller.GetNumberOfPage() + 1) * Controller.GetNumberOfClientsByPage() > Controller.GetclientData().GetLength(0))
            {
                btnUp.Hide();
            }
            else
            {
                btnUp.Show();
            }
        }
    }
}
