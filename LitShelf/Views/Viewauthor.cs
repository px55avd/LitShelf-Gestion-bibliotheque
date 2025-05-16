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
    public partial class Viewauthor : Form
    {
        public Viewauthor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Logique des boutons de navigation.
        /// </summary>
        private void Btnnavigationlogic()
        {
            // Récupère le numéro page 
            int cuurentPage = Controller.GetNumberOfPage();

            if (cuurentPage == 0)
            {
                btnMinus.Hide(); // Cache le bouton moins.
            }
            else
            {
                btnMinus.Show(); // Affiche le bouton moins.
            }

            // Vérifie si le nombre de clients est plus petit que le nombre total de clients affichables.
            if ((cuurentPage + 1) * Controller.GetNumberOfAuthorsByPage() > Controller.GetauthorData().GetLength(0))
            {
                btnUp.Hide(); // Cache le bouton moins.
            }
            else
            {
                btnUp.Show(); // Affiche le bouton plus.
            }
        }

        /// <summary>
        /// Controller associé à la vue.
        /// </summary>
        public Controller.Controller Controller { get; set; }

        private void btnBookmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewbook", FindForm());
        }

        private void btnLoanmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewloan", FindForm());
        }

        private void btnClientmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewclient", FindForm());
        }

        private void btnNewauthor_Click(object sender, EventArgs e)
        {
            Controller.changeView("ViewnewAuthor", FindForm());
        }

        /// <summary>
        /// Événement déclenché lorsque le formulaire "Viewauthor" devient actif (fenêtre ouverte ou remise au premier plan).
        /// Réinitialise la pagination et met à jour l'affichage des auteur.
        /// </summary>
        /// <param name="sender">Objet source de l'événement (le formulaire).</param>
        /// <param name="e">Arguments vides.</param>
        private void Viewauthor_Activated(object sender, EventArgs e)
        {
            // Charge les données des clients depuis le modèle via le contrôleur
            Controller.SetauthorData();

            // Met à jour la logique de navigation (activer/désactiver les boutons selon le nombre de pages)
            Btnnavigationlogic();

            // Réinitialise le numéro de page à 0 dans le contrôleur (pour revenir à la première page)
            Controller.Resetnumberofpage();

            // Affiche les clients de la page 0 dans le panneau prévu, en utilisant le formulaire actuel
            Controller.ShowAuthorTable(
                Controller.GetNumberOfPage(),  // Doit être 0 juste après la réinitialisation
                FindForm(),                    // Référence au formulaire courant
                pnlAuthorbutton                // Panel où les boutons clients sont affichés
            );
        }

        /// <summary>
        /// Gère le clic sur le bouton de navigation "précédent" (btnMinus).
        /// Décrémente le numéro de page si possible, met à jour l'affichage et les boutons.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
        private void btnMinus_Click(object sender, EventArgs e)
        {
            // Récupère le numéro page 
            int cuurentPage = Controller.GetNumberOfPage();

            // Vérifie que la page actuelle est supérieure à 0 (évite de descendre en-dessous de la première page)
            if (cuurentPage > 0)
            {
                // Décrémente le numéro de page actuel dans le contrôleur
                Controller.DecrementPageNumber();

                // Récupère le nouveau numéro de page
                int newPage = Controller.GetNumberOfPage();

                // Met à jour le texte du label pour afficher le nouveau numéro de page (+1 car indexé à 0)
                lblNumberpages.Text = Convert.ToString(newPage + 1);

                // Met à jour l'affichage des clients pour la nouvelle page courante
                Controller.ShowAuthorTable(
                    newPage,                        // Numéro de page à afficher
                    FindForm(),                    // formulaire courant
                    pnlAuthorbutton                // Panneau où afficher les boutons client
                );
            }

            // Met à jour l’état des boutons de navigation.
            Btnnavigationlogic();
        }

        /// <summary>
        /// Gère le clic sur le bouton de navigation "suivant" (btnUp).
        /// Incrémente le numéro de page si possible, met à jour l'affichage et les boutons.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            // Récupère le numéro page 
            int cuurentPage = Controller.GetNumberOfPage();

            // Vérifie si le nombre de clients est plus petit que le nombre total de clients affichables.
            if ((cuurentPage + 1) * Controller.GetNumberOfAuthorsByPage() < Controller.GetauthorData().GetLength(0))
            {
                // Décrémente le numéro de page actuel dans le contrôleur
                Controller.IncrementPageNumber();

                // Récupère le nouveau numéro de page
                int newPage = Controller.GetNumberOfPage();

                // Met à jour le texte du label pour afficher le nouveau numéro de page (+1 car indexé à 0)
                lblNumberpages.Text = Convert.ToString(newPage + 1);

                // Met à jour l'affichage des clients pour la nouvelle page courante
                Controller.ShowAuthorTable(
                    newPage,                        // Numéro de page à afficher
                    FindForm(),                    // formulaire courant
                    pnlAuthorbutton                // Panneau où afficher les boutons client
                );
            }

            // Met à jour l’état des boutons de navigation.
            Btnnavigationlogic();
        }

    }
}
