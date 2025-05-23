using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Text.RegularExpressions;

namespace LitShelf.Model
{
    public class Model
    {

        /// <summary>
        /// Contrôleur associé à ce modèle
        /// </summary>
        public Controller.Controller Controller { get; set; }

        // Préparation de la connexion.
        private string myConnectionString = "datasource=localhost;port=6033;username=root;password=root;database=db_LitShelf;";
        private MySqlConnection myConnection;

        //variables privées
        private int _lineClient;
        private int _lineAuthor;
        private int _lineBook;
        private int _lineLoan;
        private int _lineBookborrowable;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Model()
        {


        }



        /// <summary>
        /// Vérifie si le prénom fourni est valide.
        /// des tirets, des apostrophes ou des espaces, et si sa longueur est comprise entre 2 et 50 caractères.
        /// </summary>
        /// <param name="firstname">Le prénom à valider.</param>
        /// <returns>True si le prénom est valide, sinon False.</returns>
        private bool IsValidFirstname(string firstname)
        {
            if (firstname != null)
            {
                return Regex.IsMatch(firstname, @"^[A-Za-zÀ-ÖØ-öø-ÿ\-\'\s]{2,50}$");
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Vérifie si le nom fourni est valide.
        /// uniquement lettres (avec accents), tirets, apostrophes ou espaces, et une longueur de 2 à 50 caractères.
        /// </summary>
        /// <param name="name">Le nom à valider.</param>
        /// <returns>True si le nom est valide, sinon False.</returns>
        private bool IsvalidName(string name)
        {
            //Vérifie que le nom n'est pas null.
            if(name != null)
            {
                return Regex.IsMatch(name, @"^[A-Za-zÀ-ÖØ-öø-ÿ\-\'\s]{2,50}$"); // Applique la regex.
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Vérifie si la date fournie est valide.
        /// uniquement 4 digites.
        /// </summary>
        /// <param name="date">La date à valider.</param>
        /// <returns>True si la date est valide, sinon False.</returns>
        private bool IsvalidDate(string date)
        {
            if (Regex.IsMatch(date, @"^[\d]{4}$") is false)
            {
                MessageBox.Show("Le champs date n'est pas au bon format. (ex: 1435"); // Message pour non respect des regex
            }

            //Vérifie que le nom n'est pas null.
            return Regex.IsMatch(date, @"^[\d]{4}$"); // Applique la regex.    
        }

        /// <summary>
        /// Vérifie si l'ISBN fourni est valide.
        /// uniquement 10 digites.
        /// </summary>
        /// <param name="ISBN">L'ISBN à valider.</param>
        /// <returns>True si l'ISBN est valide, sinon False.</returns>
        private bool IsvalidISBN(string ISBN)
        {
            if (Regex.IsMatch(ISBN, @"^[\d]{10}$") is false)
            {
                MessageBox.Show("Le champs ISBN n'est pas au bon format. (ex: 1234567891"); // Message pour non respect des regex
            }

            //Vérifie que le nom n'est pas null.
            return Regex.IsMatch(ISBN, @"^[\d]{10}$"); // Applique la regex.    
        }

        /// <summary>
        /// Vérifie si la quantité fourni est valide.
        /// uniquement 3 digites.
        /// </summary>
        /// <param name="quantity">La quantité à valider.</param>
        /// <returns>True si La quantité est valide, sinon False.</returns>
        private bool IsvalidQuantity(string quantity)
        {
            if (Regex.IsMatch(quantity, @"^[\d]{1,3}$") is false)
            {
                MessageBox.Show("Le champs quantité n'est pas au bon format. (ex: 124"); // Message pour non respect des regex
            }
            //Vérifie que le nom n'est pas null.
            return Regex.IsMatch(quantity, @"^[\d]{1,3}$"); // Applique la regex.    
        }



        /// <summary>
        /// Récupère le nombre de clients dans la base de données et le stocke dans _lineClient.
        /// </summary>
        private void GetclientCount()
        {
            myConnection = new MySqlConnection(myConnectionString);

            // Requête SQL
            string query = "SELECT COUNT(t_client.client_id) FROM t_client;";

            // Prépare l'exécution de la requête
            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection); ;
            MySqlDataReader reader;

            //Compteur
            int count = 0;

            try
            {
                // Ouvre la connexion avec la DB.
                myConnection.Open();

                // Exécute la requète
                reader = commandDatabase.ExecuteReader();

                // Vérifie si le lecteur trouve des colonnes.
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0); // Attribue la valeur de la requète au compteur
                    }
                }

                // Ferme le lecteur et la connexion avec la DB.     
                reader.Close();
                myConnection.Close();

            }
            catch (Exception ex)
            {
                // Affiche Toutes erreurs éventuelles
                MessageBox.Show($"Échec de la connexion : {ex.Message}");
            }

            // Attribue le compte à la variable privée.
            _lineClient = count;
        }

        /// <summary>
        /// Récupère le nombre d'auteurs dans la base de données et le stocke dans _lineAuthor.
        /// </summary>
        private void GetauthorCount()
        {
            myConnection = new MySqlConnection(myConnectionString);

            // Requête SQL
            string query = "SELECT COUNT(t_auteur.auteur_id) FROM t_auteur;";

            // Prépare l'exécution de la requête
            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection); ;
            MySqlDataReader reader;

            //Compteur
            int count = 0;

            try
            {
                // Ouvre la connexion avec la DB.
                myConnection.Open();

                // Exécute la requète
                reader = commandDatabase.ExecuteReader();

                // Vérifie si le lecteur trouve des colonnes.
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0); // Attribue la valeur de la requète au compteur
                    }
                }

                // Ferme le lecteur et la connexion avec la DB.     
                reader.Close();
                myConnection.Close();

            }
            catch (Exception ex)
            {
                // Affiche Toutes erreurs éventuelles
                MessageBox.Show($"Échec de la connexion : {ex.Message}");
            }

            // Attribue le compte à la variable privée.
            _lineAuthor = count;
        }

        /// <summary>
        /// Récupère le nombre de livres dans la base de données et le stocke dans _lineAuthor.
        /// </summary>
        private void GetbookCount()
        {
            myConnection = new MySqlConnection(myConnectionString);

            // Requête SQL
            string query = @"
               SELECT COUNT(t_livre.ISBN)
                FROM t_livre
                INNER JOIN écrire ON t_livre.ISBN = écrire.ISBN
                INNER JOIN t_auteur ON écrire.auteur_id = t_auteur.auteur_id;";

            // Prépare l'exécution de la requête
            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection); ;
            MySqlDataReader reader;

            //Compteur
            int count = 0;

            try
            {
                // Ouvre la connexion avec la DB.
                myConnection.Open();

                // Exécute la requète
                reader = commandDatabase.ExecuteReader();

                // Vérifie si le lecteur trouve des colonnes.
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0); // Attribue la valeur de la requète au compteur
                    }
                }

                // Ferme le lecteur et la connexion avec la DB.     
                reader.Close();
                myConnection.Close();

            }
            catch (Exception ex)
            {
                // Affiche Toutes erreurs éventuelles
                MessageBox.Show($"Échec de la connexion : {ex.Message}");
            }

            // Attribue le compte à la variable privée.
            _lineBook = count;
        }

        /// <summary>
        /// Récupère le nombre d'emprunt dans la base de données et le stocke dans _lineLoan.
        /// </summary>
        private void GetloanCount()
        {
            myConnection = new MySqlConnection(myConnectionString);

            // Requête SQL
            string query = @"SELECT COUNT(t_emprunt.emprunt_id)
                            FROM t_emprunt
                            INNER JOIN t_client ON t_emprunt.client_id = t_client.client_id
                            INNER JOIN t_exemplaire ON t_emprunt.exemplaire_id = t_exemplaire.exemplaire_id
                            INNER JOIN t_livre ON t_exemplaire.ISBN = t_livre.ISBN;";

            // Prépare l'exécution de la requête
            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection); ;
            MySqlDataReader reader;

            //Compteur
            int count = 0;

            try
            {
                // Ouvre la connexion avec la DB.
                myConnection.Open();

                // Exécute la requète
                reader = commandDatabase.ExecuteReader();

                // Vérifie si le lecteur trouve des colonnes.
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0); // Attribue la valeur de la requète au compteur
                    }
                }

                // Ferme le lecteur et la connexion avec la DB.     
                reader.Close();
                myConnection.Close();

            }
            catch (Exception ex)
            {
                // Affiche Toutes erreurs éventuelles
                MessageBox.Show($"Échec de la connexion : {ex.Message}");
            }

            // Attribue le compte à la variable privée.
            _lineLoan = count;
        }

        /// <summary>
        /// Récupère le nombre d'emprunt dans la base de données et le stocke dans _lineLoan.
        /// </summary>
        private void GetbookBorrowablecount()
        {
            myConnection = new MySqlConnection(myConnectionString);

            // Requête SQL
            string query = @"SELECT COUNT(*) AS nb_livres_disponibles
                            FROM (
                                SELECT     
                                    t_livre.ISBN,
                                    t_livre.titre,
                                    COUNT(t_exemplaire.exemplaire_id) AS nb_exemplaires_disponibles,
                                    MIN(t_exemplaire.exemplaire_id) AS un_exemplaire_disponible_id
                                FROM t_livre
                                JOIN t_exemplaire ON t_livre.ISBN = t_exemplaire.ISBN
                                LEFT JOIN t_emprunt 
                                    ON t_exemplaire.exemplaire_id = t_emprunt.exemplaire_id 
                                    AND t_emprunt.date_retour > CURDATE()
                                WHERE t_emprunt.emprunt_id IS NULL
                                GROUP BY t_livre.ISBN, t_livre.titre
                                HAVING nb_exemplaires_disponibles > 0
                            ) AS livres_disponibles;;";

            // Prépare l'exécution de la requête
            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection); ;
            MySqlDataReader reader;

            //Compteur
            int count = 0;

            try
            {
                // Ouvre la connexion avec la DB.
                myConnection.Open();

                // Exécute la requète
                reader = commandDatabase.ExecuteReader();

                // Vérifie si le lecteur trouve des colonnes.
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0); // Attribue la valeur de la requète au compteur
                    }
                }

                // Ferme le lecteur et la connexion avec la DB.     
                reader.Close();
                myConnection.Close();

            }
            catch (Exception ex)
            {
                // Affiche Toutes erreurs éventuelles
                MessageBox.Show($"Échec de la connexion : {ex.Message}");
            }

            // Attribue le compte à la variable privée.
            _lineBookborrowable = count;
        }



        /// <summary>
        /// Récupère toutes les données de la table t_client depuis la base de données,
        /// et les retourne sous forme d’un tableau à deux dimensions (string[,]).
        /// </summary>
        /// <returns>Un tableau contenant les données utilisateur (ID, nom, prénom).</returns>
        public string[,] ReadclientData()
        {
            GetclientCount(); // Appelle une méthode externe pour définir la valeur de _lineClient

            myConnection = new MySqlConnection(myConnectionString);

            string query = "SELECT t_client.client_id, t_client.nom, t_client.prénom FROM t_client;"; // Requête SQL pour récupérer tous les utilisateurs

            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection);

            MySqlDataReader reader;

            string[,] data = new string[0, 0]; // Initialisation par défaut (sera remplacée si requête réussie)

            try
            {
                myConnection.Open(); // Ouvre la connexion à la base

                reader = commandDatabase.ExecuteReader(); // Exécute la requête et lit les résultats

                data = new string[_lineClient, reader.FieldCount]; // Crée un tableau avec [_lineClient] de lignes et autant de colonnes que de champs

                int count = 0; // Compteur de ligne

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            data[count, i] = reader.GetValue(i).ToString(); // Stocke chaque champ dans le tableau
                        }
                        count++; // Passe à la ligne suivante
                    }
                }

                myConnection.Close(); // Ferme la connexion après la lecture
            }
            catch (Exception ex)
            {
                // Affiche un message en cas d'erreur
                MessageBox.Show($"Échec de la connexion 2: {ex.Message}");
            }

            return data; // Retourne le tableau rempli (ou vide en cas d’échec)
        }

        /// <summary>
        /// Récupère toutes les données de la table t_auteur depuis la base de données,
        /// et les retourne sous forme d’un tableau à deux dimensions (string[,]).
        /// </summary>
        /// <returns>Un tableau contenant les données auteurs (ID, nom, prénom).</returns>
        public string[,] ReadauthorData()
        {
            GetauthorCount(); // Appelle une méthode externe pour définir la valeur de _lineAuthor

            myConnection = new MySqlConnection(myConnectionString);

            string query = "SELECT t_auteur.auteur_id, t_auteur.nom, t_auteur.prénom FROM t_auteur;"; // Requête SQL pour récupérer tous les auteurs

            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection);

            MySqlDataReader reader;

            string[,] data = new string[0, 0]; // Initialisation par défaut (sera remplacée si requête réussie)

            try
            {
                myConnection.Open(); // Ouvre la connexion à la base

                reader = commandDatabase.ExecuteReader(); // Exécute la requête et lit les résultats

                data = new string[_lineAuthor, reader.FieldCount]; // Crée un tableau avec [_lineAuthor]  de lignes et autant de colonnes que de champs

                int count = 0; // Compteur de ligne

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            data[count, i] = reader.GetValue(i).ToString(); // Stocke chaque champ dans le tableau
                        }
                        count++; // Passe à la ligne suivante
                    }
                }

                myConnection.Close(); // Ferme la connexion après la lecture
            }
            catch (Exception ex)
            {
                // Affiche un message en cas d'erreur
                MessageBox.Show($"Échec de la connexion 2: {ex.Message}");
            }

            return data; // Retourne le tableau rempli (ou vide en cas d’échec)
        }

        /// <summary>
        /// Récupère toutes les données de la table t_livre avec les liaisons avec la table écrire et t_auteur depuis la base de données,
        /// et les retourne sous forme d’un tableau à deux dimensions (string[,]).
        /// </summary>
        /// <returns>Un tableau contenant les données livres (ISBN, Titre, quantité, ect).</returns>
        public string[,] ReadbookData()
        {
            GetbookCount(); // Appelle une méthode externe pour définir la valeur de _linebook

            myConnection = new MySqlConnection(myConnectionString);

            // Requête SQL pour récupérer tous les auteurs
            string query = @"
            SELECT t_livre.ISBN, t_livre.titre, t_livre.année_de_publication, t_livre.quantité, écrire.auteur_id, t_auteur.prénom, t_auteur.nom
            FROM t_livre
            INNER JOIN écrire ON t_livre.ISBN = écrire.ISBN
            INNER JOIN t_auteur ON écrire.auteur_id = t_auteur.auteur_id;"; 

            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection);

            MySqlDataReader reader;

            string[,] data = new string[0, 0]; // Initialisation par défaut (sera remplacée si requête réussie)

            try
            {
                myConnection.Open(); // Ouvre la connexion à la base

                reader = commandDatabase.ExecuteReader(); // Exécute la requête et lit les résultats

                data = new string[_lineBook, reader.FieldCount]; // Crée un tableau avec [_lineBook]  de lignes et autant de colonnes que de champs

                int count = 0; // Compteur de ligne

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            data[count, i] = reader.GetValue(i).ToString(); // Stocke chaque champ dans le tableau
                        }
                        count++; // Passe à la ligne suivante
                    }
                }

                myConnection.Close(); // Ferme la connexion après la lecture
            }
            catch (Exception ex)
            {
                // Affiche un message en cas d'erreur
                MessageBox.Show($"Échec de la connexion 2: {ex.Message}");
            }

            return data; // Retourne le tableau rempli (ou vide en cas d’échec)
        }

        /// <summary>
        /// Récupère toutes les données de la table t_emprunt avec les liaisons,
        /// et les retourne sous forme d’un tableau à deux dimensions (string[,]).
        /// </summary>
        /// <returns>Un tableau contenant les données emprunt (date emprunt, date retour, ID client, ID exemplaire).</returns>
        public string[,] ReadloanData()
        {
            GetloanCount(); // Appelle une méthode externe pour définir la valeur de _lineLoan

            myConnection = new MySqlConnection(myConnectionString);

            // Requête SQL pour récupérer tous les auteurs
            string query = @"
            SELECT t_emprunt.emprunt_id, t_emprunt.date_emprunt, t_emprunt.date_retour, t_emprunt.client_id, t_emprunt.exemplaire_id, t_livre.titre, t_client.nom, t_client.prénom
            FROM t_emprunt
            INNER JOIN t_client ON t_emprunt.client_id = t_client.client_id
            INNER JOIN t_exemplaire ON t_emprunt.exemplaire_id = t_exemplaire.exemplaire_id
            INNER JOIN t_livre ON t_exemplaire.ISBN = t_livre.ISBN;";

            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection);

            MySqlDataReader reader;

            string[,] data = new string[0, 0]; // Initialisation par défaut (sera remplacée si requête réussie)

            try
            {
                myConnection.Open(); // Ouvre la connexion à la base

                reader = commandDatabase.ExecuteReader(); // Exécute la requête et lit les résultats

                data = new string[_lineLoan, reader.FieldCount]; // Crée un tableau avec [_lineLoan]  de lignes et autant de colonnes que de champs

                int count = 0; // Compteur de ligne

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            data[count, i] = reader.GetValue(i).ToString(); // Stocke chaque champ dans le tableau
                        }
                        count++; // Passe à la ligne suivante
                    }
                }

                myConnection.Close(); // Ferme la connexion après la lecture
            }
            catch (Exception ex)
            {
                // Affiche un message en cas d'erreur
                MessageBox.Show($"Échec de la connexion : {ex.Message}");
            }

            return data; // Retourne le tableau rempli (ou vide en cas d’échec)
        }


        /// <summary>
        /// Récupère toutes les données des livres pouvant être emprunté,
        /// et les retourne sous forme d’un tableau à deux dimensions (string[,]).
        /// </summary>
        /// <returns>Un tableau contenant les données emprunt (, date retour, ID client, ID exemplaire).</returns>
        public string[,] ReadbookDataBorrowable()
        {
            GetbookBorrowablecount(); // Appelle une méthode externe pour définir la valeur de _lineBookborrowable

            myConnection = new MySqlConnection(myConnectionString);

            // Requête SQL pour récupérer tous les auteurs
            string query = @"
            SELECT     
                t_livre.ISBN,
                t_livre.titre,
            COUNT(t_exemplaire.exemplaire_id) AS nb_exemplaires_disponibles,
            MIN(t_exemplaire.exemplaire_id) AS un_exemplaire_disponible_id
            FROM t_livre
            JOIN t_exemplaire ON t_livre.ISBN = t_exemplaire.ISBN
            LEFT JOIN t_emprunt 
                ON t_exemplaire.exemplaire_id = t_emprunt.exemplaire_id 
                AND t_emprunt.date_retour > CURDATE()
            WHERE t_emprunt.emprunt_id IS NULL
            GROUP BY t_livre.ISBN, t_livre.titre
            HAVING nb_exemplaires_disponibles > 0;";

            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection);

            MySqlDataReader reader;

            string[,] data = new string[0, 0]; // Initialisation par défaut (sera remplacée si requête réussie)

            try
            {
                myConnection.Open(); // Ouvre la connexion à la base

                reader = commandDatabase.ExecuteReader(); // Exécute la requête et lit les résultats

                data = new string[_lineBookborrowable, reader.FieldCount]; // Crée un tableau avec [_lineBookborrowable]  de lignes et autant de colonnes que de champs

                int count = 0; // Compteur de ligne

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            data[count, i] = reader.GetValue(i).ToString(); // Stocke chaque champ dans le tableau
                        }
                        count++; // Passe à la ligne suivante
                    }
                }

                myConnection.Close(); // Ferme la connexion après la lecture
            }
            catch (Exception ex)
            {
                // Affiche un message en cas d'erreur
                MessageBox.Show($"Échec de la connexion : {ex.Message}");
            }

            return data; // Retourne le tableau rempli (ou vide en cas d’échec)
        }



        /// <summary>
        /// Récupère toutes les données de la table t_livre avec les liaisons avec la table écrire et t_auteur depuis la base de données,
        /// et les retourne sous forme d’un tableau à deux dimensions (string[,]).
        /// </summary>
        /// <returns>Un tableau contenant les données livres (ISBN, Titre, quantité, ect).</returns>
        public string[,] ReadbookDataFiler(string idAuthor)
        {
            GetbookCount(); // Appelle une méthode externe pour définir la valeur de _linebook

            myConnection = new MySqlConnection(myConnectionString);

            // Requête SQL pour récupérer tous les auteurs
            string query = @"
            SELECT t_livre.ISBN, t_livre.titre, t_livre.année_de_publication, t_livre.quantité, écrire.auteur_id, t_auteur.prénom, t_auteur.nom
            FROM t_livre
            INNER JOIN écrire ON t_livre.ISBN = écrire.ISBN
            INNER JOIN t_auteur ON écrire.auteur_id = t_auteur.auteur_id
            WHERE (@IDauthor IS NULL OR t_auteur.auteur_id = @Idauthor);";

            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection);
            commandDatabase.Parameters.AddWithValue("@Idauthor", idAuthor);

            MySqlDataReader reader;

            string[,] data = new string[0, 0]; // Initialisation par défaut (sera remplacée si requête réussie)

            try
            {
                myConnection.Open(); // Ouvre la connexion à la base

                reader = commandDatabase.ExecuteReader(); // Exécute la requête et lit les résultats

                data = new string[_lineBook, reader.FieldCount]; // Crée un tableau avec [_lineBook]  de lignes et autant de colonnes que de champs

                int count = 0; // Compteur de ligne

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            data[count, i] = reader.GetValue(i).ToString(); // Stocke chaque champ dans le tableau
                        }
                        count++; // Passe à la ligne suivante
                    }
                }

                myConnection.Close(); // Ferme la connexion après la lecture
            }
            catch (Exception ex)
            {
                // Affiche un message en cas d'erreur
                MessageBox.Show($"Échec de la connexion : {ex.Message}");
            }

            return data; // Retourne le tableau rempli (ou vide en cas d’échec)
        }

        /// <summary>
        /// Récupère toutes les données de la table t_emprunt avec les liaisons avec la table t_exemplaire et t_client et t_livre depuis la base de données,
        /// et les retourne sous forme d’un tableau à deux dimensions (string[,]).
        /// </summary>
        /// <returns>Un tableau contenant les données livres (ISBN, Titre, prénom du clienzt ect).</returns>
        public string[,] ReadloanDataFiler(string idClient)
        {
            GetloanCount(); // Appelle une méthode externe pour définir la valeur de _lineLoan

            myConnection = new MySqlConnection(myConnectionString);

            // Requête SQL pour récupérer tous les auteurs
            string query = @"
            SELECT t_emprunt.emprunt_id, t_emprunt.date_emprunt, t_emprunt.date_retour, t_emprunt.client_id, t_emprunt.exemplaire_id, t_livre.titre, t_client.nom, t_client.prénom
            FROM t_emprunt
            INNER JOIN t_client ON t_emprunt.client_id = t_client.client_id
            INNER JOIN t_exemplaire ON t_emprunt.exemplaire_id = t_exemplaire.exemplaire_id
            INNER JOIN t_livre ON t_exemplaire.ISBN = t_livre.ISBN
            WHERE (@Idclient IS NULL OR t_client.client_id = @Idclient);";

            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection);
            commandDatabase.Parameters.AddWithValue("@Idclient", idClient);

            MySqlDataReader reader;

            string[,] data = new string[0, 0]; // Initialisation par défaut (sera remplacée si requête réussie)

            try
            {
                myConnection.Open(); // Ouvre la connexion à la base

                reader = commandDatabase.ExecuteReader(); // Exécute la requête et lit les résultats

                data = new string[_lineLoan, reader.FieldCount]; // Crée un tableau avec [_lineLoan]  de lignes et autant de colonnes que de champs

                int count = 0; // Compteur de ligne

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            data[count, i] = reader.GetValue(i).ToString(); // Stocke chaque champ dans le tableau
                        }
                        count++; // Passe à la ligne suivante
                    }
                }

                myConnection.Close(); // Ferme la connexion après la lecture
            }
            catch (Exception ex)
            {
                // Affiche un message en cas d'erreur
                MessageBox.Show($"Échec de la connexion 2: {ex.Message}");
            }

            return data; // Retourne le tableau rempli (ou vide en cas d’échec)
        }



        /// <summary>
        /// Enregistre un nouveau client dans la base de données s'il n'existe pas déjà,
        /// après validation du prénom et du nom.
        /// </summary>
        /// <param name="firstname">Le prénom du client.</param>
        /// <param name="name">Le nom du client.</param>
        public void CreatenewClient(string firstname, string name)
        {
            // Vérifie que le prénom et le nom sont valides selon les règles définies
            if (IsValidFirstname(firstname) && IsvalidName(name))
            {
                // Création de la connexion à la base de données
                MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

                // Requête SQL : insère le client seulement s'il n'existe pas déjà
                string query = @"
                    INSERT INTO t_client (prénom, nom)
                    SELECT @Firstname, @Name
                    WHERE NOT EXISTS (
                    SELECT 1 FROM t_client
                    WHERE prénom = @Firstname AND nom = @Name
                    );";

                // Préparation de la commande avec les paramètres
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@Firstname", firstname);
                commandDatabase.Parameters.AddWithValue("@Name", name);

                try
                {
                    databaseConnection.Open();
                    int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Client enregistré avec succès !");
                    }
                    else
                    {
                        MessageBox.Show("Client déjà existant.");
                    }
                }
                catch (Exception ex)
                {
                    // Affiche une erreur en cas de problème
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    databaseConnection.Close(); // Ferme toujours la connexion, même en cas d'erreur
                }
            }
            else
            {
                MessageBox.Show("L'un des deux champs n'est pas au bon format.");
            }
        }

        /// <summary>
        /// Enregistre un nouvel auteur dans la base de données s'il n'existe pas déjà,
        /// après validation du prénom et du nom.
        /// </summary>
        /// <param name="firstname">Le prénom de l'auteur.</param>
        /// <param name="name">Le nom de l'auteur.</param>
        public void CreatenewAuthor(string firstname, string name)
        {
            // Vérifie que le prénom et le nom sont valides selon les règles définies
            if (IsValidFirstname(firstname) && IsvalidName(name))
            {
                // Création de la connexion à la base de données
                MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

                // Requête SQL : insère l'auteur seulement s'il n'existe pas déjà
                string query = @"
                    INSERT INTO t_auteur (prénom, nom)
                    SELECT @Firstname, @Name
                    WHERE NOT EXISTS (
                    SELECT 1 FROM t_auteur
                    WHERE prénom = @Firstname OR nom = @Name
                    );";

                // Préparation de la commande avec les paramètres
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@Firstname", firstname);
                commandDatabase.Parameters.AddWithValue("@Name", name);

                try
                {
                    databaseConnection.Open();
                    int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Auteur enregistré avec succès !");
                    }
                    else
                    {
                        MessageBox.Show("Auteur déjà existant.");
                    }

                    
                }
                catch (Exception ex)
                {
                    // Affiche une erreur en cas de problème
                    MessageBox.Show("Erreur : " + ex.Message);
                }
                finally
                {
                    databaseConnection.Close(); // Ferme toujours la connexion, même en cas d'erreur
                }
            }
            else
            {
                MessageBox.Show("L'un des deux champs n'est pas au bon format."); // Message pour non respect des regex
            }
        }

        /// <summary>
        ///  Enregistre un nouveau livre dans la base de données s'il n'existe pas déjà,
        /// après validation des paramètres avec des regex.
        /// </summary>
        /// <param name="ISBN">N° ISBN du livre</param>
        /// <param name="title">Titre du livre</param>
        /// <param name="date">Date de publication du livre </param>
        /// <param name="quantity">Quantité du livre</param>
        /// <param name="id_auteur">Clé étranger de l'auteur</param>
        public void CreatenewBook(string ISBN, string title, string date, string quantity, int id_auteur)
        {
            // Vérifie que le prénom et le nom sont valides selon les règles définies
            if (IsvalidISBN(ISBN) && IsvalidDate(date) && IsvalidDate(Convert.ToString(date)) && IsvalidQuantity(quantity))
            {
                // Création de la connexion à la base de données
                MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

                try
                {

                    // Préparation de la commande avec les paramètres
                    using (MySqlCommand commandDatabase = new MySqlCommand("AjouterLivreAvecExemplaires", databaseConnection))
                    {
                        commandDatabase.CommandType = System.Data.CommandType.StoredProcedure;

                        // // Ajout des paramètres IN
                        commandDatabase.Parameters.AddWithValue("p_ISBN", ISBN);
                        commandDatabase.Parameters.AddWithValue("p_titre", title);
                        commandDatabase.Parameters.AddWithValue("p_annee", date);
                        commandDatabase.Parameters.AddWithValue("p_quantite", Convert.ToInt32(quantity));
                        commandDatabase.Parameters.AddWithValue("p_auteur_id", id_auteur);

                        databaseConnection.Open();

                        int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Livre enregistré avec succès !");
                        }
                        else
                        {
                            MessageBox.Show("Livre déjà existant.");
                        }

                    }
                }
                catch (Exception ex)
                {
                    // Affiche une erreur en cas de problème
                    MessageBox.Show("Erreur : " + ex.Message);
                }
                finally
                {
                    databaseConnection.Close(); // Ferme toujours la connexion, même en cas d'erreur
                }
            }
        }

        /// <summary>
        /// Enregistre un nouvel emprunt dans la base de données.
        /// </summary>
        /// <param name="idClient">La clé étangère du client.</param>
        /// <param name="idBook">La clé étangère de l'exemplaire</param>
        public void CreatenewLoan(string idClient, string idBook)
        {

                // Création de la connexion à la base de données
                MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

                // Requête SQL : insère l'auteur seulement s'il n'existe pas déjà
                string query = @"
                    INSERT INTO t_emprunt (date_emprunt, date_retour, client_id, exemplaire_id)
                    VALUES (CURDATE(), DATE_ADD(CURDATE(), INTERVAL 14 DAY), @Idclient, @Idexemplaire);";

                // Préparation de la commande avec les paramètres
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@Idclient", idClient);
                commandDatabase.Parameters.AddWithValue("@Idexemplaire", idBook);

                try
                {
                    databaseConnection.Open();
                    int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Emprunt enregistré avec succès !");
                    }

                }
                catch (Exception ex)
                {
                    // Affiche une erreur en cas de problème
                    MessageBox.Show("Erreur : " + ex.Message);
                }
                finally
                {
                    databaseConnection.Close(); // Ferme toujours la connexion, même en cas d'erreur
                }
        }



        /// <summary>
        /// Modifie un client dans la base de données,
        /// après validation du prénom et du nom.
        /// </summary>
        /// <param name="id">La clé primaire lié au client</param>
        /// <param name="firstname">Le prénom du client.</param>
        /// <param name="name">Le nom du client</param>
        public void Updateclient(string id, string firstname, string name)
        {
            // Vérifie que le prénom et le nom sont valides selon les règles définies
            if (IsValidFirstname(firstname) && IsvalidName(name))
            {
                // Requête SQL : modifier le client seulement au bonne index si il n'existe pas déjâ.
                string query = @"
                UPDATE t_client
                SET prénom = @Firstname, nom = @Name
                WHERE client_id = @Id
                AND NOT EXISTS(
                    SELECT 1 FROM(
                        SELECT 1 FROM t_client
                        WHERE prénom = @Firstname
                        AND nom = @Name
                    ) AS sub
                );";

                // Création de la connexion à la base de données
                MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

                // Préparation de la commande avec les paramètres
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@Firstname", firstname);
                commandDatabase.Parameters.AddWithValue("@Name", name);
                commandDatabase.Parameters.AddWithValue("@Id", id);

                try
                {
                    databaseConnection.Open();
                    int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Client modifié avec succès !");
                    }
                    else
                    {
                        MessageBox.Show("Client déja exitant ou informations identiques.");
                    }

                    // Ferme toujours la connexion, même en cas d'erreur
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Affiche une erreur en cas de problème
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("L'un des deux champs n'est pas au bon format."); // Message pour non respect des regex
            }
        }

        /// <summary>
        /// Modifie un  auteur dans la base de données,
        /// après validation du prénom et du nom.
        /// </summary>
        /// <param name="id">La clé primaire lié à l'auteur</param>
        /// <param name="firstname">Le prénom de l'auteur.</param>
        /// <param name="name">Le nom de l'auteur.</param>
        public void Updateauthor(string id, string firstname, string name)
        {
            // Vérifie que le prénom et le nom sont valides selon les règles définies
            if (IsValidFirstname(firstname) && IsvalidName(name))
            {
                // Requête SQL : modifier l'auteur seulement au bonne index
                string query = @"
                UPDATE t_auteur
                SET prénom = @Firstname, nom = @Name
                WHERE auteur_id = @Id
                AND NOT EXISTS(
                    SELECT 1 FROM(
                        SELECT 1 FROM t_auteur
                        WHERE prénom = @Firstname
                        AND nom = @Name
                    ) AS sub
                );";

                // Création de la connexion à la base de données
                MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

                // Préparation de la commande avec les paramètres
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@Firstname", firstname);
                commandDatabase.Parameters.AddWithValue("@Name", name);
                commandDatabase.Parameters.AddWithValue("@Id", id);

                try
                {
                    databaseConnection.Open();
                    int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Auteur modifié avec succès !");
                    }
                    else
                    {
                        MessageBox.Show("Auteur déja exitant ou informations identiques.");
                    }

                    // Ferme toujours la connexion, même en cas d'erreur
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Affiche une erreur en cas de problème
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("L'un des deux champs n'est pas au bon format."); // Message pour non respect des regex
            }
        }

        /// <summary>
        /// Modifie un livre dans la base de données et ajoute le nombre n'exemplaire supplémentaire si la quantité augmente
        /// après validation des champs avec des regex.
        /// </summary>
        /// <param name="ISBN">N° ISBN du livre</param>
        /// <param name="title">Titre du livre</param>
        /// <param name="date">Date de publication du livre </param>
        /// <param name="quantity">Quantité du livre</param>
        /// <param name="id_auteur">Clé étranger de l'auteur</param>
        public void Updatebook(string ISBN, string title, string date, string quantity, int id_auteur)
        {
            // Vérifie que le prénom et le nom sont valides selon les règles définies
            if (IsvalidISBN(ISBN) && IsvalidDate(date) && IsvalidDate(Convert.ToString(date)) && IsvalidQuantity(quantity))
            {
                // Création de la connexion à la base de données
                MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

                try
                {

                    // Préparation de la commande avec les paramètres
                    using (MySqlCommand commandDatabase = new MySqlCommand("ModifierLivreEtExemplaires", databaseConnection))
                    {
                        commandDatabase.CommandType = System.Data.CommandType.StoredProcedure;

                        // Ajout des paramètres IN
                        commandDatabase.Parameters.AddWithValue("p_ISBN", ISBN);
                        commandDatabase.Parameters.AddWithValue("p_titre", title);
                        commandDatabase.Parameters.AddWithValue("p_annee", date);
                        commandDatabase.Parameters.AddWithValue("p_nouvelle_quantite", Convert.ToInt32(quantity));
                        commandDatabase.Parameters.AddWithValue("p_auteur_id", id_auteur);

                        // Paramètre OUT
                        MySqlParameter outputParam = new MySqlParameter("@p_message", MySqlDbType.VarChar);
                        outputParam.Direction = System.Data.ParameterDirection.Output;
                        outputParam.Size = 255;
                        commandDatabase.Parameters.Add(outputParam);

                        databaseConnection.Open();

                        int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                        // Récupérer le message
                        string message = outputParam.Value.ToString();
                        MessageBox.Show(message);

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Aucune modification n'a été apportée au livre.");
                        }

                    }
                }
                catch (Exception ex)
                {
                    // Affiche une erreur en cas de problème
                    MessageBox.Show("Erreur : " + ex.Message);
                }
                finally
                {
                    databaseConnection.Close(); // Ferme toujours la connexion, même en cas d'erreur
                }
            }
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

            // Création de la connexion à la base de données
            MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

            // Requête SQL : insère l'auteur seulement s'il n'existe pas déjà
            string query = @"UPDATE `t_emprunt` 
                            SET `date_retour` = @date_retour, `client_id` = @Idclient, `exemplaire_id` = @Idexemplaire 
                            WHERE `t_emprunt`.`emprunt_id` = @Idloan ;";


            // Préparation de la commande avec les paramètres
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@Idclient", idClient);
            commandDatabase.Parameters.AddWithValue("@Idexemplaire", idBook);
            commandDatabase.Parameters.AddWithValue("@Idloan", idLoan);
            commandDatabase.Parameters.AddWithValue("@date_retour", backDate);

            try
            {
                databaseConnection.Open();
                int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Emprunt modifié avec succès !");
                }

            }
            catch (Exception ex)
            {
                // Affiche une erreur en cas de problème
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                databaseConnection.Close(); // Ferme toujours la connexion, même en cas d'erreur
            }
        }


        /// <summary>
        /// Supprime un client dans la base de données
        /// </summary>
        /// <param name="id">La clé primaire lié au client</param>
        public void Deleteclient(string id)
        {
            // Requête SQL : supprime l'auteur seulement au bonne index.
            string query = @"   
                DELETE FROM t_client 
                WHERE client_id = @Id;";

            // Création de la connexion à la base de données
            MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

            // Préparation de la commande avec les paramètres
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@Id", id);

            try
            {
                databaseConnection.Open();
                int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Client supprimé avec succès !");
                }
                else
                {
                    MessageBox.Show("Le client n'a pas pu être supprimé");
                }

                // Ferme toujours la connexion, même en cas d'erreur
                databaseConnection.Close();
            }
            catch (MySqlException ex)
            {
                // contrainte de clé étrangère
                if (ex.Number == 1451)
                {
                    MessageBox.Show("Erreur : Ce client est lié à un livre en cours d'emprunt.");
                }
                else
                {
                    // Affichage par défaut
                    MessageBox.Show($"Erreur SQL ({ex.Code}) : {ex.Message}");
                }

            }
            catch (Exception ex)
            {
                // Affiche une erreur en cas de problème
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Supprime un auteur dans la base de données
        /// </summary>
        /// <param name="id">La clé primaire lié à l'auteur</param>
        public void Deleteauthor(string id)
        {
            // Requête SQL : supprime le client seulement au bonne index.
            string query = @"   
                DELETE FROM t_auteur 
                WHERE auteur_id = @Id;";

            // Création de la connexion à la base de données
            MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

            // Préparation de la commande avec les paramètres
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@Id", id);

            try
            {
                databaseConnection.Open();
                int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Auteur supprimé avec succès !");
                }
                else
                {
                    MessageBox.Show("L'auteur n'a pas pu être supprimé");
                }

                // Ferme toujours la connexion, même en cas d'erreur
                databaseConnection.Close();

            }
            catch (MySqlException ex)
            {
                // contrainte de clé étrangère
                if (ex.Number == 1451) 
                {
                    MessageBox.Show("Erreur : Cet auteur est lié à un livre en cours d'emprunt.");
                }
                else
                {
                    // Affichage par défaut
                    MessageBox.Show($"Erreur SQL ({ex.Code}) : {ex.Message}");
                }
                
            }
            catch (Exception ex)
            {
                // Affiche une erreur en cas de problème
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Supprime un auteur dans la base de données
        /// </summary>
        /// <param name="ISBN">La clé primaire lié au livre. /param>
        public void Deletebook(string ISBN)
        {
            // Création de la connexion à la base de données
            MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

            try
            {

                // Préparation de la commande avec les paramètres
                using (MySqlCommand commandDatabase = new MySqlCommand("SupprimerLivre", databaseConnection))
                {
                    commandDatabase.CommandType = System.Data.CommandType.StoredProcedure;

                    // Ajout des paramètres IN
                    commandDatabase.Parameters.AddWithValue("p_ISBN", ISBN);


                    // Paramètre OUT
                    MySqlParameter outputParam = new MySqlParameter("@p_message", MySqlDbType.VarChar);
                    outputParam.Direction = System.Data.ParameterDirection.Output;
                    outputParam.Size = 255;
                    commandDatabase.Parameters.Add(outputParam);

                    databaseConnection.Open();

                    int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                    // Récupérer le message
                    string message = outputParam.Value.ToString();
                    MessageBox.Show(message);

                }
            }
            catch (Exception ex)
            {
                // Affiche une erreur en cas de problème
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                databaseConnection.Close(); // Ferme toujours la connexion, même en cas d'erreur
            }

        }

        /// <summary>
        /// Supprime un emprunt dans la base de données
        /// </summary>
        /// <param name="id">La clé primaire lié à l'emprunt. /param>
        public void Deleteloan(string id)
        {
            // Requête SQL : supprime l'auteur seulement au bonne index.
            string query = @"   
                DELETE FROM t_emprunt 
                WHERE emprunt_id = @Id;";

            // Création de la connexion à la base de données
            MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

            // Préparation de la commande avec les paramètres
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@Id", id);

            try
            {
                databaseConnection.Open();
                int rowsAffected = commandDatabase.ExecuteNonQuery(); // Exécute la commande et récupère les lignes affectées

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Emprunt retourné avec succès !");
                }
                else
                {
                    MessageBox.Show("L'emprunt n'a pas pu être retourné.");
                }

                // Ferme toujours la connexion, même en cas d'erreur
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Affiche une erreur en cas de problème
                MessageBox.Show(ex.Message);
            }

        }
    }
}
