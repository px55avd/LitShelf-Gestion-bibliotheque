using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
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
<<<<<<< HEAD
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
            if (Regex.IsMatch(date, @"^[d]{4}$") is false)
            {
                MessageBox.Show("Le champs date n'est pas au bon format. (ex: 1435"); // Message pour non respect des regex
            }

            //Vérifie que le nom n'est pas null.
            return Regex.IsMatch(date, @"^[d]{4}$"); // Applique la regex.    
        }

        /// <summary>
        /// Vérifie si l'ISBN fourni est valide.
        /// uniquement 10 digites.
        /// </summary>
        /// <param name="ISBN">L'ISBN à valider.</param>
        /// <returns>True si l'ISBN est valide, sinon False.</returns>
        private bool IsvalidISBN(string ISBN)
        {
            if (Regex.IsMatch(ISBN, @"^[d]{10}$") is false)
            {
                MessageBox.Show("Le champs ISBN n'est pas au bon format. (ex: 1234567891"); // Message pour non respect des regex
            }

            //Vérifie que le nom n'est pas null.
            return Regex.IsMatch(ISBN, @"^[d]{10}$"); // Applique la regex.    
        }

        /// <summary>
        /// Vérifie si la quantité fourni est valide.
        /// uniquement 3 digites.
        /// </summary>
        /// <param name="quantity">La quantité à valider.</param>
        /// <returns>True si La quantité est valide, sinon False.</returns>
        private bool IsvalidQuantity(string quantity)
        {
            if (Regex.IsMatch(quantity, @"^[d]{1,3}$") is false)
            {
                MessageBox.Show("Le champs quantité n'est pas au bon format. (ex: 124"); // Message pour non respect des regex
            }
            //Vérifie que le nom n'est pas null.
            return Regex.IsMatch(quantity, @"^[d]{1,3}$"); // Applique la regex.    
        }

=======
                return true; // Retourne vrai si null
            }
        }

>>>>>>> 94ee5fbb09a28a1a3fd652a4fe616578a6aa2a29


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

<<<<<<< HEAD
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

=======
>>>>>>> 94ee5fbb09a28a1a3fd652a4fe616578a6aa2a29


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

<<<<<<< HEAD
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



=======
>>>>>>> 94ee5fbb09a28a1a3fd652a4fe616578a6aa2a29

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
<<<<<<< HEAD

        /// <summary>
        /// Enregistre un nouveau livre dans la base de données s'il n'existe pas déjà,
        /// après validation du ISBN et de la date.
        /// </summary>
        public void CreatenewBook(string ISBN, string title, string date, string quantity)
        {
            // Vérifie que le prénom et le nom sont valides selon les règles définies
            if (IsvalidISBN(ISBN) && IsvalidDate(date))
            {
                // Création de la connexion à la base de données
                MySqlConnection databaseConnection = new MySqlConnection(myConnectionString);

                // Requête SQL : insère l'auteur seulement s'il n'existe pas déjà
                string query = @"
                    INSERT INTO t_livre (ISBN, titre, année de publication, quantité)
                    SELECT @Firstname, @Name
                    WHERE NOT EXISTS (
                    SELECT 1 FROM t_auteur
                    WHERE prénom = @Firstname OR nom = @Name
                    );";

                // Préparation de la commande avec les paramètres
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@ISBN", ISBN);
                commandDatabase.Parameters.AddWithValue("@Title", title);
                commandDatabase.Parameters.AddWithValue("@Date", date);
                commandDatabase.Parameters.AddWithValue("@Quantity", quantity);

                try
                {
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

                //MySqlDataReader reader;

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

                //MySqlDataReader reader;

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

            //MySqlDataReader reader;

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

            //MySqlDataReader reader;

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
            catch (Exception ex)
            {
                // Affiche une erreur en cas de problème
                MessageBox.Show(ex.Message);
            }

        }
=======
>>>>>>> 94ee5fbb09a28a1a3fd652a4fe616578a6aa2a29
    }
}
