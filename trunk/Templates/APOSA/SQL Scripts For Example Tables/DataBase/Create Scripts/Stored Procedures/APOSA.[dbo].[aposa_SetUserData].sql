/****** Object:  Procedure [dbo].[aposa_SetUserData]    Script Date: 04/17/2007 10:00:51 AM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[aposa_SetUserData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[aposa_SetUserData]
GO
/*********************************************************************************************
 
 Created By: This code was generated by APOSA CodeSmith Domain Object Template.
 Date:    04/17/2007
 Time:    10:00 AM
 Version: 4.0.0.0

 Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.

 Procedure Name: [dbo].[aposa_SetUserData]
 
 Description: User Table
 
 Parameters: 
		@UserID int OUTPUT,
		@UserName varchar(50),
		@DateCreated datetime,
		@IsActive bit,
		@RandomColumn1 char(10),
		@RandomColumn2 char(10),
		@TransactionType int
       
--region RevisionLog
***************************************  Revision Log  ***************************************
 
Version   Date        Revised By       Description / WO#
--------  ----------  ---------------  -------------------------------------------------------
   
**********************************************************************************************/
--endregion
CREATE PROCEDURE [dbo].[aposa_SetUserData]
(
	@UserID int OUTPUT,
	@UserName varchar(50),
	@DateCreated datetime,
	@IsActive bit,
	@RandomColumn1 char(10),
	@RandomColumn2 char(10),
	@TransactionType int
)
AS

SET NOCOUNT ON
DECLARE @ROWCOUNT int
IF @TransactionType in (2,3,4)
BEGIN
	UPDATE [dbo].[User] 
	SET    
		[UserName] = @UserName,
		[DateCreated] = @DateCreated,
		[IsActive] = @IsActive,
		[Random Column 1] = @RandomColumn1,
		[Random_Column2] = @RandomColumn2

	WHERE
		[UserID] = @UserID

	SET @ROWCOUNT = @@ROWCOUNT
	if(@@ERROR <> 0)
	BEGIN
		RAISERROR ('Could not update record.', 16, 1)  	
		RETURN @@ERROR
	END
	IF (@ROWCOUNT < 1)
	BEGIN
		
		INSERT INTO [dbo].[User] 
		(
			[UserName],
			[DateCreated],
			[IsActive],
			[Random Column 1],
			[Random_Column2]

		) 
		VALUES 
		(
			@UserName,
			@DateCreated,
			@IsActive,
			@RandomColumn1,
			@RandomColumn2

		)
		SET @UserID = SCOPE_IDENTITY()
		
		if(@@ERROR <> 0)
		BEGIN
			RAISERROR ('Could not insert record.', 16, 1)  
			RETURN @@ERROR
		END
	END
END
ELSE IF @TransactionType in (1)
BEGIN
	DELETE FROM [dbo].[User] 	
	WHERE
		[UserID] = @UserID

	
	if(@@ERROR <> 0)
	BEGIN
		RAISERROR ('Could not update record.', 16, 1)  	
		RETURN @@ERROR
	END
	
END
ELSE 
	BEGIN
		RAISERROR ('Not a valid TransactionType. This value should be Delete = 1,Insert = 2,Update = 3,InsertUpdate = 4.', 16, 1)  
		RETURN -1	
	END
--region [dbo].[aposa_SetUserData]
------------------------------------------------------------------------------------------------------------------------");
-- Generated By:   cl1 using CodeSmith 4.0.0.0
-- Template:       UpdateInsertStoredProcedure.cst
-- Procedure Name: [dbo].[aposa_SetUserData]
-- Date Generated: Tuesday, April 17, 2007
------------------------------------------------------------------------------------------------------------------------");
--endregion

