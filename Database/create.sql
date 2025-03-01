USE [FashionShopManagement]
GO
/****** Object:  StoredProcedure [dbo].[USP_GetBillInfoDetailByMonth]    Script Date: 11/14/2024 11:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[USP_GetBillInfoDetailByMonth]
    @Year INT,
    @Month INT
AS
	SELECT b.ID, b.BusinessTime, b.Discount, b.TotalPrice, b.Status,
		bi.ProductID, p.Name AS ProductName, p.Price AS ProductPrice, p.Discount AS ProductDiscount, 
		bi.Amount, 
		b.CustomerID, c.CustomerName, 
		b.StaffID, a.DisplayName AS StaffName
	FROM dbo.Bill b
	INNER JOIN dbo.BillInfo bi ON b.ID = bi.BillID
	INNER JOIn dbo.Product p ON bi.ProductID = p.Id
	INNER JOIN dbo.Customer c ON c.CustomerId = b.CustomerID
	INNER JOIN dbo.Account a ON a.Id = b.StaffID
	WHERE YEAR(b.BusinessTime) = @Year AND MONTH(b.BusinessTime) = @Month
		AND b.Status = 1