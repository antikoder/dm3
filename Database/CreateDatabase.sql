-- =========================================================
-- Скрипт создания базы данных для системы продажи обуви
-- СУБД: Microsoft SQL Server 2017+
-- Нормализация: 3НФ, ссылочная целостность через FK
-- =========================================================

IF DB_ID('ShopDB') IS NOT NULL
BEGIN
    ALTER DATABASE ShopDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ShopDB;
END
GO

CREATE DATABASE ShopDB;
GO

USE ShopDB;
GO

CREATE TABLE Roles
(
    RoleId   INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Users
(
    UserId    INT IDENTITY(1,1) PRIMARY KEY,
    Login     NVARCHAR(100) NOT NULL UNIQUE,
    Password  NVARCHAR(100) NOT NULL,
    FullName  NVARCHAR(150) NOT NULL,
    RoleId    INT           NOT NULL,
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);
GO

CREATE TABLE Categories
(
    CategoryId   INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE Manufacturers
(
    ManufacturerId   INT IDENTITY(1,1) PRIMARY KEY,
    ManufacturerName NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE Suppliers
(
    SupplierId   INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE Units
(
    UnitId   INT IDENTITY(1,1) PRIMARY KEY,
    UnitName NVARCHAR(30) NOT NULL UNIQUE
);
GO

CREATE TABLE Products
(
    ProductId       INT IDENTITY(1,1) PRIMARY KEY,
    ProductCode     NVARCHAR(20)   NULL,
    ProductName     NVARCHAR(200)  NOT NULL,
    Description     NVARCHAR(1000) NULL,
    CategoryId      INT            NOT NULL,
    ManufacturerId  INT            NOT NULL,
    SupplierId      INT            NOT NULL,
    UnitId          INT            NOT NULL,
    Price           DECIMAL(10,2)  NOT NULL CHECK (Price >= 0),
    Quantity        INT            NOT NULL CHECK (Quantity >= 0),
    Discount        INT            NOT NULL DEFAULT 0 CHECK (Discount BETWEEN 0 AND 100),
    ImagePath       NVARCHAR(300)  NULL,
    CONSTRAINT FK_Products_Categories    FOREIGN KEY (CategoryId)     REFERENCES Categories(CategoryId),
    CONSTRAINT FK_Products_Manufacturers FOREIGN KEY (ManufacturerId) REFERENCES Manufacturers(ManufacturerId),
    CONSTRAINT FK_Products_Suppliers     FOREIGN KEY (SupplierId)     REFERENCES Suppliers(SupplierId),
    CONSTRAINT FK_Products_Units         FOREIGN KEY (UnitId)         REFERENCES Units(UnitId)
);
GO

CREATE TABLE OrderStatuses
(
    StatusId   INT IDENTITY(1,1) PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE PickupPoints
(
    PickupPointId INT IDENTITY(1,1) PRIMARY KEY,
    Address       NVARCHAR(300) NOT NULL UNIQUE
);
GO

CREATE TABLE Orders
(
    OrderId        INT IDENTITY(1,1) PRIMARY KEY,
    OrderCode      NVARCHAR(20)  NOT NULL UNIQUE,
    StatusId       INT           NOT NULL,
    PickupPointId  INT           NOT NULL,
    OrderDate      DATE          NULL,
    DeliveryDate   DATE          NULL,
    UserId         INT           NULL,
    CONSTRAINT FK_Orders_Statuses     FOREIGN KEY (StatusId)      REFERENCES OrderStatuses(StatusId),
    CONSTRAINT FK_Orders_PickupPoints FOREIGN KEY (PickupPointId) REFERENCES PickupPoints(PickupPointId),
    CONSTRAINT FK_Orders_Users        FOREIGN KEY (UserId)        REFERENCES Users(UserId)
);
GO

CREATE TABLE OrderItems
(
    OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId     INT NOT NULL,
    ProductId   INT NOT NULL,
    Quantity    INT NOT NULL CHECK (Quantity > 0),
    CONSTRAINT FK_OrderItems_Orders   FOREIGN KEY (OrderId)   REFERENCES Orders(OrderId)   ON DELETE CASCADE,
    CONSTRAINT FK_OrderItems_Products FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO
-- ============== Импорт справочников из xlsx ==============
INSERT INTO Roles (RoleName) VALUES (N'Авторизированный клиент'),(N'Менеджер'),(N'Администратор');
INSERT INTO Categories (CategoryName) VALUES (N'Женская обувь');
INSERT INTO Categories (CategoryName) VALUES (N'Мужская обувь');
INSERT INTO Manufacturers (ManufacturerName) VALUES (N'Рос');
INSERT INTO Manufacturers (ManufacturerName) VALUES (N'Alessio Nesca');
INSERT INTO Manufacturers (ManufacturerName) VALUES (N'Marco Tozzi');
INSERT INTO Manufacturers (ManufacturerName) VALUES (N'Kari');
INSERT INTO Manufacturers (ManufacturerName) VALUES (N'CROSBY');
INSERT INTO Manufacturers (ManufacturerName) VALUES (N'Rieker');
INSERT INTO Suppliers (SupplierName) VALUES (N'Kari');
INSERT INTO Suppliers (SupplierName) VALUES (N'Обувь для вас');
INSERT INTO Units (UnitName) VALUES (N'шт.');
INSERT INTO OrderStatuses (StatusName) VALUES (N'Новый'),(N'В обработке'),(N'Готов к выдаче'),(N'Завершен'),(N'Отменен');
INSERT INTO PickupPoints (Address) VALUES (N'420151, г. Лесной, ул. Вишневая, 32');
INSERT INTO PickupPoints (Address) VALUES (N'125061, г. Лесной, ул. Подгорная, 8');
INSERT INTO PickupPoints (Address) VALUES (N'630370, г. Лесной, ул. Шоссейная, 24');
INSERT INTO PickupPoints (Address) VALUES (N'400562, г. Лесной, ул. Зеленая, 32');
INSERT INTO PickupPoints (Address) VALUES (N'614510, г. Лесной, ул. Маяковского, 47');
INSERT INTO PickupPoints (Address) VALUES (N'410542, г. Лесной, ул. Светлая, 46');
INSERT INTO PickupPoints (Address) VALUES (N'620839, г. Лесной, ул. Цветочная, 8');
INSERT INTO PickupPoints (Address) VALUES (N'443890, г. Лесной, ул. Коммунистическая, 1');
INSERT INTO PickupPoints (Address) VALUES (N'603379, г. Лесной, ул. Спортивная, 46');
INSERT INTO PickupPoints (Address) VALUES (N'603721, г. Лесной, ул. Гоголя, 41');
INSERT INTO PickupPoints (Address) VALUES (N'410172, г. Лесной, ул. Северная, 13');
INSERT INTO PickupPoints (Address) VALUES (N'614611, г. Лесной, ул. Молодежная, 50');
INSERT INTO PickupPoints (Address) VALUES (N'454311, г.Лесной, ул. Новая, 19');
INSERT INTO PickupPoints (Address) VALUES (N'660007, г.Лесной, ул. Октябрьская, 19');
INSERT INTO PickupPoints (Address) VALUES (N'603036, г. Лесной, ул. Садовая, 4');
INSERT INTO PickupPoints (Address) VALUES (N'394060, г.Лесной, ул. Фрунзе, 43');
INSERT INTO PickupPoints (Address) VALUES (N'410661, г. Лесной, ул. Школьная, 50');
INSERT INTO PickupPoints (Address) VALUES (N'625590, г. Лесной, ул. Коммунистическая, 20');
INSERT INTO PickupPoints (Address) VALUES (N'625683, г. Лесной, ул. 8 Марта');
INSERT INTO PickupPoints (Address) VALUES (N'450983, г.Лесной, ул. Комсомольская, 26');
INSERT INTO PickupPoints (Address) VALUES (N'394782, г. Лесной, ул. Чехова, 3');
INSERT INTO PickupPoints (Address) VALUES (N'603002, г. Лесной, ул. Дзержинского, 28');
INSERT INTO PickupPoints (Address) VALUES (N'450558, г. Лесной, ул. Набережная, 30');
INSERT INTO PickupPoints (Address) VALUES (N'344288, г. Лесной, ул. Чехова, 1');
INSERT INTO PickupPoints (Address) VALUES (N'614164, г.Лесной,  ул. Степная, 30');
INSERT INTO PickupPoints (Address) VALUES (N'394242, г. Лесной, ул. Коммунистическая, 43');
INSERT INTO PickupPoints (Address) VALUES (N'660540, г. Лесной, ул. Солнечная, 25');
INSERT INTO PickupPoints (Address) VALUES (N'125837, г. Лесной, ул. Шоссейная, 40');
INSERT INTO PickupPoints (Address) VALUES (N'125703, г. Лесной, ул. Партизанская, 49');
INSERT INTO PickupPoints (Address) VALUES (N'625283, г. Лесной, ул. Победы, 46');
INSERT INTO PickupPoints (Address) VALUES (N'614753, г. Лесной, ул. Полевая, 35');
INSERT INTO PickupPoints (Address) VALUES (N'426030, г. Лесной, ул. Маяковского, 44');
INSERT INTO PickupPoints (Address) VALUES (N'450375, г. Лесной ул. Клубная, 44');
INSERT INTO PickupPoints (Address) VALUES (N'625560, г. Лесной, ул. Некрасова, 12');
INSERT INTO PickupPoints (Address) VALUES (N'630201, г. Лесной, ул. Комсомольская, 17');
INSERT INTO PickupPoints (Address) VALUES (N'190949, г. Лесной, ул. Мичурина, 26');

-- Пользователи (логин = email из импорта)
INSERT INTO Users (Login, Password, FullName, RoleId) VALUES (N'94d5ous@gmail.com', N'uzWC67', N'Никифорова Весения Николаевна', (SELECT RoleId FROM Roles WHERE RoleName=N'Администратор'));
INSERT INTO Users (Login, Password, FullName, RoleId) VALUES (N'uth4iz@mail.com', N'2L6KZG', N'Сазонов Руслан Германович', (SELECT RoleId FROM Roles WHERE RoleName=N'Администратор'));
INSERT INTO Users (Login, Password, FullName, RoleId) VALUES (N'yzls62@outlook.com', N'JlFRCZ', N'Одинцов Серафим Артёмович', (SELECT RoleId FROM Roles WHERE RoleName=N'Администратор'));
INSERT INTO Users (Login, Password, FullName, RoleId) VALUES (N'1diph5e@tutanota.com', N'8ntwUp', N'Степанов Михаил Артёмович', (SELECT RoleId FROM Roles WHERE RoleName=N'Менеджер'));
INSERT INTO Users (Login, Password, FullName, RoleId) VALUES (N'tjde7c@yahoo.com', N'YOyhfR', N'Ворсин Петр Евгеньевич', (SELECT RoleId FROM Roles WHERE RoleName=N'Менеджер'));
INSERT INTO Users (Login, Password, FullName, RoleId) VALUES (N'wpmrc3do@tutanota.com', N'RSbvHv', N'Старикова Елена Павловна', (SELECT RoleId FROM Roles WHERE RoleName=N'Менеджер'));
INSERT INTO Users (Login, Password, FullName, RoleId) VALUES (N'5d4zbu@tutanota.com', N'rwVDh9', N'Михайлюк Анна Вячеславовна', (SELECT RoleId FROM Roles WHERE RoleName=N'Авторизированный клиент'));
INSERT INTO Users (Login, Password, FullName, RoleId) VALUES (N'ptec8ym@yahoo.com', N'LdNyos', N'Ситдикова Елена Анатольевна', (SELECT RoleId FROM Roles WHERE RoleName=N'Авторизированный клиент'));
INSERT INTO Users (Login, Password, FullName, RoleId) VALUES (N'1qz4kw@mail.com', N'gynQMT', N'Ворсин Петр Евгеньевич', (SELECT RoleId FROM Roles WHERE RoleName=N'Авторизированный клиент'));
INSERT INTO Users (Login, Password, FullName, RoleId) VALUES (N'4np6se@mail.com', N'AtnDjr', N'Старикова Елена Павловна', (SELECT RoleId FROM Roles WHERE RoleName=N'Авторизированный клиент'));

-- Товары
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'А112Т4', N'Ботинки', N'Женские Ботинки демисезонные kari', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Kari'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 4990, 6, 3, N'Images\1.jpg');
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'F635R4', N'Ботинки', N'Ботинки Marco Tozzi женские демисезонные, размер 39, цвет бежевый', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Marco Tozzi'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 3244, 13, 2, N'Images\2.jpg');
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'H782T5', N'Туфли', N'Туфли kari мужские классика MYZ21AW-450A, размер 43, цвет: черный', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Kari'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 4499, 5, 4, N'Images\3.jpg');
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'G783F5', N'Ботинки', N'Мужские ботинки Рос-Обувь кожаные с натуральным мехом', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Рос'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 5900, 8, 2, N'Images\4.jpg');
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'J384T6', N'Ботинки', N'B3430/14 Полуботинки мужские Rieker', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Rieker'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 3800, 16, 2, N'Images\5.jpg');
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'D572U8', N'Кроссовки', N'129615-4 Кроссовки мужские', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Рос'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 4100, 6, 3, N'Images\6.jpg');
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'F572H7', N'Туфли', N'Туфли Marco Tozzi женские летние, размер 39, цвет черный', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Marco Tozzi'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 2700, 14, 2, N'Images\7.jpg');
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'D329H3', N'Полуботинки', N'Полуботинки Alessio Nesca женские 3-30797-47, размер 37, цвет: бордовый', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Alessio Nesca'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 1890, 4, 4, N'Images\8.jpg');
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'B320R5', N'Туфли', N'Туфли Rieker женские демисезонные, размер 41, цвет коричневый', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Rieker'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 4300, 6, 2, N'Images\9.jpg');
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'G432E4', N'Туфли', N'Туфли kari женские TR-YR-413017, размер 37, цвет: черный', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Kari'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 2800, 15, 3, N'Images\10.jpg');
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'S213E3', N'Полуботинки', N'407700/01-01 Полуботинки мужские CROSBY', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'CROSBY'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 2156, 6, 3, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'E482R4', N'Полуботинки', N'Полуботинки kari женские MYZ20S-149, размер 41, цвет: черный', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Kari'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 1800, 14, 2, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'S634B5', N'Кеды', N'Кеды Caprice мужские демисезонные, размер 42, цвет черный', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'CROSBY'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 5500, 0, 3, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'K345R4', N'Полуботинки', N'407700/01-02 Полуботинки мужские CROSBY', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'CROSBY'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 2100, 3, 2, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'O754F4', N'Туфли', N'Туфли женские демисезонные Rieker артикул 55073-68/37', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Rieker'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 5400, 18, 4, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'G531F4', N'Ботинки', N'Ботинки женские зимние ROMER арт. 893167-01 Черный', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Kari'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 6600, 9, 12, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'J542F5', N'Тапочки', N'Тапочки мужские Арт.70701-55-67син р.41', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Kari'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 500, 0, 13, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'B431R5', N'Ботинки', N'Мужские кожаные ботинки/мужские ботинки', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Rieker'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 2700, 5, 2, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'P764G4', N'Туфли', N'Туфли женские, ARGO, размер 38', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'CROSBY'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 6800, 15, 15, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'C436G5', N'Ботинки', N'Ботинки женские, ARGO, размер 40', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Alessio Nesca'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 10200, 9, 15, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'F427R5', N'Ботинки', N'Ботинки на молнии с декоративной пряжкой FRAU', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Rieker'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 11800, 11, 15, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'N457T5', N'Полуботинки', N'Полуботинки Ботинки черные зимние, мех', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'CROSBY'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 4600, 13, 3, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'D364R4', N'Туфли', N'Туфли Luiza Belly женские Kate-lazo черные из натуральной замши', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Kari'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 12400, 5, 16, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'S326R5', N'Тапочки', N'Мужские кожаные тапочки "Профиль С.Дали" ', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'CROSBY'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 9900, 15, 17, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'L754R4', N'Полуботинки', N'Полуботинки kari женские WB2020SS-26, размер 38, цвет: черный', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Kari'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 1700, 7, 2, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'M542T5', N'Кроссовки', N'Кроссовки мужские TOFA', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Rieker'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 2800, 3, 18, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'D268G5', N'Туфли', N'Туфли Rieker женские демисезонные, размер 36, цвет коричневый', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Rieker'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 4399, 12, 3, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'T324F5', N'Сапоги', N'Сапоги замша Цвет: синий', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'CROSBY'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 4699, 5, 2, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'K358H6', N'Тапочки', N'Тапочки мужские син р.41', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Мужская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Rieker'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Kari'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 599, 2, 20, NULL);
INSERT INTO Products (ProductCode, ProductName, Description, CategoryId, ManufacturerId, SupplierId, UnitId, Price, Quantity, Discount, ImagePath) VALUES (N'H535R5', N'Ботинки', N'Женские Ботинки демисезонные', (SELECT CategoryId FROM Categories WHERE CategoryName=N'Женская обувь'), (SELECT ManufacturerId FROM Manufacturers WHERE ManufacturerName=N'Rieker'), (SELECT SupplierId FROM Suppliers WHERE SupplierName=N'Обувь для вас'), (SELECT UnitId FROM Units WHERE UnitName=N'шт.'), 2300, 7, 2, NULL);

-- Заказы
INSERT INTO Orders (OrderCode, StatusId, PickupPointId, OrderDate, DeliveryDate, UserId) VALUES (N'901', (SELECT StatusId FROM OrderStatuses WHERE StatusName=N'Завершен'), 1, '2025-02-27', '2025-04-20', (SELECT UserId FROM Users WHERE FullName=N'Степанов Михаил Артёмович'));
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'901'), (SELECT ProductId FROM Products WHERE ProductCode=N'А112Т4'), 2);
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'901'), (SELECT ProductId FROM Products WHERE ProductCode=N'F635R4'), 2);
INSERT INTO Orders (OrderCode, StatusId, PickupPointId, OrderDate, DeliveryDate, UserId) VALUES (N'902', (SELECT StatusId FROM OrderStatuses WHERE StatusName=N'Завершен'), 11, '2022-09-28', '2025-04-21', (SELECT UserId FROM Users WHERE FullName=N'Никифорова Весения Николаевна'));
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'902'), (SELECT ProductId FROM Products WHERE ProductCode=N'H782T5'), 1);
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'902'), (SELECT ProductId FROM Products WHERE ProductCode=N'G783F5'), 1);
INSERT INTO Orders (OrderCode, StatusId, PickupPointId, OrderDate, DeliveryDate, UserId) VALUES (N'903', (SELECT StatusId FROM OrderStatuses WHERE StatusName=N'Завершен'), 2, '2025-03-21', '2025-04-22', (SELECT UserId FROM Users WHERE FullName=N'Сазонов Руслан Германович'));
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'903'), (SELECT ProductId FROM Products WHERE ProductCode=N'J384T6'), 10);
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'903'), (SELECT ProductId FROM Products WHERE ProductCode=N'D572U8'), 10);
INSERT INTO Orders (OrderCode, StatusId, PickupPointId, OrderDate, DeliveryDate, UserId) VALUES (N'904', (SELECT StatusId FROM OrderStatuses WHERE StatusName=N'Завершен'), 11, '2025-02-20', '2025-04-23', (SELECT UserId FROM Users WHERE FullName=N'Одинцов Серафим Артёмович'));
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'904'), (SELECT ProductId FROM Products WHERE ProductCode=N'F572H7'), 5);
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'904'), (SELECT ProductId FROM Products WHERE ProductCode=N'D329H3'), 4);
INSERT INTO Orders (OrderCode, StatusId, PickupPointId, OrderDate, DeliveryDate, UserId) VALUES (N'905', (SELECT StatusId FROM OrderStatuses WHERE StatusName=N'Завершен'), 2, '2025-03-17', '2025-04-24', (SELECT UserId FROM Users WHERE FullName=N'Степанов Михаил Артёмович'));
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'905'), (SELECT ProductId FROM Products WHERE ProductCode=N'А112Т4'), 2);
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'905'), (SELECT ProductId FROM Products WHERE ProductCode=N'F635R4'), 2);
INSERT INTO Orders (OrderCode, StatusId, PickupPointId, OrderDate, DeliveryDate, UserId) VALUES (N'906', (SELECT StatusId FROM OrderStatuses WHERE StatusName=N'Завершен'), 15, '2025-03-01', '2025-04-25', (SELECT UserId FROM Users WHERE FullName=N'Никифорова Весения Николаевна'));
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'906'), (SELECT ProductId FROM Products WHERE ProductCode=N'H782T5'), 1);
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'906'), (SELECT ProductId FROM Products WHERE ProductCode=N'G783F5'), 1);
INSERT INTO Orders (OrderCode, StatusId, PickupPointId, OrderDate, DeliveryDate, UserId) VALUES (N'907', (SELECT StatusId FROM OrderStatuses WHERE StatusName=N'Завершен'), 3, NULL, '2025-04-26', (SELECT UserId FROM Users WHERE FullName=N'Сазонов Руслан Германович'));
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'907'), (SELECT ProductId FROM Products WHERE ProductCode=N'J384T6'), 10);
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'907'), (SELECT ProductId FROM Products WHERE ProductCode=N'D572U8'), 10);
INSERT INTO Orders (OrderCode, StatusId, PickupPointId, OrderDate, DeliveryDate, UserId) VALUES (N'908', (SELECT StatusId FROM OrderStatuses WHERE StatusName=N'Новый'), 19, '2025-03-31', '2025-04-27', (SELECT UserId FROM Users WHERE FullName=N'Одинцов Серафим Артёмович'));
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'908'), (SELECT ProductId FROM Products WHERE ProductCode=N'F572H7'), 5);
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'908'), (SELECT ProductId FROM Products WHERE ProductCode=N'D329H3'), 4);
INSERT INTO Orders (OrderCode, StatusId, PickupPointId, OrderDate, DeliveryDate, UserId) VALUES (N'909', (SELECT StatusId FROM OrderStatuses WHERE StatusName=N'Новый'), 5, '2025-04-02', '2025-04-28', (SELECT UserId FROM Users WHERE FullName=N'Степанов Михаил Артёмович'));
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'909'), (SELECT ProductId FROM Products WHERE ProductCode=N'B320R5'), 5);
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'909'), (SELECT ProductId FROM Products WHERE ProductCode=N'G432E4'), 1);
INSERT INTO Orders (OrderCode, StatusId, PickupPointId, OrderDate, DeliveryDate, UserId) VALUES (N'910', (SELECT StatusId FROM OrderStatuses WHERE StatusName=N'Новый'), 19, '2025-04-03', '2025-04-29', (SELECT UserId FROM Users WHERE FullName=N'Степанов Михаил Артёмович'));
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'910'), (SELECT ProductId FROM Products WHERE ProductCode=N'S213E3'), 5);
INSERT INTO OrderItems (OrderId, ProductId, Quantity) VALUES ((SELECT OrderId FROM Orders WHERE OrderCode=N'910'), (SELECT ProductId FROM Products WHERE ProductCode=N'E482R4'), 5);

GO
PRINT N'База данных ShopDB успешно создана.';
GO