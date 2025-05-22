-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : db:3306
-- Généré le : jeu. 22 mai 2025 à 14:01
-- Version du serveur : 9.1.0
-- Version de PHP : 8.0.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `db_LitShelf`
--
CREATE DATABASE IF NOT EXISTS `db_LitShelf` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `db_LitShelf`;

DELIMITER $$
--
-- Procédures
--
CREATE DEFINER=`root`@`%` PROCEDURE `AjouterLivreAvecExemplaires` (IN `p_ISBN` VARCHAR(10), IN `p_titre` VARCHAR(255), IN `p_annee` VARCHAR(4), IN `p_quantite` INT, IN `p_auteur_id` INT)   BEGIN
    DECLARE i INT DEFAULT 1;

    -- Insérer le livre
    INSERT INTO t_livre (ISBN, titre, année_de_publication, quantité)
    VALUES (p_ISBN, p_titre, p_annee, p_quantite);

    -- Associer l'auteur
    INSERT INTO écrire (ISBN, auteur_id)
    VALUES (p_ISBN, p_auteur_id);

    -- Boucle pour insérer les exemplaires
    WHILE i <= p_quantite DO
        INSERT INTO t_exemplaire (commentaire, ISBN)
        VALUES (CONCAT('Exemplaire ', i), p_ISBN);
        SET i = i + 1;
    END WHILE;
END$$

CREATE DEFINER=`root`@`%` PROCEDURE `ModifierLivreEtExemplaires` (IN `p_ISBN` VARCHAR(10), IN `p_titre` VARCHAR(255), IN `p_annee` VARCHAR(4), IN `p_nouvelle_quantite` INT, OUT `p_message` VARCHAR(255))   BEGIN
    DECLARE qte_actuelle INT DEFAULT 0;
    DECLARE diff INT DEFAULT 0;
    DECLARE i INT;

    -- Récupérer la quantité actuelle
    SELECT quantité INTO qte_actuelle FROM t_livre WHERE ISBN = p_ISBN;

    -- Mettre à jour titre et année
    UPDATE t_livre
    SET titre = p_titre,
        année_de_publication = p_annee
    WHERE ISBN = p_ISBN;

    -- Vérifier si la quantité doit être augmentée
    IF p_nouvelle_quantite > qte_actuelle THEN
        SET diff = p_nouvelle_quantite - qte_actuelle;

        -- Mettre à jour la quantité
        UPDATE t_livre
        SET quantité = p_nouvelle_quantite
        WHERE ISBN = p_ISBN;

        -- Insérer les exemplaires supplémentaires
        SET i = 1;
        WHILE i <= diff DO
            INSERT INTO t_exemplaire (commentaire, ISBN)
            VALUES (CONCAT('Exemplaire ajouté ', qte_actuelle + i), p_ISBN);
            SET i = i + 1;
        END WHILE;

        SET p_message = CONCAT('Quantité mise à jour à ', p_nouvelle_quantite, ' et ', diff, ' exemplaires ajoutés.');
    ELSE
        SET p_message = 'Quantité inchangée. Aucun exemplaire ajouté. La quantité ne peut diminuer';
    END IF;
END$$

CREATE DEFINER=`root`@`%` PROCEDURE `SupprimerLivre` (IN `p_ISBN` VARCHAR(10), OUT `p_message` VARCHAR(255))   BEGIN
    DECLARE nb_emprunts INT;

    SELECT COUNT(*) INTO nb_emprunts
    FROM t_emprunt
    WHERE exemplaire_id IN (
        SELECT exemplaire_id FROM t_exemplaire WHERE ISBN = p_ISBN
    );

    IF nb_emprunts > 0 THEN
        SET p_message = 'Impossible de supprimer ce livre : des exemplaires sont actuellement empruntés.';
    ELSE
        DELETE FROM t_exemplaire WHERE ISBN = p_ISBN;
        DELETE FROM t_livre WHERE ISBN = p_ISBN;
        SET p_message = 'Livre et exemplaires supprimés avec succès.';
    END IF;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `t_auteur`
--

CREATE TABLE `t_auteur` (
  `auteur_id` int NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `prénom` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_auteur`
--

INSERT INTO `t_auteur` (`auteur_id`, `nom`, `prénom`) VALUES
(1, 'Hugo', 'Victor'),
(2, 'Saint-Exupéry', 'Antoine de'),
(3, 'Camus', 'Albert'),
(4, 'Voltaire', ''),
(5, 'Stendhal', 'Henri'),
(6, 'Flaubert', 'Gustave'),
(7, 'Zola', 'Émile'),
(8, 'Baudelaire', 'Charles'),
(9, 'Proust', 'Marcel'),
(10, 'Dumas', 'Alexandre'),
(11, 'Balzac', 'Honoré de'),
(12, 'Maupassant', 'Guy de'),
(13, 'Rimbaud', 'Arthur'),
(14, 'Verne', 'Jules'),
(15, 'Colette', ''),
(16, 'Sartre', 'Jean-Paul'),
(17, 'Beckett', 'Samuel'),
(18, 'Molière', ''),
(19, 'La Fontaine', 'Jean de'),
(20, 'Nerval', 'Gérard de'),
(21, 'Chateaubriand', 'François-René'),
(22, 'Apollinaire', 'Guillaume'),
(23, 'Rousseau', 'Jean-Jacques'),
(24, 'Pagnol', 'Marcel'),
(25, 'Yourcenar', 'Marguerite'),
(26, 'Duras', 'Marguerite'),
(27, 'Modiano', 'Patrick'),
(28, 'Cocteau', 'Jean'),
(29, 'Sarrazin', 'Lucie'),
(30, 'Delacroix', 'Émile'),
(31, 'Villon', 'François'),
(32, 'Egal Ahmed', 'Omar'),
(34, 'Oda', 'Echiro');

-- --------------------------------------------------------

--
-- Structure de la table `t_client`
--

CREATE TABLE `t_client` (
  `client_id` int NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `prénom` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_client`
--

INSERT INTO `t_client` (`client_id`, `nom`, `prénom`) VALUES
(3, 'Tille', 'Marc'),
(4, 'Dupont', 'Marie'),
(5, 'Martin', 'Jean'),
(6, 'Bernard', 'Sophie'),
(7, 'Petit', 'Lucas'),
(8, 'Robert', 'Emma'),
(9, 'Richard', 'Paul'),
(10, 'Durand', 'Julie'),
(11, 'Moreau', 'Nicolas'),
(12, 'Simon', 'Claire'),
(13, 'Laurent', 'Thomas'),
(14, 'Lemoine', 'Alice'),
(15, 'Roux', 'Julien'),
(16, 'Faure', 'Camille'),
(17, 'Blanc', 'Maxime'),
(18, 'Garnier', 'Chloé'),
(19, 'Chevalier', 'Antoine'),
(20, 'Lopez', 'Manon'),
(21, 'Fontaine', 'Lucas'),
(22, 'Barbier', 'Sarah'),
(23, 'Meyer', 'Adrien'),
(24, 'Leroy', 'Eva'),
(25, 'Colin', 'Mathieu'),
(26, 'Guillaume', 'Laura'),
(27, 'Poirier', 'Benoît'),
(28, 'Andre', 'Julie'),
(29, 'Benoit', 'Hugo'),
(30, 'Marchand', 'Léa'),
(31, 'Fernandez', 'Simon'),
(32, 'Henry', 'Nina'),
(33, 'Gauthier', 'Louis'),
(34, 'Sierro', 'Félix '),
(35, 'Pittet', 'Joel');

-- --------------------------------------------------------

--
-- Structure de la table `t_emprunt`
--

CREATE TABLE `t_emprunt` (
  `emprunt_id` int NOT NULL,
  `date_emprunt` date DEFAULT NULL,
  `date_retour` date DEFAULT NULL,
  `client_id` int NOT NULL,
  `exemplaire_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_emprunt`
--

INSERT INTO `t_emprunt` (`emprunt_id`, `date_emprunt`, `date_retour`, `client_id`, `exemplaire_id`) VALUES
(1, '2025-05-22', '2025-05-05', 5, 9),
(7, '2025-05-22', '2025-06-05', 7, 10);

-- --------------------------------------------------------

--
-- Structure de la table `t_exemplaire`
--

CREATE TABLE `t_exemplaire` (
  `exemplaire_id` int NOT NULL,
  `commentaire` text,
  `ISBN` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_exemplaire`
--

INSERT INTO `t_exemplaire` (`exemplaire_id`, `commentaire`, `ISBN`) VALUES
(1, 'Première édition, couverture rigide', '9780140449'),
(2, 'Edition poche', '9780140449'),
(3, 'Réimpression 2010', '9782070368'),
(4, 'Edition collector, signée par l’auteur', '9782264056'),
(5, 'Exemplaire annoté', '9782070409'),
(6, 'Livre abîmé, couverture usée', '9782757843'),
(7, 'Edition limitée', '9782070360'),
(9, 'Exemplaire réservé pour bibliothèque', '9782070361'),
(10, 'Couverture souple', '9782070382'),
(12, 'Réédition 2023', '9782070412'),
(25, 'Exemplaire 1', '1234567890'),
(26, 'Exemplaire ajouté 2', '1234567890');

-- --------------------------------------------------------

--
-- Structure de la table `t_livre`
--

CREATE TABLE `t_livre` (
  `ISBN` varchar(10) NOT NULL,
  `titre` varchar(255) DEFAULT NULL,
  `année_de_publication` varchar(4) DEFAULT NULL,
  `quantité` tinyint DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_livre`
--

INSERT INTO `t_livre` (`ISBN`, `titre`, `année_de_publication`, `quantité`) VALUES
('1234567890', 'la Bête Humaie', '1912', 2),
('6436745576', 'Les Misérables', '1884', 1),
('9780140449', 'Les Misérables', '1862', 1),
('9782070360', 'Madame Bovary', '1857', 1),
('9782070361', 'Les Fleurs du mal', '1857', 1),
('9782070368', 'Le Petit Prince', '1943', 1),
('9782070382', 'La Peste', '1947', 1),
('9782070409', 'Candide', '1759', 1),
('9782070412', 'À la recherche du temps perdu', '1913', 1),
('9782264056', 'L’Étranger', '1942', 1),
('9782757843', 'Le Rouge et le Noir', '1830', 1);

-- --------------------------------------------------------

--
-- Structure de la table `écrire`
--

CREATE TABLE `écrire` (
  `ISBN` varchar(10) NOT NULL,
  `auteur_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `écrire`
--

INSERT INTO `écrire` (`ISBN`, `auteur_id`) VALUES
('6436745576', 1),
('9780140449', 1),
('9782070368', 2),
('9782070382', 3),
('9782264056', 3),
('9782070409', 4),
('9782757843', 5),
('9782070360', 6),
('1234567890', 7),
('9782070361', 8),
('9782070412', 9);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `t_auteur`
--
ALTER TABLE `t_auteur`
  ADD PRIMARY KEY (`auteur_id`);

--
-- Index pour la table `t_client`
--
ALTER TABLE `t_client`
  ADD PRIMARY KEY (`client_id`);

--
-- Index pour la table `t_emprunt`
--
ALTER TABLE `t_emprunt`
  ADD PRIMARY KEY (`emprunt_id`),
  ADD KEY `client_id` (`client_id`),
  ADD KEY `exemplaire_id` (`exemplaire_id`);

--
-- Index pour la table `t_exemplaire`
--
ALTER TABLE `t_exemplaire`
  ADD PRIMARY KEY (`exemplaire_id`),
  ADD KEY `fk_exemplaire_livre` (`ISBN`);

--
-- Index pour la table `t_livre`
--
ALTER TABLE `t_livre`
  ADD PRIMARY KEY (`ISBN`);

--
-- Index pour la table `écrire`
--
ALTER TABLE `écrire`
  ADD PRIMARY KEY (`ISBN`,`auteur_id`),
  ADD KEY `auteur_id` (`auteur_id`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `t_auteur`
--
ALTER TABLE `t_auteur`
  MODIFY `auteur_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT pour la table `t_client`
--
ALTER TABLE `t_client`
  MODIFY `client_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT pour la table `t_emprunt`
--
ALTER TABLE `t_emprunt`
  MODIFY `emprunt_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT pour la table `t_exemplaire`
--
ALTER TABLE `t_exemplaire`
  MODIFY `exemplaire_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `t_emprunt`
--
ALTER TABLE `t_emprunt`
  ADD CONSTRAINT `t_emprunt_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `t_client` (`client_id`),
  ADD CONSTRAINT `t_emprunt_ibfk_2` FOREIGN KEY (`exemplaire_id`) REFERENCES `t_exemplaire` (`exemplaire_id`);

--
-- Contraintes pour la table `t_exemplaire`
--
ALTER TABLE `t_exemplaire`
  ADD CONSTRAINT `fk_exemplaire_livre` FOREIGN KEY (`ISBN`) REFERENCES `t_livre` (`ISBN`) ON DELETE CASCADE,
  ADD CONSTRAINT `t_exemplaire_ibfk_1` FOREIGN KEY (`ISBN`) REFERENCES `t_livre` (`ISBN`);

--
-- Contraintes pour la table `écrire`
--
ALTER TABLE `écrire`
  ADD CONSTRAINT `fk_ecrire_livre` FOREIGN KEY (`ISBN`) REFERENCES `t_livre` (`ISBN`) ON DELETE CASCADE,
  ADD CONSTRAINT `écrire_ibfk_1` FOREIGN KEY (`ISBN`) REFERENCES `t_livre` (`ISBN`),
  ADD CONSTRAINT `écrire_ibfk_2` FOREIGN KEY (`auteur_id`) REFERENCES `t_auteur` (`auteur_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
