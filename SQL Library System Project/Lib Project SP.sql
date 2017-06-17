USE lib_system
GO

CREATE PROCEDURE dbo.uspQueryLib
AS
BEGIN


/*-------------------------------------------------------------
Query How many copies of the book titled "The Lost Tribe" are owned 
by the library branch whose name is "Sharpstown"?
---------------------------------------------------------------*/

SELECT a.No_Of_Copies
FROM BOOK_COPIES a
	INNER JOIN BOOK b ON b.BookId = a.BookId
	INNER JOIN LIBRARY_BRANCH c ON c.BranchId = a.BranchId
WHERE b.Title = 'The Lost Tribe' AND c.BranchName = 'Sharpstown'
;

/*-----------------------------------------------------------
Query How many copies of the book titled "The Lost Tribe" are 
owned by each library branch?
-------------------------------------------------------------*/

SELECT c.BranchName, a.No_Of_Copies
FROM BOOK_COPIES a
	INNER JOIN BOOK b ON b.BookId = a.BookId
	INNER JOIN LIBRARY_BRANCH c ON c.BranchId = a.BranchId
WHERE b.Title = 'The Lost Tribe'
;

/*-----------------------------------------------------------------------
Retrieve the names of all borrowers who do not have any books checked out.
-------------------------------------------------------------------------*/

SELECT DISTINCT a.Name
FROM BORROWER a
	LEFT JOIN BOOK_LOANS b ON b.CardNo = a.CardNo
WHERE b.DueDate < '2017-05-30' OR b.DueDate IS NULL
;

/* ------------------------------------------------
Query borrowers with no books checked out using NOT IN

SELECT DISTINCT a.Name
FROM BORROWER a
	LEFT JOIN BOOK_LOANS b ON b.CardNo = a.CardNo
WHERE b.DueDate < '2017-05-30'
AND b.DueDate NOT IN (
	SELECT b.DueDate
	FROM BOOK_LOANS
	WHERE b.DueDate > '2017-05-30')
OR
a.CardNo NOT IN (
	SELECT CardNo
	FROM BOOK_LOANS)
;
------------------------------------------*/


/*----------------------------------------------------------------
Query each book that is loaned out from the "Sharpstown" branch and
whose DueDate is today, retrieve the book title, the borrower's name, 
and the borrower's address.
-------------------------------------------------------------------*/

SELECT b.Title, c.Name, c.Address
FROM BOOK_LOANS a
	INNER JOIN BOOK b ON b.BookId = a.BookId
	INNER JOIN BORROWER c ON c.CardNo = a.CardNo
	INNER JOIN LIBRARY_BRANCH d ON d.BranchId = a.BranchId
WHERE d.BranchName = 'Sharpstown' AND a.DueDate = '2017-05-30'
;

/*------------------------------------------------------
For each library branch, retrieve the branch name and the 
total number of books loaned out from that branch.
--------------------------------------------------------*/

SELECT a.BranchName, COUNT(*) AS 'Loans'
FROM LIBRARY_BRANCH a
	INNER JOIN BOOK_LOANS b ON b.BranchId = a.BranchId
WHERE b.DueDate > '2017-05-30'
GROUP BY (a.BranchName)
;

/*-------------------------------------------------------------
Retrieve the names, addresses, and number of books checked 
out for all borrowers who have more than five books checked out.
----------------------------------------------------------------*/

SELECT a.Name, a.Address, COUNT(*) AS 'Number of Books Checked Out'
FROM  BORROWER a
	INNER JOIN BOOK_LOANS b ON b.CardNo = a.CardNo
WHERE b.DueDate > '2017-05-30'
GROUP BY a.Name, a.Address
HAVING COUNT(*) > 5
;

/*------------------------------------------------------------
For each book authored (or co-authored) by "Stephen King", 
retrieve the title and the number of copies owned by the library 
branch whose name is "Central".
---------------------------------------------------------------*/

SELECT b.Title, a.No_Of_Copies
FROM BOOK_COPIES a
	INNER JOIN BOOK b ON b.BookId = a.BookId
	INNER JOIN BOOK_AUTHOR c ON c.BookId = a.BookId
	INNER JOIN LIBRARY_BRANCH d ON d.BranchId = a.BranchId
WHERE c.AuthorName LIKE '%Stephen King%' AND d.BranchName = 'Central'
;


END
GO