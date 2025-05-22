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
        private int _booksBypage = 10;
        private int _loansBypage = 10;


        private string[,] _clients; // Stocke les clients
        private string[,] _authors; // Stocke les auteurs
        private string[,] _books; // Stocke les livres
        private string[,] _loans; // Stocke les emprunts
        private string[,] _booksBorrowable; // Stocke les livre empruntable


        private string[] _currentClient = new string[3]; // Stocke le client sélectionné
        private string[] _currentAuthor = new string[3]; //Stocke le auteur sélectionné
        private string[] _currentBook = new string[7]; // Stocke le livres sélectionné
        private string[] _currentLoan = new string[8]; // Strocke l'emprunt sélectioné



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
        /// Charge les données auteurs à partir du modèle et les stocke dans le tableau local "_authors".
        /// </summary>
        public void SetauthorData()
        {
            _authors = _model.ReadauthorData(); // Appelle la méthode du modèle pour récupérer les données auteurs et les stocke dans une variable locale.
        }

        /// <summary>
        /// Charge les données livres à partir du modèle et les stocke dans le tableau local "_books".
        /// </summary>
        public void SetbookData()
        {
            _books = _model.ReadbookData(); // Appelle la méthode du modèle pour récupérer les données auteurs et les stocke dans une variable locale.
        }

        /// <summary>
        /// Charge les données livres à partir du modèle et les stocke dans le tableau local "_loans".
        /// </summary>
        public void SetloanData()
        {
            _loans = _model.ReadloanData(); // Appelle la méthode du modèle pour récupérer les données emprunts et les stocke dans une variable locale.
        }



        /// <summary>
        /// Charge les données livres empruntable à partir du modèle et les stocke dans le tableau local "_booksBorrowable".
        /// </summary>
        public void SetbookBorrowabledata()
        {
            _booksBorrowable = _model.ReadbookDataBorrowable(); // Appelle la méthode du modèle pour récupérer les données emprunts et les stocke dans une variable locale.
        }



        /// <summary>
        /// Charge les données livres filtrés à partir du modèle et les stocke dans le tableau local "_books".
        /// </summary>
        /// <param name="idAuthor">Clé étrangère de l'auteur</param>
        public void SetbookDataFilter(string idAuthor)
        {
            _books = _model.ReadbookDataFiler(idAuthor); // Appelle la méthode du modèle pour récupérer les données livres filtrés et les stocke dans une variable locale.
        }

        /// <summary>
        /// Charge les données emprunts filtrés à partir du modèle et les stocke dans le tableau local "_loans".
        /// </summary>
        /// <param name="idClient">Clé étrangère du client</param>
        public void SetloanDataFiler(string idClient)
        {
            _loans = _model.ReadloanDataFiler(idClient); // Appelle la méthode du modèle pour récupérer les données emprunt filtrer et les stocke dans une variable locale.
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
        /// Retourne les données auteurs chargées dans '_authors'.
        /// </summary>
        /// <returns>Un tableau 2D contenant les données auteurs.</returns>
        public string[,] GetauthorData()
        {
            return _authors; // Fournit l’accès aux données des auteurs.
        }

        /// <summary>
        /// Retourne les données livres chargées dans "_books".
        /// </summary>
        /// <returns>Un tableau 2D contenant les données lives.</returns>
        public string[,] GetbookData()
        {
            return _books;
        }

        /// <summary>
        /// Retourne les données livres chargées dans "_loans".
        /// </summary>
        /// <returns>Un tableau 2D contenant les données lives.</returns>
        public string[,] GetloanData()
        {
            return _loans;
        }



        /// <summary>
        /// Retourne les données livres empruntables chargées dans "_booksBorrowable".
        /// </summary>
        /// <returns>Un tableau 2D contenant les données lives.</returns>
        public string[,] GetbookBorrowabledata()
        {
            return _booksBorrowable;
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
        /// Enregistre un nouveau liuvre dans la base de données.
        /// </summary>
        /// <param name="ISBN">N° ISBN du livre</param>
        /// <param name="title">Titre du livre</param>
        /// <param name="date">Date de publication du livre </param>
        /// <param name="quantity">Quantité du livre</param>
        /// <param name="id_auteur">Clé étranger de l'auteur</param>
        public void CreatenewBook(string ISBN, string title, string date, string quantity, int id_auteur)
        {
            _model.CreatenewBook(ISBN, title, date, quantity, id_auteur);
        }

        /// <summary>
        /// Enregistre un nouvel emprunt dans la base de données.
        /// </summary>
        /// <param name="idClient">La clé étangère du client.</param>
        /// <param name="idBook">La clé étangère de l'exemplaire</param>
        public void CreatenewLoan(string idClient, string idBook)
        {
            _model.CreatenewLoan(idClient, idBook);
        }



        /// <summary>
        /// Modifie un client dans la base de données.
        /// </summary>
        /// <param name="firstname">Le prénom du client.</param>
        /// <param name="name">Le nom du client</param>
        public void Updateclient(string firstname, string name)
        {
            _model.Updateclient(_currentClient[0], firstname, name);
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
        /// modifie un nouveau liuvre dans la base de données.
        /// </summary>
        /// <param name="ISBN">N° ISBN du livre</param>
        /// <param name="title">Titre du livre</param>
        /// <param name="date">Date de publication du livre </param>
        /// <param name="quantity">Quantité du livre</param>
        /// <param name="id_auteur">Clé étranger de l'auteur</param>
        public void Updatebook(string ISBN, string title, string date, string quantity, int id_auteur)
        {
            _model.Updatebook(ISBN, title, date, quantity, id_auteur);
        }

        /// <summary>
        /// Modifie un emprunt dans la base de données.
        /// </summary>
        /// <param name="idLoan">Clé primaire de l'emprunt</param>
        /// <param name="backDate">Date retour de l'emprunt</param>
        /// <param name="idClient">La clé étangère du client.</param>
        /// <param name="idBook">La clé étangère de l'exemplaire</param>
        public void Updateloan(string idLoan, string backDate, string idClient, string idBook)
        {
            _model.Updateloan(idLoan, backDate, idClient, idBook);
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

        /// <summary>
        /// Supprime le livre selectionné
        /// </summary>
        public void Deletebook()
        {
            _model.Deletebook(_currentBook[0]);
        }

        /// <summary>
        /// Supprime l'emprunt selectionné
        /// </summary>
        public void Deleteloan()
        {
            _model.Deleteloan(_currentLoan[0]);
        }



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
        /// Affiche une grille de boutons représentant les livres, correspondant à la page demandée.
        /// Chaque bouton permet d'afficher les détails du livre sélectionné.
        /// </summary>
        /// <param name="page">Le numéro de la page à afficher (index 0-based).</param>
        /// <param name="form">Le formulaire actuel, qui sera masqué après sélection d'un livre.</param>
        /// <param name="pnl">Le panneau dans lequel les boutons seront affichés.</param>
        public void ShowBookTable(int page, Form form, Panel pnl)
        {
            pnl.Controls.Clear(); // Efface les anciens boutons du panneau

            int nbBooks = _books.GetLength(0); // Nombre total de clients
            int debut = page * _elementBypage; // Index de départ des éléments pour cette page
            int fin = Math.Min(debut + _elementBypage, nbBooks); // Ne pas dépasser le nombre total de clients

            for (int i = debut; i < fin; i++)
            {
                string bookName = $"{_books[i, 5]} {_books[i, 6]} - {_books[i, 1]}"; // Prénom + Nom de l'auteur et titre du livre

                if (_books[i, 0] != null) // Vérifie que le client est valide (champ ID ou autre non null)
                {
                    Button btn = new Button
                    {
                        Text = bookName,
                        Size = new Size(200, 40)
                    };

                    // Position du bouton dans la grille
                    int colonne = (i - debut) % _columns;
                    int ligne = (i - debut) / _columns;
                    btn.Location = new Point(10 + colonne * _spaceX, 10 + ligne * _spaceY);

                    int index = i; // Nécessaire pour capturer l'index correct dans l'événement

                    // Ajoute les actions sur clic du bouton : sélectionne le client, masque le formulaire, change de vue
                    btn.Click += (s, args) => SetcurrentBook(_books[index, 0], _books[index, 1], _books[index, 2], _books[index, 3], _books[index, 4], _books[index, 5],
                        _books[index, 6]);
                    btn.Click += (s, args) => form.Hide();
                    btn.Click += (s, args) => changeView("ViewoneBook", form);

                    pnl.Controls.Add(btn); // Ajoute le bouton au panneau
                }
            }
        }

        /// <summary>
        /// Affiche une grille de boutons représentant les emprunts, correspondant à la page demandée.
        /// Chaque bouton permet d'afficher les détails de l'emprunt sélectionné.
        /// </summary>
        /// <param name="page">Le numéro de la page à afficher.</param>
        /// <param name="form">Le formulaire actuel, qui sera masqué après sélection d'un emrunt.</param>
        /// <param name="pnl">Le panneau dans lequel les boutons seront affichés.</param>
        public void ShowLoanTable(int page, Form form, Panel pnl)
        {
            pnl.Controls.Clear(); // Efface les anciens boutons du panneau

            int nbLoans = _loans.GetLength(0); // Nombre total de clients
            int debut = page * _elementBypage; // Index de départ des éléments pour cette page
            int fin = Math.Min(debut + _elementBypage, nbLoans); // Ne pas dépasser le nombre total de clients

            for (int i = debut; i < fin; i++)
            {
                string loanName = $"{_loans[i, 7]} {_loans[i, 6]} - {_loans[i, 5]} \nRetour: {Convert.ToDateTime(_loans[i, 2]).ToString("dd.MM.yyyy")}"; // Prénom + Nom de l'auteur et titre du livre  date de retour

                if (_loans[i, 0] != null) // Vérifie que l'emprunt est valide (champ ID ou autre non null)
                {
                    Button btn = new Button
                    {
                        Text = loanName,
                        Size = new Size(200, 40)
                    };

                    // Position du bouton dans la grille
                    int colonne = (i - debut) % _columns;
                    int ligne = (i - debut) / _columns;
                    btn.Location = new Point(10 + colonne * _spaceX, 10 + ligne * _spaceY);

                    int index = i; // Nécessaire pour capturer l'index correct dans l'événement

                    // Ajoute les actions sur clic du bouton : sélectionne le client, masque le formulaire, change de vue
                    btn.Click += (s, args) => SetcurrentLoan(_loans[index, 0], _loans[index, 1], _loans[index, 2], _loans[index, 3], _loans[index, 4], _loans[index, 5], _loans[index, 6], _loans[index, 7]);
                    btn.Click += (s, args) => form.Hide();
                    btn.Click += (s, args) => changeView("ViewoneLoan", form);

                    pnl.Controls.Add(btn); // Ajoute le bouton au panneau
                }
            }
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
        /// Retourne le nombre de livres affichés par page.
        /// </summary>
        /// <returns>Le nombre de livres par page.</returns>
        public int GetNumberOfBooksByPage()
        {
            return _booksBypage;
        }

        /// <summary>
        /// Retourne le nombre d'emprunt affichés par page.
        /// </summary>
        /// <returns>Le nombre d'emprunt par page.</returns>
        public int GetNumberOfLoansByPage()
        {
            return _loansBypage;
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
        /// Définit les informations du livre actuellement sélectionné.
        /// </summary>
        /// <param name="currrentBookISBN">Numéro ISBN du livre</param>
        /// <param name="currrentBooktitle">Titre du livre</param>
        /// <param name="currrentBookyearOfpublication">Année de pubication du livre</param>
        /// <param name="currrentBookquantity">Quantité du livre</param>
        /// <param name="currrentBookauthorID">Index de l'auteur lié au livre</param>
        /// <param name="currrentBookauthorFirstname">prénom de l'auteur lié au livre</param>
        /// <param name="currrentBookauthorName">Nom de l'auteur lié au livre</param>
        public void SetcurrentBook(string currrentBookISBN, string currrentBooktitle, string currrentBookyearOfpublication, string currrentBookquantity,
            string currrentBookauthorID, string currrentBookauthorFirstname, string currrentBookauthorName)
        {
            _currentBook[0] = currrentBookISBN;
            _currentBook[1] = currrentBooktitle;
            _currentBook[2] = currrentBookyearOfpublication;
            _currentBook[3] = currrentBookquantity;
            _currentBook[4] = currrentBookauthorID;
            _currentBook[5] = currrentBookauthorFirstname;
            _currentBook[6] = currrentBookauthorName;
        }

        public void SetcurrentLoan(string currrentloanindex, string currrentLoanDate, string currrentLoanbackDate, string currrentLoanbookID,
            string currrentLoanclientID, string cuurentLoantitleBook, string cuurentLoannameClient, string cuurentLoanfisrtnameClient)
        {
            _currentLoan[0] = currrentloanindex;
            _currentLoan[1] = currrentLoanDate;
            _currentLoan[2] = currrentLoanbackDate;
            _currentLoan[3] = currrentLoanclientID;
            _currentLoan[4] = currrentLoanbookID;
            _currentLoan[5] = cuurentLoantitleBook;
            _currentLoan[6] = cuurentLoannameClient;
            _currentLoan[7] = cuurentLoanfisrtnameClient;



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

        /// <summary>
        /// Retourne les informations du livre sélectionné
        /// </summary>
        /// <returns>Tableau de string des informations livre</returns>
        public string[] GetcurrentBook()
        {
            return _currentBook;
        }

        /// <summary>
        /// Retourne les informations du l'emprunt sélectionné
        /// </summary>
        /// <returns>Tableau de string des informations emprunt</returns>
        public string[] GetcurrentLoan()
        {
            return _currentLoan;
        }


    }
}
