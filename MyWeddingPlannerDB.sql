CREATE DATABASE  IF NOT EXISTS `MyWeddingPlannerDB` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `MyWeddingPlannerDB`;
-- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
--
-- Host: 127.0.0.1    Database: MyWeddingPlannerDB
-- ------------------------------------------------------
-- Server version	5.6.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Guests`
--

DROP TABLE IF EXISTS `Guests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Guests` (
  `GuestId` int(11) NOT NULL AUTO_INCREMENT,
  `Action` varchar(45) DEFAULT NULL,
  `WeddingId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `GCreated_At` datetime DEFAULT NULL,
  `GUpdated_At` datetime DEFAULT NULL,
  PRIMARY KEY (`GuestId`),
  KEY `fk_Guests_Weddings_idx` (`WeddingId`),
  KEY `fk_Guests_Users1_idx` (`UserId`),
  CONSTRAINT `fk_Guests_Users1` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Guests_Weddings` FOREIGN KEY (`WeddingId`) REFERENCES `Weddings` (`WeddingId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Guests`
--

LOCK TABLES `Guests` WRITE;
/*!40000 ALTER TABLE `Guests` DISABLE KEYS */;
INSERT INTO `Guests` VALUES (9,'RSVP',4,7,'2017-06-21 16:20:10','2017-06-21 16:20:10'),(12,'RSVP',5,8,'2017-06-21 16:20:45','2017-06-21 16:20:45'),(13,'RSVP',7,8,'2017-06-21 16:20:48','2017-06-21 16:20:48'),(14,'RSVP',8,8,'2017-06-21 16:20:50','2017-06-21 16:20:50'),(15,'RSVP',10,8,'2017-06-21 16:20:52','2017-06-21 16:20:52'),(16,'RSVP',11,8,'2017-06-21 16:20:53','2017-06-21 16:20:53'),(17,'RSVP',5,8,'2017-06-21 16:20:55','2017-06-21 16:20:55'),(18,'RSVP',5,8,'2017-06-21 16:20:58','2017-06-21 16:20:58'),(19,'RSVP',5,8,'2017-06-21 16:23:56','2017-06-21 16:23:56'),(20,'RSVP',11,8,'2017-06-21 16:24:03','2017-06-21 16:24:03'),(24,'RSVP',5,7,'2017-06-21 18:57:15','2017-06-21 18:57:15');
/*!40000 ALTER TABLE `Guests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Users` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(69) DEFAULT NULL,
  `LastName` varchar(69) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Password` varchar(69) DEFAULT NULL,
  `UserCreated_At` datetime DEFAULT NULL,
  `UserUpdated_At` datetime DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES (7,'Jim','Halper','jim@dunder.com','HelloHello','2017-06-21 11:11:42','2017-06-21 11:11:42'),(8,'Dwight','Schrut','dwight@dunder.com','HelloHello','2017-06-21 11:39:16','2017-06-21 11:39:16'),(9,'PamPam','PamPam','pam@dunder.com','HelloHello','2017-06-21 11:42:12','2017-06-21 11:42:12');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Weddings`
--

DROP TABLE IF EXISTS `Weddings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Weddings` (
  `WeddingId` int(11) NOT NULL AUTO_INCREMENT,
  `WedderOne` varchar(150) DEFAULT NULL,
  `WedderTwo` varchar(150) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `WeddingAddress` varchar(150) DEFAULT NULL,
  `WedCreated_At` datetime DEFAULT NULL,
  `WedUpdated_At` datetime DEFAULT NULL,
  `UserId` int(11) NOT NULL,
  PRIMARY KEY (`WeddingId`),
  KEY `fk_Weddings_Users1_idx` (`UserId`),
  CONSTRAINT `fk_Weddings_Users1` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Weddings`
--

LOCK TABLES `Weddings` WRITE;
/*!40000 ALTER TABLE `Weddings` DISABLE KEYS */;
INSERT INTO `Weddings` VALUES (4,'Jim','Pam','2019-12-31 00:00:00','Your Butt','2017-06-21 11:39:33','2017-06-21 11:39:33',8),(5,'Patric Star','A Rock','2024-04-29 00:00:00','Underwater','2017-06-21 11:44:45','2017-06-21 11:44:45',9),(7,'SpongeBob','SandyCheeks','2019-12-01 00:00:00','Krusty Crab','2017-06-21 12:28:20','2017-06-21 12:28:20',7),(8,'MysterPerson','MysteryPerson','2020-01-01 00:00:00','asdasdasdasd','2017-06-21 12:33:23','2017-06-21 12:33:23',7),(10,'Another WEdding','Hello','2020-12-02 00:00:00','asdasdsadasdasdasd','2017-06-21 14:38:55','2017-06-21 14:38:55',9),(11,'Make Believe','Fake','2021-04-06 00:00:00','PPPPPP','2017-06-21 14:53:43','2017-06-21 14:53:43',7);
/*!40000 ALTER TABLE `Weddings` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-06-21 18:59:55
