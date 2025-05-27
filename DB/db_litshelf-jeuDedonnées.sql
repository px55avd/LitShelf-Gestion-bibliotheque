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
(34, 'Oda', 'Echiro');

-- --------------------------------------------------------

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
-- Déchargement des données de la table `t_livre`
--

INSERT INTO `t_livre` (`ISBN`, `titre`, `année_de_publication`, `quantité`) VALUES
('6436745576', 'Les Misérables', '1884', 1),
('7483938373', 'One piece - Volume 1', '1998', 1),
('9780140451', 'Les Misérables - Édition augmentée Deluxe', '1865', 2),
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
-- Déchargement des données de la table `écrire`
--

INSERT INTO `écrire` (`ISBN`, `auteur_id`) VALUES
('6436745576', 1),
('9780140451', 1),
('9782070368', 2),
('9782070382', 3),
('9782264056', 3),
('9782070409', 4),
('9782757843', 5),
('9782070360', 6),
('9782070361', 8),
('9782070412', 9),
('7483938373', 34);
-- --------------------------------------------------------

--
-- Déchargement des données de la table `t_exemplaire`
--

INSERT INTO `t_exemplaire` (`exemplaire_id`, `commentaire`, `ISBN`) VALUES
(1, 'Première édition, couverture rigide', '9780140451'),
(2, 'Edition poche', '9780140451'),
(3, 'Réimpression 2010', '9782070368'),
(4, 'Edition collector, signée par l’auteur', '9782264056'),
(5, 'Exemplaire annoté', '9782070409'),
(6, 'Livre abîmé, couverture usée', '9782757843'),
(7, 'Edition limitée', '9782070360'),
(9, 'Exemplaire réservé pour bibliothèque', '9782070361'),
(10, 'Couverture souple', '9782070382'),
(12, 'Réédition 2023', '9782070412'),
(29, 'Exemplaire 1', '7483938373'),
(30, 'Exemplaire ajouté 2', '9780140451');

--
-- Déchargement des données de la table `t_emprunt`
--

-- --------------------------------------------------------
INSERT INTO `t_emprunt` (`emprunt_id`, `date_emprunt`, `date_retour`, `client_id`, `exemplaire_id`) VALUES
(1, '2025-05-22', '2025-06-05', 5, 9),
(7, '2025-05-22', '2025-06-19', 5, 10),
(8, '2025-05-23', '2025-06-06', 3, 29);




