USE [DbDapperRealEstate]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddresstID] [int] IDENTITY(1,1) NOT NULL,
	[AddressTitle1] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[AddressTitle2] [nvarchar](100) NULL,
	[Phone1] [nvarchar](50) NULL,
	[Phone2] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Location] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[AddresstID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Amenity]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amenity](
	[AmenityId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Amenity] PRIMARY KEY CLUSTERED 
(
	[AmenityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRole]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRole](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_AppRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUser]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](70) NULL,
	[UserRole] [int] NULL,
	[UserImageUrl] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](40) NULL,
 CONSTRAINT [PK_AppUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BottomGrid]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BottomGrid](
	[BottomGridID] [int] IDENTITY(1,1) NOT NULL,
	[Icon] [nvarchar](100) NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[BottomGridID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[CategoryStatus] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Title] [nvarchar](100) NULL,
	[Comment] [nvarchar](2000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Subject] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Message] [nvarchar](max) NULL,
	[SendDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Title] [nvarchar](100) NULL,
	[Mail] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](100) NULL,
	[ImageUrl] [nvarchar](100) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MailSubscribe]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MailSubscribe](
	[MailID] [int] IDENTITY(1,1) NOT NULL,
	[EMail] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[Sender] [int] NULL,
	[Subject] [nvarchar](70) NULL,
	[Receiver] [int] NULL,
	[Detail] [nvarchar](max) NULL,
	[SendDate] [date] NULL,
	[IsRead] [bit] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PopularLocation]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PopularLocation](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NULL,
	[ImageUrl] [nvarchar](400) NULL,
	[PropertyCount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[AppUserId] [int] NULL,
	[Title] [nvarchar](100) NULL,
	[SlugUrl] [nvarchar](100) NULL,
	[Price] [decimal](18, 2) NULL,
	[CoverImage] [nvarchar](250) NULL,
	[City] [nvarchar](100) NULL,
	[District] [nvarchar](100) NULL,
	[Address] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[Type] [nvarchar](50) NULL,
	[ProductCategory] [int] NULL,
	[AdvertisementDate] [date] NULL,
	[DealOfTheDay] [bit] NULL,
	[ProductStatus] [bit] NULL,
 CONSTRAINT [PK__Product__B40CC6ED948962C6] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetails]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetails](
	[ProductDetailID] [int] IDENTITY(1,1) NOT NULL,
	[ProductSize] [int] NULL,
	[BedRoomCount] [tinyint] NULL,
	[BathCount] [tinyint] NULL,
	[RoomCount] [tinyint] NULL,
	[GarageSize] [tinyint] NULL,
	[BuildYear] [char](4) NULL,
	[Price] [decimal](18, 2) NULL,
	[Location] [nvarchar](50) NULL,
	[VideoUrl] [nvarchar](max) NULL,
	[ProductID] [int] NULL,
	[LocationMap] [nvarchar](max) NULL,
 CONSTRAINT [PK__ProductD__3C8DD6945B3840ED] PRIMARY KEY CLUSTERED 
(
	[ProductDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ProductImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[ProductId] [int] NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[ProductImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyAmenity]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyAmenity](
	[PropertyAmenityId] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[AmenityId] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_PropertyAmenity] PRIMARY KEY CLUSTERED 
(
	[PropertyAmenityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](100) NULL,
	[ServiceStatus] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialMedia]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialMedia](
	[SocialMediaID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Icon] [nvarchar](100) NULL,
	[SocialMediaUrl] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[SocialMediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubFeature]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubFeature](
	[SubFeatureID] [int] IDENTITY(1,1) NOT NULL,
	[Icon] [nvarchar](100) NULL,
	[TopTitle] [nvarchar](100) NULL,
	[MainTitle] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NULL,
	[SubTitle] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubFeatureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Testimonial]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Testimonial](
	[TestimonialID] [int] IDENTITY(1,1) NOT NULL,
	[NameSurname] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Comment] [nvarchar](500) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TestimonialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToDoList]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToDoList](
	[ToDoListID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ToDoListStatus] [bit] NULL,
 CONSTRAINT [PK_ToDoList] PRIMARY KEY CLUSTERED 
(
	[ToDoListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WhoWeAreDetail]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WhoWeAreDetail](
	[WhoWeAreDetailID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[SubTitle] [nvarchar](100) NULL,
	[Description1] [nvarchar](500) NULL,
	[Description2] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[WhoWeAreDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Amenity] ON 

INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (1, N'Klima')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (2, N'Alarm Sistemi')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (3, N'Wifi')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (4, N'Merkezi Tv')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (5, N'Şömine')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (6, N'Panjur')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (7, N'Zemin Isıtması')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (8, N'Eşyalı')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (9, N'Güvenlik')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (10, N'Havuz')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (11, N'Çamaşır Odası')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (12, N'Ebeveyn Banyosu')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (13, N'Gömme Dolap')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (14, N'Boyalı')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (15, N'Çelik Kapı')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (16, N'Küvet')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (17, N'Yangın Merdiveni')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (18, N'Apartman Görevlisi')
INSERT [dbo].[Amenity] ([AmenityId], [Title]) VALUES (19, N'Ses Yalıtımı')
SET IDENTITY_INSERT [dbo].[Amenity] OFF
GO
SET IDENTITY_INSERT [dbo].[AppRole] ON 

INSERT [dbo].[AppRole] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[AppRole] ([RoleId], [RoleName]) VALUES (2, N'Member')
INSERT [dbo].[AppRole] ([RoleId], [RoleName]) VALUES (3, N'Manager')
INSERT [dbo].[AppRole] ([RoleId], [RoleName]) VALUES (4, N'Visitor')
INSERT [dbo].[AppRole] ([RoleId], [RoleName]) VALUES (5, N'Employee')
SET IDENTITY_INSERT [dbo].[AppRole] OFF
GO
SET IDENTITY_INSERT [dbo].[AppUser] ON 

INSERT [dbo].[AppUser] ([UserId], [UserName], [Password], [Name], [Email], [UserRole], [UserImageUrl], [PhoneNumber]) VALUES (1, N'baran', N'1234', N'Baran Yücedağ', N'baran@gmail.com', 1, N'https://www.rismedia.com/wp-content/uploads/2018/01/productive_agent_667961228.jpg', N'0551 123 2212')
INSERT [dbo].[AppUser] ([UserId], [UserName], [Password], [Name], [Email], [UserRole], [UserImageUrl], [PhoneNumber]) VALUES (2, N'eylul', N'0000', N'Eylül Yıldız', N'eylul@gmail.com', 2, N'https://s3-media0.fl.yelpcdn.com/bphoto/ZTreEBb_x1cHkgARX-hSVw/1000s.jpg', N'0551 123 2323')
INSERT [dbo].[AppUser] ([UserId], [UserName], [Password], [Name], [Email], [UserRole], [UserImageUrl], [PhoneNumber]) VALUES (3, N'ali01', N'1111', N'Ali Kaya', N'ali@gmail.com', 1, N'https://www.rismedia.com/wp-content/uploads/2018/01/productive_agent_667961228.jpg', N'0551 123 23 23')
SET IDENTITY_INSERT [dbo].[AppUser] OFF
GO
SET IDENTITY_INSERT [dbo].[BottomGrid] ON 

INSERT [dbo].[BottomGrid] ([BottomGridID], [Icon], [Title], [Description]) VALUES (1, N'fa fa-home', N'Hayalinizdeki Evi Satın Alın', N'Yılların tecrübesini hissedin.')
INSERT [dbo].[BottomGrid] ([BottomGridID], [Icon], [Title], [Description]) VALUES (2, N'fa fa-home', N'Ev Kiralayın', N'Depreme Dayanıklı Daireler .')
INSERT [dbo].[BottomGrid] ([BottomGridID], [Icon], [Title], [Description]) VALUES (3, N'fa fa-building-o', N'Komşularınızı Görün', N'Doğayla iç içe.')
SET IDENTITY_INSERT [dbo].[BottomGrid] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (1, N'Villa', 1)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (2, N'Apartman', 1)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (3, N'Yazlık', 1)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (4, N'Tarla', 1)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (5, N'Bahçe', 0)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryStatus]) VALUES (10, N'Yalı', 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ContactID], [Name], [Subject], [Email], [Message], [SendDate]) VALUES (1, N'Emre Binici', N'Teşekkür', N'emre@gmail.com', N'Ev gerçekten harika , teşekkürler', CAST(N'2024-11-08' AS Date))
INSERT [dbo].[Contact] ([ContactID], [Name], [Subject], [Email], [Message], [SendDate]) VALUES (2, N'Ali Çınar', N'Şikayet', N'ali@gmail.com', N'Çatı akıtıyor!!', CAST(N'2024-12-08' AS Date))
INSERT [dbo].[Contact] ([ContactID], [Name], [Subject], [Email], [Message], [SendDate]) VALUES (3, N'Eylül Deniz', N'Üst Komşu', N'Eylül@gmail.com', N'Üst komşu çok ses yapıyor.', CAST(N'2024-08-08' AS Date))
INSERT [dbo].[Contact] ([ContactID], [Name], [Subject], [Email], [Message], [SendDate]) VALUES (4, N'Veli Yılmaz', N'Bahçe', N'Veli@gmail.com', N'Bahçe Gerçekten çok kullanışlı, teşekkürler.', CAST(N'2024-11-10' AS Date))
INSERT [dbo].[Contact] ([ContactID], [Name], [Subject], [Email], [Message], [SendDate]) VALUES (5, N'Merve Sancak', N'Aidat', N'Merve@gmail.com', N'Aidatlar çok pahalı', CAST(N'2024-08-05' AS Date))
INSERT [dbo].[Contact] ([ContactID], [Name], [Subject], [Email], [Message], [SendDate]) VALUES (6, N'Aliye Yılmaz', N'Güvenlik', N'Aliye@gmail.com', N'Güvenlik yeterli değil.', CAST(N'2024-02-03' AS Date))
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [Name], [Title], [Mail], [PhoneNumber], [ImageUrl], [Status]) VALUES (1, N'Ali Çınar', N'Mühendisss', N'ali@gmail.com', N'5512356688', N'Boş', 1)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Title], [Mail], [PhoneNumber], [ImageUrl], [Status]) VALUES (2, N'Veysel Doğru', N'Mühendis', N'veysel@gmail.com', N'5512358899', N' boş', 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Message] ON 

INSERT [dbo].[Message] ([MessageId], [Sender], [Subject], [Receiver], [Detail], [SendDate], [IsRead]) VALUES (1, 1, N'Bir Soru?', 3, N'Merhaba rica etsem görünce arar mısın ?', CAST(N'2025-11-24' AS Date), 0)
INSERT [dbo].[Message] ([MessageId], [Sender], [Subject], [Receiver], [Detail], [SendDate], [IsRead]) VALUES (2, 3, N'Cevap', 1, N'Müsait Olunca Döneceğim.', CAST(N'2025-11-25' AS Date), 0)
INSERT [dbo].[Message] ([MessageId], [Sender], [Subject], [Receiver], [Detail], [SendDate], [IsRead]) VALUES (3, 2, N'Maç', 3, N'Yarın Maça Gelecek Misin', CAST(N'2025-11-25' AS Date), 0)
SET IDENTITY_INSERT [dbo].[Message] OFF
GO
SET IDENTITY_INSERT [dbo].[PopularLocation] ON 

INSERT [dbo].[PopularLocation] ([LocationID], [CityName], [ImageUrl], [PropertyCount]) VALUES (1, N'Budapeşte', N'/cityimages/budapest.jpg', 0)
INSERT [dbo].[PopularLocation] ([LocationID], [CityName], [ImageUrl], [PropertyCount]) VALUES (2, N'Dresten', N'/cityimages/dresden.jpg', 0)
INSERT [dbo].[PopularLocation] ([LocationID], [CityName], [ImageUrl], [PropertyCount]) VALUES (3, N'Liviv', N'/cityimages/lviv.jpg', 0)
INSERT [dbo].[PopularLocation] ([LocationID], [CityName], [ImageUrl], [PropertyCount]) VALUES (4, N'Lyon', N'/cityimages/lyon.jpg', 0)
INSERT [dbo].[PopularLocation] ([LocationID], [CityName], [ImageUrl], [PropertyCount]) VALUES (5, N'Miami', N'/cityimages/miami.jpg', 0)
INSERT [dbo].[PopularLocation] ([LocationID], [CityName], [ImageUrl], [PropertyCount]) VALUES (6, N'Montenegro', N'/cityimages/montenegro.jpg', 0)
INSERT [dbo].[PopularLocation] ([LocationID], [CityName], [ImageUrl], [PropertyCount]) VALUES (7, N'Roma', N'/cityimages/rome.jpg', 1)
INSERT [dbo].[PopularLocation] ([LocationID], [CityName], [ImageUrl], [PropertyCount]) VALUES (8, N'Sofya', N'/cityimages/sofia.jpg', 0)
SET IDENTITY_INSERT [dbo].[PopularLocation] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [AppUserId], [Title], [SlugUrl], [Price], [CoverImage], [City], [District], [Address], [Description], [Type], [ProductCategory], [AdvertisementDate], [DealOfTheDay], [ProductStatus]) VALUES (1, 1, N'Metroya 5 dakika', N'metroya-yakin-daire', CAST(300000.00 AS Decimal(18, 2)), N'/starter/images/1.jpg', N'Budapeşte', N'Merkez', N'Balkan Sokak No:4', N'Enflasyona inat kaçırılmayacak fırsat.', N'Satılık', 1, CAST(N'2024-11-08' AS Date), 1, 1)
INSERT [dbo].[Product] ([ProductID], [AppUserId], [Title], [SlugUrl], [Price], [CoverImage], [City], [District], [Address], [Description], [Type], [ProductCategory], [AdvertisementDate], [DealOfTheDay], [ProductStatus]) VALUES (2, 1, N'Sahibinden Yazlık', N'sahibinden-yazlik', CAST(240000.00 AS Decimal(18, 2)), N'/starter/images/2.jpg', N'Dresten', N'2.Bölge', N'Papatya Sokak No:20', N'Depreme dayanıklı yeni bina.', N'Satılık', 5, CAST(N'2024-05-05' AS Date), 1, 1)
INSERT [dbo].[Product] ([ProductID], [AppUserId], [Title], [SlugUrl], [Price], [CoverImage], [City], [District], [Address], [Description], [Type], [ProductCategory], [AdvertisementDate], [DealOfTheDay], [ProductStatus]) VALUES (3, 1, N'Ucuz Fiyatlı Daire', N'ucuz-fiyatli-daire', CAST(180000.00 AS Decimal(18, 2)), N'/starter/images/3.jpg', N'Liviv', N'Merkez', N'Çiçek Sokak No:15', N'Manzara Ayağınıza Geldi.', N'Satılık', 1, CAST(N'2024-06-05' AS Date), 1, 1)
INSERT [dbo].[Product] ([ProductID], [AppUserId], [Title], [SlugUrl], [Price], [CoverImage], [City], [District], [Address], [Description], [Type], [ProductCategory], [AdvertisementDate], [DealOfTheDay], [ProductStatus]) VALUES (4, 1, N'Uygun Fiyatlı Villa', N'uygun-fiyatli-villa', CAST(220000.00 AS Decimal(18, 2)), N'/starter/images/4.jpg', N'Lyon', N'1.Bölge', N'Kırlangıç Sokak No:4', N'Tatile Doyamayanlar İçin Kaçırılmayacak Fırsat.', N'Satılık', 1, CAST(N'2024-07-05' AS Date), 1, 1)
INSERT [dbo].[Product] ([ProductID], [AppUserId], [Title], [SlugUrl], [Price], [CoverImage], [City], [District], [Address], [Description], [Type], [ProductCategory], [AdvertisementDate], [DealOfTheDay], [ProductStatus]) VALUES (5, 1, N'Havuzlu Villa', N'havuzlu-villa', CAST(3000.00 AS Decimal(18, 2)), N'/starter/images/5.jpeg', N'Miami', N'Florida', N'Güneş Caddesi No:9', N'Huzurlu bir yer arayanlar için inanılmaz fırsat.', N'Kiralık', 1, CAST(N'2024-08-05' AS Date), 1, 1)
INSERT [dbo].[Product] ([ProductID], [AppUserId], [Title], [SlugUrl], [Price], [CoverImage], [City], [District], [Address], [Description], [Type], [ProductCategory], [AdvertisementDate], [DealOfTheDay], [ProductStatus]) VALUES (6, 1, N'Trabzon Usulü Daire', N'trabzon-mimarisi', CAST(175000.00 AS Decimal(18, 2)), N'/starter/images/6.jpg', N'Montenegro', N'Mekrez', N'Okul Caddesi No:4', N'Depreme dayanıklı yeni bina.', N'Satılık', 3, CAST(N'2024-09-05' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductDetails] ON 

INSERT [dbo].[ProductDetails] ([ProductDetailID], [ProductSize], [BedRoomCount], [BathCount], [RoomCount], [GarageSize], [BuildYear], [Price], [Location], [VideoUrl], [ProductID], [LocationMap]) VALUES (1, 140, 3, 2, 5, 50, N'2005', CAST(300000.00 AS Decimal(18, 2)), N'Bursa', N'https://www.youtube.com/embed/4jnzf1yj48M', 1, N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d10330.819117050565!2d27.136095204066937!3d38.44013860614806!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14bbd85a305be291%3A0xd98decf832d0f057!2zQXRhdMO8cmsgTcO8emVzaQ!5e0!3m2!1str!2str!4v1740050569848!5m2!1str!2str')
INSERT [dbo].[ProductDetails] ([ProductDetailID], [ProductSize], [BedRoomCount], [BathCount], [RoomCount], [GarageSize], [BuildYear], [Price], [Location], [VideoUrl], [ProductID], [LocationMap]) VALUES (2, 150, 2, 2, 4, 25, N'2019', CAST(240000.00 AS Decimal(18, 2)), N'İzmir', N'https://www.youtube.com/embed/4jnzf1yj48M', 2, N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d10330.819117050565!2d27.136095204066937!3d38.44013860614806!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14bbd85a305be291%3A0xd98decf832d0f057!2zQXRhdMO8cmsgTcO8emVzaQ!5e0!3m2!1str!2str!4v1740050569848!5m2!1str!2str')
INSERT [dbo].[ProductDetails] ([ProductDetailID], [ProductSize], [BedRoomCount], [BathCount], [RoomCount], [GarageSize], [BuildYear], [Price], [Location], [VideoUrl], [ProductID], [LocationMap]) VALUES (3, 80, 2, 1, 3, 25, N'2020', CAST(180000.00 AS Decimal(18, 2)), N'Balıkesir', N'https://www.youtube.com/embed/4jnzf1yj48M', 3, N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d10330.819117050565!2d27.136095204066937!3d38.44013860614806!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14bbd85a305be291%3A0xd98decf832d0f057!2zQXRhdMO8cmsgTcO8emVzaQ!5e0!3m2!1str!2str!4v1740050569848!5m2!1str!2str')
INSERT [dbo].[ProductDetails] ([ProductDetailID], [ProductSize], [BedRoomCount], [BathCount], [RoomCount], [GarageSize], [BuildYear], [Price], [Location], [VideoUrl], [ProductID], [LocationMap]) VALUES (4, 100, 2, 1, 3, 20, N'2005', CAST(120000.00 AS Decimal(18, 2)), N'Bursa', N'https://www.youtube.com/embed/4jnzf1yj48M', 4, N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d10330.819117050565!2d27.136095204066937!3d38.44013860614806!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14bbd85a305be291%3A0xd98decf832d0f057!2zQXRhdMO8cmsgTcO8emVzaQ!5e0!3m2!1str!2str!4v1740050569848!5m2!1str!2str')
INSERT [dbo].[ProductDetails] ([ProductDetailID], [ProductSize], [BedRoomCount], [BathCount], [RoomCount], [GarageSize], [BuildYear], [Price], [Location], [VideoUrl], [ProductID], [LocationMap]) VALUES (5, 200, 2, 2, 4, 15, N'2009', CAST(190000.00 AS Decimal(18, 2)), N'İstanbul', N'https://www.youtube.com/embed/4jnzf1yj48M', 5, N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d10330.819117050565!2d27.136095204066937!3d38.44013860614806!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14bbd85a305be291%3A0xd98decf832d0f057!2zQXRhdMO8cmsgTcO8emVzaQ!5e0!3m2!1str!2str!4v1740050569848!5m2!1str!2str')
INSERT [dbo].[ProductDetails] ([ProductDetailID], [ProductSize], [BedRoomCount], [BathCount], [RoomCount], [GarageSize], [BuildYear], [Price], [Location], [VideoUrl], [ProductID], [LocationMap]) VALUES (6, 225, 3, 3, 6, 20, N'2007', CAST(260000.00 AS Decimal(18, 2)), N'İstanbul', N'https://www.youtube.com/embed/4jnzf1yj48M', 6, N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d10330.819117050565!2d27.136095204066937!3d38.44013860614806!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14bbd85a305be291%3A0xd98decf832d0f057!2zQXRhdMO8cmsgTcO8emVzaQ!5e0!3m2!1str!2str!4v1740050569848!5m2!1str!2str')
SET IDENTITY_INSERT [dbo].[ProductDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImage] ON 

INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (1, N'https://coralhomes.com.au/wp-content/uploads/Atlanta-Series-1190x680.png', 1)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (2, N'https://dropinblog.net/34246798/files/featured/Home_Interior__Budget_Friendly_Once_for_Every_Homeowner.png', 1)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (3, N'https://assets.vogue.com/photos/61e1ddb1b1c1870aceac90bb/master/w_2560%2Cc_limit/Sarbonne%2520Road.jpg', 1)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (4, N'https://www.theaa.ie/wp-content/uploads/2022/06/spacejoy-YI2YkyaREHk-unsplash-scaled.jpg', 1)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (5, N'https://images.unsplash.com/photo-1586023492125-27b2c045efd7?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aG9tZSUyMGRlc2lnbnxlbnwwfHwwfHx8MA%3D%3D', 1)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (6, N'https://evgezmesi.com/storage/assets/p/23-fbUy7BPjdxAra156.jpg', 2)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (7, N'https://i.pinimg.com/originals/25/5a/68/255a6845f2c9da41bdcc6877bc7962bc.jpg', 2)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (8, N'https://evgezmesi.com/storage/assets/p/29503-RPOD4NfOlv33ViFh.jpg', 2)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (9, N'https://i.pinimg.com/736x/e3/6b/40/e36b40bfc881311534861c08108cf1bf.jpg', 3)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (10, N'https://evgezmesi.com/storage/assets/p/medium/23-NzjdfEr0du88Rigc.jpg', 3)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (11, N'https://i.pinimg.com/564x/6d/7d/e4/6d7de49af23102a475fadd7a6c0a5dd5.jpg', 4)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (12, N'https://i.pinimg.com/736x/a7/f4/c4/a7f4c49f5a8decc5f1de07511eb8ce08.jpg', 4)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (13, N'https://evgezmesi.com/storage/assets/p/23-OP0ES4W72s4FKFbd.jpg', 5)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (14, N'https://i.pinimg.com/736x/16/0f/d1/160fd1b1a1ac77537c9b54f9e7291752.jpg', 5)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (15, N'https://i.pinimg.com/564x/6e/b8/2f/6eb82f47ad8a46664ac11f4ae2386041.jpg', 6)
INSERT [dbo].[ProductImage] ([ProductImageId], [ImageUrl], [ProductId]) VALUES (16, N'https://i.pinimg.com/736x/ea/82/8c/ea828c98efe82e2a6306ef49eceaf884.jpg', 6)
SET IDENTITY_INSERT [dbo].[ProductImage] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyAmenity] ON 

INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (1, 1, 1, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (2, 1, 2, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (3, 1, 3, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (4, 1, 4, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (5, 1, 5, 0)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (6, 1, 6, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (7, 1, 7, 0)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (8, 1, 8, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (9, 1, 9, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (10, 1, 10, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (11, 1, 11, 0)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (12, 1, 12, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (13, 1, 13, 0)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (14, 1, 14, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (15, 1, 15, 0)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (16, 1, 16, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (17, 1, 17, 0)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (18, 1, 18, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (19, 1, 19, 0)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (20, 2, 1, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (21, 2, 2, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (22, 2, 3, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (23, 3, 3, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (24, 3, 4, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (25, 3, 5, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (26, 4, 2, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (27, 4, 9, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (28, 5, 5, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (29, 5, 9, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (30, 5, 1, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (31, 6, 5, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (32, 6, 12, 1)
INSERT [dbo].[PropertyAmenity] ([PropertyAmenityId], [PropertyId], [AmenityId], [Status]) VALUES (33, 6, 13, 1)
SET IDENTITY_INSERT [dbo].[PropertyAmenity] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([ServiceID], [ServiceName], [ServiceStatus]) VALUES (1, N'Uzman Kadromuz', 1)
INSERT [dbo].[Service] ([ServiceID], [ServiceName], [ServiceStatus]) VALUES (2, N'Deneme', 0)
INSERT [dbo].[Service] ([ServiceID], [ServiceName], [ServiceStatus]) VALUES (3, N'Vizyon', 1)
INSERT [dbo].[Service] ([ServiceID], [ServiceName], [ServiceStatus]) VALUES (4, N'Misyon', 1)
INSERT [dbo].[Service] ([ServiceID], [ServiceName], [ServiceStatus]) VALUES (5, N'Grup Yapısı', 1)
INSERT [dbo].[Service] ([ServiceID], [ServiceName], [ServiceStatus]) VALUES (6, N'Strateji', 1)
INSERT [dbo].[Service] ([ServiceID], [ServiceName], [ServiceStatus]) VALUES (8, N'deneme2', 0)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[SubFeature] ON 

INSERT [dbo].[SubFeature] ([SubFeatureID], [Icon], [TopTitle], [MainTitle], [Description], [SubTitle]) VALUES (1, N'fa fa-search-plus', N'HEPSİ BİR YERDE', N'Hayalinizdeki Evi Bulun.', N'Aradığınız her şey burada.', N'a')
INSERT [dbo].[SubFeature] ([SubFeatureID], [Icon], [TopTitle], [MainTitle], [Description], [SubTitle]) VALUES (2, N'fa fa-user-o', N'KALİTELİ YAŞAM', N'Yaşamın Sırrı Doğada.', N'Doğa ile iç içe olun.', N'b')
INSERT [dbo].[SubFeature] ([SubFeatureID], [Icon], [TopTitle], [MainTitle], [Description], [SubTitle]) VALUES (3, N'fa fa-home', N'GÜVENLİ EVLER', N'Güvenlik Önceliğimizdir.', N'Kaliteli ev için doğru yer.', N'c')
SET IDENTITY_INSERT [dbo].[SubFeature] OFF
GO
SET IDENTITY_INSERT [dbo].[Testimonial] ON 

INSERT [dbo].[Testimonial] ([TestimonialID], [NameSurname], [Title], [Comment], [Status]) VALUES (1, N'Emre Binici', N'Software Developer', N'Bundan sonra yeni bir müstakil ev aldığıma inanamıyorum.
                                                        villa almak. Çok rahattı.', 1)
INSERT [dbo].[Testimonial] ([TestimonialID], [NameSurname], [Title], [Comment], [Status]) VALUES (2, N'Ali Çınar', N'Elektronik Mühendisi', N'Her şey çok kolay oldu , tecrübeli bir ekip.', 1)
SET IDENTITY_INSERT [dbo].[Testimonial] OFF
GO
SET IDENTITY_INSERT [dbo].[ToDoList] ON 

INSERT [dbo].[ToDoList] ([ToDoListID], [Description], [ToDoListStatus]) VALUES (1, N'Bilgisayar Temizlenecek', 1)
INSERT [dbo].[ToDoList] ([ToDoListID], [Description], [ToDoListStatus]) VALUES (2, N'Saçlar Kestirilecek', 0)
INSERT [dbo].[ToDoList] ([ToDoListID], [Description], [ToDoListStatus]) VALUES (3, N'Saatçiye Gidilecek', 1)
INSERT [dbo].[ToDoList] ([ToDoListID], [Description], [ToDoListStatus]) VALUES (4, N'Halı Sahata gidilecek', 1)
INSERT [dbo].[ToDoList] ([ToDoListID], [Description], [ToDoListStatus]) VALUES (5, N'Telefon Taksiti Yatırılacak', 0)
INSERT [dbo].[ToDoList] ([ToDoListID], [Description], [ToDoListStatus]) VALUES (6, N'Bahçe Temizliği Yapılacak', 1)
SET IDENTITY_INSERT [dbo].[ToDoList] OFF
GO
SET IDENTITY_INSERT [dbo].[WhoWeAreDetail] ON 

INSERT [dbo].[WhoWeAreDetail] ([WhoWeAreDetailID], [Title], [SubTitle], [Description1], [Description2]) VALUES (2, N'Biz Kimiz?', N'Neler Yapıyoruz ?', N'Dünyanın her yerinde hizmet veriyoruz.', N'İşimizi aşkla yapıyoruz.')
SET IDENTITY_INSERT [dbo].[WhoWeAreDetail] OFF
GO
ALTER TABLE [dbo].[AppUser]  WITH CHECK ADD  CONSTRAINT [FK_AppUser_AppRole] FOREIGN KEY([UserRole])
REFERENCES [dbo].[AppRole] ([RoleId])
GO
ALTER TABLE [dbo].[AppUser] CHECK CONSTRAINT [FK_AppUser_AppRole]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_AppUser] FOREIGN KEY([Sender])
REFERENCES [dbo].[AppUser] ([UserId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_AppUser]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_AppUser1] FOREIGN KEY([Receiver])
REFERENCES [dbo].[AppUser] ([UserId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_AppUser1]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_AppUser] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AppUser] ([UserId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_AppUser]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([ProductCategory])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[ProductDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetails_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductDetails] CHECK CONSTRAINT [FK_ProductDetails_Product]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product]
GO
ALTER TABLE [dbo].[PropertyAmenity]  WITH CHECK ADD  CONSTRAINT [FK_PropertyAmenity_Amenity] FOREIGN KEY([AmenityId])
REFERENCES [dbo].[Amenity] ([AmenityId])
GO
ALTER TABLE [dbo].[PropertyAmenity] CHECK CONSTRAINT [FK_PropertyAmenity_Amenity]
GO
ALTER TABLE [dbo].[PropertyAmenity]  WITH CHECK ADD  CONSTRAINT [FK_PropertyAmenity_Product] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[PropertyAmenity] CHECK CONSTRAINT [FK_PropertyAmenity_Product]
GO
/****** Object:  Trigger [dbo].[IncreaseLocationCount]    Script Date: 13.06.2025 01:55:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[IncreaseLocationCount] 
on [dbo].[Product]
after Insert
as
declare @city nvarchar(50)
select @city=City From inserted
update PopularLocation set PropertyCount +=1 where CityName=@city
GO
ALTER TABLE [dbo].[Product] ENABLE TRIGGER [IncreaseLocationCount]
GO
