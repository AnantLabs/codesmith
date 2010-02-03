--region Drop Existing Procedures

IF OBJECT_ID(N'[dbo].[CSLA_LineItem_Insert]') IS NOT NULL
	DROP PROCEDURE [dbo].[CSLA_LineItem_Insert]

IF OBJECT_ID(N'[dbo].[CSLA_LineItem_Update]') IS NOT NULL
	DROP PROCEDURE [dbo].[CSLA_LineItem_Update]

IF OBJECT_ID(N'[dbo].[CSLA_LineItem_Delete]') IS NOT NULL
	DROP PROCEDURE [dbo].[CSLA_LineItem_Delete]

IF OBJECT_ID(N'[dbo].[CSLA_LineItem_Select]') IS NOT NULL
	DROP PROCEDURE [dbo].[CSLA_LineItem_Select]

--endregion

GO

--region [dbo].[CSLA_LineItem_Insert]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Blake Niemyjski using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0
-- Procedure Name: [dbo].[CSLA_LineItem_Insert]
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[CSLA_LineItem_Insert]
	@p_OrderId int,
	@p_LineNum int,
	@p_ItemId varchar(10),
	@p_Quantity int,
	@p_UnitPrice decimal(10, 2)
AS

INSERT INTO [dbo].[LineItem] (
	[OrderId],
	[LineNum],
	[ItemId],
	[Quantity],
	[UnitPrice]
) VALUES (
	@p_OrderId,
	@p_LineNum,
	@p_ItemId,
	@p_Quantity,
	@p_UnitPrice
)

--endregion

GO

--region [dbo].[CSLA_LineItem_Update]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Blake Niemyjski using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0
-- Procedure Name: [dbo].[CSLA_LineItem_Update]
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[CSLA_LineItem_Update]
	@p_OrderId int,
	@p_LineNum int,
	@p_ItemId varchar(10),
	@p_Quantity int,
	@p_UnitPrice decimal(10, 2)
AS

UPDATE [dbo].[LineItem] SET
	[ItemId] = @p_ItemId,
	[Quantity] = @p_Quantity,
	[UnitPrice] = @p_UnitPrice
WHERE
	[OrderId] = @p_OrderId
	AND [LineNum] = @p_LineNum

--endregion

GO

--region [dbo].[CSLA_LineItem_Delete]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Blake Niemyjski using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0
-- Procedure Name: [dbo].[CSLA_LineItem_Delete]
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[CSLA_LineItem_Delete]
	@p_OrderId int,
	@p_LineNum int
AS

DELETE FROM
    [dbo].[LineItem]
WHERE
	[OrderId] = @p_OrderId
	AND [LineNum] = @p_LineNum

--endregion

GO

--region [dbo].[CSLA_LineItem_Select]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Blake Niemyjski using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0
-- Procedure Name: [dbo].[CSLA_LineItem_Select]
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[CSLA_LineItem_Select]
	@p_OrderId int = NULL,
	@p_LineNum int = NULL,
	@p_ItemId varchar(10) = NULL,
	@p_Quantity int = NULL,
	@p_UnitPrice decimal(10, 2) = NULL
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[OrderId],
	[LineNum],
	[ItemId],
	[Quantity],
	[UnitPrice]
FROM
    [dbo].[LineItem]
WHERE
	([OrderId] = @p_OrderId OR @p_OrderId IS NULL)
	AND ([LineNum] = @p_LineNum OR @p_LineNum IS NULL)
	AND ([ItemId] = @p_ItemId OR @p_ItemId IS NULL)
	AND ([Quantity] = @p_Quantity OR @p_Quantity IS NULL)
	AND ([UnitPrice] = @p_UnitPrice OR @p_UnitPrice IS NULL)

--endregion

GO

