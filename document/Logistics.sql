/*
Navicat MySQL Data Transfer

Source Server         : MariaDB-aliyun
Source Server Version : 50544
Source Host           : 121.42.197.31:3306
Source Database       : Logistics

Target Server Type    : MYSQL
Target Server Version : 50544
File Encoding         : 65001

Date: 2016-06-30 15:42:00
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for Booking
-- ----------------------------
DROP TABLE IF EXISTS `Booking`;
CREATE TABLE `Booking` (
  `BookNo` int(11) NOT NULL AUTO_INCREMENT,
  `BookName` varchar(30) DEFAULT NULL,
  `BookTel` int(11) DEFAULT NULL,
  `BookAddress` varchar(30) DEFAULT NULL,
  `BookItems` varchar(150) DEFAULT NULL,
  `BookGetTime` datetime DEFAULT NULL,
  `BookStartTime` datetime DEFAULT NULL,
  `CourierNo` int(11) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  PRIMARY KEY (`BookNo`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Booking
-- ----------------------------
INSERT INTO `Booking` VALUES ('5', '3', '33', '3', '3', '2016-06-10 04:04:00', '2016-06-30 13:49:15', '2', '1');

-- ----------------------------
-- Table structure for Complaint
-- ----------------------------
DROP TABLE IF EXISTS `Complaint`;
CREATE TABLE `Complaint` (
  `ComplaintNo` int(11) NOT NULL AUTO_INCREMENT,
  `PackNo` int(11) DEFAULT NULL,
  `ComplaintName` char(20) DEFAULT NULL,
  `ComplaintTel` int(11) DEFAULT NULL,
  `ComplaintContent` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`ComplaintNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Complaint
-- ----------------------------

-- ----------------------------
-- Table structure for Delivery
-- ----------------------------
DROP TABLE IF EXISTS `Delivery`;
CREATE TABLE `Delivery` (
  `DeliveryNo` int(11) NOT NULL AUTO_INCREMENT,
  `PackNo` int(11) DEFAULT NULL,
  `Network` int(11) DEFAULT NULL,
  `DeliveryTime` datetime DEFAULT NULL,
  `DeliveryClass` int(11) DEFAULT NULL,
  `DeliveryStatus` int(11) DEFAULT NULL,
  `DeliveryStorage` int(11) DEFAULT NULL,
  PRIMARY KEY (`DeliveryNo`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Delivery
-- ----------------------------
INSERT INTO `Delivery` VALUES ('20', '26', '6', '2016-06-30 12:22:19', '1', '1', '8');
INSERT INTO `Delivery` VALUES ('21', '27', '6', '2016-06-30 12:22:24', '1', '1', '8');
INSERT INTO `Delivery` VALUES ('22', '28', '6', '2016-06-30 12:22:28', '1', '1', '8');
INSERT INTO `Delivery` VALUES ('23', '29', '6', '2016-06-30 12:22:32', '1', '1', '8');
INSERT INTO `Delivery` VALUES ('24', '28', '7', '2016-06-30 12:25:25', '1', '1', '8');
INSERT INTO `Delivery` VALUES ('25', '31', '6', '2016-06-30 12:42:51', '1', '0', '8');
INSERT INTO `Delivery` VALUES ('26', '32', '6', '2016-06-30 13:54:14', '1', '0', '8');
INSERT INTO `Delivery` VALUES ('27', '32', '6', '2016-06-30 13:54:16', '1', '0', '8');
INSERT INTO `Delivery` VALUES ('28', '32', '6', '2016-06-30 13:54:26', '1', '0', '8');
INSERT INTO `Delivery` VALUES ('29', '32', '6', '2016-06-30 13:54:28', '1', '0', '8');
INSERT INTO `Delivery` VALUES ('30', '32', '6', '2016-06-30 13:54:29', '1', '0', '8');
INSERT INTO `Delivery` VALUES ('31', '32', '6', '2016-06-30 13:54:30', '1', '0', '8');
INSERT INTO `Delivery` VALUES ('32', '32', '6', '2016-06-30 13:54:54', '1', '0', '8');
INSERT INTO `Delivery` VALUES ('33', '33', '6', '2016-06-30 14:02:36', '4', '1', '8');
INSERT INTO `Delivery` VALUES ('34', '33', '7', '2016-06-30 14:07:15', '1', '1', '8');

-- ----------------------------
-- Table structure for Dispatch
-- ----------------------------
DROP TABLE IF EXISTS `Dispatch`;
CREATE TABLE `Dispatch` (
  `DispatchNo` int(11) NOT NULL AUTO_INCREMENT,
  `PackNo` int(11) DEFAULT NULL,
  `CourierNo` int(11) DEFAULT NULL,
  `PackName` varchar(30) DEFAULT NULL,
  `ToName` varchar(20) DEFAULT NULL,
  `DispatchTime` datetime DEFAULT NULL,
  `DispatchStatus` int(11) DEFAULT NULL,
  `ToTel` int(11) DEFAULT NULL,
  `ToAddresss` varchar(50) DEFAULT NULL,
  `DispatchType` int(11) DEFAULT NULL,
  PRIMARY KEY (`DispatchNo`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Dispatch
-- ----------------------------
INSERT INTO `Dispatch` VALUES ('13', '26', '5', '11', '2', '2016-06-30 12:23:55', '2', '2', '2', '0');
INSERT INTO `Dispatch` VALUES ('14', '27', '5', '12', '2', '2016-06-30 12:24:06', '2', '2', '2', '0');
INSERT INTO `Dispatch` VALUES ('15', '28', '5', '12', '2', '2016-06-30 12:24:13', '3', '2', '2', '0');
INSERT INTO `Dispatch` VALUES ('16', '28', '3', '12', '2', '2016-06-30 12:26:02', '2', '2', '2', '1');
INSERT INTO `Dispatch` VALUES ('17', '33', '4', '6', '6', '2016-06-30 14:04:57', '3', '6', '66', '0');
INSERT INTO `Dispatch` VALUES ('18', '33', '2', '6', '6', '2016-06-30 14:08:17', '2', '6', '66', '1');

-- ----------------------------
-- Table structure for LogDetail
-- ----------------------------
DROP TABLE IF EXISTS `LogDetail`;
CREATE TABLE `LogDetail` (
  `PackNo` int(11) NOT NULL AUTO_INCREMENT,
  `FromProvince` varchar(10) DEFAULT NULL,
  `FromCity` varchar(10) DEFAULT NULL,
  `FromStatue` varchar(10) DEFAULT NULL,
  `FromAddress` varchar(50) DEFAULT NULL,
  `FromName` varchar(10) DEFAULT NULL,
  `FromTel` int(11) DEFAULT NULL,
  `ToProvince` varchar(10) DEFAULT NULL,
  `ToCity` varchar(10) DEFAULT NULL,
  `ToStatue` varchar(10) DEFAULT NULL,
  `ToAddress` varchar(50) DEFAULT NULL,
  `ToName` varchar(10) DEFAULT NULL,
  `ToTel` int(11) DEFAULT NULL,
  `Pay` varchar(10) DEFAULT NULL,
  `PackName` varchar(10) DEFAULT NULL,
  `Weight` double DEFAULT NULL,
  `Momey` double DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `getter` int(11) DEFAULT NULL,
  `sender` int(11) DEFAULT NULL,
  PRIMARY KEY (`PackNo`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of LogDetail
-- ----------------------------
INSERT INTO `LogDetail` VALUES ('26', '1', '上海', '1', '1', '1', '1', '2', '北京', '2', '2', '2', '2', '1', '11', '1', '1', '0', '2016-06-30 12:19:22', '2', '5');
INSERT INTO `LogDetail` VALUES ('27', '1', '上海', '1', '1', '1', '1', '2', '北京', '2', '2', '2', '2', '11', '12', '1', '12', '0', '2016-06-30 12:19:43', '2', '5');
INSERT INTO `LogDetail` VALUES ('28', '1', '上海', '1', '1', '1', '1', '2', '北京', '2', '2', '2', '2', '1', '12', '12', '12', '1', '2016-06-30 12:20:00', '2', '3');
INSERT INTO `LogDetail` VALUES ('29', '1', '上海', '1', '1', '1', '1', '2', '北京', '2', '2', '2', '2', '2', '22', '2', '2', '0', '2016-06-30 12:20:24', '2', null);
INSERT INTO `LogDetail` VALUES ('30', '1', '上海', '1', '1', '1', '1', '2', '北京', '2', '2', '2', '2', '2', '22', '2', '2', '0', '2016-06-30 12:20:41', '2', null);
INSERT INTO `LogDetail` VALUES ('31', '5', '上海', '5', '5', '5', '5', '5', '北京', '5', '5', '5', '5', '5', '5', '5', '5', '0', '2016-06-30 12:41:31', '2', null);
INSERT INTO `LogDetail` VALUES ('32', '6', '上海', '6', '6', '6', '6', '6', '北京', '6', '6', '6', '6', '6', '6', '66', '6', '0', '2016-06-30 13:50:21', '2', null);
INSERT INTO `LogDetail` VALUES ('33', '66', '上海', '6', '6', '666666', '6', '6', '北京', '6', '66', '6', '6', '6', '6', '6', '6', '1', '2016-06-30 14:02:20', '2', '2');

-- ----------------------------
-- Table structure for Process
-- ----------------------------
DROP TABLE IF EXISTS `Process`;
CREATE TABLE `Process` (
  `PackNo` int(11) NOT NULL,
  `DeliveryNo` int(11) DEFAULT NULL,
  `Network` char(50) DEFAULT NULL,
  `DeliveryTime` datetime DEFAULT NULL,
  `StorageNo` int(11) DEFAULT NULL,
  `Storage` char(50) DEFAULT NULL,
  `StorageTime` datetime DEFAULT NULL,
  `OutboundNo` int(11) DEFAULT NULL,
  `OutboundStorage` char(50) DEFAULT NULL,
  `OutboundTime` datetime DEFAULT NULL,
  `DispatchNo` int(11) DEFAULT NULL,
  `CourierNo` char(50) DEFAULT NULL,
  `DispatchTime` datetime DEFAULT NULL,
  `Location` char(50) DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  PRIMARY KEY (`PackNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Process
-- ----------------------------
INSERT INTO `Process` VALUES ('26', '20', '网点1', '2016-06-30 12:22:19', '58', '仓库', '2016-06-30 12:22:57', '62', '仓库', '2016-06-30 12:23:27', '13', '快递员4', '2016-06-30 12:23:55', '网点2', '2016-06-30 12:24:50', '2');
INSERT INTO `Process` VALUES ('27', '21', '网点1', '2016-06-30 12:22:23', '59', '仓库', '2016-06-30 12:23:05', '63', '仓库', '2016-06-30 12:23:34', '14', '快递员4', '2016-06-30 12:24:06', '网点2', '2016-06-30 12:24:59', '2');
INSERT INTO `Process` VALUES ('28', '22', '网点1', '2016-06-30 12:22:28', '60', '仓库', '2016-06-30 12:23:13', '64', '仓库', '2016-06-30 12:23:38', '15', '快递员4', '2016-06-30 12:24:13', '网点2', '2016-06-30 12:26:22', '3');
INSERT INTO `Process` VALUES ('29', '23', '网点1', '2016-06-30 12:22:32', '61', '仓库', '2016-06-30 12:23:23', null, null, null, null, null, null, '仓库', '2016-06-30 12:23:23', '0');
INSERT INTO `Process` VALUES ('31', '25', '网点1', '2016-06-30 12:42:51', null, null, null, null, null, null, null, null, null, '网点1', '2016-06-30 12:42:51', '0');
INSERT INTO `Process` VALUES ('32', '26', '网点1', '2016-06-30 13:53:55', null, null, null, null, null, null, null, null, null, '网点1', '2016-06-30 13:53:55', '0');
INSERT INTO `Process` VALUES ('33', '33', '网点1', '2016-06-30 14:02:36', '67', '仓库', '2016-06-30 14:03:43', '68', '仓库', '2016-06-30 14:04:12', '17', '快递员3', '2016-06-30 14:04:57', '网点2', '2016-06-30 14:09:00', '3');

-- ----------------------------
-- Table structure for Stock
-- ----------------------------
DROP TABLE IF EXISTS `Stock`;
CREATE TABLE `Stock` (
  `PackNo` int(11) NOT NULL,
  `Storage` int(11) DEFAULT NULL,
  `StockTime` datetime DEFAULT NULL,
  `StockStatus` int(11) DEFAULT NULL,
  PRIMARY KEY (`PackNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Stock
-- ----------------------------
INSERT INTO `Stock` VALUES ('26', '8', '2016-06-30 12:23:27', '0');
INSERT INTO `Stock` VALUES ('27', '8', '2016-06-30 12:23:34', '0');
INSERT INTO `Stock` VALUES ('28', '8', '2016-06-30 12:25:46', '0');
INSERT INTO `Stock` VALUES ('29', '8', '2016-06-30 12:23:23', '1');
INSERT INTO `Stock` VALUES ('33', '8', '2016-06-30 14:07:57', '0');

-- ----------------------------
-- Table structure for Storage
-- ----------------------------
DROP TABLE IF EXISTS `Storage`;
CREATE TABLE `Storage` (
  `StorageNo` int(11) NOT NULL AUTO_INCREMENT,
  `PackNo` int(11) DEFAULT NULL,
  `Storage` int(11) DEFAULT NULL,
  `StorageTime` datetime DEFAULT NULL,
  `StorageType` int(11) DEFAULT NULL,
  `StorageNetwork` int(11) DEFAULT NULL,
  `StorageStatus` int(11) DEFAULT NULL,
  PRIMARY KEY (`StorageNo`)
) ENGINE=InnoDB AUTO_INCREMENT=71 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Storage
-- ----------------------------
INSERT INTO `Storage` VALUES ('58', '26', '8', '2016-06-30 12:22:57', '0', null, null);
INSERT INTO `Storage` VALUES ('59', '27', '8', '2016-06-30 12:23:05', '0', null, null);
INSERT INTO `Storage` VALUES ('60', '28', '8', '2016-06-30 12:23:13', '0', null, null);
INSERT INTO `Storage` VALUES ('61', '29', '8', '2016-06-30 12:23:23', '0', null, null);
INSERT INTO `Storage` VALUES ('62', '26', '8', '2016-06-30 12:23:27', '1', '7', '1');
INSERT INTO `Storage` VALUES ('63', '27', '8', '2016-06-30 12:23:34', '1', '7', '1');
INSERT INTO `Storage` VALUES ('64', '28', '8', '2016-06-30 12:23:38', '1', '7', '1');
INSERT INTO `Storage` VALUES ('65', '28', '8', '2016-06-30 12:25:42', '0', null, null);
INSERT INTO `Storage` VALUES ('66', '28', '8', '2016-06-30 12:25:46', '1', '6', '1');
INSERT INTO `Storage` VALUES ('67', '33', '8', '2016-06-30 14:03:43', '0', null, null);
INSERT INTO `Storage` VALUES ('68', '33', '8', '2016-06-30 14:04:12', '1', '7', '1');
INSERT INTO `Storage` VALUES ('69', '33', '8', '2016-06-30 14:07:38', '0', null, null);
INSERT INTO `Storage` VALUES ('70', '33', '8', '2016-06-30 14:07:57', '1', '6', '1');

-- ----------------------------
-- Table structure for User
-- ----------------------------
DROP TABLE IF EXISTS `User`;
CREATE TABLE `User` (
  `Account` int(11) NOT NULL,
  `UserName` char(30) DEFAULT NULL,
  `Password` char(20) DEFAULT NULL,
  `Permissions` int(11) DEFAULT NULL,
  PRIMARY KEY (`Account`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of User
-- ----------------------------
INSERT INTO `User` VALUES ('1', '业务员1', '1', '1');
INSERT INTO `User` VALUES ('2', '快递员1', '2', '2');
INSERT INTO `User` VALUES ('3', '快递员2', '3', '2');
INSERT INTO `User` VALUES ('4', '快递员3', '4', '2');
INSERT INTO `User` VALUES ('5', '快递员4', '5', '2');
INSERT INTO `User` VALUES ('6', '网点1', '6', '3');
INSERT INTO `User` VALUES ('7', '网点2', '7', '3');
INSERT INTO `User` VALUES ('8', '仓库', '8', '4');
