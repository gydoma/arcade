-- --------------------------------------------------------
-- Host:                         87.229.6.28
-- Server version:               8.0.32 - MySQL Community Server - GPL
-- Server OS:                    Linux
-- HeidiSQL Version:             12.3.0.6589
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for arcade
CREATE DATABASE IF NOT EXISTS `arcade` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `arcade`;

-- Dumping structure for table arcade.authsessions
CREATE TABLE IF NOT EXISTS `authsessions` (
  `AuthId` int NOT NULL AUTO_INCREMENT,
  `AuthKey` varchar(96) COLLATE utf8mb4_general_ci NOT NULL,
  `UId` int NOT NULL,
  `expire_date` datetime NOT NULL,
  PRIMARY KEY (`AuthId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table arcade.authsessions: ~0 rows (approximately)

-- Dumping structure for table arcade.games
CREATE TABLE IF NOT EXISTS `games` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `by` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `language` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `engine` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `updated` date NOT NULL,
  `url` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `download` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table arcade.games: ~10 rows (approximately)
INSERT INTO `games` (`id`, `name`, `description`, `by`, `language`, `engine`, `updated`, `url`, `download`) VALUES
	(1, 'Snake Game - v1', "A játék a Snake játékot próbálja megvalósítani. A játék célja, hogy a kígyót a falakon és a saját magán kívül ellenőrzött irányba mozgatva a lehető legtöbb gyümölcsöt megegye. A játékot a nyilak segítségével lehet irányítani. A játék véget ér, ha a kígyó a falba ütközik vagy a saját magába ütközik.", 'Orosz Eszter', 'cs', '', '2023-01-27', NULL, 1),
	(2, 'Blackjack', "A játék célja, hogy a játékosnak 21 pontot kell elérnie. A játékosnak 2 lapja van, amelyeket a lapokat kattintva tudja látni. A lapokat kattintva a játékosnak lehetősége van új lapot kapni, vagy leállni", 'Katona Roland', 'js', '', '2023-01-27', '../Games/Javascript/Blackjack/index.html', 0),
	(3, 'Python Quiz', NULL, 'Gyurkovics Dominik', 'py', '', '2023-01-30', NULL, 1),
	(4, 'Tank Trouble', NULL, 'Molnár-Horgos Kristóf, Vígh Noel, Horváth Péter Ákos', 'cs', 'unity', '2023-01-27', NULL, 1),
	(5, 'Catan', NULL, 'Dávid Benedek', 'py', '', '2023-02-01', NULL, 1),
	(6, 'Keeper Of The Hates - v1.6', NULL, 'Vajda Dániel', 'cs', 'unity', '2023-02-01', NULL, 1),
	(7, 'Repülős Projektmunka', NULL, 'Bábolnai Bence', 'js', '', '2023-02-07', NULL, 0),
	(8, 'Repülős Projektmunka', NULL, 'Suhajda Zsolt', 'cs', 'unity', '2023-02-07', NULL, 1),
	(9, 'Flappy Bird', NULL, 'Bárczi Bence', 'cs', 'MonoGame', '2023-02-14', NULL, 1),
	(10, 'Quoridor', NULL, 'Bárczi Bence', 'cs', 'MonoGame', '2023-02-14', NULL, 1),
	(11, 'Tic Tac Toe', "A játék célja, hogy a játékosok egymás ellen játszanak. A játékosoknak 3x3-as táblán kell elhelyezniük a saját jelüket. A játék akkor ér véget, ha valamelyik játékosnak sikerül 3 jelét egymás mellett elhelyeznie. A játékot a nyilak segítségével lehet irányítani. A játék véget ér, ha a kígyó a falba ütközik vagy a saját magába ütközik.", 'gydoma', 'js', '', '2023-02-14', NULL, 1),
	(12, 'Space Mem', NULL, 'Kósa Márk', 'cpp', '', '2023-03-29', NULL, 1);

-- Dumping structure for table arcade.ratings
CREATE TABLE IF NOT EXISTS `ratings` (
  `id` int NOT NULL AUTO_INCREMENT,
  `rating` int DEFAULT NULL,
  `gameid` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table arcade.ratings: ~3 rows (approximately)
INSERT INTO `ratings` (`id`, `rating`, `gameid`) VALUES
	(1, 5, 1),
	(2, 3, 1),
	(3, 1, 5);

-- Dumping structure for table arcade.users
CREATE TABLE IF NOT EXISTS `users` (
  `UId` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(64) COLLATE utf8mb4_general_ci NOT NULL,
  `Email` varchar(64) COLLATE utf8mb4_general_ci NOT NULL,
  `Password` varchar(64) COLLATE utf8mb4_general_ci NOT NULL,
  `CreatedAt` datetime NOT NULL,
  PRIMARY KEY (`UId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table arcade.users: ~0 rows (approximately)

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
