-- phpMyAdmin SQL Dump
-- version 4.8.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 25, 2018 at 04:59 PM
-- Server version: 10.1.33-MariaDB
-- PHP Version: 7.2.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `projekat1`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `ID` int(2) NOT NULL,
  `USER` varchar(30) NOT NULL,
  `PASSWORD` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`ID`, `USER`, `PASSWORD`) VALUES
(1, 'admin', 'admin'),
(2, 'Dragana', '123456789');

-- --------------------------------------------------------

--
-- Table structure for table `arhiva`
--

CREATE TABLE `arhiva` (
  `ID` int(11) NOT NULL,
  `IME` varchar(30) NOT NULL,
  `PREZIME` varchar(30) NOT NULL,
  `MATICNI_BROJ` varchar(20) NOT NULL,
  `MJESTO_STANOVANJA` varchar(50) NOT NULL,
  `BROJ_TELEFONA` varchar(20) NOT NULL,
  `DOM` int(11) NOT NULL,
  `PAVILJON` varchar(2) NOT NULL,
  `SOBA` int(11) NOT NULL,
  `USLUGA` varchar(20) NOT NULL,
  `DATUM_ZADUZIVANJA` date NOT NULL,
  `DATUM_RAZDUZENJA` date NOT NULL,
  `GODINA_UPOTREBE` varchar(10) NOT NULL,
  `FAKULTET` varchar(30) NOT NULL,
  `GODINA` int(11) NOT NULL,
  `KOMENTAR` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `arhiva`
--

INSERT INTO `arhiva` (`ID`, `IME`, `PREZIME`, `MATICNI_BROJ`, `MJESTO_STANOVANJA`, `BROJ_TELEFONA`, `DOM`, `PAVILJON`, `SOBA`, `USLUGA`, `DATUM_ZADUZIVANJA`, `DATUM_RAZDUZENJA`, `GODINA_UPOTREBE`, `FAKULTET`, `GODINA`, `KOMENTAR`) VALUES
(1, 'Stefan', 'Nikolic', '7694821973405', 'Beograd', '0687548115', 2, 'M', 1, 'Hrana i soba', '2016-10-01', '2017-06-08', '2016/2017', 'ETF', 2, NULL),
(2, 'Nikola', 'Nikolic', '7694821973405', 'Beograd', '0687548115', 2, 'M', 1, 'Hrana i soba', '2016-10-01', '2017-06-08', '2016/2017', 'ETF', 2, NULL),
(3, 'Ranko', 'Rajic', '0131821213405', 'Beograd', '0687548115', 1, 'M', 1, 'Hrana i soba', '2016-10-01', '2017-06-08', '2016/2017', 'ETF', 2, NULL),
(4, 'Andrej', 'Sovjet', '7001122344556', 'Beograd', '0687548115', 2, 'M', 1, 'Hrana i soba', '2016-10-01', '2017-06-08', '2016/2017', 'ETF', 2, NULL),
(5, 'Ana', 'Anic', '0101999121212', 'Beograd', '0687548115', 2, 'Z', 4, 'Hrana i soba', '2016-10-01', '2017-06-08', '2016/2017', 'ETF', 4, NULL),
(6, 'Stefan', 'Nikolic', '7694821973405', 'Beograd', '0687548115', 2, 'M', 1, 'Hrana i soba', '2017-09-12', '2018-05-16', '2017/2018', 'ETF', 3, NULL),
(7, 'Nina', 'Nikolic', '7694821973405', 'Beograd', '0687548115', 2, 'Z', 1, 'Hrana i soba', '2017-09-12', '2018-05-16', '2017/2018', 'ETF', 2, NULL),
(8, 'Danijel', 'Matic', '0102991524163', 'Sarajevo', '065241845', 1, 'M', 2, 'Hrana i soba', '2016-09-01', '2017-06-06', '2016/2017', 'ETF', 1, NULL),
(9, 'Marko', 'Jeftic', '0505996251423', 'Gorazde', '064582152', 1, 'M', 3, 'Hrana i soba', '2017-09-01', '2018-09-15', '2017/2018', 'ETF', 2, '');

-- --------------------------------------------------------

--
-- Table structure for table `sobe`
--

CREATE TABLE `sobe` (
  `ID` int(2) NOT NULL,
  `DOM` int(10) NOT NULL,
  `PAVILJON` varchar(2) NOT NULL,
  `SOBA` int(5) NOT NULL,
  `KREVETA` int(10) NOT NULL,
  `SLOBODNIH` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sobe`
--

INSERT INTO `sobe` (`ID`, `DOM`, `PAVILJON`, `SOBA`, `KREVETA`, `SLOBODNIH`) VALUES
(1, 1, 'M', 1, 4, 3),
(2, 1, 'M', 2, 4, 3),
(3, 1, 'M', 3, 4, 4),
(4, 1, 'M', 4, 4, 4),
(5, 1, 'M', 5, 4, 4),
(6, 1, 'M', 6, 4, 4),
(7, 1, 'M', 7, 3, 3),
(8, 1, 'M', 8, 3, 3),
(9, 1, 'M', 9, 3, 2),
(10, 1, 'Z', 10, 4, 3),
(11, 1, 'Z', 11, 4, 3),
(12, 1, 'Z', 12, 3, 3),
(13, 1, 'Z', 13, 3, 3),
(14, 1, 'Z', 14, 3, 3),
(15, 1, 'Z', 15, 3, 3),
(16, 2, 'M', 1, 5, 5),
(17, 2, 'M', 2, 5, 5),
(18, 2, 'M', 3, 5, 5),
(19, 2, 'M', 4, 5, 5),
(20, 2, 'M', 5, 4, 4),
(21, 2, 'M', 6, 4, 4),
(22, 2, 'M', 7, 4, 4),
(23, 2, 'M', 8, 4, 4),
(24, 2, 'M', 9, 4, 4),
(25, 2, 'M', 10, 4, 4),
(26, 2, 'M', 11, 4, 4),
(27, 2, 'Z', 1, 4, 3),
(28, 2, 'Z', 2, 4, 4),
(29, 2, 'Z', 3, 4, 3),
(30, 2, 'Z', 4, 4, 4);

-- --------------------------------------------------------

--
-- Table structure for table `studenti`
--

CREATE TABLE `studenti` (
  `ID` int(11) NOT NULL,
  `IME` varchar(30) NOT NULL,
  `PREZIME` varchar(30) NOT NULL,
  `MATICNI_BROJ` varchar(20) NOT NULL,
  `MJESTO_STANOVANJA` varchar(50) NOT NULL,
  `BROJ_TELEFONA` varchar(20) NOT NULL,
  `DOM` int(11) DEFAULT NULL,
  `PAVILJON` varchar(2) NOT NULL,
  `SOBA` int(11) DEFAULT NULL,
  `USLUGA` varchar(20) NOT NULL,
  `DATUM_ZADUZIVANJA` date NOT NULL,
  `GODINA_UPOTREBE` varchar(10) NOT NULL,
  `FAKULTET` varchar(30) NOT NULL,
  `GODINA` int(11) NOT NULL,
  `KOMENTAR` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `studenti`
--

INSERT INTO `studenti` (`ID`, `IME`, `PREZIME`, `MATICNI_BROJ`, `MJESTO_STANOVANJA`, `BROJ_TELEFONA`, `DOM`, `PAVILJON`, `SOBA`, `USLUGA`, `DATUM_ZADUZIVANJA`, `GODINA_UPOTREBE`, `FAKULTET`, `GODINA`, `KOMENTAR`) VALUES
(1, 'Stefan', 'Markovic', '0101996548743', 'Sarajevo', '065789651', 1, 'M', 9, 'Hrana i soba', '2017-09-01', '2017/2018', 'ETF', 1, ''),
(2, 'Nikola', 'Nikolic', '5748014252563', 'Gorazde', '065859745', 1, 'M', 1, 'Hrana i soba', '2017-09-01', '2017/2018', 'ETF', 1, ''),
(3, 'Marijana', 'Markovic', '3102995011215', 'Visegrad', '066485127', 1, 'Z', 10, 'Hrana i soba', '2017-09-01', '2017/2018', 'MAK', 2, ''),
(4, 'Nikolina', 'Stefanovic', '3103992584745', 'Mostar', '0641584963', NULL, '', NULL, 'Hrana', '2017-09-01', '2017/2018', 'ETF', 4, ''),
(5, 'Nikola', 'Nikolic', '0204990154585', 'Herceg Novi', '066585749', 1, 'M', 2, 'Hrana i soba', '2017-09-01', '2017/2018', 'ETF', 1, ''),
(6, 'Tatjana', 'Simic', '1208999857495', 'Kalinovik', '065685954', 2, 'Z', 3, 'Hrana i soba', '2017-09-01', '2017/2018', 'ETF', 1, ''),
(7, 'Natasa', 'Lakic', '1312998857451', 'Podgorica', '065241849', 2, 'Z', 1, 'Hrana i soba', '2017-09-01', '2017/2018', 'MAF', 2, ''),
(8, 'Danijela', 'Lazarevic', '1509989584121', 'Trebinje', '066582136', 1, 'Z', 11, 'Hrana i soba', '2017-09-01', '2017/2018', 'MAF', 4, ''),
(9, 'Tamara', 'Ninkovic', '1902997541230', 'Kalnovik', '065524135', NULL, '', NULL, 'Hrana', '2018-07-03', '2017/2018', 'ETF', 1, '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `arhiva`
--
ALTER TABLE `arhiva`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `sobe`
--
ALTER TABLE `sobe`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `studenti`
--
ALTER TABLE `studenti`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `ID` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `arhiva`
--
ALTER TABLE `arhiva`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `sobe`
--
ALTER TABLE `sobe`
  MODIFY `ID` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `studenti`
--
ALTER TABLE `studenti`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
