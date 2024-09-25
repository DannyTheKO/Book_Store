-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.30 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table book_store.book
CREATE TABLE IF NOT EXISTS `book` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET armscii8 COLLATE armscii8_bin NOT NULL,
  `author` varchar(255) CHARACTER SET armscii8 COLLATE armscii8_bin NOT NULL,
  `avaliable` int DEFAULT NULL,
  `publisher` varchar(50) CHARACTER SET armscii8 COLLATE armscii8_bin DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `created_on` datetime DEFAULT NULL,
  `is_active` enum('Y','N') CHARACTER SET armscii8 COLLATE armscii8_bin DEFAULT 'N',
  `genre_id` int DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `KEY` (`genre_id`),
  CONSTRAINT `FK_book_book_catalouge` FOREIGN KEY (`id`) REFERENCES `book_catalouge` (`book_id`),
  CONSTRAINT `FK_book_book_review` FOREIGN KEY (`id`) REFERENCES `book_review` (`book_id`),
  CONSTRAINT `FK_book_cart_detail` FOREIGN KEY (`id`) REFERENCES `cart_detail` (`book_id`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table book_store.book_catalouge
CREATE TABLE IF NOT EXISTS `book_catalouge` (
  `id` int NOT NULL AUTO_INCREMENT,
  `book_id` int DEFAULT NULL,
  `catalouge_id` int DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `BOOK_KEY` (`book_id`) /*!80000 INVISIBLE */,
  KEY `CATALOUGE_KEY` (`catalouge_id`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table book_store.book_review
CREATE TABLE IF NOT EXISTS `book_review` (
  `id` int NOT NULL AUTO_INCREMENT,
  `book_id` int DEFAULT NULL,
  `user_id` int DEFAULT NULL,
  `review` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `BOOK_KEY` (`book_id`) /*!80000 INVISIBLE */,
  KEY `USER_KEY` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

-- Dumping structure for table book_store.cart
CREATE TABLE IF NOT EXISTS `cart` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int DEFAULT NULL,
  `address` int DEFAULT NULL,
  `phone` int DEFAULT NULL,
  `payment_id` int DEFAULT NULL,
  `create_date` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `KEY` (`user_id`),
  CONSTRAINT `FK_cart_cart_detail` FOREIGN KEY (`id`) REFERENCES `cart_detail` (`cart_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

-- Dumping structure for table book_store.cart_detail
CREATE TABLE IF NOT EXISTS `cart_detail` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cart_id` int DEFAULT NULL,
  `book_id` int DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `BOOK_KEY` (`book_id`) /*!80000 INVISIBLE */,
  KEY `CART_KEY` (`cart_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

-- Dumping structure for table book_store.catalouge
CREATE TABLE IF NOT EXISTS `catalouge` (
  `id` int NOT NULL AUTO_INCREMENT,
  `description` varchar(50) CHARACTER SET armscii8 COLLATE armscii8_bin NOT NULL,
  `is_active` enum('Y','N') CHARACTER SET armscii8 COLLATE armscii8_bin NOT NULL,
  `name` varchar(255) CHARACTER SET armscii8 COLLATE armscii8_bin NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  CONSTRAINT `FK_catalouge` FOREIGN KEY (`id`) REFERENCES `book_catalouge` (`catalouge_id`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Data exporting was unselected.

-- Dumping structure for table book_store.genre
CREATE TABLE IF NOT EXISTS `genre` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` int DEFAULT NULL,
  `description` int DEFAULT NULL,
  `is_active` enum('Y','N') DEFAULT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `FK_genre_book` FOREIGN KEY (`id`) REFERENCES `book` (`genre_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

-- Dumping structure for table book_store.user
CREATE TABLE IF NOT EXISTS `user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `phone` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `FK_user_book_review` FOREIGN KEY (`id`) REFERENCES `book_review` (`user_id`),
  CONSTRAINT `FK_user_cart` FOREIGN KEY (`id`) REFERENCES `cart` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
