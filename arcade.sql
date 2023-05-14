-- --------------------------------------------------------
-- Host:                         87.229.6.28
-- Server version:               10.10.3-MariaDB-1:10.10.3+maria~deb11 - mariadb.org binary distribution
-- Server OS:                    debian-linux-gnu
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
CREATE DATABASE IF NOT EXISTS `arcade` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `arcade`;

-- Dumping structure for table arcade.authsessions
CREATE TABLE IF NOT EXISTS `authsessions` (
  `AuthId` int(11) NOT NULL AUTO_INCREMENT,
  `AuthKey` varchar(96) NOT NULL,
  `UId` int(11) NOT NULL,
  `expire_date` datetime NOT NULL,
  PRIMARY KEY (`AuthId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table arcade.authsessions: ~0 rows (approximately)

-- Dumping structure for table arcade.games
CREATE TABLE IF NOT EXISTS `games` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `by` varchar(100) NOT NULL,
  `language` varchar(100) NOT NULL,
  `engine` varchar(100) NOT NULL,
  `updated` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table arcade.games: ~10 rows (approximately)
INSERT INTO `games` (`id`, `name`, `by`, `language`, `engine`, `updated`) VALUES
	(1, 'Snake Game - v1', 'Orosz Eszter', 'cs', '', '2023-01-27'),
	(2, 'Blackjack', 'Katona Roland', 'js', '', '2023-01-27'),
	(3, 'Python Quiz', 'Gyurkovics Dominik', 'py', '', '2023-01-30'),
	(4, 'Tank Trouble', 'Molnár-Horgos Kristóf, Vígh Noel, Horváth Péter Ákos', 'cs', 'unity', '2023-01-27'),
	(5, 'Catan', 'Dávid Benedek', 'py', '', '2023-02-01'),
	(6, 'Keeper Of The Gates - v1.6', 'Vajda Dániel', 'cs', 'unity', '2023-02-01'),
	(7, 'Repülős Projektmunka', 'Bábolnai Bence', 'js', '', '2023-02-07'),
	(8, 'Repülős Projektmunka', 'Suhajda Zsolt', 'cs', 'unity', '2023-02-07'),
	(9, 'Flappy Bird', 'Bárczi Bence', 'cs', 'MonoGame', '2023-02-14'),
	(10, 'Quoridor', 'Bárczi Bence', 'cs', 'MonoGame', '2023-02-14'),
	(11, 'Space Mem', 'Kósa Márk', 'c++', '', '2023-03-01');

-- Dumping structure for table arcade.ratings
CREATE TABLE IF NOT EXISTS `ratings` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `rating` int(11) DEFAULT NULL,
  `gameid` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table arcade.ratings: ~0 rows (approximately)

-- Dumping structure for table arcade.users
CREATE TABLE IF NOT EXISTS `users` (
  `UId` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(64) NOT NULL,
  `Email` varchar(64) NOT NULL,
  `Password` varchar(64) NOT NULL,
  `CreatedAt` datetime NOT NULL,
  PRIMARY KEY (`UId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
