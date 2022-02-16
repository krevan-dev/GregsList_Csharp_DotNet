CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE cars(
  id INT NOT NULL AUTO_INCREMENT,
  year INT NOT NULL,
  make VARCHAR(255) NOT NULL,
  model VARCHAR(255) NOT NULL,
  color VARCHAR(255) NOT NULL,
  body VARCHAR(255) NOT NULL,
  price INT NOT NULL,
  PRIMARY KEY (id)
) default charset utf8 COMMENT 'GL Cars';
CREATE TABLE houses(
  id INT NOT NULL primary key AUTO_INCREMENT,
  year INT NOT NULL,
  type VARCHAR(255) NOT NULL,
  bed INT NOT NULL,
  bath INT NOT NULL,
  sqft INT NOT NULL,
  location VARCHAR(255) NOT NULL
) DEFAULT charset utf8 COMMENT 'GL Houses';
CREATE TABLE jobs(
  id INT NOT NULL primary key AUTO_INCREMENT,
  jobTitle VARCHAR(255) NOT NULL,
  pay INT NOT NULL,
  empType VARCHAR(255) NOT NULL,
  location VARCHAR(255) NOT NULL
) DEFAULT charset utf8 COMMENT 'GL Jobs';
SELECT
  *
FROM
  cars;
INSERT INTO
  cars (year, make, model, price, color, body)
VALUES
  (
    2007,
    "Pizza",
    "Planet",
    1000,
    "Yellow",
    "Pizza Rocket Ship"
  );
SELECT
  LAST_INSERT_ID();