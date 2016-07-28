USE [master]
GO

CREATE DATABASE [PianoMelody]
GO

USE [PianoMelody]
GO

CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
	CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
	(
		[MigrationId] ASC,
		[ContextKey] ASC
	)
)
GO

CREATE TABLE [dbo].[ArticleGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	CONSTRAINT [PK_dbo.ArticleGroups] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
	(
		[LoginProvider] ASC,
		[ProviderKey] ASC,
		[UserId] ASC
	)
)
GO

CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
	(
		[UserId] ASC,
		[RoleId] ASC
	)
)
GO

CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

CREATE TABLE [dbo].[Information](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Multimedia_Id] [int] NULL,
	CONSTRAINT [PK_dbo.Information] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

CREATE TABLE [dbo].[Manufacturers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UrlAddress] [nvarchar](max) NULL,
	[Multimedia_Id] [int] NULL,
	CONSTRAINT [PK_dbo.Manufacturers] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

CREATE TABLE [dbo].[Multimedias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Url] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[ProductId] [int] NULL,
	CONSTRAINT [PK_dbo.Multimedias] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Multimedia_Id] [int] NULL,
	CONSTRAINT [PK_dbo.News] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Position] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[IsNew] [bit] NOT NULL,
	[ArticleGroupId] [int] NULL,
	[ManufacturerId] [int] NULL,
	CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

CREATE TABLE [dbo].[References](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Multimedia_Id] [int] NULL,
	CONSTRAINT [PK_dbo.References] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

CREATE TABLE [dbo].[Resources](
	[Name] [nvarchar](128) NOT NULL,
	[Culture] [nvarchar](8) NOT NULL,
	[Value] [nvarchar](max) NULL,
	CONSTRAINT [PK_dbo.Resources] PRIMARY KEY CLUSTERED 
	(
		[Name] ASC,
		[Culture] ASC
	)
)
GO

CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	CONSTRAINT [PK_dbo.Services] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_Multimedia_Id] ON [dbo].[Information]
(
	[Multimedia_Id] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_Multimedia_Id] ON [dbo].[Manufacturers]
(
	[Multimedia_Id] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[Multimedias]
(
	[ProductId] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_Multimedia_Id] ON [dbo].[News]
(
	[Multimedia_Id] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_ArticleGroupId] ON [dbo].[Products]
(
	[ArticleGroupId] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_ManufacturerId] ON [dbo].[Products]
(
	[ManufacturerId] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_Multimedia_Id] ON [dbo].[References]
(
	[Multimedia_Id] ASC
)
GO

ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO

ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO

ALTER TABLE [dbo].[Information]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Information_dbo.Multimedias_Multimedia_Id] FOREIGN KEY([Multimedia_Id])
REFERENCES [dbo].[Multimedias] ([Id])
GO

ALTER TABLE [dbo].[Information] CHECK CONSTRAINT [FK_dbo.Information_dbo.Multimedias_Multimedia_Id]
GO

ALTER TABLE [dbo].[Manufacturers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Manufacturers_dbo.Multimedias_Multimedia_Id] FOREIGN KEY([Multimedia_Id])
REFERENCES [dbo].[Multimedias] ([Id])
GO

ALTER TABLE [dbo].[Manufacturers] CHECK CONSTRAINT [FK_dbo.Manufacturers_dbo.Multimedias_Multimedia_Id]
GO

ALTER TABLE [dbo].[Multimedias]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Multimedias_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO

ALTER TABLE [dbo].[Multimedias] CHECK CONSTRAINT [FK_dbo.Multimedias_dbo.Products_ProductId]
GO

ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_dbo.News_dbo.Multimedias_Multimedia_Id] FOREIGN KEY([Multimedia_Id])
REFERENCES [dbo].[Multimedias] ([Id])
GO

ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_dbo.News_dbo.Multimedias_Multimedia_Id]
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.ArticleGroups_ArticleGroupId] FOREIGN KEY([ArticleGroupId])
REFERENCES [dbo].[ArticleGroups] ([Id])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.ArticleGroups_ArticleGroupId]
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Manufacturers_ManufacturerId] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturers] ([Id])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Manufacturers_ManufacturerId]
GO

ALTER TABLE [dbo].[References]  WITH CHECK ADD  CONSTRAINT [FK_dbo.References_dbo.Multimedias_Multimedia_Id] FOREIGN KEY([Multimedia_Id])
REFERENCES [dbo].[Multimedias] ([Id])
GO

ALTER TABLE [dbo].[References] CHECK CONSTRAINT [FK_dbo.References_dbo.Multimedias_Multimedia_Id]
GO

INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) 
VALUES (
	N'201607250637258_AutomaticMigration', N'PianoMelody.Data.Migrations.Configuration', 
	0x1F8B0800000000000400ED5DDB6EE4B8117D0F907F10F49404B36E5FB28B8961EFC26B8F2746C61E63DAB3C89B214B745B585D7A25F5AC8D205F96877C527E21A4AEBC1545EAD6F24C6380815B248BC5E2A912592CB1FEF79FFF9EFCF41C06D61794A47E1C9DDA077BFBB6852237F6FC68756A6FB2C7EFDEDA3FFDF8C73F9CBCF3C267EB97AADE11A9875B46E9A9FD9465EBE3C522759F50E8A47BA1EF26711A3F667B6E1C2E1C2F5E1CEEEFFF6D7170B04098848D6959D6C9A74D94F921CA7FE09FE771E4A275B67182EBD843415A3EC725CB9CAA75E384285D3B2E3AB56F7D278AAF51107B2F7B174EE6D8D659E03B988F250A1E6DCB89A2387332CCE5F1E7142DB3248E56CB357EE004772F6B84EB3D3A418A4AEE8F9BEABA03D93F240359340D2B52EE26CDE2D090E0C151299905DFBC937CED5A725876EFB08CB31732EA5C7EA7F65992F96E80DE27F1666D5B7C87C7E741422AB3222E26648F6EFAC6122BBCA9B1812144FEBDB1CE3741B649D069843659E204B8D5E621F0DD7FA097BBF857149D469B20A0F9C51CE332E6017E749BC46B94642F9FD063398A2BCFB6166CBB05DFB06E46B529C67615654787B675833B771E0254C38192C3328B13F41E45287132E4DD3A59869288D040B94085DEB9BEC8FF556F187F58916CEBDA79FE80A255F6746AE33F6DEBD27F465EF5A4E4E073E463BDC38DB26483844E6E9C2FFE2AE78FEB0EFFF4366E96DAD62714E415D2277F5DA8C35E59784FA62F70AB99BF4CE2F0531C348D99F2FB3B2759A10C0F2156545AC69BC4E5D83C5934905302B1A46888C1B2D50E7ECABE6EE3D42FEC87BAC76D8098EBE402A56EE2AF696E47EBEB36F1DD7A4417C8F54327B0ADDB04FF55BEFADEDAD6D27588840EDB885DA537E8F78AD8CF31D612273216316D520580A89B5E3BD1E6D17109BE93B6A6A0E1606DC250C6A3B20B4AE35159185D56E9F14A59A52BDC3716B1E1555A41B074F25A3253A7E4165B1EBCB8F1F0AA44CE6C5D7E5F1B428A53A1546453ACD2CB1CB3E235B2C974D39D61DEBE49FD9C04679E97A0349D7009D2E0B15D39E9BA807A52F0E6AD0954CFD4A028174D1D8D899257C1E47453544A78666A5A37DC29A9B2AFF3049176F54201FFB8F389DE1ABEDCB11E8EAEEB78D79CE1518DDE0F215F77C2BEC08A2243D994BAD079E152BF348778B70A5A0BBF7E3BA9EC55F4182761B9A337D259AAE54E692751DA3B3F0BC67F458FA6B65DDFCF14D080D7B3BC86A03B40B55EFA83375AA9A1E290263B8DD969CC781A431006A80A5724E8085FDE4B3930E050822242DF4843EA763B35D9A9C9786A52C30CD01559B9A030D24A3DB526CDFB307DAFD4EDB6AC35852361D15EB164C05CC75A5C1507876FB56064A82535BB60C7A374FB8B136C86564EFDED41698908D65570BCAE4FFDCED2F50DCAF6AA867B05C9CB0493FB3D4E7EDDA329BEB1B4DB35F83DD4C5EFD1C1C3E3D1DBEF7F70BCA31FFE8A8EBE9FFE0D301D365B34E2F0FB1F06E915B4B49F533C3BF2D53B35DFF765356AE52E948AAB76B14ABF1D6F498F901A1ED615D5F9439B702AC25B5A950CA88B26545D4CAD0D15BFE3F6AB8DB8254ABEF8C68BE0B2D56E09BCFD538B577210AC0D48A2978668244D5E3514A7B33EEF42C75779D7755FC61ABDE02DD5A39F84CD16B0EB61FFAD93A6F85DE4FDDD499F4687F812B99B0423729939E17A7C857A8A2374B3091F08E6A7EB6BB0A9B9FB3DBE745C6C25DF45A4556F7A1F62F7D77893BD8B3CE22FF89CB9A2FB4093C020EC9CB978C79A5E623023EF3CDE34FE816E8141C44E6D7B317C1E387E285F0D13F6EEABF266194C3D16D6BF7499E939F28778E5470A4EAA728E93E2B19C93B2CC94134241C14859CCF1913F95B351140DB611C8E53BFC4E20273BFFADC0DC1779DBDA47E4D3C71C2F8FE61B253DCDC2D343649DEBF8F0DA90939DBF36E46CE2C75F7C8F2C1934F6C755654C5EABBE7CEBDDAE731C6753AB0333CCA93B9FC606C0EAB209A5814E8575B84A2F0367D57CBC61B4B522B451512FE5625786DC716139E0B90B5EB0DC68BBCD0AFD1A91B56B39CAF74E10A0E4E55D80C2FCDC26B74FA7F6BE30554CAB25EE20407CA30351CE8544E98767691ABB7E2E093696868DF1653BC70B594B27E0B7890FAA236F7261AFB1A4F08C9FDA7F11C6D542BA8E7B6D48B39FB0B0F4F7F7F60E842ECAE323F2FD0FDE31A478FAFC28132D881FB9FEDA0934B8E1DA6ABEEFC98CD4BDF02517688D2262A335E4ACD33D1F592EB252F7C819C836699D2C2808A9912589C482265F1596258B3A3301962A9CBA15B1C3210A6663023CC1F2D5E99C0AD7DB0E9080F06170C6DB628929483181EF06A06A0943D642AD08AEAE42A96394B5F8150396F504225586B63EF4754D94773745530D750A5D538941A77FFEDB9EADE81C101208CD7D5B7C6033F94C38ACBEC2B544168EAF6F7CC417C42818FED570584434EA8F1D8A181B7FD0D2F81D884D75304FC32B15B3A62F036510D0F882909CB18348551CB8536AC0847DB09C1EF066E2E4637481029421EBCC2D3E2C3F7752D7F124813D980F03C62402140FEF47B1D2B0942630D1B024743A979FD54F649769F73634D1525F7733C3C5D9E424909379D601AC95FEE151C02611C80428930C5EA757306A643278956716CA49E50F30B6072FEEB8048057E9701D0F5EAC40A682173BF8D701AFE2244A39A7DCB1D4F6C0C51E824DFF9A14A53115B29891CF0C5885079944BBE316B55B9472E4E681F0CFB2EB453097A5A7382DDDD5FCFC13D24B94493C6978D1DEF8AEA5EE4861F9CA126B3E2516E8D47BE21612F4E6504687DDBFB711A316CB2225AAB0850EB53993F1C46CF95A48157B238144F1B8A56DBD479051A0761DAD64EAAF032454EAB2362AC579BB280C66E1DF2658CECAA8083696A8856819F628A355C751B69028A38C85F6857936185415A8A11C55B93434205B455D28C9964B028E2C657204C5E52E42A1AAAA2E4CE1EDA1E6714A3D3EDA6E08C655F3008522C65934FE8DC88E5F4336B20FAE45C9B41D06E81E075003810D94AEFF5F43C45D0402DD7621918A8E67DBC8B74DCB877D55A844D4E2CDD6127A5F493533D02227B9B3DBC0DDDD5F4682777B1C2441DF658B02D271D79A386CA9F1B02F7785845A5CB4638148F81457948ED277ABE5BDA598972D45B4DCB5630940FE91A528857667AEBE3B971A0BBDEA524845E9C01D4B34B24FA324CAD3E2DCD575EFD24229166B2A6D81BDB1B4F2890BC0DE426122644569801EC6561F23C577296BC5F865AE4160E015AFC38CBC5A1B02239739BF5ADD5FE623E7BC56C0C82B5E871979092060E012B74C9B63C67CD8AC3F6520A0572165B543A02E3B5914D707970F4E16C03DC327D7CE7AED472BEADEE1F289B52C2E1D3EFF6E697E1F6F58D058B88C5C79F745DD531627CE0A71A5E4AB7E0F5DFA499A91CB8E1F1C12FD76EE85423589FB03D830551DCA3C1CE2FC553BA8AA15F95B70B8E41731B3CE10D1675452B8C4A324916BF98011B033119B5BE42E682770124998F4791C6CC208767EC1AD8B2F19E8F6F28FEB097838FE053F97202BC1D9C84E80D6F42856BB063303ECB93426056C39CE7C3497D7D2349AA763CC2C4481F9289126C414188CADF8F09019582271B728A55B5C3CCB08B878A44F838F0EA489B5450EC254F9B0159A6A5B48CBD6B48BDDFFF55231C6F36AAE67EAE6DB367E1005FAB6519A0EFD7C3E93ADDAF698CC344847679E158DC799E5FA0E239A44FDD068AE854936E2A3BA9D88E1A37AA84FA7F8208026523C3131C475402B6B8CC138D7AD6196F1BEF4422D7D0A630E5B65EB79E3F6AEB87B8B014CF1683CEC6E092DB96FAA174A641434E0216FB6C3C54C7041F9E87AA1A33944358788A2ED0E27B3C14975BCDD132600192D98806DC75BC6D617CF31D323BF3C4F45A7FCBE98A6523E9ACF14036E3E9395041DC2D06129A16CBEED9DCEB6D67982FF739029AA8342BA4F134C02DC28A4A207008A0E83A95461D6341528F47A6BD356C7D2F49AAD2AECC67C92C096DB56A339FAD4B68411E844D10020795C95393AE4CDC681467927174DA07C644883BAD649204695194084B9798B410A53A24F91BB5E8B26C9151970495FA2C530491774A20748545EC3605D2C5C9BC52C9185527DCA920BB468D292E20EB4253CF365062E75F18E2DC6AB2E161BF8DDEA0BB7F817EA8CD730600041C7454C1103DA6F1503D018C71E0EB308A2EE4762B626CD63435A921D0AFD7C96580243323A62A908FCED872580066C75987B8558A3A3BC0C09A6C95C16C4F9B1E1CB92607A66881D1B176CB4077C6AC704BD691ECF316D4C0EE248388BE2D85312DA26CA4DCBD65084E4DFD4508C74E711FCA4A8B33D54328657195E7E8C6F5DA5E48EA8FA3227ED91F34140C6C881226AF5CE4D94B8519C9048A6441D2C3B0BD4A84384BF21D00811C62DE7274A98004734BCF08120E25900030892FE8610210FB9D639385162033C22914C822A9E7A162851C58F7F4D5011A24FF92AF54AA97C52FFAEA34FCBC84F26243597090930CD65919651A87C28685185DC5E5F2CF94EEDE54B9AA1B0F42BFE169C077E7EC45455C04B01FF11A559716DA17DB87F70685B6781EFA4452C7019E47ACC7F38AB15F57A7044A25E91172EF8E6E6B1B3844A9A7ACC3DF6E29DAA70C8E814F7F2FA44B2AD37EFF64834137D7112F7C949FE143ACF7FA629F5B886561AD0F96AA5D54486529D4C23719190248B452F7A4CA60AAF35538519F1326CB420FEE09B8B8D0F15A52640F8ECFE2AF2D0F3A9FDAFBCE9B175F5CF7BB6F51BEB6382ADD3B1B56FFDDB74207C70A9191F6C6B7D3EF4537683FBC957AB7483298C98ACBE1739EE4D6E0804BAF11838806E507BAD28E072637AF847D633537AAFD9E7B25FF6A2455F49DFE5954285929AA1B06E380202410FC5370FC13B3A3DEB6C40386B7326FA317628DAA1C8144580C76307A51D94CCA1240D1C9D6346E56A12C4EC1AFD12264BE99A5365B2E48CE182802340A750FCC1A42F9FD236552083267FE58FDF5857E9E7C8FF6D830BEEB0408936F089D4864991AA0EE79C69425B7DA962035334652D4BCF1966D3DC1A715334EDC18D71F2DBAFE30DFA2D38E3CCD2C8BE5E03C9E4699552E50C5CF7B4AC5D1C98B294ACBD20224DBBDA0F74626AD5A1E80D224228756A175A60DA54D92A5A67B0F234AA9D5CDD500AD52EBE213E81AAFE6BA56AB9C5A5832486F2D5BE6AE6B5D6105261F6DBF609E92EC75CC80311915F6536C8C1DE8EB762B2C7C1686F13DA107A7AE61E646FDA2E06D62D23A07067EE84D9A95AAEC8D2B19B96C95DEED2D37EA0ABD79635D060F6DA529771515C1D120EF64933396D0AC0AF33E79FE90C1A24B3EB9131B067AAC8A9F3D5E9E5A76B0B139C1A1EB726D90F87CA7638FDABC378A2267C75BCC69C85439B0C26CD0545D028E3E12B3018EA8BA4E6692F74B3370E8D89E2B2708A925EEEC7578002E0A2A8794EBF511ECBA13140659EA1C81964C17C0568505D0C354F4874CCE83997249E4DB61F093F13E6EE9C325DA7E2321BDD03C889C0A59BA5735BB9ED24D99500188D9D96736AFC40F708181C76CF290FE71C0054E6D102003476E2CDA901045D1E304700B567DA9C037EB6F51ADB067AB45F5F5BCFA629669DE0E7B2FC6C55E23C6ECD93597CB6786A7B0F319EF9E224419D978EEFAE76B5083DD525B24E6EA1E45C3C7DD6332474C216CB7A526616EB9E8953DA555DDEDE11E38C107A624A655D0D96CA5346DC2CC9A73AC7A78C3E9CA9AA6B0E50792FBA2942D9ED8338194CB15465D2F50DCAE4E972A0CE1AA30A76D854813B85F3F4F01DD7394585FEEA1259374D96D216FAC55B4B205E3C560FC04C6AE5525829B6B28EBA5B209F95AAEF7215A5ECBBACA3EE1BC8283565D653D99B42CCFF23BEF924BE77AA71FD8C5F85CC21A1A901C3A02B8A6A3A5E12CEC1D3959A0E40716E43B75765B99E691E52ED014C08F511138CF69B79C93245B864A9FFF0074D1DDA6FC0F462094C333A9FE4A0FD062BACE1B8DB6F0600F6B8893FA5A90B65C9D75B36BD122A601AF72D26FA14323D6A0F9359330117720E34D021F27A761F28B340036E8B1C68A0FDD378761FE690B03548DB295E9074B2F8B48988AD297E5DA0D45F3524C8C54F1172194F475D87BC432A870BC7515585FFEE11658EE7640E59A092B7362E26F1E07EB4B2AD3CC6967C95F080BCABE8E3265B6F323C64143E044C702A71DCA8FACF7393B23C9F7CCCBF5E4987180266D32771F41FA39F377EE0D57C5F4AE2370112C42354465F93B9CC4814F6EAA5A67413479A844AF1D58EAC3B14AE034C2CFD182D9D2FA80B6F187E1FD0CA715F9A685D8848FB44B0623FB9F09D55E2846949A3698F7F620C7BE1F38FFF0722FCF91548CF0000, 
	N'6.1.3-40302'
)
GO

INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4fa92237-5ec3-46ea-a05a-6ca4e3e736f9', N'melodia.ltd@abv.bg', 0, N'ANoxEJ/xTgDNsCVHkMqhnQQBTQLIy4J4cg0rkGbidMIxKk/jdQ+cCpPJQEUC0/lK2w==', N'c962beff-e960-4ded-b804-c6109f337a50', NULL, 0, 0, NULL, 0, 0, N'melodia.ltd@abv.bg')
GO

INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9beb88b0-3298-447a-9079-7284e715d6a1', N'Admin')
GO

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4fa92237-5ec3-46ea-a05a-6ca4e3e736f9', N'9beb88b0-3298-447a-9079-7284e715d6a1')
GO

INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_AddAdministrator', N'bg', N'Добави администратор')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_AddAdministrator', N'en', N'Add administrator')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_AddAdministrator', N'ru', N'Добави администратор')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_AddLabel', N'bg', N'Добави надпис')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_AddLabel', N'en', N'Add label')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_AddLabel', N'ru', N'Добави надпис')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Administration', N'bg', N'Администрация')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Administration', N'en', N'Administration')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Administration', N'ru', N'Администрация')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_AreYouSure', N'bg', N'Сигурни ли сте, че искате да изтриете това?')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_AreYouSure', N'en', N'Are you sure you want to delete this?')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_AreYouSure', N'ru', N'Сигурни ли сте, че искате да изтриете това?')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ArticleGroup', N'bg', N'Артикулна група')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ArticleGroup', N'en', N'Article group')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ArticleGroup', N'ru', N'Артикулна група')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ArticleGroups', N'bg', N'Артикулни групи')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ArticleGroups', N'en', N'Article groups')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ArticleGroups', N'ru', N'Артикулни групи')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgContent', N'bg', N'BG Съдържание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgContent', N'en', N'BG Content')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgContent', N'ru', N'BG Съдържание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgDescription', N'bg', N'BG Описание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgDescription', N'en', N'BG Description')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgDescription', N'ru', N'BG Описание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgName', N'bg', N'BG Име')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgName', N'en', N'BG Name')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgName', N'ru', N'BG Име')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgTitle', N'bg', N'BG Заглавие')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgTitle', N'en', N'BG Title')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_BgTitle', N'ru', N'BG Заглавие')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Carousel', N'bg', N'Слайд елементи')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Carousel', N'en', N'Carousel')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Carousel', N'ru', N'Слайд елементи')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Cancel', N'bg', N'Отказ')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Cancel', N'en', N'Cancel')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Cancel', N'ru', N'Отказ')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ChangePassword', N'bg', N'Смени паролата')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ChangePassword', N'en', N'Change password')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ChangePassword', N'ru', N'Смени паролата')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Condition', N'bg', N'Състояние')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Condition', N'en', N'Condition')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Condition', N'ru', N'Състояние')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ConfirmPassword', N'bg', N'Повторете паролата')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ConfirmPassword', N'en', N'Confirma password')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ConfirmPassword', N'ru', N'Повторете паролата')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_CreateNew', N'bg', N'Създай')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_CreateNew', N'en', N'Create')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_CreateNew', N'ru', N'Създай')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_CurrentPassword', N'bg', N'Текуща парола')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_CurrentPassword', N'en', N'Current password')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_CurrentPassword', N'ru', N'Текуща парола')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Delete', N'bg', N'Изтрий')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Delete', N'en', N'Delete')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Delete', N'ru', N'Изтрий')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Description', N'bg', N'Описание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Description', N'en', N'Description')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Description', N'ru', N'Описание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Edit', N'bg', N'Редактирай')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Edit', N'en', N'Edit')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Edit', N'ru', N'Редактирай')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Email', N'bg', N'Електронна поща')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Email', N'en', N'Email')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Email', N'ru', N'Електронна поща')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnContent', N'bg', N'EN Съдържание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnContent', N'en', N'EN Content')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnContent', N'ru', N'EN Съдържание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnDescription', N'bg', N'EN Описание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnDescription', N'en', N'EN Description')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnDescription', N'ru', N'EN Описание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnName', N'bg', N'EN Име')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnName', N'en', N'EN Name')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnName', N'ru', N'EN Име')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnTitle', N'bg', N'EN Заглавие')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnTitle', N'en', N'EN Title')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_EnTitle', N'ru', N'EN Заглавие')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrInvalidEmail', N'bg', N'Полето {0} е невалидно')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrInvalidEmail', N'en', N'The {0} field is not valid email address')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrInvalidEmail', N'ru', N'Полето {0} е невалидно')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrInvalidPrice', N'bg', N'Невалидна цена')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrInvalidPrice', N'en', N'Invalid price')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrInvalidPrice', N'ru', N'Невалидна цена')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrLenghtValidation', N'bg', N'Полето {0} трябва да бъде с дължина поне {2} символа')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrLenghtValidation', N'en', N'The {0} field must be at least {2} characters long')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrLenghtValidation', N'ru', N'Полето {0} трябва да бъде с дължина поне {2} символа')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrRequired', N'bg', N'Полето е задължително')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrRequired', N'en', N'The field is required')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrRequired', N'ru', N'Полето е задължително')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrSelectImage', N'bg', N'Моля изберете снимка')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrSelectImage', N'en', N'Please select image')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_ErrSelectImage', N'ru', N'Моля изберете снимка')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_GalleryImage', N'bg', N'Снимка за галерията')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_GalleryImage', N'en', N'Gallery image')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_GalleryImage', N'ru', N'Снимка за галерията')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_IsNew', N'bg', N'Нов')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_IsNew', N'en', N'New')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_IsNew', N'ru', N'Нов')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Key', N'bg', N'Ключ')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Key', N'en', N'Key')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Key', N'ru', N'Ключ')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Label', N'bg', N'надпис')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Label', N'en', N'label')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Label', N'ru', N'надпис')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_LabelCreated', N'bg', N'Надписа е създаден')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_LabelCreated', N'en', N'Label created')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_LabelCreated', N'ru', N'Надписа е създаден')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Login', N'bg', N'Вход')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Login', N'en', N'Login')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Login', N'ru', N'Вход')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_LogOff', N'bg', N'Изход')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_LogOff', N'en', N'Log Off')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_LogOff', N'ru', N'Изход')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Manufacturer', N'bg', N'Производител')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Manufacturer', N'en', N'Manufacturer')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Manufacturer', N'ru', N'Производител')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Name', N'bg', N'Име')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Name', N'en', N'Name')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Name', N'ru', N'Име')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Negotiable', N'bg', N'По договаряне')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Negotiable', N'en', N'Negotiable')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Negotiable', N'ru', N'По договаряне')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_New', N'bg', N'Ново')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_New', N'en', N'New')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_New', N'ru', N'Ново')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_NewPassword', N'bg', N'Нова парола')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_NewPassword', N'en', N'New password')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_NewPassword', N'ru', N'Нова парола')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_News', N'bg', N'Новина')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_News', N'en', N'News')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_News', N'ru', N'Новина')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Password', N'bg', N'Парола')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Password', N'en', N'Password')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Password', N'ru', N'Парола')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_PasswordValidation', N'bg', N'Паролите не съвпадат')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_PasswordValidation', N'en', N'The passwords do not match')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_PasswordValidation', N'ru', N'Паролите не съвпадат')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Photo', N'bg', N'Снимка')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Photo', N'en', N'Photo')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Photo', N'ru', N' Снимка')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Photos', N'bg', N'Снимки')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Photos', N'en', N'Photos')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Photos', N'ru', N'Снимки')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Product', N'bg', N'Продукт')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Product', N'en', N'Product')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Product', N'ru', N'Продуцт')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Reference', N'bg', N'Референция')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Reference', N'en', N'Reference')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Reference', N'ru', N'Референция')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuContent', N'bg', N'RU Съдържание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuContent', N'en', N'RU Content')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuContent', N'ru', N'RU Съдържание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuDescription', N'bg', N'RU Описание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuDescription', N'en', N'RU Description')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuDescription', N'ru', N'RU Описание')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuName', N'bg', N'RU Име')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuName', N'en', N'RU Name')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuName', N'ru', N'RU Име')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuTitle', N'bg', N'RU Заглавие')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuTitle', N'en', N'RU Title')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_RuTitle', N'ru', N'RU Заглавие')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Save', N'bg', N'Запиши')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Save', N'en', N'Save')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Save', N'ru', N'Запиши')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_SecondHand', N'bg', N'Втора употреба')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_SecondHand', N'en', N'Second hand')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_SecondHand', N'ru', N'Втора употреба')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Service', N'bg', N'Услуга')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Service', N'en', N'Service')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Service', N'ru', N'Услуга')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Type', N'bg', N'Вид')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Type', N'en', N'Type')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_Type', N'ru', N'Вид')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_UrlAddress', N'bg', N'Url адрес')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_UrlAddress', N'en', N'Url address')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_UrlAddress', N'ru', N'Url адрес')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_WithoutChoice', N'bg', N'Без избор')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_WithoutChoice', N'en', N'Without choice')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'_WithoutChoice', N'ru', N'Без избор')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'About', N'bg', N'За нас')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'About', N'en', N'About us')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'About', N'ru', N'За нас')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'All', N'bg', N'Всички')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'All', N'en', N'All')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'All', N'ru', N'Всички')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Contacts', N'bg', N'Контакти')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Contacts', N'en', N'Contacts')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Contacts', N'ru', N'Контакти')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Gallery', N'bg', N'Галерия')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Gallery', N'en', N'Gallery')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Gallery', N'ru', N'Галерия')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Home', N'bg', N'Начало')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Home', N'en', N'Home')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Home', N'ru', N'Начало')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Info', N'bg', N'Полезна информация')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Info', N'en', N'Useful information')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Info', N'ru', N'Полезна информация')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Logo', N'bg', N'Пиано')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Logo', N'en', N'Piano')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Logo', N'ru', N'Пиано')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Manufacturers', N'bg', N'Производители')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Manufacturers', N'en', N'Manufacturers')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Manufacturers', N'ru', N'Производители')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'News', N'bg', N'Новини')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'News', N'en', N'News')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'News', N'ru', N'Новини')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Price', N'bg', N'Цена')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Price', N'en', N'Price')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Price', N'ru', N'Цена')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Products', N'bg', N'Продукти')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Products', N'en', N'Products')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Products', N'ru', N'Продукти')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'References', N'bg', N'Референции')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'References', N'en', N'References')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'References', N'ru', N'Референции')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Services', N'bg', N'Услуги')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Services', N'en', N'Services')
INSERT [dbo].[Resources] ([Name], [Culture], [Value]) VALUES (N'Services', N'ru', N'Услуги')
GO

SET IDENTITY_INSERT [dbo].[Multimedias] ON 
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (2, CAST(N'2016-07-19T23:33:29.493' AS DateTime), N'http://localhost/Multimedia/304ccdff-34df-4678-84d7-c36f690180f3.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (3, CAST(N'2016-07-19T23:33:44.230' AS DateTime), N'http://localhost/Multimedia/bd355ce5-b959-44ad-aac0-13200dc1c202.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (4, CAST(N'2016-07-19T23:34:37.847' AS DateTime), N'http://localhost/Multimedia/3b259e29-ea78-48ec-a9f2-545f7f616b3b.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (5, CAST(N'2016-07-19T23:35:23.377' AS DateTime), N'http://localhost/Multimedia/ed4a7803-9ff2-40db-a2b1-d7a9f67e1c8c.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (6, CAST(N'2016-07-19T23:36:20.417' AS DateTime), N'http://localhost/Multimedia/5f2b3131-1b3e-4703-b7be-9262060b758a.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (7, CAST(N'2016-07-19T23:37:01.847' AS DateTime), N'http://localhost/Multimedia/f0227c48-b120-4c21-8c06-b6d8c2cdbdac.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (8, CAST(N'2016-07-19T23:37:50.937' AS DateTime), N'http://localhost/Multimedia/119386f9-90fe-4437-b652-522807ea854d.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (9, CAST(N'2016-07-19T23:38:48.107' AS DateTime), N'http://localhost/Multimedia/3acb3eeb-7368-4931-a2d2-6ffe972e5e16.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (10, CAST(N'2016-07-20T01:39:52.810' AS DateTime), N'http://localhost/Multimedia/650bad7f-3497-4f15-8005-05cea74ebedc.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (11, CAST(N'2016-07-20T01:55:12.790' AS DateTime), N'http://localhost/Multimedia/d4e5a917-4726-4e01-96a2-ed49d58a1759.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (12, CAST(N'2016-07-20T01:55:59.397' AS DateTime), N'http://localhost/Multimedia/ddbe3e52-66d4-4b30-b754-8b86f333c407.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (13, CAST(N'2016-07-20T01:56:49.077' AS DateTime), N'http://localhost/Multimedia/b548dd95-70eb-494a-8328-08174c8e7dcb.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (14, CAST(N'2016-07-20T01:57:27.187' AS DateTime), N'http://localhost/Multimedia/39533068-44d7-41f6-a47f-7268a2caf3b6.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (15, CAST(N'2016-07-20T01:58:40.407' AS DateTime), N'http://localhost/Multimedia/3250a0f0-500f-43c6-8f1d-bbf31607495a.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (16, CAST(N'2016-07-20T01:59:42.047' AS DateTime), N'http://localhost/Multimedia/a70d04a4-b1c0-4258-a233-682058a40525.jpg', N'', 1, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (17, CAST(N'2016-07-28T21:37:39.177' AS DateTime), N'http://localhost/Multimedia/e88cf5a3-861f-45cc-bafe-fc82e9eb5c4c.jpg', N'[{"k":"en","v":"Pic 1 description"},{"k":"ru","v":"Описание на снимка 1"},{"k":"bg","v":"Описание на снимка 1"}]', 2, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (18, CAST(N'2016-07-28T21:38:15.553' AS DateTime), N'http://localhost/Multimedia/79cad95f-4414-4823-9888-e6ffbb1a08d4.jpg', N'[{"k":"en","v":"Pic 2"},{"k":"ru","v":"Снимка 2"},{"k":"bg","v":"Снимка 2"}]', 2, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (19, CAST(N'2016-07-28T21:38:36.090' AS DateTime), N'http://localhost/Multimedia/e14cf71f-6266-4438-b469-bf91fcb56fe5.jpg', N'[{"k":"en","v":"Pic 3"},{"k":"ru","v":"Снимка 3"},{"k":"bg","v":"Снимка 3"}]', 2, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (20, CAST(N'2016-07-28T21:39:05.893' AS DateTime), N'http://localhost/Multimedia/2f0d94a0-6a04-4a60-8f2d-9d7b56a63c08.jpg', N'[{"k":"en","v":"Pic 4"},{"k":"ru","v":"Снимка 4"},{"k":"bg","v":"Снимка 4"}]', 2, NULL)
INSERT [dbo].[Multimedias] ([Id], [Created], [Url], [Content], [Type], [ProductId]) VALUES (21, CAST(N'2016-07-28T21:39:38.940' AS DateTime), N'http://localhost/Multimedia/4c1ac78d-f5d5-43e5-8be5-1b4f32497a9f.jpg', N'[{"k":"en","v":"Pic 5"},{"k":"ru","v":"Снимка 5"},{"k":"bg","v":"Снимка 5"}]', 2, NULL)
SET IDENTITY_INSERT [dbo].[Multimedias] OFF
GO

INSERT [dbo].[Services] ([Name], [Description], [Price]) VALUES (N'[{"k":"en","v":"ПРИЕМАМЕ ПЛАЩАНЕ С КРЕДИТНИ И ДЕБИТНИ КАРТИ."},{"k":"ru","v":"ПРИЕМАМЕ ПЛАЩАНЕ С КРЕДИТНИ И ДЕБИТНИ КАРТИ."},{"k":"bg","v":"ПРИЕМАМЕ ПЛАЩАНЕ С КРЕДИТНИ И ДЕБИТНИ КАРТИ."}]', N'[{"k":"en","v":"При нас може да платите както в брой и с банков превод така и с кредитни и дебитни карти VISA, MASTERCARD, MAESTRO, БОРИКА, AMERICAN EXPRESS."},{"k":"ru","v":"При нас може да платите както в брой и с банков превод така и с кредитни и дебитни карти VISA, MASTERCARD, MAESTRO, БОРИКА, AMERICAN EXPRESS."},{"k":"bg","v":"При нас може да платите както в брой и с банков превод така и с кредитни и дебитни карти VISA, MASTERCARD, MAESTRO, БОРИКА, AMERICAN EXPRESS."}]', CAST(0.00 AS Decimal(18, 2)))
GO

INSERT [dbo].[News] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-19T00:30:36.447' AS DateTime), N'[{"k":"en","v":"УЧАСТИЕ В ИЗЛОЖЕНИЯ"},{"k":"ru","v":"УЧАСТИЕ В ИЗЛОЖЕНИЯ"},{"k":"bg","v":"УЧАСТИЕ В ИЗЛОЖЕНИЯ"}]', N'[{"k":"en","v":"ПИАНО САЛОН \"МЕЛОДИЯ\" ежегодно взима участие в ИЗЛОЖЕНИЯТА \"СТРОЙКО 2000\" - НДК, \"ХОТЕЛИ ЕКСПО\" - ЕКСПО ЦЕНТЪР, \" НЕСЕБЪР ЕКСПО\" - Слънчев Бряг!\r\nПо време на изложенията се ползват специални отстъпки!!!"},{"k":"ru","v":"ПИАНО САЛОН \"МЕЛОДИЯ\" ежегодно взима участие в ИЗЛОЖЕНИЯТА \"СТРОЙКО 2000\" - НДК, \"ХОТЕЛИ ЕКСПО\" - ЕКСПО ЦЕНТЪР, \" НЕСЕБЪР ЕКСПО\" - Слънчев Бряг!\r\nПо време на изложенията се ползват специални отстъпки!!!"},{"k":"bg","v":"ПИАНО САЛОН \"МЕЛОДИЯ\" ежегодно взима участие в ИЗЛОЖЕНИЯТА \"СТРОЙКО 2000\" - НДК, \"ХОТЕЛИ ЕКСПО\" - ЕКСПО ЦЕНТЪР, \" НЕСЕБЪР ЕКСПО\" - Слънчев Бряг!\r\nПо време на изложенията се ползват специални отстъпки!!!"}]', 3)
INSERT [dbo].[News] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-19T23:33:29.497' AS DateTime), N'[{"k":"en","v":"ІІІ. 2003 - Дилър на PETROF "},{"k":"ru","v":"ІІІ. 2003 - Дилър на PETROF "},{"k":"bg","v":"ІІІ. 2003 - Дилър на PETROF "}]', N'[{"k":"en","v":"Март 2003г. - Подписахме договор и до ден днешен сме ексклузивен представител за внос и разпространение на пиана и рояли ''PETROF'' на територията на Република България."},{"k":"ru","v":"Март 2003г. - Подписахме договор и до ден днешен сме ексклузивен представител за внос и разпространение на пиана и рояли ''PETROF'' на територията на Република България."},{"k":"bg","v":"Март 2003г. - Подписахме договор и до ден днешен сме ексклузивен представител за внос и разпространение на пиана и рояли ''PETROF'' на територията на Република България."}]', 2)
INSERT [dbo].[News] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-19T23:34:37.850' AS DateTime), N'[{"k":"en","v":"ІІІ. 2008 - Споразумение със STEINWAY & SONS "},{"k":"ru","v":"ІІІ. 2008 - Споразумение със STEINWAY & SONS "},{"k":"bg","v":"ІІІ. 2008 - Споразумение със STEINWAY & SONS "}]', N'[{"k":"en","v":"Постигнахме споразумение със STEINWAY & SONS да предлагаме и обслужваме техните ВИСОК КЛАС ПИАНА и РОЯЛИ в България. Ние сме единствената фирма в България, която има такова споразумение."},{"k":"ru","v":"Постигнахме споразумение със STEINWAY & SONS да предлагаме и обслужваме техните ВИСОК КЛАС ПИАНА и РОЯЛИ в България. Ние сме единствената фирма в България, която има такова споразумение."},{"k":"bg","v":"Постигнахме споразумение със STEINWAY & SONS да предлагаме и обслужваме техните ВИСОК КЛАС ПИАНА и РОЯЛИ в България. Ние сме единствената фирма в България, която има такова споразумение."}]', 4)
INSERT [dbo].[News] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-19T23:35:23.377' AS DateTime), N'[{"k":"en","v":"Х. 2008г. - ДИЛЪР НА SAMICK "},{"k":"ru","v":"Х. 2008г. - ДИЛЪР НА SAMICK "},{"k":"bg","v":"Х. 2008г. - ДИЛЪР НА SAMICK "}]', N'[{"k":"en","v":"От месец октомври 2008г. сме официални дилъри на марката SAMICK за България. Благодарение на коректните ни взаимоотношения с чуждестранните ни бизнес партньори и добрите обороти постигнахме споразумение за дилърски права на територията на Република България."},{"k":"ru","v":"От месец октомври 2008г. сме официални дилъри на марката SAMICK за България. Благодарение на коректните ни взаимоотношения с чуждестранните ни бизнес партньори и добрите обороти постигнахме споразумение за дилърски права на територията на Република България."},{"k":"bg","v":"От месец октомври 2008г. сме официални дилъри на марката SAMICK за България. Благодарение на коректните ни взаимоотношения с чуждестранните ни бизнес партньори и добрите обороти постигнахме споразумение за дилърски права на територията на Република България."}]', 5)
INSERT [dbo].[News] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-19T23:36:20.417' AS DateTime), N'[{"k":"en","v":"ІХ.2009г. - ДИЛЪР на марката WEBER "},{"k":"ru","v":"ІХ.2009г. - ДИЛЪР на марката WEBER "},{"k":"bg","v":"ІХ.2009г. - ДИЛЪР на марката WEBER "}]', N'[{"k":"en","v":"Вече имаме и споразумение за дилърски права с една от най-бързо развиващите се фирми в света - YOUNG CHANG - Южна Корея. Световният лидер STEINWAY & SONS възлага на YOUNG CHANG да произвежда някои техни марки пиана и рояли, като ESSEX."},{"k":"ru","v":"Вече имаме и споразумение за дилърски права с една от най-бързо развиващите се фирми в света - YOUNG CHANG - Южна Корея. Световният лидер STEINWAY & SONS възлага на YOUNG CHANG да произвежда някои техни марки пиана и рояли, като ESSEX."},{"k":"bg","v":"Вече имаме и споразумение за дилърски права с една от най-бързо развиващите се фирми в света - YOUNG CHANG - Южна Корея. Световният лидер STEINWAY & SONS възлага на YOUNG CHANG да произвежда някои техни марки пиана и рояли, като ESSEX."}]', 6)
INSERT [dbo].[News] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-19T23:37:01.847' AS DateTime), N'[{"k":"en","v":"X.2009 - ДИЛЪР на C.BECHSTEIN "},{"k":"ru","v":"X.2009 - ДИЛЪР на C.BECHSTEIN "},{"k":"bg","v":"X.2009 - ДИЛЪР на C.BECHSTEIN "}]', N'[{"k":"en","v":"Месец Октомври 2009г. Горди сме да бъдем дилъри на световно известният производител на висок клас пиана и рояли - C.BECHSTEIN за България."},{"k":"ru","v":"Месец Октомври 2009г. Горди сме да бъдем дилъри на световно известният производител на висок клас пиана и рояли - C.BECHSTEIN за България."},{"k":"bg","v":"Месец Октомври 2009г. Горди сме да бъдем дилъри на световно известният производител на висок клас пиана и рояли - C.BECHSTEIN за България."}]', 7)
INSERT [dbo].[News] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-19T23:37:50.937' AS DateTime), N'[{"k":"en","v":"ІІІ. 2010г. - Споразумение за ВНОС на SCHIMMEL и SEILER"},{"k":"ru","v":"ІІІ. 2010г. - Споразумение за ВНОС на SCHIMMEL и SEILER"},{"k":"bg","v":"ІІІ. 2010г. - Споразумение за ВНОС на SCHIMMEL и SEILER"}]', N'[{"k":"en","v":"ІІІ. 2010г. - Продължаваме да се развиваме! Вече имаме споразумение за ВНОС на пиана и рояли - SCHIMMEL и SEILER!"},{"k":"ru","v":"ІІІ. 2010г. - Продължаваме да се развиваме! Вече имаме споразумение за ВНОС на пиана и рояли - SCHIMMEL и SEILER!"},{"k":"bg","v":"ІІІ. 2010г. - Продължаваме да се развиваме! Вече имаме споразумение за ВНОС на пиана и рояли - SCHIMMEL и SEILER!"}]', 8)
INSERT [dbo].[News] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-19T23:38:48.107' AS DateTime), N'[{"k":"en","v":"Х. 2012 г. - МЕЛОДИЯ С ИЗЦЯЛО ОБНОВЕН САЛОН "},{"k":"ru","v":"Х. 2012 г. - МЕЛОДИЯ С ИЗЦЯЛО ОБНОВЕН САЛОН "},{"k":"bg","v":"Х. 2012 г. - МЕЛОДИЯ С ИЗЦЯЛО ОБНОВЕН САЛОН "}]', N'[{"k":"en","v":"През 2013г. Пиано салон Мелодия ще отпразнува своята 15 годишнина от основавнето си в изцяло обновен шоу рум, с европейски вид и изискан стил."},{"k":"ru","v":"През 2013г. Пиано салон Мелодия ще отпразнува своята 15 годишнина от основавнето си в изцяло обновен шоу рум, с европейски вид и изискан стил."},{"k":"bg","v":"През 2013г. Пиано салон Мелодия ще отпразнува своята 15 годишнина от основавнето си в изцяло обновен шоу рум, с европейски вид и изискан стил."}]', 9)
INSERT [dbo].[News] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-20T01:39:52.810' AS DateTime), N'[{"k":"en","v":"17.11.2014 Участниците в детската Евровизия бяха при нас."},{"k":"ru","v":"17.11.2014 Участниците в детската Евровизия бяха при нас."},{"k":"bg","v":"17.11.2014 Участниците в детската Евровизия бяха при нас."}]', N'[{"k":"en","v":"Имахме удоволствието да чуем на живо и да се насладим на изпълнението на \"Планетата на децата\" от самите участници в детската Евровизия Хасан и Ибрахим Игнатови. Благодарим Ви мили деца за прекрасните моменти!"},{"k":"ru","v":"Имахме удоволствието да чуем на живо и да се насладим на изпълнението на \"Планетата на децата\" от самите участници в детската Евровизия Хасан и Ибрахим Игнатови. Благодарим Ви мили деца за прекрасните моменти!"},{"k":"bg","v":"Имахме удоволствието да чуем на живо и да се насладим на изпълнението на \"Планетата на децата\" от самите участници в детската Евровизия Хасан и Ибрахим Игнатови. Благодарим Ви мили деца за прекрасните моменти!"}]', 10)
GO

INSERT [dbo].[Information] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-20T01:55:12.793' AS DateTime), N'[{"k":"en","v":"МОЯТА ПРЕПОРЪКА Е:"},{"k":"ru","v":"МОЯТА ПРЕПОРЪКА Е:"},{"k":"bg","v":"МОЯТА ПРЕПОРЪКА Е:"}]', N'[{"k":"en","v":"Ориентирайте се към употребявани европейски пиана около 30-40-50 годишни. Цените на употребяваните немски и чешки пиана варират от 1000 до 2-3000 лв.\r\nВисоко качествените немски пиана и рояли могат да бъдат и на по-високи цени, зависи от марката, състоянието и годината на производство на инструмента.\r\n\r\nАко пък имате възможност да вложите повече пари в НОВО европейско пиано – това е най-добрият избор, смятайте че това пиано ще радва Вас, децата Ви и внуците Ви."},{"k":"ru","v":"Ориентирайте се към употребявани европейски пиана около 30-40-50 годишни. Цените на употребяваните немски и чешки пиана варират от 1000 до 2-3000 лв.\r\nВисоко качествените немски пиана и рояли могат да бъдат и на по-високи цени, зависи от марката, състоянието и годината на производство на инструмента.\r\n\r\nАко пък имате възможност да вложите повече пари в НОВО европейско пиано – това е най-добрият избор, смятайте че това пиано ще радва Вас, децата Ви и внуците Ви."},{"k":"bg","v":"Ориентирайте се към употребявани европейски пиана около 30-40-50 годишни. Цените на употребяваните немски и чешки пиана варират от 1000 до 2-3000 лв.\r\nВисоко качествените немски пиана и рояли могат да бъдат и на по-високи цени, зависи от марката, състоянието и годината на производство на инструмента.\r\n\r\nАко пък имате възможност да вложите повече пари в НОВО европейско пиано – това е най-добрият избор, смятайте че това пиано ще радва Вас, децата Ви и внуците Ви."}]', 11)
INSERT [dbo].[Information] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-20T01:55:59.397' AS DateTime), N'[{"k":"en","v":"Пиано от нерегламентирани търговци - категорично НЕ!"},{"k":"ru","v":"Пиано от нерегламентирани търговци - категорично НЕ!"},{"k":"bg","v":"Пиано от нерегламентирани търговци - категорично НЕ!"}]', N'[{"k":"en","v":"Бъдете изключително внимателни при избор на пиано от гараж. На пазара има доста нерегламентирани търговци, които извършват НЕЛЕГАЛЕН ВНОС на инструменти от Швейцария, Австрия и западна Европа.\r\n\r\nПовечето такива инструменти са от музикални училища, на които доста е свирено и са амортизирани. Други пък просто са били оставени на улицата от собствениците им или подарени срещу изнасяне."},{"k":"ru","v":"Бъдете изключително внимателни при избор на пиано от гараж. На пазара има доста нерегламентирани търговци, които извършват НЕЛЕГАЛЕН ВНОС на инструменти от Швейцария, Австрия и западна Европа.\r\n\r\nПовечето такива инструменти са от музикални училища, на които доста е свирено и са амортизирани. Други пък просто са били оставени на улицата от собствениците им или подарени срещу изнасяне."},{"k":"bg","v":"Бъдете изключително внимателни при избор на пиано от гараж. На пазара има доста нерегламентирани търговци, които извършват НЕЛЕГАЛЕН ВНОС на инструменти от Швейцария, Австрия и западна Европа.\r\n\r\nПовечето такива инструменти са от музикални училища, на които доста е свирено и са амортизирани. Други пък просто са били оставени на улицата от собствениците им или подарени срещу изнасяне."}]', 12)
INSERT [dbo].[Information] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-20T01:56:49.077' AS DateTime), N'[{"k":"en","v":"Ползвано пиано - може, но да е от добра марка и не много старо."},{"k":"ru","v":"Ползвано пиано - може, но да е от добра марка и не много старо."},{"k":"bg","v":"Ползвано пиано - може, но да е от добра марка и не много старо."}]', N'[{"k":"en","v":"Ако търсите употребявано пиано е важно да знаете, че животът на едно пиано или роял е около 80-100 г. Това означава, че много стар инструмент също не е добър избор. Вероятността да започнат да се получават цепнатини по резонаторната дъска е голяма. А вероятно и вирбелите, които държат струните ще бъдат вече „разхлабени” и пианото няма да държи строй.\r\n\r\nИма и стар тип механика т.нар \"Виенски\", който не отговаря на съвременното темпериране.\r\nКоректните търговци не биха Ви подвели относно вида механика, но при покупка от частен клиент е възможно да се получи такова нещо, дори и не умишлено, а просто от незнание от страна на продавача."},{"k":"ru","v":"Ако търсите употребявано пиано е важно да знаете, че животът на едно пиано или роял е около 80-100 г. Това означава, че много стар инструмент също не е добър избор. Вероятността да започнат да се получават цепнатини по резонаторната дъска е голяма. А вероятно и вирбелите, които държат струните ще бъдат вече „разхлабени” и пианото няма да държи строй.\r\n\r\nИма и стар тип механика т.нар \"Виенски\", който не отговаря на съвременното темпериране.\r\nКоректните търговци не биха Ви подвели относно вида механика, но при покупка от частен клиент е възможно да се получи такова нещо, дори и не умишлено, а просто от незнание от страна на продавача."},{"k":"bg","v":"Ако търсите употребявано пиано е важно да знаете, че животът на едно пиано или роял е около 80-100 г. Това означава, че много стар инструмент също не е добър избор. Вероятността да започнат да се получават цепнатини по резонаторната дъска е голяма. А вероятно и вирбелите, които държат струните ще бъдат вече „разхлабени” и пианото няма да държи строй.\r\n\r\nИма и стар тип механика т.нар \"Виенски\", който не отговаря на съвременното темпериране.\r\nКоректните търговци не биха Ви подвели относно вида механика, но при покупка от частен клиент е възможно да се получи такова нещо, дори и не умишлено, а просто от незнание от страна на продавача."}]', 13)
INSERT [dbo].[Information] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-20T01:57:27.190' AS DateTime), N'[{"k":"en","v":"Качествено европейско пиано на разумна цена"},{"k":"ru","v":"Качествено европейско пиано на разумна цена"},{"k":"bg","v":"Качествено европейско пиано на разумна цена"}]', N'[{"k":"en","v":"Качествените европейски пиана – PETROF, C.BECHSTEIN, BLUTHNER, FORSTER, SEILER се произвеждат ИЗЦЯЛО в ЕВРОПА от фирми с над 100 годишен опит, доказали се на пазара с качествените инструменти, които произвеждат. Моля не се подвеждайте по некоректна информация давана от конкурентни фирми, че всички фирми са изнесли производството си в Китай. Това НЕ е вярно. В Европа има много фирми с традиции, които произвеждат инструментите си изцяло в Европа и държат на качеството и реномето си. Цените на новите европейски пиана са около 5000 евро и нагоре."},{"k":"ru","v":"Качествените европейски пиана – PETROF, C.BECHSTEIN, BLUTHNER, FORSTER, SEILER се произвеждат ИЗЦЯЛО в ЕВРОПА от фирми с над 100 годишен опит, доказали се на пазара с качествените инструменти, които произвеждат. Моля не се подвеждайте по некоректна информация давана от конкурентни фирми, че всички фирми са изнесли производството си в Китай. Това НЕ е вярно. В Европа има много фирми с традиции, които произвеждат инструментите си изцяло в Европа и държат на качеството и реномето си. Цените на новите европейски пиана са около 5000 евро и нагоре."},{"k":"bg","v":"Качествените европейски пиана – PETROF, C.BECHSTEIN, BLUTHNER, FORSTER, SEILER се произвеждат ИЗЦЯЛО в ЕВРОПА от фирми с над 100 годишен опит, доказали се на пазара с качествените инструменти, които произвеждат. Моля не се подвеждайте по некоректна информация давана от конкурентни фирми, че всички фирми са изнесли производството си в Китай. Това НЕ е вярно. В Европа има много фирми с традиции, които произвеждат инструментите си изцяло в Европа и държат на качеството и реномето си. Цените на новите европейски пиана са около 5000 евро и нагоре."}]', 14)
INSERT [dbo].[Information] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-20T01:58:40.407' AS DateTime), N'[{"k":"en","v":"Ако търсите ново пиано внимавайте - Китайски пиана с немски имена!"},{"k":"ru","v":"Ако търсите ново пиано внимавайте - Китайски пиана с немски имена!"},{"k":"bg","v":"Ако търсите ново пиано внимавайте - Китайски пиана с немски имена!"}]', N'[{"k":"en","v":"Пазарът е залят от редица марки, които само имат немски имена, но всъщност се произвеждат в Китай. Едни от тях са SCHUMANN, OFFENBACH, OTTO MEISTER, TAYLOR London и др. За съжаление тази информация често се спестява на клиента и обяснението че са внесени от Европа и са с немски части, не означава, че са европейски.\r\nЗа да бъде качествено едно пиано или роял дървото трябва да отлежава на естествени атмосферни условия поне 20 - 30 години. Голяма част от източните фабрики сравнително от скоро произвеждат пиана и нямат възможност да чакат толкова дълго дървото да отлежи, за да произведат качествени пиана.\r\nИма и много други изисквания, като отливката на чугунената лира и т.н.\r\nПоискайте сертификат за произход, или потърсете в интеренет повече информация за марката и производителя.\r\nЦените на тези пиана са около 4-5000 лв. и те със сигурност не са произведени в Европа."},{"k":"ru","v":"Пазарът е залят от редица марки, които само имат немски имена, но всъщност се произвеждат в Китай. Едни от тях са SCHUMANN, OFFENBACH, OTTO MEISTER, TAYLOR London и др. За съжаление тази информация често се спестява на клиента и обяснението че са внесени от Европа и са с немски части, не означава, че са европейски.\r\nЗа да бъде качествено едно пиано или роял дървото трябва да отлежава на естествени атмосферни условия поне 20 - 30 години. Голяма част от източните фабрики сравнително от скоро произвеждат пиана и нямат възможност да чакат толкова дълго дървото да отлежи, за да произведат качествени пиана.\r\nИма и много други изисквания, като отливката на чугунената лира и т.н.\r\nПоискайте сертификат за произход, или потърсете в интеренет повече информация за марката и производителя.\r\nЦените на тези пиана са около 4-5000 лв. и те със сигурност не са произведени в Европа."},{"k":"bg","v":"Пазарът е залят от редица марки, които само имат немски имена, но всъщност се произвеждат в Китай. Едни от тях са SCHUMANN, OFFENBACH, OTTO MEISTER, TAYLOR London и др. За съжаление тази информация често се спестява на клиента и обяснението че са внесени от Европа и са с немски части, не означава, че са европейски.\r\nЗа да бъде качествено едно пиано или роял дървото трябва да отлежава на естествени атмосферни условия поне 20 - 30 години. Голяма част от източните фабрики сравнително от скоро произвеждат пиана и нямат възможност да чакат толкова дълго дървото да отлежи, за да произведат качествени пиана.\r\nИма и много други изисквания, като отливката на чугунената лира и т.н.\r\nПоискайте сертификат за произход, или потърсете в интеренет повече информация за марката и производителя.\r\nЦените на тези пиана са около 4-5000 лв. и те със сигурност не са произведени в Европа."}]', 15)
INSERT [dbo].[Information] ([Created], [Title], [Content], [Multimedia_Id]) VALUES (CAST(N'2016-07-20T01:59:42.047' AS DateTime), N'[{"k":"en","v":"ВАЖНО за ПИАНАТА"},{"k":"ru","v":"ВАЖНО за ПИАНАТА"},{"k":"bg","v":"ВАЖНО за ПИАНАТА"}]', N'[{"k":"en","v":"Позававйки се на дългогодишния си опит в бизнеса с пиана и рояли бих искал да Ви дам повече информация, ако Ви предстои да купувате пиано или роял.\r\nФирмата, която създадох МЕЛОДИЯ е от 18 години на пазара. Държа на името си и на това клиентите ми да бъдат информирани и доволни, както от пианото или рояла така и от обслужването във фирмата.\r\nЗа мен най-голямото признание е препоръката от клиент.\r\nНадявам се да Ви бъда полезен и ще се радвам на Вашето посещение в изцяло обновения шоу рум на пиано салон Мелодия.\r\nВалентин Маврев\r\nСобственик"},{"k":"ru","v":"Позававйки се на дългогодишния си опит в бизнеса с пиана и рояли бих искал да Ви дам повече информация, ако Ви предстои да купувате пиано или роял.\r\nФирмата, която създадох МЕЛОДИЯ е от 18 години на пазара. Държа на името си и на това клиентите ми да бъдат информирани и доволни, както от пианото или рояла така и от обслужването във фирмата.\r\nЗа мен най-голямото признание е препоръката от клиент.\r\nНадявам се да Ви бъда полезен и ще се радвам на Вашето посещение в изцяло обновения шоу рум на пиано салон Мелодия.\r\nВалентин Маврев\r\nСобственик"},{"k":"bg","v":"Позававйки се на дългогодишния си опит в бизнеса с пиана и рояли бих искал да Ви дам повече информация, ако Ви предстои да купувате пиано или роял.\r\nФирмата, която създадох МЕЛОДИЯ е от 18 години на пазара. Държа на името си и на това клиентите ми да бъдат информирани и доволни, както от пианото или рояла така и от обслужването във фирмата.\r\nЗа мен най-голямото признание е препоръката от клиент.\r\nНадявам се да Ви бъда полезен и ще се радвам на Вашето посещение в изцяло обновения шоу рум на пиано салон Мелодия.\r\nВалентин Маврев\r\nСобственик"}]', 16)
GO

USE [master]
GO