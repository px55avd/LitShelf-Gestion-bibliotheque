using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitShelf.Views;
using LitShelf.Model;

namespace LitShelf.Controller
{
    public class Controller
    {
        // Déclarations des différentes vues utilisées par le contrôleur.
        private Viewbook _viewbook;
        private Viewauthor _viewauthor;
        private Viewloan _viewloan;
        private Viewclient _viewclient;
        private ViewoneAuthor _viewoneauthor;
        private ViewoneBook _viewonebook;
        private ViewoneClient _viewoneclient;
        private ViewoneLoan _viewoneloan;
        private ViewnewAuthor _viewnewauthor;
        private ViewnewBook _viewnewbook;
        private ViewnewClient _viewnewclient;
        private ViewnewLoan _viewnewloan;
        
        // Référence au modèle utilisé par le contrôleur.
        private Model.Model _model;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewbook"></param>
        /// <param name="model"></param>
        /// <param name="viewauthor"></param>
        /// <param name="viewloan"></param>
        /// <param name="viewclient"></param>
        /// <param name="viewoneauthor"></param>
        /// <param name="viewonebook"></param>
        /// <param name="viewoneclient"></param>
        /// <param name="viewoneloan"></param>
        /// <param name="viewnewauthor"></param>
        /// <param name="viewnewbook"></param>
        /// <param name="viewnewclient"></param>
        /// <param name="viewnewloan"></param>
        public Controller(Viewbook viewbook, Model.Model model, Viewauthor viewauthor, Viewloan viewloan, Viewclient viewclient, ViewoneAuthor viewoneauthor, ViewoneBook viewonebook,
            ViewoneClient viewoneclient, ViewoneLoan viewoneloan, ViewnewAuthor viewnewauthor, ViewnewBook viewnewbook, ViewnewClient viewnewclient, ViewnewLoan viewnewloan)
        {
            // Initialisation des références aux vues et au modèle.
            _model = model;
            _model.Controller = this;

            // Vue Livre
            _viewbook = viewbook;
            _viewbook.Controller = this;

            //Vue Auteur
            _viewauthor = viewauthor;
            _viewauthor.Controller = this;

            // Vue Emprunt
            _viewloan = viewloan;
            _viewloan.Controller = this;

            // Vue Client 
            _viewclient = viewclient;
            _viewclient.Controller = this;

            // Vue isolée pour chaque élément
            _viewoneauthor = viewoneauthor;
            _viewoneauthor.Controller = this;

            _viewonebook = viewonebook;
            _viewonebook.Controller = this;

            _viewoneclient = viewoneclient;
            _viewoneclient.Controller = this;

            _viewoneloan = viewoneloan;
            _viewoneloan.Controller = this;
            
            // Vues spécifique pour les nouveaux éléments
            _viewnewauthor = viewnewauthor;
            _viewnewauthor.Controller = this;

            _viewnewbook = viewnewbook;
            _viewnewbook.Controller = this;

            _viewnewclient = viewnewclient;
            _viewnewclient.Controller = this;

            _viewnewloan = viewnewloan;
            _viewnewloan.Controller = this;

        }


        /// <summary>
        /// Méthode pour changer de vue selon 
        /// </summary>
        /// <param name="nameview"></param>
        /// <param name="form"></param>
        public void changeView(string nameview, Form form)
        {
            if (nameview == "Viewauthor")
            {
                form.Hide();
                _viewauthor.Show();
            }
            else if (nameview == "Viewbook")
            {
                form.Hide();
                _viewbook.Show();
            }
            else if (nameview == "Viewclient")
            {
                form.Hide();
                _viewclient.Show();
            }
            else if (nameview == "Viewloan")
            {
                form.Hide();
                _viewloan.Show();
            }
            else if (nameview == "ViewnewAuthor")
            {
                form.Hide();
                _viewnewauthor.Show();
            }
            else if (nameview == "ViewnewBook")
            {
                form.Hide();
                _viewnewbook.Show();
            }
            else if (nameview == "ViewnewClient")
            {
                form.Hide();
                _viewnewclient.Show();
            }
            else if (nameview == "ViewnewLoan")
            {
                form.Hide();
                _viewnewloan.Show();
            }
            else if (nameview == "ViewoneAuthor")
            {
                form.Hide();
                _viewoneauthor.Show();
            }
            else if (nameview == "ViewoneBook")
            {
                form.Hide();
                _viewonebook.Show();
            }
            else if (nameview == "ViewoneClient")
            {
                form.Hide();
                _viewoneclient.Show();
            }
            else if (nameview == "ViewoneLoan")
            {
                form.Hide();
                _viewoneloan.Show();
            }
        }
    }
}
