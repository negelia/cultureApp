USE [master]
GO
/****** Object:  Database [Culture_ProjectDB]    Script Date: 30.01.2022 12:09:11 ******/
CREATE DATABASE [Culture_ProjectDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Culture_ProjectDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Culture_ProjectDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Culture_ProjectDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Culture_ProjectDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Culture_ProjectDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Culture_ProjectDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Culture_ProjectDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Culture_ProjectDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Culture_ProjectDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Culture_ProjectDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Culture_ProjectDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Culture_ProjectDB] SET  MULTI_USER 
GO
ALTER DATABASE [Culture_ProjectDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Culture_ProjectDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Culture_ProjectDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Culture_ProjectDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Culture_ProjectDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Culture_ProjectDB] SET QUERY_STORE = OFF
GO
USE [Culture_ProjectDB]
GO
/****** Object:  Table [dbo].[Theatres]    Script Date: 30.01.2022 12:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Theatres](
	[ID_Theatre] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Feature] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Theatres] PRIMARY KEY CLUSTERED 
(
	[ID_Theatre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Concerts]    Script Date: 30.01.2022 12:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concerts](
	[ID_Concert] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Genre] [varchar](50) NOT NULL,
	[Concert_Date] [date] NOT NULL,
	[Ticket] [decimal](18, 0) NOT NULL,
	[ID_Theatre] [int] NOT NULL,
	[ID_Actor] [int] NOT NULL,
	[ID_Reward] [int] NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[ID_Concert] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Afisha]    Script Date: 30.01.2022 12:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Afisha]
AS
SELECT dbo.Concerts.ID_Concert, dbo.Theatres.ID_Theatre, dbo.Concerts.Title AS Название, dbo.Concerts.Concert_Date AS Дата, dbo.Concerts.Genre AS Жанр, dbo.Theatres.Title AS Место, dbo.Concerts.Ticket AS Стоимость
FROM     dbo.Concerts INNER JOIN
                  dbo.Theatres ON dbo.Concerts.ID_Theatre = dbo.Theatres.ID_Theatre
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 30.01.2022 12:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[ID_Actor] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Middle_Name] [varchar](50) NULL,
	[BIrthday] [date] NOT NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[ID_Actor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rewards]    Script Date: 30.01.2022 12:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rewards](
	[ID_Reward] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rewards] PRIMARY KEY CLUSTERED 
(
	[ID_Reward] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Award]    Script Date: 30.01.2022 12:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Award]
AS
SELECT dbo.Actors.ID_Actor, dbo.Concerts.ID_Concert, dbo.Rewards.ID_Reward, dbo.Concerts.Title AS Концерт, dbo.Rewards.Title AS Награда, dbo.Actors.Surname AS Фамилия, dbo.Actors.Name AS Имя, 
                  dbo.Actors.Middle_Name AS Отчество
FROM     dbo.Actors INNER JOIN
                  dbo.Concerts ON dbo.Actors.ID_Actor = dbo.Concerts.ID_Actor INNER JOIN
                  dbo.Rewards ON dbo.Concerts.ID_Reward = dbo.Rewards.ID_Reward
GO
/****** Object:  Table [dbo].[Managers]    Script Date: 30.01.2022 12:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Managers](
	[ID_Manager] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Middle_Name] [varchar](50) NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[ID_Manager] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Concerts]  WITH CHECK ADD  CONSTRAINT [FK_Concerts_Actors] FOREIGN KEY([ID_Actor])
REFERENCES [dbo].[Actors] ([ID_Actor])
GO
ALTER TABLE [dbo].[Concerts] CHECK CONSTRAINT [FK_Concerts_Actors]
GO
ALTER TABLE [dbo].[Concerts]  WITH CHECK ADD  CONSTRAINT [FK_Concerts_Rewards] FOREIGN KEY([ID_Reward])
REFERENCES [dbo].[Rewards] ([ID_Reward])
GO
ALTER TABLE [dbo].[Concerts] CHECK CONSTRAINT [FK_Concerts_Rewards]
GO
ALTER TABLE [dbo].[Concerts]  WITH CHECK ADD  CONSTRAINT [FK_Concerts_Theatres] FOREIGN KEY([ID_Theatre])
REFERENCES [dbo].[Theatres] ([ID_Theatre])
GO
ALTER TABLE [dbo].[Concerts] CHECK CONSTRAINT [FK_Concerts_Theatres]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Concerts"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Theatres"
            Begin Extent = 
               Top = 26
               Left = 336
               Bottom = 167
               Right = 537
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Afisha'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Afisha'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Actors"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Concerts"
            Begin Extent = 
               Top = 7
               Left = 297
               Bottom = 170
               Right = 498
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Rewards"
            Begin Extent = 
               Top = 7
               Left = 546
               Bottom = 126
               Right = 747
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Award'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Award'
GO
USE [master]
GO
ALTER DATABASE [Culture_ProjectDB] SET  READ_WRITE 
GO
