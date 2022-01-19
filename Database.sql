USE [WT_Test]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 19/01/2022 13:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nchar](14) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[ManagerId] [bigint] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 19/01/2022 13:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[StatusEnumId] [tinyint] NOT NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificationPreferenceByEmployee]    Script Date: 19/01/2022 13:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationPreferenceByEmployee](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NotificationTypeEnumId] [tinyint] NOT NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_NotificationPreferenceByEmployee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 19/01/2022 13:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleUser]    Script Date: 19/01/2022 13:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUser](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_RoleUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 19/01/2022 13:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([Id], [UserId], [FirstName], [LastName], [PhoneNumber], [Email], [ManagerId]) VALUES (1, 1, N'Faisal', N'Islam', N'01628300000   ', N'', 0)
GO
INSERT [dbo].[Employee] ([Id], [UserId], [FirstName], [LastName], [PhoneNumber], [Email], [ManagerId]) VALUES (2, 2, N'Jhon', N'Cena', N'01234567891   ', N'b@email.com', 1)
GO
INSERT [dbo].[Employee] ([Id], [UserId], [FirstName], [LastName], [PhoneNumber], [Email], [ManagerId]) VALUES (3, 3, N'Steve', N'Nicol', N'012345632     ', N's@email.com', 4)
GO
INSERT [dbo].[Employee] ([Id], [UserId], [FirstName], [LastName], [PhoneNumber], [Email], [ManagerId]) VALUES (4, 4, N'Ron', N'Jonson', N'012342343     ', N'r@email.com', 0)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[NotificationPreferenceByEmployee] ON 
GO
INSERT [dbo].[NotificationPreferenceByEmployee] ([Id], [NotificationTypeEnumId], [UserId]) VALUES (1, 0, 1)
GO
INSERT [dbo].[NotificationPreferenceByEmployee] ([Id], [NotificationTypeEnumId], [UserId]) VALUES (2, 1, 1)
GO
INSERT [dbo].[NotificationPreferenceByEmployee] ([Id], [NotificationTypeEnumId], [UserId]) VALUES (3, 2, 2)
GO
INSERT [dbo].[NotificationPreferenceByEmployee] ([Id], [NotificationTypeEnumId], [UserId]) VALUES (4, 1, 2)
GO
INSERT [dbo].[NotificationPreferenceByEmployee] ([Id], [NotificationTypeEnumId], [UserId]) VALUES (5, 0, 3)
GO
INSERT [dbo].[NotificationPreferenceByEmployee] ([Id], [NotificationTypeEnumId], [UserId]) VALUES (6, 0, 4)
GO
INSERT [dbo].[NotificationPreferenceByEmployee] ([Id], [NotificationTypeEnumId], [UserId]) VALUES (7, 1, 4)
GO
SET IDENTITY_INSERT [dbo].[NotificationPreferenceByEmployee] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'HR Manager')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleUser] ON 
GO
INSERT [dbo].[RoleUser] ([Id], [RoleId], [UserId]) VALUES (1, 1, 3)
GO
SET IDENTITY_INSERT [dbo].[RoleUser] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Password], [UserName]) VALUES (1, N'123456', N'test')
GO
INSERT [dbo].[User] ([Id], [Password], [UserName]) VALUES (2, N'123456', N'jhon')
GO
INSERT [dbo].[User] ([Id], [Password], [UserName]) VALUES (3, N'123456', N'steve')
GO
INSERT [dbo].[User] ([Id], [Password], [UserName]) VALUES (4, N'123456', N'ron')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  Index [UQ__Employee__1788CC4D5108FF84]    Script Date: 19/01/2022 13:28:09 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [UQ__Employee__1788CC4D5108FF84] UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_Email]  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_User]
GO
ALTER TABLE [dbo].[Leave]  WITH CHECK ADD  CONSTRAINT [FK_Leave_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Leave] CHECK CONSTRAINT [FK_Leave_User]
GO
ALTER TABLE [dbo].[NotificationPreferenceByEmployee]  WITH CHECK ADD  CONSTRAINT [FK_NotificationPreferenceByEmployee_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[NotificationPreferenceByEmployee] CHECK CONSTRAINT [FK_NotificationPreferenceByEmployee_User]
GO
ALTER TABLE [dbo].[RoleUser]  WITH CHECK ADD  CONSTRAINT [FK_RoleUser_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RoleUser] CHECK CONSTRAINT [FK_RoleUser_Role]
GO
ALTER TABLE [dbo].[RoleUser]  WITH CHECK ADD  CONSTRAINT [FK_RoleUser_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[RoleUser] CHECK CONSTRAINT [FK_RoleUser_User]
GO
