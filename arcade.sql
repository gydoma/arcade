-- phpMyAdmin SQL Dump
-- version 4.9.10
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: May 24, 2023 at 12:24 AM
-- Server version: 10.5.18-MariaDB-0+deb11u1
-- PHP Version: 7.4.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `c1752_arcade`
--

-- --------------------------------------------------------

--
-- Table structure for table `active_sessions`
--

CREATE TABLE `active_sessions` (
  `Id` int(11) NOT NULL,
  `UId` int(11) NOT NULL,
  `Time` int(11) NOT NULL,
  `Date` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `active_sessions`
--

INSERT INTO `active_sessions` (`Id`, `UId`, `Time`, `Date`) VALUES
(1, 2, 14, '2023-05-13'),
(2, 2, 15, '2023-05-14'),
(3, 2, 122, '2023-05-15'),
(111, 2, 86, '2023-05-16'),
(112, 2, 29, '2023-05-17'),
(113, 2, 1, '2023-05-17'),
(114, 2, 94, '2023-05-18'),
(115, 2, 14, '2023-05-24');

-- --------------------------------------------------------

--
-- Table structure for table `authsessions`
--

CREATE TABLE `authsessions` (
  `AuthId` int(11) NOT NULL,
  `AuthKey` varchar(96) NOT NULL,
  `UId` int(11) NOT NULL,
  `expire_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `authsessions`
--

INSERT INTO `authsessions` (`AuthId`, `AuthKey`, `UId`, `expire_date`) VALUES
(11, 'RsbOdYJp1WPewqO0RbX/NbBrLYAc8bVGIjtrhwbDZLE=', 2, '2023-05-21 21:32:19'),
(12, 'RrxBDcdTS0MsrMD8ZldmDkFw7d5ZICTi3ALiUlaUZEA=', 2, '2023-05-21 21:53:09'),
(13, 'ThqjhvxkHhYHxvLT0SDzLi+/XbNfuYcCFPizocAwO7s=', 3, '2023-05-21 22:57:59'),
(14, '5zujPSssF9r2HmYrHlgf9JB4a6v0FtwMQuN27OBgxTU=', 3, '2023-05-22 00:41:36'),
(15, '5obgQeR93KRb3yBbSA31U3FP1eeeWFktV6s8MfPXEOo=', 2, '2023-05-22 20:04:01'),
(16, 'l8E06i3Tzzl6LW9rCQMqhsfTCaGLA2vYsaJA3POl/Ls=', 2, '2023-05-30 23:42:26');

-- --------------------------------------------------------

--
-- Table structure for table `games`
--

CREATE TABLE `games` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `by` varchar(100) NOT NULL,
  `language` varchar(100) NOT NULL,
  `engine` varchar(100) NOT NULL,
  `updated` date NOT NULL,
  `url` varchar(100) DEFAULT NULL,
  `download` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `games`
--

INSERT INTO `games` (`id`, `name`, `description`, `by`, `language`, `engine`, `updated`, `url`, `download`) VALUES
(1, 'Snake Game - v1', 'A játék a Snake játékot próbálja megvalósítani. A játék célja, hogy a kígyót a falakon és a saját magán kívül ellenőrzött irányba mozgatva a lehető legtöbb gyümölcsöt megegye. A játékot a nyilak segítségével lehet irányítani. A játék véget ér, ha a kígyó ', 'Orosz Eszter', 'cs', '', '2023-01-27', NULL, 1),
(2, 'Blackjack', 'A játék célja, hogy a játékosnak 21 pontot kell elérnie. A játékosnak 2 lapja van, amelyeket a lapokat kattintva tudja látni. A lapokat kattintva a játékosnak lehetősége van új lapot kapni, vagy leállni', 'Katona Roland', 'js', '', '2023-01-27', '../Games/Javascript/Blackjack/index.html', 0),
(3, 'Python Quiz', NULL, 'Gyurkovics Dominik', 'py', '', '2023-01-30', NULL, 1),
(4, 'Tank Trouble', NULL, 'Molnár-Horgos Kristóf, Vígh Noel, Horváth Péter Ákos', 'cs', 'unity', '2023-01-27', NULL, 1),
(5, 'Catan', NULL, 'Dávid Benedek', 'py', '', '2023-02-01', NULL, 1),
(6, 'Keeper Of The Gates - v1.6', NULL, 'Vajda Dániel', 'cs', 'unity', '2023-02-01', NULL, 1),
(7, 'Repülős Projektmunka', NULL, 'Bábolnai Bence', 'js', '', '2023-02-07', NULL, 0),
(8, 'Repülős Projektmunka', NULL, 'Suhajda Zsolt', 'cs', 'unity', '2023-02-07', NULL, 1),
(9, 'Flappy Bird', NULL, 'Bárczi Bence', 'cs', 'MonoGame', '2023-02-14', NULL, 1),
(10, 'Quoridor', NULL, 'Bárczi Bence', 'cs', 'MonoGame', '2023-02-14', NULL, 1),
(11, 'Tic Tac Toe', 'A játék célja, hogy a játékosok egymás ellen játszanak. A játékosoknak 3x3-as táblán kell elhelyezniük a saját jelüket. A játék akkor ér véget, ha valamelyik játékosnak sikerül 3 jelét egymás mellett elhelyeznie. A játékot a nyilak segítségével lehet irán', 'gydoma', 'js', '', '2023-02-14', NULL, 1),
(12, 'Space Mem', NULL, 'Kósa Márk', 'cpp', '', '2023-03-29', NULL, 1);

-- --------------------------------------------------------

--
-- Table structure for table `ratings`
--

CREATE TABLE `ratings` (
  `id` int(11) NOT NULL,
  `rating` int(11) DEFAULT NULL,
  `gameid` int(11) DEFAULT NULL,
  `UId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ratings`
--

INSERT INTO `ratings` (`id`, `rating`, `gameid`, `UId`) VALUES
(1, 5, 1, 0),
(2, 3, 1, 0),
(3, 1, 5, 0),
(5, 5, 1, 2),
(6, 5, 5, 2);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UId` int(11) NOT NULL,
  `Username` varchar(64) NOT NULL,
  `Email` varchar(64) NOT NULL,
  `Password` varchar(64) NOT NULL,
  `CreatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UId`, `Username`, `Email`, `Password`, `CreatedAt`) VALUES
(2, 'teszt', 'teszt@gmail.com', '81de960c94c9174ed73e6ea967fcf16e', '2023-05-14 21:32:02'),
(3, 'teszt2', 'teszt2@gmail.com', '83dc3c89e1abf7a58d35c87599f1b3bc', '2023-05-14 22:57:55');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `active_sessions`
--
ALTER TABLE `active_sessions`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `authsessions`
--
ALTER TABLE `authsessions`
  ADD PRIMARY KEY (`AuthId`);

--
-- Indexes for table `games`
--
ALTER TABLE `games`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `ratings`
--
ALTER TABLE `ratings`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `active_sessions`
--
ALTER TABLE `active_sessions`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=116;

--
-- AUTO_INCREMENT for table `authsessions`
--
ALTER TABLE `authsessions`
  MODIFY `AuthId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `games`
--
ALTER TABLE `games`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `ratings`
--
ALTER TABLE `ratings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
