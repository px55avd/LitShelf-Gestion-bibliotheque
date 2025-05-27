namespace LitShelf
{
    public partial class Viewbook : Form
    {
        public Viewbook()
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
            if ((cuurentPage + 1) * Controller.GetNumberOfBooksByPage() > Controller.GetbookData().GetLength(0))
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

        /// <summary>
        /// Gère l'événement de clic sur le bouton "Auteur".
        /// Lorsque l'utilisateur clique sur ce bouton, la vue actuelle est remplacée
        /// par la vue "Viewauthor" en appelant la méthode `changeView` du contrôleur.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement (le bouton cliqué).</param>
        /// <param name="e">Les arguments de l'événement de clic.</param>
        private void btnAuthormenu_Click(object sender, EventArgs e)
        {
            Controller.Changeview("Viewauthor", FindForm());
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
            Controller.Changeview("Viewloan", FindForm());
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
            Controller.Changeview("Viewclient", FindForm());
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton "Nouveau livre".
        /// Lorsque l'utilisateur clique sur ce bouton, la vue actuelle est remplacée
        /// par la vue "ViewnewBook" en appelant la méthode `changeView` du contrôleur.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement (le bouton cliqué).</param>
        /// <param name="e">Les arguments de l'événement de clic.</param>
        private void btnNewbook_Click(object sender, EventArgs e)
        {
            Controller.Changeview("ViewnewBook", FindForm());
        }

        /// <summary>
        /// Événement déclenché lorsque le formulaire `Viewbook` devient actif (fenêtre ouverte ou remise au premier plan).
        /// Réinitialise la pagination et met à jour l'affichage des livres.
        /// </summary>
        /// <param name="sender">Objet source de l'événement (le formulaire).</param>
        /// <param name="e">Arguments vides.</param>
        private void Viewbook_Activated(object sender, EventArgs e)
        {
            // Charge les données des clients depuis le modèle via le contrôleur
            Controller.SetbookData();


            // Réinitialise le numéro de page à 0 dans le contrôleur (pour revenir à la première page)
            Controller.Resetnumberofpage();

            // Met à jour la logique de navigation (activer/désactiver les boutons selon le nombre de pages)
            Btnnavigationlogic();


            // Affiche le numéro de page + 1
            lblNumberpages.Text = Convert.ToString(Controller.GetNumberOfPage() + 1);

            // Affiche les clients de la page 0 dans le panneau prévu, en utilisant le formulaire actuel
            Controller.ShowBookTable(
                Controller.GetNumberOfPage(),  // Doit être 0 juste après la réinitialisation
                FindForm(),                    // Référence au formulaire courant
                pnlBookbutton                // Panel où les boutons clients sont affichés
            );

            // Récupère tous les auteur
            Controller.SetauthorData();

            //Nettoye le combobox
            cmboxAuthor.Items.Clear();

            //Afffiche le texte
            cmboxAuthor.Text = "Toutes les auteurs";

            // Ajout en item
            cmboxAuthor.Items.Add("Toutes les auteurs");

            //Empeche la saisie de texte
            cmboxAuthor.DropDownStyle = ComboBoxStyle.DropDownList;

            //Intergre tous les auteurs en items du combobox
            for (int i = 0; i < Controller.GetauthorData().GetLength(0); i++)
            {
                cmboxAuthor.Items.Add(Controller.GetauthorData()[i, 2] + " " + Controller.GetauthorData()[i, 1]);
            }

            cmboxAuthor.SelectedIndex = 0; // Selectionne le premier index 
            cmboxAuthor.DropDownHeight = 200; // Hauteur en pixels

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
                Controller.ShowBookTable(
                    newPage,                        // Numéro de page à afficher
                    FindForm(),                    // formulaire courant
                    pnlBookbutton                // Panneau où afficher les boutons client
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
            if ((cuurentPage + 1) * Controller.GetNumberOfBooksByPage() < Controller.GetbookData().GetLength(0))
            {
                // Décrémente le numéro de page actuel dans le contrôleur
                Controller.IncrementPageNumber();

                // Récupère le nouveau numéro de page
                int newPage = Controller.GetNumberOfPage();

                // Met à jour le texte du label pour afficher le nouveau numéro de page (+1 car indexé à 0)
                lblNumberpages.Text = Convert.ToString(newPage + 1);

                // Met à jour l'affichage des clients pour la nouvelle page courante
                Controller.ShowBookTable(
                    newPage,                        // Numéro de page à afficher
                    FindForm(),                    // formulaire courant
                    pnlBookbutton                // Panneau où afficher les boutons client
                );
            }

            // Met à jour l’état des boutons de navigation.
            Btnnavigationlogic();
        }

        /// <summary>
        /// Gère le clic sur le bouton de recherche.
        /// Filtre les livres par auteur.
        /// </summary>
        /// <param name="sender">Objet source de l’événement (le bouton lui-même).</param>
        /// <param name="e">Arguments de l’événement (clique souris ici).</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Vérifie que le champs selectionné ne soit pas "Tous les auteurs"
            if (cmboxAuthor.Text != "Toutes les auteurs")
            {
                //Parcours les auteurs
                for (int i = 0; i < Controller.GetauthorData().GetLength(0); i++)
                {
                    //Si le nom et prénom de l'auteur sont correct
                    if (Controller.GetauthorData()[i, 2] + " " + Controller.GetauthorData()[i, 1] == cmboxAuthor.Text)
                    {
                        //Appelle la méthode pour filtrer les données des livre.
                        Controller.SetbookDataFilter(Controller.GetauthorData()[i, 0]);
                        break;
                    }
                }
            }

            //Vérifie que le champs 
            if (cmboxAuthor.Text == "Toutes les auteurs")
            {
                //Appelle tous les livre
                Controller.SetbookData();
            }

            //Réinitialise le numéro de page
            Controller.Resetnumberofpage();

            // Ajout dans le label
            lblNumberpages.Text = Convert.ToString(Controller.GetNumberOfPage() +1);

            //Affichage de la liste de livres filtrés ou non 
            Controller.ShowBookTable(Controller.GetNumberOfPage(), this, pnlBookbutton);
        }
    }
}