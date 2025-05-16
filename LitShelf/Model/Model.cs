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

        // Prepare the connection
        private string myConnectionString = "datasource=localhost;port=6033;username=root;password=root;database=db_LitShelf;";
        private MySqlConnection myConnection;

        //variables privées
        private int _lineClient;
        private int _lineAuthor;

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
            return Regex.IsMatch(firstname, @"^[A-Za-zÀ-ÖØ-öø-ÿ\-\'\s]{2,50}$");
        }

        /// <summary>
        /// Vérifie si le nom fourni est valide.
        /// uniquement lettres (avec accents), tirets, apostrophes ou espaces, et une longueur de 2 à 50 caractères.
        /// </summary>
        /// <param name="name">Le nom à valider.</param>
        /// <returns>True si le nom est valide, sinon False.</returns>
        private bool IsvalidName(string name)
        {
            return Regex.IsMatch(name, @"^[A-Za-zÀ-ÖØ-öø-ÿ\-\'\s]{2,50}$");
        }

        /// <summary>
        /// Récupère le nombre de clients dans la base de données et le stocke dans _lineClient.
        /// </summary>
        private void GetclientCount()
        {
            myConnection = new MySqlConnection(myConnectionString);

            string query = "SELECT COUNT(t_client.client_id) FROM t_client;";

            MySqlCommand commandDatabase = new MySqlCommand(query, myConnection); ;
            MySqlDataReader reader;

            //Compteur
            int count = 0;

            try
            {
                // Open the database
                myConnection.Open();

                // Execute la requète
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                }

                // Finally close the connection     
                reader.Close();
                myConnection.Close();

            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show($"Échec de la connexion : {ex.Message}");
            }

            _lineClient = count;
        }




        /// <summary>
        /// Récupère toutes les données de la table t_client depuis la base de données,
        /// et les retourne sous forme d’un tableau à deux dimensions (string[,]).
        /// </summary>
        /// <returns>Un tableau contenant les données utilisateur (id, nom, etc.).</returns>
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

                data = new string[_lineClient, reader.FieldCount]; // Crée un tableau avec [_lineClient] lignes et autant de colonnes que de champs

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
                    commandDatabase.ExecuteReader(); // Exécute la commande

                    MessageBox.Show("Client enregistré avec succès !");
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
                    WHERE prénom = @Firstname AND nom = @Name
                    );";

                // Préparation de la commande avec les paramètres
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@Firstname", firstname);
                commandDatabase.Parameters.AddWithValue("@Name", name);

                try
                {
                    databaseConnection.Open();
                    commandDatabase.ExecuteReader(); // Exécute la commande

                    MessageBox.Show("Client enregistré avec succès !");
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
    }
}
