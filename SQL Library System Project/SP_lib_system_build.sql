CREATE DATABASE lib_system;

USE lib_system;
GO

CREATE PROCEDURE [dbo].[construct_lib]
AS
BEGIN

	/******************************************************
	 * If our tables already exist, drop and recreate them
	 ******************************************************/
	IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES tbl_species)
		DROP TABLE tbl_species, tbl_animalia, tbl_care, tbl_class, tbl_habitat, tbl_nutrition, tbl_order, tbl_specialist;
		
		
	/******************************************************
	 * Build our database tables and define ther schema
	 ******************************************************/


CREATE TABLE BOOK (
	BookId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Title VARCHAR(60) NOT NULL,
	PublisherName VARCHAR(60) NOT NULL
);

CREATE TABLE PUBLISHER (
	Name VARCHAR(60) PRIMARY KEY NOT NULL,
	Address VARCHAR(200) NOT NULL,
	Phone VARCHAR(30) NOT NULL
);

CREATE TABLE BOOK_AUTHOR (
	BookId INT NOT NULL CONSTRAINT fk_book_id FOREIGN KEY REFERENCES BOOK(BookId) ON UPDATE CASCADE ON DELETE CASCADE,
	AuthorName VARCHAR(50) NOT NULL
);

CREATE TABLE LIBRARY_BRANCH (
	BranchId INT PRIMARY KEY NOT NULL IDENTITY(2300,1),
	BranchName VARCHAR(100) NOT NULL,
	Address VARCHAR(200) NOT NULL
);

CREATE TABLE BORROWER (
	CardNo INT PRIMARY KEY NOT NULL IDENTITY(77005500,1),
	Name VARCHAR(50) NOT NULL,
	Address VARCHAR(200) NOT NULL,
	Phone VARCHAR(30) NOT NULL
);

CREATE TABLE BOOK_COPIES (
	BookId INT NOT NULL CONSTRAINT fk_book_copies_id FOREIGN KEY REFERENCES BOOK(BookId) ON UPDATE CASCADE ON DELETE CASCADE,
	BranchId INT NOT NULL CONSTRAINT fk_copies_branch_id FOREIGN KEY REFERENCES LIBRARY_BRANCH(BranchId) ON UPDATE CASCADE ON DELETE CASCADE,
	No_Of_Copies INT NOT NULL
);

CREATE TABLE BOOK_LOANS (
	BookId INT NOT NULL CONSTRAINT fk_book_loans_id FOREIGN KEY REFERENCES BOOK(BookId) ON UPDATE CASCADE ON DELETE CASCADE,
	BranchId INT NOT NULL CONSTRAINT fk_loans_branch_id FOREIGN KEY REFERENCES LIBRARY_BRANCH(BranchId) ON UPDATE CASCADE ON DELETE CASCADE,
	CardNo INT NOT NULL CONSTRAINT fk_loans_cardno FOREIGN KEY REFERENCES BORROWER(CardNo) ON UPDATE CASCADE ON DELETE CASCADE,
	DateOut DATE NOT NULL,
	DueDate DATE NOT NULL
);

	/******************************************************
	 * Populate Tables
	 ******************************************************/


INSERT INTO LIBRARY_BRANCH
	(BranchName, Address)
	VALUES
	('Sharpstown', '4301 NE Maple St, Sharpstown, OR 97242'),
	('Central', '2212 NW Broadway St, Portland, OR 97217'),
	('Clackamas', '7335 Stark St, Clackamas, OR 97842'),
	('Trill Creek', '9700 122nd St SE, Trill Creek, OR 97319')
;

SELECT * FROM LIBRARY_BRANCH;

INSERT INTO BORROWER
	(Name, Address, Phone)
	VALUES
	('Mark Holladay', '6743 NE 47th St, Portland, OR 97217', '503-671-9899'),
	('Michael Bolton', '4796 SW Ashmore Avenue, Lake Oswego, OR 97032', '503-228-8929'),
	('Dave Ainsworth', '2252 SE 35th St, Sharpstown, OR 97242', '971-626-3383'),
	('Maddie Crenshaw', '5434 NW Freeshavacadoo Lane, Clackamas, OR 97842', '971-626-8696'),
	('Herbert Hernandez', '2824 S Williams St, Trill Creek, OR 97319', '503-422-8191'),
	('Francine Mancinetti', '6421 NW Fremont Ave, Portland OR, 97217', '503-771-5467'),
	('Shrek Love', '8673 Secret Swamp Road, Swampland, OR 97033', '503-422-4663'),
	('Danielle Dougherty', '2106 NE Poplar Drive, Portland, OR 97217', '971-493-3303')
;

SELECT * FROM BORROWER;

INSERT INTO BOOK
	(Title, PublisherName)
	VALUES
	('Brave New World', 'Penguin'),
	('Of Mice and Men', 'Oxford'),
	('Don Quixote', 'Cambridge'),
	('1984', 'Houghton Mifflin'),
	('Fundamentals of Finance', 'McGraw-Hill'),
	('Music Production for Dummies', 'Scholastic'),
	('Who Is She?', 'Penguin'),
	('Intro to Home Brewing', 'Scholastic'),
	('Stardust', 'Oxford'),
	('Ultimate Guide to Dog Training', 'Houghton Mifflin'),
	('Bada Bing Bada Doom', 'Cambridge'),
	('Bring It Down A Peg: The Opposite of a Self Help Book', 'Scholastic'),
	('Swamp Horticulture', 'McGraw-Hill'),
	('Photography: Fully Developed', 'Penguin'),
	('Short Stories With Long Titles', 'Scholastic'),
	('Tax Reform Through the Years', 'McGraw-Hill'),
	('The Shining', 'Houghton Mifflin'),
	('Half Past Threat Level Midnight', 'Penguin'),
	('The Lost Tribe', 'Oxford'),
	('Self Actualization & You!', 'Penguin'),
	('Brain Hacker: Psychology for Daily Life', 'Scholastic'),
	('A Comprehensive History of Music', 'McGraw-Hill')
;

SELECT * FROM BOOK;

INSERT INTO BOOK_AUTHOR
	(BookId, AuthorName)
	VALUES
	(1, 'Aldous Huxley'),
	(2, 'John Steinbeck'),
	(3, 'Miguel de Cervantes'),
	(4, 'George Orwell'),
	(5, 'Paul Jackson'),
	(6, 'James Van Damme'),
	(7, 'Richard Walker'),
	(8, 'Gregory Malcolm'),
	(9, 'Amy Alderman'),
	(10, 'Sharon King'),
	(11, 'Max Truman'),
	(12, 'Chelsea Black'),
	(13, 'Thragg Ogreman'),
	(14, 'Jessica Morris'),
	(15, 'Max Truman'),
	(16, 'Walter Brinsley'),
	(17, 'Stephen King'),
	(18, 'Michael Scott'),
	(19, 'Mary Platt'),
	(20, 'Grant Wilde'),
	(21, 'Grant Wilde'),
	(22, 'Georgia Harmon')
;

SELECT * FROM BOOK_AUTHOR;

INSERT INTO PUBLISHER
	(Name, Address, Phone)
	VALUES
	('Penguin', '3542 N Denny Way, New York, NY 10028', '212-734-9893'),
	('Oxford', '2200 SE 152nd Ave, Boston, MA, 02124', '617-443-6532'),
	('Cambridge', '8824 W Bockman St, Plymouth, MA, 02362', '508-624-5529'),
	('Houghton Mifflin', '9205 Southpark Center Loop, Orlando, FL, 32819', '786-513-5369'),
	('McGraw-Hill', '400 7th Avenue, New York, NY, 10001', '212-893-3856'),
	('Scholastic', '557 Broadway, New York, NY 10012', '212-555-3829')
;

SELECT* FROM PUBLISHER;

INSERT INTO BOOK_COPIES
	(BookId,BranchId, No_Of_Copies)
	VALUES
	(4, 2301, 7),
	(4, 2303, 5),
	(4, 2300, 5),
	(4, 2302, 4),
	(1, 2300, 4),
	(1, 2301, 5),
	(1, 2302, 3),
	(1, 2303, 4),
	(2, 2300, 5),
	(2, 2301, 6),
	(2, 2302, 4),
	(2, 2303, 4),
	(3, 2300, 3),
	(3, 2301, 4),
	(3, 2302, 2),
	(3, 2303, 3),
	(5, 2300, 1),
	(5, 2301, 2),
	(5, 2302, 0),
	(5, 2303, 1),
	(6, 2300, 2),
	(6, 2301, 2),
	(6, 2302, 1),
	(6, 2303, 1),
	(7, 2300, 3),
	(7, 2301, 3),
	(7, 2302, 2),
	(7, 2303, 2),
	(8, 2300, 1),
	(8, 2301, 2),
	(8, 2302, 0),
	(8, 2303, 1),
	(9, 2300, 1),
	(9, 2301, 2),
	(9, 2302, 0),
	(9, 2303, 1),
	(10, 2300, 0),
	(10, 2301, 2),
	(10, 2302, 1),
	(10, 2303, 1),
	(11, 2300, 1),
	(11, 2301, 2),
	(11, 2302, 2),
	(11, 2303, 2),
	(12, 2300, 2),
	(12, 2301, 2),
	(12, 2302, 3),
	(12, 2303, 2),
	(13, 2300, 0),
	(13, 2301, 0),
	(13, 2302, 1),
	(13, 2303, 1),
	(14, 2300, 2),
	(14, 2301, 3),
	(14, 2302, 2),
	(14, 2303, 3),
	(15, 2300, 2),
	(15, 2301, 3),
	(15, 2302, 2),
	(15, 2303, 2),
	(16, 2300, 1),
	(16, 2301, 0),
	(16, 2302, 2),
	(16, 2303, 0),
	(17, 2300, 3),
	(17, 2301, 2),
	(17, 2302, 2),
	(17, 2303, 2),
	(18, 2300, 3),
	(18, 2301, 5),
	(18, 2302, 3),
	(18, 2303, 4),
	(19, 2300, 2),
	(19, 2301, 2),
	(19, 2302, 1),
	(19, 2303, 2),
	(20, 2300, 2),
	(20, 2301, 3),
	(20, 2302, 3),
	(20, 2303, 3),
	(21, 2300, 2),
	(21, 2301, 3),
	(21, 2302, 2),
	(21, 2303, 2),
	(22, 2300, 1),
	(22, 2301, 2),
	(22, 2302, 1),
	(22, 2303, 2)
;

SELECT * FROM BOOK_COPIES;

INSERT INTO BOOK_LOANS
	(BookId, BranchId, CardNo, DateOut, DueDate)
	VALUES
	(7, 2300, 77005501, '2017-05-09', '2017-06-09'),
	(18, 2300, 77005501, '2017-05-09', '2017-06-09'),
	(20, 2300, 77005501, '2017-05-09', '2017-06-09'),
	(15, 2300, 77005501, '2017-05-09', '2017-06-09'),
	(21, 2300, 77005501, '2017-05-09', '2017-06-09'),
	(6, 2300, 77005501, '2017-05-09', '2017-06-09'),
	(7, 2301, 77005505, '2017-05-14', '2017-06-14'),
	(9, 2301, 77005505, '2017-05-14', '2017-06-14'),
	(14, 2301, 77005505, '2017-05-14', '2017-06-14'),
	(1, 2301, 77005505, '2017-05-14', '2017-06-14'),
	(15, 2301, 77005505, '2017-05-14', '2017-06-14'),
	(11, 2300, 77005502, '2017-04-30', '2017-05-30'),
	(9, 2300, 77005507, '2017-04-30', '2017-05-30'),
	(20, 2300, 77005503, '2017-04-30', '2017-05-30'),
	(21, 2302, 77005503, '2017-05-19', '2017-06-19'),
	(13, 2303, 77005506, '2017-03-21', '2017-04-21'),
	(5, 2301, 77005500, '2017-05-11', '2017-06-11'),
	(19, 2301, 77005505, '2017-02-06', '2017-03-06')
;

SELECT * FROM BOOK_LOANS;


END
GO