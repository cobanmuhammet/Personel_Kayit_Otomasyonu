USE [PersonelVeriTabanı]
GO
/****** Object:  Table [dbo].[KullaniciBilgi]    Script Date: 21.03.2024 22:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KullaniciBilgi](
	[KullaniciAdi] [varchar](50) NULL,
	[Sifre] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Personel]    Script Date: 21.03.2024 22:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Personel](
	[Perid] [smallint] IDENTITY(1,1) NOT NULL,
	[PerAd] [varchar](10) NULL,
	[PerSoyad] [varchar](20) NULL,
	[PerSehir] [varchar](13) NULL,
	[PerMaas] [smallint] NULL,
	[PerDurum] [bit] NULL,
	[PerMeslek] [varchar](15) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Personel] ON 

INSERT [dbo].[Tbl_Personel] ([Perid], [PerAd], [PerSoyad], [PerSehir], [PerMaas], [PerDurum], [PerMeslek]) VALUES (1, N'Mehmet', N'Kartal', N'İstanbul', 5000, 1, N'Yazılımcı')
INSERT [dbo].[Tbl_Personel] ([Perid], [PerAd], [PerSoyad], [PerSehir], [PerMaas], [PerDurum], [PerMeslek]) VALUES (2, N'Mahmut', N'Aslan', N'Ankara', 4650, 0, N'Yazılımcı')
SET IDENTITY_INSERT [dbo].[Tbl_Personel] OFF
