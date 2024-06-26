USE [DemoMayBayCN]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airports]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airports](
	[AirportID] [int] IDENTITY(1,1) NOT NULL,
	[AirportCode] [nvarchar](max) NOT NULL,
	[AirportName] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Airports] PRIMARY KEY CLUSTERED 
(
	[AirportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookingID] [int] IDENTITY(1,1) NOT NULL,
	[FlightID] [int] NOT NULL,
	[PassengerID] [int] NOT NULL,
	[PaymentID] [int] NOT NULL,
	[SeatID] [int] NOT NULL,
	[BookingDate] [datetime2](7) NULL,
	[BookingStatus] [bit] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[Verification] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fares]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fares](
	[FareID] [int] IDENTITY(1,1) NOT NULL,
	[FlightID] [int] NOT NULL,
	[FareType] [nvarchar](max) NOT NULL,
	[FareAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Fares] PRIMARY KEY CLUSTERED 
(
	[FareID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[FlightID] [int] IDENTITY(1,1) NOT NULL,
	[FlightNumber] [varchar](50) NOT NULL,
	[DepartureDay] [date] NULL,
	[ArrivalTime] [time](7) NULL,
	[DepartureTime] [time](7) NULL,
	[ArrivlaCity] [int] NULL,
	[DepartureCity] [int] NULL,
	[TotalSeats] [int] NOT NULL,
	[AvailableSeats] [int] NOT NULL,
	[HinhAnh] [nvarchar](max) NOT NULL,
	[created_by] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED 
(
	[FlightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passengers]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passengers](
	[PassengerID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[NgaySinh] [datetime2](7) NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Passengers] PRIMARY KEY CLUSTERED 
(
	[PassengerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [datetime2](7) NULL,
	[PaymentAmount] [decimal](18, 2) NULL,
	[PaymentMethod] [bit] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostID] [int] NOT NULL,
	[TopicID] [int] NOT NULL,
	[title] [nvarchar](max) NOT NULL,
	[slug] [nvarchar](max) NOT NULL,
	[detail] [nvarchar](max) NOT NULL,
	[img] [nvarchar](max) NOT NULL,
	[type] [nvarchar](max) NOT NULL,
	[created_at] [datetime2](7) NULL,
	[created_by] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefeshToken]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefeshToken](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[Token] [nvarchar](max) NOT NULL,
	[JwtId] [nvarchar](max) NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[IsRevoked] [bit] NOT NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[ExpiryDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RefeshToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seats](
	[SeatID] [int] IDENTITY(1,1) NOT NULL,
	[FlightID] [int] NOT NULL,
	[SeatNumber] [nvarchar](max) NOT NULL,
	[SeatClass] [nvarchar](max) NOT NULL,
	[SeatAvailable] [int] NOT NULL,
 CONSTRAINT [PK_Seats] PRIMARY KEY CLUSTERED 
(
	[SeatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 12/17/2023 8:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[TopicID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[slug] [nvarchar](max) NOT NULL,
	[NgayViet] [datetime2](7) NULL,
	[created_by] [int] NULL,
 CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED 
(
	[TopicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231117023308_InitData', N'7.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231118160749_InitData', N'7.0.13')
GO
SET IDENTITY_INSERT [dbo].[Airports] ON 

INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (1, N'HAN', N'Nội Bài', N'Hà Nội')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (2, N'SGN', N'Tân Sơn Nhất', N'Hồ Chí Minh')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (3, N'VCA', N'Cần Thơ', N'Cần Thơ')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (4, N'DAD', N'Đà Nẵng', N'Đà Nẵng')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (5, N'CXR', N'Cam Ranh', N'Khánh Hòa')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (6, N'HUI', N'Phú Bài', N'Huế')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (7, N'VII', N'Vinh', N'Nghệ An')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (8, N'CAH', N'Cà Mau', N'Cà Mau')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (9, N'abc', N'abc', N'áda')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (10, N'ádsadasd', N'adad', N'adadad')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (11, N'adad', N'adad', N'adad')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (16, N'ádsad', N'ádad', N'adasd')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (31, N'agagag', N'agag', N'agag')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (32, N'agagag', N'agag', N'agag')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (33, N'avavav', N'avav', N'avav')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (34, N'avavav', N'avav', N'avav')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (35, N'avavav', N'avav', N'avav')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (36, N'bbbb', N'bb', N'bbbb')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (37, N'bbbb', N'bb', N'bbbb')
INSERT [dbo].[Airports] ([AirportID], [AirportCode], [AirportName], [City]) VALUES (38, N'bbbb', N'bb', N'bbbb')
SET IDENTITY_INSERT [dbo].[Airports] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0a4cb0cc-e98b-4124-bafe-2432657b5e6c', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'19fff217-4724-4b7b-aeea-bb307852e34e', N'bbbbbb', N'BBBBBB', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2766da1d-179e-4ba2-88f9-a62cc904b33e', N'Member', N'MEMBER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bf5975ad-3508-44a8-9270-abad085a9a12', N'aaaa', N'AAAA', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'affa63f2-3fd6-44eb-a659-dea777c9f368', N'0a4cb0cc-e98b-4124-bafe-2432657b5e6c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'59974269-4f28-4b5e-a4cd-d2b666f8a9ae', N'2766da1d-179e-4ba2-88f9-a62cc904b33e')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Gender], [Address], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'59974269-4f28-4b5e-a4cd-d2b666f8a9ae', N'a', N'a', N'a', N'Member', N'MEMBER', N'Member@gmail.com', N'MEMBER@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEERFWxTop8g0v0KldsEm7QpIb5CdpBVzqwldLPI2cR80rHiEYatYa8BwsrIGwiLHXQ==', N'QEBTUAAZOSN4JQQQGMMW4FUARSOPXC53', N'1ba0b908-45af-42cd-a849-08939208479a', N'1234567890', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Gender], [Address], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'affa63f2-3fd6-44eb-a659-dea777c9f368', N'Nam', N'abc', N'trung', N'Admin', N'ADMIN', N'Admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEHMoztEragslWdkhgEGw9xiBx0nNXJF2EdiIUtjiB9EMIPQMnS4FbnMbze2RIuZkSA==', N'QRRC733QN2UD65GXHLLNWX2LQAUZH4QK', N'e04a4453-f648-4b5f-80a0-76c280d849df', N'123456', 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([BookingID], [FlightID], [PassengerID], [PaymentID], [SeatID], [BookingDate], [BookingStatus], [TotalPrice], [Verification]) VALUES (128, 2, 164, 143, 19, CAST(N'2023-12-17T11:15:45.9065873' AS DateTime2), 1, CAST(400000.00 AS Decimal(18, 2)), N'ULFJGK')
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Fares] ON 

INSERT [dbo].[Fares] ([FareID], [FlightID], [FareType], [FareAmount]) VALUES (9, 2, N'Thương Gia', CAST(800000.00 AS Decimal(18, 2)))
INSERT [dbo].[Fares] ([FareID], [FlightID], [FareType], [FareAmount]) VALUES (17, 8, N'Thương Gia', CAST(600000.00 AS Decimal(18, 2)))
INSERT [dbo].[Fares] ([FareID], [FlightID], [FareType], [FareAmount]) VALUES (18, 8, N'Phổ Thông', CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[Fares] ([FareID], [FlightID], [FareType], [FareAmount]) VALUES (19, 9, N'Thương Gia', CAST(600000.00 AS Decimal(18, 2)))
INSERT [dbo].[Fares] ([FareID], [FlightID], [FareType], [FareAmount]) VALUES (20, 9, N'Phổ Thông', CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[Fares] ([FareID], [FlightID], [FareType], [FareAmount]) VALUES (31, 15, N'Thương Gia', CAST(600000.00 AS Decimal(18, 2)))
INSERT [dbo].[Fares] ([FareID], [FlightID], [FareType], [FareAmount]) VALUES (32, 15, N'Phổ Thông', CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[Fares] ([FareID], [FlightID], [FareType], [FareAmount]) VALUES (33, 16, N'Thương Gia', CAST(600000.00 AS Decimal(18, 2)))
INSERT [dbo].[Fares] ([FareID], [FlightID], [FareType], [FareAmount]) VALUES (34, 16, N'Phổ Thông', CAST(300000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Fares] OFF
GO
SET IDENTITY_INSERT [dbo].[Flights] ON 

INSERT [dbo].[Flights] ([FlightID], [FlightNumber], [DepartureDay], [ArrivalTime], [DepartureTime], [ArrivlaCity], [DepartureCity], [TotalSeats], [AvailableSeats], [HinhAnh], [created_by]) VALUES (1, N'VN00', CAST(N'2023-12-30' AS Date), NULL, NULL, 1, 2, 60, 60, N'ghost.png', N'affa63f2-3fd6-44eb-a659-dea777c9f368')
INSERT [dbo].[Flights] ([FlightID], [FlightNumber], [DepartureDay], [ArrivalTime], [DepartureTime], [ArrivlaCity], [DepartureCity], [TotalSeats], [AvailableSeats], [HinhAnh], [created_by]) VALUES (2, N'VN01', CAST(N'2023-12-30' AS Date), CAST(N'02:00:00' AS Time), CAST(N'01:30:00' AS Time), 1, 2, 60, 59, N'ghost.png', N'affa63f2-3fd6-44eb-a659-dea777c9f368')
INSERT [dbo].[Flights] ([FlightID], [FlightNumber], [DepartureDay], [ArrivalTime], [DepartureTime], [ArrivlaCity], [DepartureCity], [TotalSeats], [AvailableSeats], [HinhAnh], [created_by]) VALUES (8, N'VN02', CAST(N'2023-12-31' AS Date), CAST(N'00:15:00' AS Time), CAST(N'01:00:00' AS Time), 2, 1, 60, 60, N'ghost.png', N'affa63f2-3fd6-44eb-a659-dea777c9f368')
INSERT [dbo].[Flights] ([FlightID], [FlightNumber], [DepartureDay], [ArrivalTime], [DepartureTime], [ArrivlaCity], [DepartureCity], [TotalSeats], [AvailableSeats], [HinhAnh], [created_by]) VALUES (9, N'VN03', CAST(N'2023-12-30' AS Date), CAST(N'00:30:00' AS Time), CAST(N'01:00:00' AS Time), 2, 1, 60, 60, N'ghost.png', N'affa63f2-3fd6-44eb-a659-dea777c9f368')
INSERT [dbo].[Flights] ([FlightID], [FlightNumber], [DepartureDay], [ArrivalTime], [DepartureTime], [ArrivlaCity], [DepartureCity], [TotalSeats], [AvailableSeats], [HinhAnh], [created_by]) VALUES (15, N'VN04', CAST(N'2023-12-30' AS Date), CAST(N'01:00:00' AS Time), CAST(N'01:30:00' AS Time), 1, 2, 60, 60, N'ghost.png', N'affa63f2-3fd6-44eb-a659-dea777c9f368')
INSERT [dbo].[Flights] ([FlightID], [FlightNumber], [DepartureDay], [ArrivalTime], [DepartureTime], [ArrivlaCity], [DepartureCity], [TotalSeats], [AvailableSeats], [HinhAnh], [created_by]) VALUES (16, N'VN05', CAST(N'2023-12-30' AS Date), CAST(N'01:00:00' AS Time), CAST(N'02:00:00' AS Time), 1, 2, 60, 60, N'ghost.png', N'affa63f2-3fd6-44eb-a659-dea777c9f368')
SET IDENTITY_INSERT [dbo].[Flights] OFF
GO
SET IDENTITY_INSERT [dbo].[Passengers] ON 

INSERT [dbo].[Passengers] ([PassengerID], [FullName], [Phone], [Email], [Gender], [NgaySinh], [Address]) VALUES (164, N'a', N'123456', N'mr.trung1307@gmail.com', N'Nam', CAST(N'2023-12-30T00:00:00.0000000' AS DateTime2), N'abcasd')
SET IDENTITY_INSERT [dbo].[Passengers] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([PaymentID], [PaymentDate], [PaymentAmount], [PaymentMethod]) VALUES (143, CAST(N'2023-12-17T11:15:43.6466158' AS DateTime2), CAST(400000.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[RefeshToken] ON 

INSERT [dbo].[RefeshToken] ([Id], [UserId], [Token], [JwtId], [IsUsed], [IsRevoked], [AddedDate], [ExpiryDate]) VALUES (27, N'affa63f2-3fd6-44eb-a659-dea777c9f368', N'7rfaVe2RQssHcdaOytSueMG', N'5b475258-d9fe-4286-a3de-78e3d77a88cb', 0, 0, CAST(N'2023-12-08T12:54:10.0610847' AS DateTime2), CAST(N'2023-12-08T13:24:10.0611467' AS DateTime2))
INSERT [dbo].[RefeshToken] ([Id], [UserId], [Token], [JwtId], [IsUsed], [IsRevoked], [AddedDate], [ExpiryDate]) VALUES (28, N'affa63f2-3fd6-44eb-a659-dea777c9f368', N'N7gwGKLrZTHX3xKqQPpsg9n', N'75117db3-7ed1-4622-8025-8879a2e822ea', 0, 0, CAST(N'2023-12-08T12:58:45.7596555' AS DateTime2), CAST(N'2023-12-08T13:28:45.7596961' AS DateTime2))
INSERT [dbo].[RefeshToken] ([Id], [UserId], [Token], [JwtId], [IsUsed], [IsRevoked], [AddedDate], [ExpiryDate]) VALUES (29, N'affa63f2-3fd6-44eb-a659-dea777c9f368', N'O6C8qZcuex8DO6HveCp2Vu3', N'dab7fba6-60a4-4eed-84f1-5a0618e868db', 0, 0, CAST(N'2023-12-10T21:43:03.6053002' AS DateTime2), CAST(N'2023-12-10T22:13:03.6053617' AS DateTime2))
INSERT [dbo].[RefeshToken] ([Id], [UserId], [Token], [JwtId], [IsUsed], [IsRevoked], [AddedDate], [ExpiryDate]) VALUES (30, N'affa63f2-3fd6-44eb-a659-dea777c9f368', N'VyhwTM3e1922jeVMCTH9B0J', N'9b0349dc-8f32-47ed-96df-2cacc536d6d7', 0, 0, CAST(N'2023-12-10T22:39:33.9387577' AS DateTime2), CAST(N'2023-12-10T23:09:33.9388023' AS DateTime2))
INSERT [dbo].[RefeshToken] ([Id], [UserId], [Token], [JwtId], [IsUsed], [IsRevoked], [AddedDate], [ExpiryDate]) VALUES (31, N'affa63f2-3fd6-44eb-a659-dea777c9f368', N'GADsUEMjTBnt6PN3BL3wE69', N'6921767f-8d25-44f5-881e-f7b2f8a366b3', 0, 0, CAST(N'2023-12-17T11:17:09.0828890' AS DateTime2), CAST(N'2023-12-17T11:47:09.0829272' AS DateTime2))
INSERT [dbo].[RefeshToken] ([Id], [UserId], [Token], [JwtId], [IsUsed], [IsRevoked], [AddedDate], [ExpiryDate]) VALUES (32, N'affa63f2-3fd6-44eb-a659-dea777c9f368', N'a8KAZd0X07PzlW7lpjBSatV', N'170ad8a6-87ed-440c-b18e-5def4e1d2924', 0, 0, CAST(N'2023-12-17T11:31:51.3841792' AS DateTime2), CAST(N'2023-12-17T12:01:51.3842886' AS DateTime2))
INSERT [dbo].[RefeshToken] ([Id], [UserId], [Token], [JwtId], [IsUsed], [IsRevoked], [AddedDate], [ExpiryDate]) VALUES (33, N'affa63f2-3fd6-44eb-a659-dea777c9f368', N'emFplGqrU2Jk0YcVbEan4oE', N'e18c5b78-414c-4dcb-acc0-b26f385ee94c', 0, 0, CAST(N'2023-12-17T11:31:51.3929206' AS DateTime2), CAST(N'2023-12-17T12:01:51.3929229' AS DateTime2))
SET IDENTITY_INSERT [dbo].[RefeshToken] OFF
GO
SET IDENTITY_INSERT [dbo].[Seats] ON 

INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (1, 2, N'1A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (2, 2, N'1B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (3, 2, N'1C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (4, 2, N'1D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (5, 2, N'1E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (6, 2, N'1F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (7, 2, N'2A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (8, 2, N'2B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (9, 2, N'2C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (10, 2, N'2D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (11, 2, N'2E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (12, 2, N'2F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (13, 2, N'3A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (14, 2, N'3B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (15, 2, N'3C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (16, 2, N'3D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (17, 2, N'3E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (18, 2, N'3F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (19, 2, N'4A', N'Phổ thông', 1)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (20, 2, N'4B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (21, 2, N'4C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (22, 2, N'4D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (23, 2, N'4E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (24, 2, N'4F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (25, 2, N'5A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (26, 2, N'5B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (27, 2, N'5C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (28, 2, N'5D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (29, 2, N'5E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (30, 2, N'5F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (31, 2, N'6A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (32, 2, N'6B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (33, 2, N'6C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (34, 2, N'6D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (35, 2, N'6E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (36, 2, N'6F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (37, 2, N'7A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (38, 2, N'7B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (39, 2, N'7C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (40, 2, N'7D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (41, 2, N'7E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (42, 2, N'7F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (43, 2, N'8A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (44, 2, N'8B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (45, 2, N'8C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (46, 2, N'8D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (47, 2, N'8E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (48, 2, N'8F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (49, 2, N'9A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (50, 2, N'9B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (51, 2, N'9C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (52, 2, N'9D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (53, 2, N'9E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (54, 2, N'9F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (55, 2, N'10A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (56, 2, N'10B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (57, 2, N'10C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (58, 2, N'10D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (59, 2, N'10E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (60, 2, N'10F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (361, 8, N'1A', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (362, 8, N'1B', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (363, 8, N'1C', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (364, 8, N'1D', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (365, 8, N'1E', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (366, 8, N'1F', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (367, 8, N'2A', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (368, 8, N'2B', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (369, 8, N'2C', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (370, 8, N'2D', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (371, 8, N'2E', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (372, 8, N'2F', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (373, 8, N'3A', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (374, 8, N'3B', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (375, 8, N'3C', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (376, 8, N'3D', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (377, 8, N'3E', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (378, 8, N'3F', N'Thương gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (379, 8, N'4A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (380, 8, N'4B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (381, 8, N'4C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (382, 8, N'4D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (383, 8, N'4E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (384, 8, N'4F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (385, 8, N'5A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (386, 8, N'5B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (387, 8, N'5C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (388, 8, N'5D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (389, 8, N'5E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (390, 8, N'5F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (391, 8, N'6A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (392, 8, N'6B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (393, 8, N'6C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (394, 8, N'6D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (395, 8, N'6E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (396, 8, N'6F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (397, 8, N'7A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (398, 8, N'7B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (399, 8, N'7C', N'Phổ thông', 0)
GO
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (400, 8, N'7D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (401, 8, N'7E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (402, 8, N'7F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (403, 8, N'8A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (404, 8, N'8B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (405, 8, N'8C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (406, 8, N'8D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (407, 8, N'8E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (408, 8, N'8F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (409, 8, N'9A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (410, 8, N'9B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (411, 8, N'9C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (412, 8, N'9D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (413, 8, N'9E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (414, 8, N'9F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (415, 8, N'10A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (416, 8, N'10B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (417, 8, N'10C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (418, 8, N'10D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (419, 8, N'10E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (420, 8, N'10F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (421, 9, N'1A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (422, 9, N'1B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (423, 9, N'1C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (424, 9, N'1D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (425, 9, N'1E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (426, 9, N'1F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (427, 9, N'2A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (428, 9, N'2B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (429, 9, N'2C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (430, 9, N'2D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (431, 9, N'2E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (432, 9, N'2F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (433, 9, N'3A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (434, 9, N'3B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (435, 9, N'3C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (436, 9, N'3D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (437, 9, N'3E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (438, 9, N'3F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (439, 9, N'4A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (440, 9, N'4B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (441, 9, N'4C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (442, 9, N'4D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (443, 9, N'4E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (444, 9, N'4F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (445, 9, N'5A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (446, 9, N'5B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (447, 9, N'5C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (448, 9, N'5D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (449, 9, N'5E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (450, 9, N'5F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (451, 9, N'6A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (452, 9, N'6B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (453, 9, N'6C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (454, 9, N'6D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (455, 9, N'6E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (456, 9, N'6F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (457, 9, N'7A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (458, 9, N'7B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (459, 9, N'7C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (460, 9, N'7D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (461, 9, N'7E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (462, 9, N'7F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (463, 9, N'8A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (464, 9, N'8B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (465, 9, N'8C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (466, 9, N'8D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (467, 9, N'8E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (468, 9, N'8F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (469, 9, N'9A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (470, 9, N'9B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (471, 9, N'9C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (472, 9, N'9D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (473, 9, N'9E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (474, 9, N'9F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (475, 9, N'10A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (476, 9, N'10B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (477, 9, N'10C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (478, 9, N'10D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (479, 9, N'10E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (480, 9, N'10F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (781, 15, N'1A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (782, 15, N'1B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (783, 15, N'1C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (784, 15, N'1D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (785, 15, N'1E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (786, 15, N'1F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (787, 15, N'2A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (788, 15, N'2B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (789, 15, N'2C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (790, 15, N'2D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (791, 15, N'2E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (792, 15, N'2F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (793, 15, N'3A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (794, 15, N'3B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (795, 15, N'3C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (796, 15, N'3D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (797, 15, N'3E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (798, 15, N'3F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (799, 15, N'4A', N'Phổ thông', 0)
GO
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (800, 15, N'4B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (801, 15, N'4C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (802, 15, N'4D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (803, 15, N'4E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (804, 15, N'4F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (805, 15, N'5A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (806, 15, N'5B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (807, 15, N'5C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (808, 15, N'5D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (809, 15, N'5E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (810, 15, N'5F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (811, 15, N'6A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (812, 15, N'6B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (813, 15, N'6C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (814, 15, N'6D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (815, 15, N'6E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (816, 15, N'6F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (817, 15, N'7A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (818, 15, N'7B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (819, 15, N'7C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (820, 15, N'7D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (821, 15, N'7E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (822, 15, N'7F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (823, 15, N'8A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (824, 15, N'8B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (825, 15, N'8C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (826, 15, N'8D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (827, 15, N'8E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (828, 15, N'8F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (829, 15, N'9A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (830, 15, N'9B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (831, 15, N'9C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (832, 15, N'9D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (833, 15, N'9E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (834, 15, N'9F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (835, 15, N'10A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (836, 15, N'10B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (837, 15, N'10C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (838, 15, N'10D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (839, 15, N'10E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (840, 15, N'10F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (841, 16, N'1A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (842, 16, N'1B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (843, 16, N'1C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (844, 16, N'1D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (845, 16, N'1E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (846, 16, N'1F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (847, 16, N'2A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (848, 16, N'2B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (849, 16, N'2C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (850, 16, N'2D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (851, 16, N'2E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (852, 16, N'2F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (853, 16, N'3A', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (854, 16, N'3B', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (855, 16, N'3C', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (856, 16, N'3D', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (857, 16, N'3E', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (858, 16, N'3F', N'Thương Gia', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (859, 16, N'4A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (860, 16, N'4B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (861, 16, N'4C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (862, 16, N'4D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (863, 16, N'4E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (864, 16, N'4F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (865, 16, N'5A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (866, 16, N'5B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (867, 16, N'5C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (868, 16, N'5D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (869, 16, N'5E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (870, 16, N'5F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (871, 16, N'6A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (872, 16, N'6B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (873, 16, N'6C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (874, 16, N'6D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (875, 16, N'6E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (876, 16, N'6F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (877, 16, N'7A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (878, 16, N'7B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (879, 16, N'7C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (880, 16, N'7D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (881, 16, N'7E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (882, 16, N'7F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (883, 16, N'8A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (884, 16, N'8B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (885, 16, N'8C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (886, 16, N'8D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (887, 16, N'8E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (888, 16, N'8F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (889, 16, N'9A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (890, 16, N'9B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (891, 16, N'9C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (892, 16, N'9D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (893, 16, N'9E', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (894, 16, N'9F', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (895, 16, N'10A', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (896, 16, N'10B', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (897, 16, N'10C', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (898, 16, N'10D', N'Phổ thông', 0)
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (899, 16, N'10E', N'Phổ thông', 0)
GO
INSERT [dbo].[Seats] ([SeatID], [FlightID], [SeatNumber], [SeatClass], [SeatAvailable]) VALUES (900, 16, N'10F', N'Phổ thông', 0)
SET IDENTITY_INSERT [dbo].[Seats] OFF
GO
ALTER TABLE [dbo].[Passengers] ADD  DEFAULT (N'') FOR [Address]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Flights_FlightID] FOREIGN KEY([FlightID])
REFERENCES [dbo].[Flights] ([FlightID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Flights_FlightID]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Passengers_PassengerID] FOREIGN KEY([PassengerID])
REFERENCES [dbo].[Passengers] ([PassengerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Passengers_PassengerID]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Payments_PaymentID] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payments] ([PaymentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Payments_PaymentID]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Seats_SeatID] FOREIGN KEY([SeatID])
REFERENCES [dbo].[Seats] ([SeatID])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Seats_SeatID]
GO
ALTER TABLE [dbo].[Fares]  WITH CHECK ADD  CONSTRAINT [FK_Fares_Flights_FlightID] FOREIGN KEY([FlightID])
REFERENCES [dbo].[Flights] ([FlightID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fares] CHECK CONSTRAINT [FK_Fares_Flights_FlightID]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Airports_ArrivlaCity] FOREIGN KEY([ArrivlaCity])
REFERENCES [dbo].[Airports] ([AirportID])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Airports_ArrivlaCity]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Airports_DepartureCity] FOREIGN KEY([DepartureCity])
REFERENCES [dbo].[Airports] ([AirportID])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Airports_DepartureCity]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_AspNetUsers_created_by] FOREIGN KEY([created_by])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_AspNetUsers_created_by]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_AspNetUsers_created_by] FOREIGN KEY([created_by])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_AspNetUsers_created_by]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Topics_PostID] FOREIGN KEY([PostID])
REFERENCES [dbo].[Topics] ([TopicID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Topics_PostID]
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD  CONSTRAINT [FK_Seats_Flights_FlightID] FOREIGN KEY([FlightID])
REFERENCES [dbo].[Flights] ([FlightID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Seats] CHECK CONSTRAINT [FK_Seats_Flights_FlightID]
GO
