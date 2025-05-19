using LitShelf.Views;

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

        // Variables globales pour la pagination
        private const int _elementBypage = 10; // Nombre total d’éléments par page
        private const int _columns = 2; // Nombres de colonnes
        private const int _spaceX = 210, _spaceY = 50; // Espacement des boutons

        private int _currentPage = 0;
        private int _clientsBypage = 10;
        private int _authorsBypage = 10;


        private string[,] _clients; // Stocke les clients
        private string[,] _authors; // Stocke les auteurs
        private string[,] _books; // Stocke les livres
        private string[,] _loans; // Stocke les emprunts

        
        private string[] _currentClient = new string[3]; // Stocke le client sélectionné
        private string[] _currentAuthor = new string[3]; //Stocke le auteur sélectionné
        private string[] _currentBook = new string[4]; // Stocke le livres sélectionné



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
        /// <param name="nameview">Nom de la vue</param>
        /// <param name="form">Formulaire en cours d'utilisation</param>
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



        /// <summary>
        /// Charge les données clients à partir du modèle et les stocke dans le tableau local `_clients`.
        /// </summary>
        public void SetclientData()
        {
            _clients = _model.ReadclientData(); // Appelle la méthode du modèle pour récupérer les données client et les stocke dans une variable locale
        }

        /// <summary>
        /// Retourne les données clients chargées dans `_clients`.
        /// </summary>
        /// <returns>Un tableau 2D contenant les données clients.</returns>
        public string[,] GetclientData()
        {
            return _clients; // Fournit l’accès aux données client
        }



        /// <summary>
        /// Charge les données auteurs à partir du modèle et les stocke dans le tableau local "_authors".
        /// </summary>
        public void SetauthorData()
        {
            _authors = _model.ReadauthorData(); // Appelle la méthode du modèle pour récupérer les données auteurs et les stocke dans une variable locale.
        }

        /// <summary>
        /// Retourne les données auteurs chargées dans '_authors'.
        /// </summary>
        /// <returns>Un tableau 2D contenant les données auteurs.</returns>
        public string[,] GetauthorData()
        {
            return _authors; // Fournit l’accès aux données des auteurs.
        }



        /// <summary>
        /// Enregistre un nouvel auteur dans la base de données s'il n'existe pas déjà.
        /// </summary>
        /// <param name="firstname">Le prénom de l'auteur.</param>
        /// <param name="name">Le nom de l'auteur.</param>
        public void CreatenewAuthor(string firstname, string name)
        { 
            _model.CreatenewAuthor(firstname, name);
        }

        /// <summary>
        /// Enregistre un nouveau client dans la base de données s'il n'existe pas déjà.
        /// </summary>
        /// <param name="firstname">Le prénom du client.</param>
        /// <param name="name">Le nom du client.</param>
        public void CreatenewClient(string firstname, string name)
        {
            _model.CreatenewClient(firstname, name);
        }



        /// <summary>
        /// Modifie un client dans la base de données.
        /// </summary>
        /// <param name="firstname">Le prénom du client.</param>
        /// <param name="name">Le nom du client</param>
        public void Updateclient(string firstname, string name)
        {
            _model.Updateclient(_currentClient[0] ,firstname, name);
        }

        /// <summary>
        /// Modifie un auteur dans la base de données.
        /// </summary>
        /// <param name="firstname">Le prénom d'un auteur.</param>
        /// <param name="name">Le nom d'un auteur</param>
        public void Updateauthor(string firstname, string name)
        {
            _model.Updateauthor(_currentAuthor[0], firstname, name);
        }




        /// <summary>
        /// Supprime le client selectionné
        /// </summary>
        public void Deleteclient()
        {
            _model.Deleteclient(_currentClient[0]);
        }

        /// <summary>
        /// Supprime l'auteur selectionné
        /// </summary>
        public void Deleteauthor()
        {
            _model.Deleteauthor(_currentAuthor[0]);
        }

        ///// <summary>
        ///// Affiche une grille de boutons représentant les clients, correspondant à la page demandée.
        ///// Chaque bouton permet d'afficher les détails du client sélectionné.
        ///// </summary>
        ///// <param name="page">Le numéro de la page à afficher (index 0-based).</param>
        ///// <param name="form">Le formulaire actuel, qui sera masqué après sélection d'un client.</param>
        ///// <param name="pnl">Le panneau dans lequel les boutons seront affichés.</param>
        //public void ShowClientTable(int page, Form form, Panel pnl)
        //{
        //    pnl.Controls.Clear(); // Efface les anciens boutons du panneau

        //    int nbClients = _clients.GetLength(0); // Nombre total de clients
        //    int debut = page * _elementBypage; // Index de départ des éléments pour cette page
        //    int fin = Math.Min(debut + _elementBypage, nbClients); // Ne pas dépasser le nombre total de clients

        //    for (int i = debut; i < fin; i++)
        //    {
        //        string clientName = $"{_clients[i, 2]} {_clients[i, 1]}"; // Prénom + Nom

        //        if (_clients[i, 0] != null) // Vérifie que le client est valide (champ ID ou autre non null)
        //        {
        //            Button btn = new Button
        //            {
        //                Text = clientName,
        //                Size = new Size(200, 40)
        //            };

        //            // Position du bouton dans la grille
        //            int colonne = (i - debut) % _columns;
        //            int ligne = (i - debut) / _columns;
        //            btn.Location = new Point(10 + colonne * _spaceX, 10 + ligne * _spaceY);

        //            int index = i; // Nécessaire pour capturer l'index correct dans l'événement

        //            // Ajoute les actions sur clic du bouton : sélectionne le client, masque le formulaire, change de vue
        //            btn.Click += (s, args) => SetcurrentClient(_clients[index, 0], _clients[index, 1], _clients[index, 2]);
        //            btn.Click += (s, args) => form.Hide();
        //            btn.Click += (s, args) => changeView("ViewoneClient", form);

        //            pnl.Controls.Add(btn); // Ajoute le bouton au panneau
        //        }
        //    }
        //}



        ///// <summary>
        ///// Affiche un tableau de boutons représentant les auteurs sur une page donnée.
        ///// Chaque bouton correspond à un auteur et permet d’afficher ses détails lors d’un clic.
        ///// </summary>
        ///// <param name="page">Le numéro de la page actuelle à afficher.</param>
        ///// <param name="form">Le formulaire actif, qui sera masqué après le clic sur un auteur.</param>
        ///// <param name="pnl">Le panneau dans lequel les boutons des auteurs seront affichés.</param>
        //public void ShowAuthorTable(int page, Form form, Panel pnl)
        //{
        //    pnl.Controls.Clear(); // Efface les anciens contrôles du panneau (boutons d'auteurs précédents)

        //    int nbAuthor = _authors.GetLength(0); // Nombre total d’auteurs
        //    int debut = page * _elementBypage; // Index de départ en fonction de la pagination
        //    int fin = Math.Min(debut + _elementBypage, nbAuthor); // Index de fin (ne dépasse pas le total)

        //    for (int i = debut; i < fin; i++)
        //    {
        //        string authorName = $"{_authors[i, 2]} {_authors[i, 1]}"; // Prénom + Nom

        //        if (_clients[i, 0] != null) // Vérifie que l'auteur est lié à un client (ou existe ?)
        //        {
        //            Button btn = new Button
        //            {
        //                Text = authorName,
        //                Size = new Size(200, 40)
        //            };

        //            // Calcul de la position du bouton dans la grille
        //            int colonne = (i - debut) % _columns;
        //            int ligne = (i - debut) / _columns;
        //            btn.Location = new Point(10 + colonne * _spaceX, 10 + ligne * _spaceY);

        //            int index = i; // Capture de l'index dans la boucle pour l'utiliser dans les événements

        //            // Événements au clic : sélectionne l’auteur, cache le formulaire et change la vue
        //            btn.Click += (s, args) => SetcurrentAuthor(_authors[index, 0], _authors[index, 1], _authors[index, 2]);
        //            btn.Click += (s, args) => form.Hide();
        //            btn.Click += (s, args) => changeView("ViewoneAuthor", form);

        //            pnl.Controls.Add(btn); // Ajoute le bouton au panneau
        //        }
        //    }
        //}



        /// <summary>
        /// Affiche dynamiquement une grille de boutons représentant des entités clients et auteurs.
        /// </summary>
        /// <param name="data">Matrice 2D contenant les données (id, nom, prénom...)</param>
        /// <param name="page">Numéro de la page à afficher.</param>
        /// <param name="form">Formulaire actuel (sera masqué au clic).</param>
        /// <param name="pnl">Panneau de destination pour les boutons.</param>
        /// <param name="onClick">Action à exécuter lors du clic sur un bouton.</param>
        private void ShowEntityTable(string[,] data, int page, Form form, Panel pnl, Action<int> onClick)
        {
            // Nettoie le panel pour retirer tous les boutons précédemment affichés
            pnl.Controls.Clear();

            int total = data.GetLength(0); // Nombre total d'éléments à afficher (lignes du tableau `data`)
            int start = page * _elementBypage; // Index de départ pour la page actuelle
            int end = Math.Min(start + _elementBypage, total); // Index de fin (ne pas dépasser le total d'éléments)

            // Boucle sur chaque élément de la page actuelle
            for (int i = start; i < end; i++)
            {
                if (data[i, 0] != null) // Vérifie que la ligne contient bien des données (évite les entrées vides)
                {
                    // Construit le nom affiché : Prénom (colonne 2) + Nom (colonne 1)
                    string displayName = $"{data[i, 2]} {data[i, 1]}";

                    // Crée un nouveau bouton avec le nom de l'élément
                    Button btn = new Button
                    {
                        Text = displayName,
                        Size = new Size(200, 40)
                    };

                    // Calcule la position du bouton dans la grille (colonnes/espacement)
                    int col = (i - start) % _columns;
                    int row = (i - start) / _columns;
                    btn.Location = new Point(10 + col * _spaceX, 10 + row * _spaceY);

                    int index = i; // Capture l’index actuel pour l’utiliser dans le gestionnaire d’événements

                    // Attache un gestionnaire d’événement : Montre la fiche client
                    btn.Click += (s, args) => onClick(index);

                    // Cache le formulaire actuel une fois le bouton cliqué 
                    btn.Click += (s, args) => form.Hide();

                    // Ajoute le bouton au panel
                    pnl.Controls.Add(btn);
                }
            }

        }



        /// <summary>
        /// Afficahge des clients.
        /// </summary>
        /// <param name="page">Numéro de la page à afficher.</param>
        /// <param name="form">Formulaire actuel.</param>
        /// <param name="pnl">Panneau de destination pour les boutons</param>
        public void ShowClientTable(int page, Form form, Panel pnl)
        {
            ShowEntityTable(_clients, page, form, pnl, index =>
            {
                SetcurrentClient(_clients[index, 0], _clients[index, 1], _clients[index, 2]);
                changeView("ViewoneClient", form);
            });
        }

        /// <summary>
        /// Afficahge des clients. 
        /// </summary>
        /// <param name="page">Numéro de la page à afficher.</param>
        /// <param name="form">Formulaire actuel.</param>
        /// <param name="pnl">Panneau de destination pour les boutons</param>
        public void ShowAuthorTable(int page, Form form, Panel pnl)
        {
            ShowEntityTable(_authors, page, form, pnl, index =>
            {
                SetcurrentAuthor(_authors[index, 0], _authors[index, 1], _authors[index, 2]);
                changeView("ViewoneAuthor", form);
            });
        }



        /// <summary>
        /// Retourne le numéro actuel de la page en cours d'affichage.
        /// </summary>
        /// <returns>Le numéro de la page actuelle.</returns>
        public int GetNumberOfPage()
        {
            return _currentPage;
        }

        /// <summary>
        /// Réinitialise la page actuelle à 0
        /// </summary>
        public void Resetnumberofpage()
        {
            _currentPage = 0;
        }



        /// <summary>
        /// Retourne le nombre de clients affichés par page.
        /// </summary>
        /// <returns>Le nombre de clients par page.</returns>
        public int GetNumberOfClientsByPage()
        {
            return _clientsBypage;
        }

        /// <summary>
        /// Retourne le nombre d'auteurs affichés par page.
        /// </summary>
        /// <returns>Le nombre d'auteurs par page.</returns>
        public int GetNumberOfAuthorsByPage()
        {
            return _authorsBypage;
        }



        /// <summary>
        /// Incrémente le numéro de la page actuelle.
        /// </summary>
        public void IncrementPageNumber()
        {
            _currentPage++;
        }

        /// <summary>
        /// Décrémente le numéro de la page actuelle.
        /// </summary>
        public void DecrementPageNumber()
        {
            _currentPage--;
        }



        /// <summary>
        /// Définit les informations de l'auteur actuellement sélectionné.
        /// </summary>
        /// <param name="currrentAuthorindex">Identifiant ou index de l'auteur.</param>
        /// <param name="currrentAuthorname">Nom de famille de l'auteur.</param>
        /// <param name="currrentArticlefirstname">Prénom de l'auteur lié à l'article.</param>
        public void SetcurrentAuthor(string currrentAuthorindex, string currrentAuthorname, string currrentArticlefirstname)
        {
            _currentAuthor[0] = currrentAuthorindex;
            _currentAuthor[1] = currrentAuthorname;
            _currentAuthor[2] = currrentArticlefirstname;
        }

        /// <summary>
        /// Définit les informations du client actuellement sélectionné.
        /// </summary>
        /// <param name="currrentClientindex">Identifiant ou index du client.</param>
        /// <param name="currrentClientname">Nom de famille du client.</param>
        /// <param name="currrentClientfirstname">Prénom du client.</param>
        public void SetcurrentClient(string currrentClientindex, string currrentClientname, string currrentClientfirstname)
        {
            _currentClient[0] = currrentClientindex;
            _currentClient[1] = currrentClientname;
            _currentClient[2] = currrentClientfirstname;
        }


        /// <summary>
        /// Retourne les informations du client sélectionné
        /// </summary>
        /// <returns>Tableau de string des informations client</returns>
        public string[] GetcurrentClient()
        {
            return _currentClient;
        }

        /// <summary>
        /// Retourne les informations du client sélectionné
        /// </summary>
        /// <returns>Tableau de string des informations client</returns>
        public string[] GetcurrentAuthor()
        {
            return _currentAuthor;
        }

    }
}
