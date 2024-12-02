using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Shared.Constants
{
    public class SQLConstant
    {
        #region Product
        public const string Get_All_Products = @"SELECT *
                                                FROM Product
                                                ORDER BY RowId
                                                OFFSET @Skip ROWS FETCH NEXT 8 ROWS ONLY;";

        public const string Update_Product_By_Id = @"UPDATE Product
                                                    Set ProductName = @ProductName,
	                                                    ProductDescription = @ProductDescription, 
	                                                    ProductPrice = @Price
                                                    WHERE Product.RowId = @RowId";
        public const string DELETE_PRODUCT_BYID = @"DELETE FROM Product
                                                    WHERE RowId = @RowId";
        public const string Add_PRODUCT = @"INSERT INTO Product (ProductName, ProductDescription, ProductPrice,QuantityInStock,CreatedDate,ModifiedDate)
                                            VALUES (@ProductName, @ProductDescription, @Price, @QuantityInStock,@CreateDate,@ModifyDate)";
        public const string SEARCH_PRODUCT = @"
                                                SELECT *
                                                FROM Product
                                                WHERE [ProductName] COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%'+@searchValue+'%' COLLATE SQL_Latin1_General_CP1_CI_AI
                                                ORDER BY RowId ASC
                                                OFFSET @Skip ROWS
                                                FETCH NEXT 8 ROWS ONLY";

        #endregion

        #region OrderDetail
        public const string GET_ORDERDETAIL_BY_ID = @"SELECT 
                                                            OD.RowId,
                                                            P.ProductName, 
                                                            C.UserName, 
                                                            O.OrderDate, 
                                                            OD.Quantity, 
                                                            OD.UnitPrice
                                                        FROM 
                                                            [DTPaint].[dbo].[Order] AS O
                                                            INNER JOIN [DTPaint].[dbo].[User] AS C ON O.UserId = C.RowId
                                                            INNER JOIN [DTPaint].[dbo].[OrderDetail] AS OD ON O.RowId = OD.OrderId
                                                            INNER JOIN [DTPaint].[dbo].[Product] AS P ON OD.ProductId = P.RowId
                                                        WHERE
                                                            O.UserId = @RowId";
        public const string Update_ORDERDETAIL = @" UPDATE OrderDetail
                                                    SET Quantity = @Quantity
                                                    WHERE 
	                                                    RowId = @OrderDetailId";
        public const string ADD_ORDERDETAIL = @"INSERT INTO OrderDetail (OrderId,ProductId,Quantity,UnitPrice,Subtotal,ModifiedDate,ModifiedBy,CreatedDate,CreatedBy)
                                                VALUES (@OrderId,@ProductId,@Quantity,@UnitPrice,@Subtotal,@ModifiedDate,@ModifiedBy,@CreatedDate,@CreatedBy)";
        public const string DELETE_ORDERDETAIL_BY_ID = @"DELETE FROM OrderDetail
                                                         WHERE RowId = @RowId";
        #endregion

        #region Order
        public const string ADD_ORDER = @"INSERT INTO [Order] (UserId,OrderDate,Status,TotalAmount,ModifiedDate,ModifiedBy,CreatedDate,CreatedBy)
                                                VALUES (@UserId,@OrderDate,@Status,@TotalAmount,@ModifiedDate,@ModifiedBy,@CreatedDate,@CreatedBy)";
        public const string GET_ALL_ORDER_BY_USER = @"SELECT    OD.RowId AS OrderDetailId,
                                                                P.ProductName AS ProductName,
	                                                            P.ProductPrice AS ProductPrice,
		                                                        OD.Quantity AS Quantity,
	                                                            O.Status AS STATUS,
	                                                            O.OrderDate AS OrderDate,
	                                                            U.UserName AS UserName,
	                                                            OD.UnitPrice AS UnitPrice,
		                                                        O.UserId AS UserId,
		                                                        OD.RowId AS OrderDetailId,
		                                                        U.Address AS Address,
		                                                        U.PhoneNumber AS PhoneNumber
                                                        FROM [Order] O
                                                        INNER JOIN [User] U ON U.RowId = O.UserId
                                                        INNER JOIN [OrderDetail] OD ON OD.OrderId = O.RowId
                                                        INNER JOIN [Product] P ON OD.ProductId = P.RowId
                                                        WHERE O.UserId = UserId";
        public const string Get_Checkout_ForPayment = @"SELECT ProductName,ProductPrice, Quantity
                                                         FROM [OrderDetail] DT
                                                         INNER JOIN [Product] P ON DT.ProductId = P.RowId
                                                         INNER JOIN [Order] O ON DT.OrderId = O.RowId
                                                         WHERE O.UserId = @UserId
                                                        ";
        #endregion

        #region User
        public const string Get_User = @"SELECT RowId ,
                                        UserName as UserName,
                                        UserPassword as Password,
                                        UserRole as UserRole, 
                                        UserEmail as UserEmail,
                                        Address as Address,
                                        PhoneNumber as  UserPhone
                                          FROM [DTPaint].[dbo].[User]
                                          Where UserEmail = @email";

        public const string Register_Account = @"INSERT INTO [User] (UserName,UserEmail,UserPassword,CreatedDate,ModifiedDate)
                                                VALUES(@name,@email,@password,@CreatedDate,@ModifiedDate)";
        #endregion

    }
}
