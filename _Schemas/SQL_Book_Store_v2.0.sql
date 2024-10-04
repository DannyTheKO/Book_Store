-- MySQL Script generated by MySQL Workbench
-- Thu Oct  3 00:11:35 2024
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema book_store_v2.0
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `book_store_v2.0` ;

-- -----------------------------------------------------
-- Schema book_store_v2.0
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `book_store_v2.0` DEFAULT CHARACTER SET utf8 ;
USE `book_store_v2.0` ;

-- -----------------------------------------------------
-- Table `book_store_v2.0`.`OrderDetail`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `book_store_v2.0`.`OrderDetail` (
  `OrderDetailId` INT NOT NULL,
  `BookId` VARCHAR(10) NULL,
  `OrderId` VARCHAR(16) NULL,
  `Quantity` INT NULL,
  `Price` FLOAT NULL,
  `TotalMoney` FLOAT NULL,
  PRIMARY KEY (`OrderDetailId`))
ENGINE = InnoDB;

CREATE INDEX `Book_KEY` ON `book_store_v2.0`.`OrderDetail` (`BookId` ASC) INVISIBLE;

CREATE INDEX `Order_KEY` ON `book_store_v2.0`.`OrderDetail` (`OrderId` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `book_store_v2.0`.`Book`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `book_store_v2.0`.`Book` (
  `BookId` VARCHAR(10) NOT NULL,
  `CategoryId` INT NULL,
  `PublisherId` INT NULL,
  `Title` NVARCHAR(255) NULL,
  `Author` NVARCHAR(255) NULL,
  `Release` INT NULL,
  `Price` FLOAT NULL,
  `Description` LONGTEXT NULL,
  `Picture` NVARCHAR(255) NULL,
  PRIMARY KEY (`BookId`),
  CONSTRAINT `FK_Book_OrderDetail`
    FOREIGN KEY (`BookId`)
    REFERENCES `book_store_v2.0`.`OrderDetail` (`BookId`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;

CREATE INDEX `Category_KEY` ON `book_store_v2.0`.`Book` (`CategoryId` ASC) VISIBLE;

CREATE INDEX `Publisher_KEY` ON `book_store_v2.0`.`Book` (`PublisherId` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `book_store_v2.0`.`Category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `book_store_v2.0`.`Category` (
  `CategoryId` INT NOT NULL,
  `CategoryName` NVARCHAR(255) NULL,
  PRIMARY KEY (`CategoryId`),
  CONSTRAINT `FK_Category_Book`
    FOREIGN KEY (`CategoryId`)
    REFERENCES `book_store_v2.0`.`Book` (`CategoryId`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `book_store_v2.0`.`Publisher`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `book_store_v2.0`.`Publisher` (
  `PublisherId` INT NOT NULL,
  `PublisherName` NVARCHAR(255) NULL,
  `Phone` VARCHAR(45) NULL,
  `Address` VARCHAR(45) NULL,
  PRIMARY KEY (`PublisherId`),
  CONSTRAINT `FK_Publisher_Book`
    FOREIGN KEY (`PublisherId`)
    REFERENCES `book_store_v2.0`.`Book` (`PublisherId`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `book_store_v2.0`.`OrderBook`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `book_store_v2.0`.`OrderBook` (
  `OrderId` VARCHAR(16) NOT NULL,
  `OrderDate` DATETIME NULL,
  `AccountId` VARCHAR(36) NULL,
  `ReceiveAddress` NVARCHAR(512) NULL,
  `ReceivePhone` VARCHAR(64) NULL,
  `OrderReceive` DATETIME NULL,
  `Note` NVARCHAR(512) NULL,
  `Status` VARCHAR(16) NULL,
  PRIMARY KEY (`OrderId`),
  CONSTRAINT `FK_OrderBook_OrderDetail`
    FOREIGN KEY (`OrderId`)
    REFERENCES `book_store_v2.0`.`OrderDetail` (`OrderId`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
ENGINE = InnoDB;

CREATE INDEX `Account_KEY` ON `book_store_v2.0`.`OrderBook` (`AccountId` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `book_store_v2.0`.`Account`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `book_store_v2.0`.`Account` (
  `AccountId` VARCHAR(36) NOT NULL,
  `Usernane` VARCHAR(64) NULL,
  `Password` VARCHAR(256) NULL,
  `FullName` NVARCHAR(100) NULL,
  `Picture` VARCHAR(512) NULL,
  `Email` VARCHAR(64) NULL,
  `Address` NVARCHAR(512) NULL,
  `Phone` VARCHAR(64) NULL,
  `IsAdmin` ENUM('N', 'Y') NULL,
  `Active` ENUM('N', 'Y') NULL,
  PRIMARY KEY (`AccountId`),
  CONSTRAINT `FK_Account_OrderBook`
    FOREIGN KEY (`AccountId`)
    REFERENCES `book_store_v2.0`.`OrderBook` (`AccountId`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
