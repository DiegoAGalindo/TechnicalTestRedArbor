/****** Object:  Table [dbo].[Employee]    Script Date: 17/04/2021 3:30:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[CreatedOn] [date] NULL,
	[DeletedOn] [date] NULL,
	[Email] [nvarchar](100) NULL,
	[Fax] [nvarchar](20) NULL,
	[LastLogin] [date] NULL,
	[Name] [nvarchar](100) NULL,
	[Password] [nvarchar](50) NULL,
	[PortalId] [int] NULL,
	[RoleId] [int] NULL,
	[StatusId] [int] NULL,
	[Telephone] [nvarchar](20) NULL,
	[UpdatedOn] [date] NULL,
	[Username] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeById]    Script Date: 17/04/2021 3:30:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Galindo	
-- =============================================
create PROCEDURE [dbo].[DeleteEmployeeById]
@Id numeric(11,0)	
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Employee WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeById]    Script Date: 17/04/2021 3:30:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Galindo	
-- =============================================
CREATE PROCEDURE [dbo].[GetEmployeeById]
@Id numeric(11,0)	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Employee WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SpGetEmployees]    Script Date: 17/04/2021 3:30:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Galindo	
-- =============================================
create PROCEDURE [dbo].[SpGetEmployees]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Employee 
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertEmployees]    Script Date: 17/04/2021 3:30:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Galindo	
-- =============================================
CREATE PROCEDURE [dbo].[SpInsertEmployees]
@CompanyId int,
@CreatedOn date,
@DeletedOn date,
@Email nvarchar(100),
@Fax nvarchar(20),
@LastLogin date,
@Name nvarchar(100),
@Password nvarchar(50),
@PortalId int,
@RoleId int,
@StatusId int,
@Telephone nvarchar(20),
@UpdatedOn date,
@Username nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Employee] (
        [CompanyId]
        ,[CreatedOn]
        ,[DeletedOn]
        ,[Email]
        ,[Fax]
        ,[LastLogin]
        ,[Name]
        ,[Password]
        ,[PortalId]
        ,[RoleId]
        ,[StatusId]
        ,[Telephone]
        ,[UpdatedOn]
        ,[Username]
    ) VALUES (
        @CompanyId ,
        @CreatedOn, 
        @DeletedOn, 
        @Email, 
        @Fax, 
        @LastLogin, 
        @Name, 
        @Password, 
        @PortalId, 
        @RoleId, 
        @StatusId, 
        @Telephone, 
        @UpdatedOn, 
        @Username 
    );
	SELECT @@IDENTITY AS 'Id';
           
END
GO
/****** Object:  StoredProcedure [dbo].[SpUpdateEmployees]    Script Date: 17/04/2021 3:30:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Galindo	
-- =============================================
CREATE PROCEDURE [dbo].[SpUpdateEmployees]
@Id int,
@CompanyId int,
@CreatedOn date,
@DeletedOn date,
@Email nvarchar(100),
@Fax nvarchar(20),
@LastLogin date,
@Name nvarchar(100),
@Password nvarchar(50),
@PortalId int,
@RoleId int,
@StatusId int,
@Telephone nvarchar(20),
@UpdatedOn date,
@Username nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[Employee]
   SET [CompanyId] = @CompanyId
      ,[CreatedOn] = @CreatedOn
      ,[DeletedOn] = @DeletedOn
      ,[Email] = @Email
      ,[Fax] = @Fax
      ,[LastLogin] = @LastLogin
      ,[Name] = @Name
      ,[Password] = @Password
      ,[PortalId] = @PortalId
      ,[RoleId] = @RoleId
      ,[StatusId] = @StatusId
      ,[Telephone] = @Telephone
      ,[UpdatedOn] = @UpdatedOn
      ,[Username] = @Username
 WHERE Id = @Id
           
END
GO
