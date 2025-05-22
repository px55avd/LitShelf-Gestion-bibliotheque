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
            // R�cup�re le num�ro page 
            int cuurentPage = Controller.GetNumberOfPage();

            if (cuurentPage == 0)
            {
                btnMinus.Hide(); // Cache le bouton moins.
            }
            else
            {
                btnMinus.Show(); // Affiche le bouton moins.
            }

            // V�rifie si le nombre de clients est plus petit que le nombre total de clients affichables.
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
        /// Controller associ� � la vue.
        /// </summary>
        public Controller.Controller Controller { get; set; }

        private void btnAuthormenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewauthor", FindForm());
        }

        private void btnLoanmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewloan", FindForm());
        }

        private void btnClientmenu_Click(object sender, EventArgs e)
        {
            Controller.changeView("Viewclient", FindForm());
        }

        private void btnNewbook_Click(object sender, EventArgs e)
        {
            Controller.changeView("ViewnewBook", FindForm());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Viewbook_Activated(object sender, EventArgs e)
        {
            // Charge les donn�es des clients depuis le mod�le via le contr�leur
            Controller.SetbookData();


            // R�initialise le num�ro de page � 0 dans le contr�leur (pour revenir � la premi�re page)
            Controller.Resetnumberofpage();

            // Met � jour la logique de navigation (activer/d�sactiver les boutons selon le nombre de pages)
            Btnnavigationlogic();


            // Affiche le num�ro de page + 1
            lblNumberpages.Text = Convert.ToString(Controller.GetNumberOfPage() + 1);

            // Affiche les clients de la page 0 dans le panneau pr�vu, en utilisant le formulaire actuel
            Controller.ShowBookTable(
                Controller.GetNumberOfPage(),  // Doit �tre 0 juste apr�s la r�initialisation
                FindForm(),                    // R�f�rence au formulaire courant
                pnlBookbutton                // Panel o� les boutons clients sont affich�s
            );

            Controller.SetauthorData();

            cmboxAuthor.Items.Clear();

            cmboxAuthor.Text = "Toutes les auteurs";


            for (int i = 0; i < Controller.GetauthorData().GetLength(0); i++)
            {
                cmboxAuthor.Items.Add(Controller.GetauthorData()[i, 2] + " " + Controller.GetauthorData()[i, 1]);
            }

            cmboxAuthor.Items.Add("Toutes les auteurs");

        }

        /// <summary>
        /// G�re le clic sur le bouton de navigation "pr�c�dent" (btnMinus).
        /// D�cr�mente le num�ro de page si possible, met � jour l'affichage et les boutons.
        /// </summary>
        /// <param name="sender">Objet source de l��v�nement (le bouton lui-m�me).</param>
        /// <param name="e">Arguments de l��v�nement (clique souris ici).</param>
        private void btnMinus_Click(object sender, EventArgs e)
        {
            // R�cup�re le num�ro page 
            int cuurentPage = Controller.GetNumberOfPage();

            // V�rifie que la page actuelle est sup�rieure � 0 (�vite de descendre en-dessous de la premi�re page)
            if (cuurentPage > 0)
            {
                // D�cr�mente le num�ro de page actuel dans le contr�leur
                Controller.DecrementPageNumber();

                // R�cup�re le nouveau num�ro de page
                int newPage = Controller.GetNumberOfPage();

                // Met � jour le texte du label pour afficher le nouveau num�ro de page (+1 car index� � 0)
                lblNumberpages.Text = Convert.ToString(newPage + 1);

                // Met � jour l'affichage des clients pour la nouvelle page courante
                Controller.ShowBookTable(
                    newPage,                        // Num�ro de page � afficher
                    FindForm(),                    // formulaire courant
                    pnlBookbutton                // Panneau o� afficher les boutons client
                );
            }

            // Met � jour l��tat des boutons de navigation.
            Btnnavigationlogic();
        }

        /// <summary>
        /// G�re le clic sur le bouton de navigation "suivant" (btnUp).
        /// Incr�mente le num�ro de page si possible, met � jour l'affichage et les boutons.
        /// </summary>
        /// <param name="sender">Objet source de l��v�nement (le bouton lui-m�me).</param>
        /// <param name="e">Arguments de l��v�nement (clique souris ici).</param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            // R�cup�re le num�ro page 
            int cuurentPage = Controller.GetNumberOfPage();

            // V�rifie si le nombre de clients est plus petit que le nombre total de clients affichables.
            if ((cuurentPage + 1) * Controller.GetNumberOfBooksByPage() < Controller.GetbookData().GetLength(0))
            {
                // D�cr�mente le num�ro de page actuel dans le contr�leur
                Controller.IncrementPageNumber();

                // R�cup�re le nouveau num�ro de page
                int newPage = Controller.GetNumberOfPage();

                // Met � jour le texte du label pour afficher le nouveau num�ro de page (+1 car index� � 0)
                lblNumberpages.Text = Convert.ToString(newPage + 1);

                // Met � jour l'affichage des clients pour la nouvelle page courante
                Controller.ShowBookTable(
                    newPage,                        // Num�ro de page � afficher
                    FindForm(),                    // formulaire courant
                    pnlBookbutton                // Panneau o� afficher les boutons client
                );
            }

            // Met � jour l��tat des boutons de navigation.
            Btnnavigationlogic();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //V�rifie que le champs selectionn� ne soit pas "Tous les auteurs"
            if (cmboxAuthor.Text != "Toutes les auteurs")
            {
                //Parcours les auteurs
                for (int i = 0; i < Controller.GetauthorData().GetLength(0); i++)
                {
                    //Si le nom et pr�nom de l'auteur sont correct
                    if (Controller.GetauthorData()[i, 2] + " " + Controller.GetauthorData()[i, 1] == cmboxAuthor.Text)
                    {
                        //Appelle la m�thode pour filtrer les donn�es des livre.
                        Controller.SetbookDataFilter(Controller.GetauthorData()[i, 0]);
                        break;
                    }
                }
            }

            //V�rifie que le champs 
            if (cmboxAuthor.Text == "Toutes les auteurs")
            {
                //Appelle tous les livre
                Controller.SetbookData();
            }

            //R�initialise le num�ro de page
            Controller.Resetnumberofpage();

            // Ajout dans le label
            lblNumberpages.Text = Convert.ToString(Controller.GetNumberOfPage() +1);

            //Affichage de la liste de livres filtr�s ou non 
            Controller.ShowBookTable(Controller.GetNumberOfPage(), this, pnlBookbutton);
        }
    }
}