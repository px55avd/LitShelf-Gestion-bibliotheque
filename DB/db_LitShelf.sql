-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : db:3306
-- Généré le : ven. 16 mai 2025 à 13:57
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

-- --------------------------------------------------------

--
-- Structure de la table `t_auteur`
--

CREATE TABLE `t_auteur` (
  `auteur_id` int NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `prénom` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
(33, NULL, 'Félix');

-- --------------------------------------------------------

--
-- Structure de la table `t_client`
--

CREATE TABLE `t_client` (
  `client_id` int NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `prénom` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `t_client`
--

INSERT INTO `t_client` (`client_id`, `nom`, `prénom`) VALUES
(1, 'Egal', 'Omar'),
(3, 'Egal', 'Jean'),
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
(35, 'Pittet', 'Joel'),
(36, 'omar', 'Joel');

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `t_exemplaire`
--

CREATE TABLE `t_exemplaire` (
  `exemplaire_id` int NOT NULL,
  `commentaire` text,
  `ISBN` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `t_livre`
--

CREATE TABLE `t_livre` (
  `ISBN` varchar(10) NOT NULL,
  `titre` varchar(255) DEFAULT NULL,
  `année_de_publication` date DEFAULT NULL,
  `quantité` smallint DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `écrire`
--

CREATE TABLE `écrire` (
  `ISBN` varchar(10) NOT NULL,
  `auteur_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
  ADD KEY `ISBN` (`ISBN`);

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
  MODIFY `auteur_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT pour la table `t_client`
--
ALTER TABLE `t_client`
  MODIFY `client_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT pour la table `t_emprunt`
--
ALTER TABLE `t_emprunt`
  MODIFY `emprunt_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `t_exemplaire`
--
ALTER TABLE `t_exemplaire`
  MODIFY `exemplaire_id` int NOT NULL AUTO_INCREMENT;

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
  ADD CONSTRAINT `t_exemplaire_ibfk_1` FOREIGN KEY (`ISBN`) REFERENCES `t_livre` (`ISBN`);

--
-- Contraintes pour la table `écrire`
--
ALTER TABLE `écrire`
  ADD CONSTRAINT `écrire_ibfk_1` FOREIGN KEY (`ISBN`) REFERENCES `t_livre` (`ISBN`),
  ADD CONSTRAINT `écrire_ibfk_2` FOREIGN KEY (`auteur_id`) REFERENCES `t_auteur` (`auteur_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
