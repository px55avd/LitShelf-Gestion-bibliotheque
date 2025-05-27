/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `db_LitShelf`
--
CREATE DATABASE IF NOT EXISTS `db_litshelf` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `db_litshelf`;

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

CREATE DEFINER=`root`@`%` PROCEDURE `ModifierLivreEtExemplaires` (IN `p_ISBN_original` VARCHAR(13), IN `p_ISBN` VARCHAR(13), IN `p_titre` VARCHAR(255), IN `p_annee` INT, IN `p_auteur_id` INT, IN `p_auteur_id_old` INT, IN `p_nouvelle_quantite` INT, OUT `p_message` VARCHAR(255))   BEGIN
    DECLARE qte_actuelle INT DEFAULT 0;
    DECLARE diff INT DEFAULT 0;
    DECLARE i INT DEFAULT 1;

    -- Début du bloc pour pouvoir utiliser LEAVE
    main_block: BEGIN

        -- Récupérer la quantité actuelle
        SELECT quantité INTO qte_actuelle
        FROM t_livre
        WHERE ISBN = p_ISBN_original;

        -- CAS 1 : L'ISBN ne change pas
        IF p_ISBN = p_ISBN_original THEN
            -- Mise à jour du livre
            UPDATE t_livre
            SET titre = p_titre,
                année_de_publication = p_annee
            WHERE ISBN = p_ISBN;

            -- Mise à jour de l'auteur si besoin
            UPDATE écrire
            SET auteur_id = p_auteur_id
            WHERE ISBN = p_ISBN AND auteur_id = p_auteur_id_old;

            -- Ajouter des exemplaires si besoin
            IF p_nouvelle_quantite > qte_actuelle THEN
                SET diff = p_nouvelle_quantite - qte_actuelle;
                WHILE i <= diff DO
                    INSERT INTO t_exemplaire (commentaire, ISBN)
                    VALUES (CONCAT('Exemplaire ajouté ', qte_actuelle + i), p_ISBN);
                    SET i = i + 1;
                END WHILE;

                UPDATE t_livre
                SET quantité = p_nouvelle_quantite
                WHERE ISBN = p_ISBN;

                SET p_message = CONCAT('Livre mis à jour. ', diff, ' exemplaires ajoutés.');
            ELSE
                SET p_message = 'Livre mis à jour. Quantité inchangée.';
            END IF;

        -- CAS 2 : L'ISBN change
        ELSE
            -- Vérifier si le nouvel ISBN existe déjà
            IF EXISTS (
                SELECT 1 FROM t_livre WHERE ISBN = p_ISBN
            ) THEN
                SET p_message = 'Erreur : le nouvel ISBN existe déjà.';
                LEAVE main_block;
            END IF;

            -- Insérer le nouveau livre avec l'ancienne quantité
            INSERT INTO t_livre (ISBN, titre, année_de_publication, quantité)
            VALUES (p_ISBN, p_titre, p_annee, qte_actuelle);

            -- Mettre à jour écrire
            UPDATE écrire
            SET ISBN = p_ISBN, auteur_id = p_auteur_id
            WHERE ISBN = p_ISBN_original AND auteur_id = p_auteur_id_old;

            -- Mettre à jour les exemplaires
            UPDATE t_exemplaire
            SET ISBN = p_ISBN
            WHERE ISBN = p_ISBN_original;

            -- Supprimer l'ancien livre
            DELETE FROM t_livre WHERE ISBN = p_ISBN_original;

            -- Ajouter des exemplaires si besoin
            IF p_nouvelle_quantite > qte_actuelle THEN
                SET diff = p_nouvelle_quantite - qte_actuelle;
                WHILE i <= diff DO
                    INSERT INTO t_exemplaire (commentaire, ISBN)
                    VALUES (CONCAT('Exemplaire ajouté ', qte_actuelle + i), p_ISBN);
                    SET i = i + 1;
                END WHILE;

                UPDATE t_livre
                SET quantité = p_nouvelle_quantite
                WHERE ISBN = p_ISBN;

                SET p_message = CONCAT('ISBN modifié. Quantité mise à jour à ', p_nouvelle_quantite, ' avec ', diff, ' exemplaires ajoutés.');
            ELSE
                SET p_message = 'ISBN modifié. Quantité inchangée.';
            END IF;

        END IF;
    END main_block;
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

-- --------------------------------------------------------

--
-- Structure de la table `t_client`
--

CREATE TABLE `t_client` (
  `client_id` int NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `prénom` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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

-- --------------------------------------------------------

--
-- Structure de la table `t_exemplaire`
--

CREATE TABLE `t_exemplaire` (
  `exemplaire_id` int NOT NULL,
  `commentaire` text,
  `ISBN` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


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

-- --------------------------------------------------------

--
-- Structure de la table `écrire`
--

CREATE TABLE `écrire` (
  `ISBN` varchar(10) NOT NULL,
  `auteur_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


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
  MODIFY `emprunt_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT pour la table `t_exemplaire`
--
ALTER TABLE `t_exemplaire`
  MODIFY `exemplaire_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

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
