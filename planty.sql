-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 19, 2022 at 05:24 PM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ecommerce`
--
create database ecommerce;
-- --------------------------------------------------------
use ecommerce;
--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `CateId` int(255) NOT NULL,
  `CateName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`CateId`, `CateName`) VALUES
(1, 'Hoa');

-- --------------------------------------------------------

--
-- Table structure for table `favoriteproduct`
--

CREATE TABLE `favoriteproduct` (
  `UserID` int(255) NOT NULL,
  `ProductID` int(255) NOT NULL,
  `AddOn` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `favoriteproduct`
--

INSERT INTO `favoriteproduct` (`UserID`, `ProductID`, `AddOn`) VALUES
(2, 4, '2022-12-19');

--
-- Triggers `favoriteproduct`
--
DELIMITER $$
CREATE TRIGGER `AutoUpdateAddOn` BEFORE INSERT ON `favoriteproduct` FOR EACH ROW BEGIN
SET New.AddOn = CURRENT_DATE;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `invoice`
--

CREATE TABLE `invoice` (
  `PackID` int(255) NOT NULL,
  `IsPaid` tinyint(1) NOT NULL DEFAULT 0,
  `TotalPrice` float NOT NULL DEFAULT 0,
  `CreatedOn` date DEFAULT NULL,
  `PaidOn` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `invoice`
--

INSERT INTO `invoice` (`PackID`, `IsPaid`, `TotalPrice`, `CreatedOn`, `PaidOn`) VALUES
(1, 0, 190, '2022-12-19', NULL);

--
-- Triggers `invoice`
--
DELIMITER $$
CREATE TRIGGER `AutoUpdateCreatedOnInInvoice` BEFORE INSERT ON `invoice` FOR EACH ROW BEGIN
SET New.CreatedOn = CURRENT_DATE;

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `invoicedetail`
--

CREATE TABLE `invoicedetail` (
  `ProId` int(255) NOT NULL,
  `PackID` int(255) NOT NULL,
  `Quantity` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `invoicedetail`
--

INSERT INTO `invoicedetail` (`ProId`, `PackID`, `Quantity`) VALUES
(3, 1, 5),
(4, 1, 6),
(5, 1, 7);

--
-- Triggers `invoicedetail`
--
DELIMITER $$
CREATE TRIGGER `AutoUpdateTotalPrice` AFTER INSERT ON `invoicedetail` FOR EACH ROW BEGIN
DECLARE tp float DEFAULT 0.0;

select sum(P.Price * I.Quantity) INTO tp from Products P JOIN InvoiceDetail I ON P.ProductID = I.ProID where I.PackID = New.PackID;
                                    
UPDATE invoice
SET TotalPrice = tp
WHERE PackID = New.PackID;

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `Price` float NOT NULL DEFAULT 0,
  `ProductID` int(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL DEFAULT ' ',
  `StarNumber` int(255) NOT NULL DEFAULT 0,
  `Image` blob DEFAULT NULL,
  `Quantity` int(255) NOT NULL DEFAULT 0,
  `CateId` int(255) NOT NULL DEFAULT 0,
  `CreatedOn` date DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  `Status` int(255) NOT NULL DEFAULT 0,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`Price`, `ProductID`, `Name`, `Description`, `StarNumber`, `Image`, `Quantity`, `CateId`, `CreatedOn`, `UpdatedOn`, `Status`, `IsDeleted`) VALUES
(12, 3, 'Hoa cảnh', ' Hoa cảnh đẹp rẻ', 4, NULL, 100, 1, '2022-12-19', '2022-12-19', 0, 0),
(10, 4, 'Hoa cảnh 2', ' Hoa cảnh đẹp rẻ nè', 0, NULL, 100, 1, '2022-12-19', NULL, 0, 0),
(10, 5, 'Hoa cảnh 3', ' Hoa cảnh đẹp rẻ 3', 0, NULL, 100, 1, '2022-12-19', NULL, 0, 0);

--
-- Triggers `products`
--
DELIMITER $$
CREATE TRIGGER `AutoUpdateCreatedOnInProduct` BEFORE INSERT ON `products` FOR EACH ROW BEGIN
SET New.CreatedOn = CURRENT_DATE;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `AutoUpdateUpdatedOnInProduct` BEFORE UPDATE ON `products` FOR EACH ROW BEGIN
SET New.UpdatedOn = CURRENT_DATE;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `review`
--

CREATE TABLE `review` (
  `ProId` int(255) NOT NULL,
  `Reviewer` int(255) NOT NULL,
  `Content` varchar(255) NOT NULL,
  `Star` int(255) NOT NULL,
  `DateReview` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `review`
--

INSERT INTO `review` (`ProId`, `Reviewer`, `Content`, `Star`, `DateReview`) VALUES
(3, 1, 'Hoa đẹp lắm', 5, '2022-12-19'),
(3, 2, 'Hoa đẹp lắm', 5, '2022-12-19'),
(3, 3, 'Hoa đẹp lắm', 4, '2022-12-19'),
(3, 4, 'Hoa đẹp lắm', 1, '2022-12-19');

--
-- Triggers `review`
--
DELIMITER $$
CREATE TRIGGER `AutoUpdateProductStar` AFTER INSERT ON `review` FOR EACH ROW BEGIN

DECLARE a int DEFAULT 0;

set a = ( SELECT avg(Star)
FROM review
WHERE ProId = New.ProId);

UPDATE products
SET StarNumber = a
WHERE ProductID = New.ProId;

END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `UpdateDateReview` BEFORE INSERT ON `review` FOR EACH ROW BEGIN

SET New.DateReview = CURRENT_DATE;

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(255) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Avt` blob DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Phone` varchar(255) NOT NULL,
  `Firstname` varchar(255) NOT NULL,
  `Lastname` varchar(255) NOT NULL,
  `DateOfBirth` date DEFAULT NULL,
  `Registrationdate` date DEFAULT NULL,
  `UpdatedOn` date DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `IsBan` tinyint(1) NOT NULL DEFAULT 0,
  `IsAdmin` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `Username`, `Password`, `Avt`, `Address`, `Email`, `Phone`, `Firstname`, `Lastname`, `DateOfBirth`, `Registrationdate`, `UpdatedOn`, `IsDeleted`, `IsBan`, `IsAdmin`) VALUES
(1, 'Phtuan', '12345', NULL, NULL, NULL, '0123456789', 'Pham', 'Tuan', NULL, '2022-12-19', '0000-00-00', 0, 0, 1),
(2, 'Phtuan', '12345', NULL, NULL, NULL, '0123456789', 'Pham', 'Tuan', NULL, '2022-12-19', '0000-00-00', 0, 0, 1),
(3, 'Wednes', '12345', NULL, NULL, NULL, '0129384', 'Wed', 'Day', NULL, '2022-12-19', NULL, 0, 0, 1),
(4, 'Tue', '12345', NULL, NULL, NULL, '01223957', 'Tue', 'day', NULL, '2022-12-19', NULL, 0, 0, 1);

--
-- Triggers `users`
--
DELIMITER $$
CREATE TRIGGER `AutoUpdateRegistrationdateInUser` BEFORE INSERT ON `users` FOR EACH ROW BEGIN
SET New.Registrationdate = CURRENT_DATE;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `AutoUpdateUpdatedOnInUser` BEFORE UPDATE ON `users` FOR EACH ROW BEGIN
SET New.UpdatedOn = CURRENT_DATE;
END
$$
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`CateId`);

--
-- Indexes for table `favoriteproduct`
--
ALTER TABLE `favoriteproduct`
  ADD PRIMARY KEY (`UserID`,`ProductID`),
  ADD KEY `KhoaNgoaiFavoriteVaProduct` (`ProductID`);

--
-- Indexes for table `invoice`
--
ALTER TABLE `invoice`
  ADD PRIMARY KEY (`PackID`);

--
-- Indexes for table `invoicedetail`
--
ALTER TABLE `invoicedetail`
  ADD PRIMARY KEY (`ProId`,`PackID`),
  ADD KEY `KhoaNgoaiInvoiceVaDetail` (`PackID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ProductID`),
  ADD KEY `KhoaNgoaiProductVaCate` (`CateId`);

--
-- Indexes for table `review`
--
ALTER TABLE `review`
  ADD PRIMARY KEY (`ProId`,`Reviewer`),
  ADD KEY `KhoaNgoaiReviewerVaUser` (`Reviewer`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `CateId` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `invoice`
--
ALTER TABLE `invoice`
  MODIFY `PackID` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `ProductID` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `favoriteproduct`
--
ALTER TABLE `favoriteproduct`
  ADD CONSTRAINT `KhoaNgoaiFavoriteVaProduct` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`),
  ADD CONSTRAINT `KhoaNgoaiFavoriteVaUser` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `invoicedetail`
--
ALTER TABLE `invoicedetail`
  ADD CONSTRAINT `KhoaNgoaiInvoiceVaDetail` FOREIGN KEY (`PackID`) REFERENCES `invoice` (`PackID`),
  ADD CONSTRAINT `KhoaNgoaiInvoiceVaProduct` FOREIGN KEY (`ProId`) REFERENCES `products` (`ProductID`);

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `KhoaNgoaiProductVaCate` FOREIGN KEY (`CateId`) REFERENCES `category` (`CateId`);

--
-- Constraints for table `review`
--
ALTER TABLE `review`
  ADD CONSTRAINT `KhoaNgoaiRevieweVaProduct` FOREIGN KEY (`ProId`) REFERENCES `products` (`ProductID`),
  ADD CONSTRAINT `KhoaNgoaiReviewerVaUser` FOREIGN KEY (`Reviewer`) REFERENCES `users` (`UserID`);
COMMIT;

use ecommerce;
select * from category;
select * from users;
select * from products;
select * from invoice;
select * from invoicedetail;
select * from favoriteproduct;
select * from review;

select count(productId) from products;
show triggers;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

/*Category*/
insert into `category` values (1, 'Small type');
insert into `category` values (2, 'Large type');
select * from products;

/* Loại nhỏ */
insert into () `products` values (225000, 1,'CÂY ĐỂ BÀN - HAPPY DAY 21','Thay vì tìm kiếm người đặc biệt và dành thời phần lớn thời gian ở bên cạnh họ thì bạn hãy tự trở thành người đặc biệt của chính mình!', 4 , 'https://locat.com.vn/hinh-hoa-tuoi/cay-de-ban/7462_happy-day-21.jpg', 20, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (420000, 2,'CÂY KHUYẾN MÃI - DARLING', 'Tiểu cảnh mini với những khu vườn, cỏ cây hoa lá, ngôi nhà và muôn thú,...', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/cay-khuyen-mai/10061_darling.jpg', 10, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (310000, 3,'CÂY THỦY SINH - TS LAN Ý', 'Người ta hay gọi cây là Huệ “Hòa Bình” cũng là vì vậy. Ngoài ra, loài cây này lại mang đến may mắn, tiền tài và đặc biệt hơn là thanh lọc không khí cực kì tốt.', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/cay-thuy-sinh/10252_ts-lan-y.jpg', 10, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (220000, 4,'CÂY ĐỂ BÀN - THỌ TỈ NAM SƠN', 'Sen đá có ý nghĩa rất đặc biệt đó là sự che chở và đùm bọc. Khi tặng nó cho ai có nghĩa là cầu chúc sự may mắn đến với họ và mong muốn mối quan hệ giữa hai người bền chặt, lâu dài.', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/cay-de-ban/11052_tho-ti-nam-son.jpg', 45, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (280000, 5,'CÂY ĐỂ BÀN - AN KHANG THỊNH VƯỢNG', 'Sản phẩm chậu cây để bàn cây Kim Ngân giúp thúc đẩy tài vận thăng tiến mạnh mẽ.', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/cay-de-ban/11165_an-khang-thinh-vuong.jpg', 15, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (420000, 6,'CÂY ĐỂ BÀN - HỒNG MÔN CÁT TƯỜNG', 'Trong phong thủy, Cây hồng môn hoa đỏ cực kì phù hợp với người mạng Hỏa. Vì vậy người mệnh này nếu trồng Cây Hồng Môn trong nhà hoặc đặt trên bàn làm việc sẽ mang đến rất nhiều may mắn, thuận lợi và tiền tài cho gia chủ.', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/cay-de-ban/11738_hong-mon-cat-tuong.jpg', 6, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (350000, 7,'CÂY ĐỂ BÀN - ĐẠI PHÚC', 'Cây Lan Ý còn có tên gọi khác là cây Huệ Hòa Bình nên đây là loại cây mang đến ý nghĩa phong thủy về sự yên ấm, hòa thuận trong gia đình cũng như tránh được những xung đột, cãi vã ngoài cuộc sống.', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/cay-de-ban/11065_dai-phuc.jpg', 16, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (420000, 8,'CÂY ĐỂ BÀN - ĐẠI CÁT', 'Cây kim ngân 1 thân hay kim ngân chân voi có dáng gọi là “Trụ Thiên”, tức là chọc trời, mang ý nghĩa kiên cường, bất khuất.', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/cay-de-ban/11062_dai-cat.jpg', 84, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (825000, 9,'LAN HỒ ĐIỆP - LAN HỒ ĐIỆP XUÂN MẪU 11', 'Lan hồ điệp mẫu thứ 11.', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/lan-ho-diep/12706_lan-ho-diep-xuan-mau-11.jpg', 3, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (5450000, 10,'LAN HỒ ĐIỆP - CHẬU HỒ ĐIỆP TÍM 18 CÀNH', '18 cành hồ điệp tím', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/lan-ho-diep/13974_chau-ho-diep-tim-18-canh.jpg', 2, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (310000, 11,'XƯƠNG RỒNG - SEN ĐÁ - LITTLE SUCCULENTS', 'Tiểu cảnh mini với những khu vườn, cỏ cây hoa lá, ngôi nhà và muôn thú,...ngày nay đã trở thành sản phẩm trang trí được yêu chuộng vì điểm nổi bật, thu hút và mang hiều tác dụng tốt cho người trồng.', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/xuong-rong-sen-da/11736_little-succulents.jpg', 27, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (390000, 12,'CÂY THỦY SINH - HỒNG MÔN THỦY SINH', 'Trồng cây thủy sinh không chỉ giúp cho không gian sống của bạn trở nên tươi mới và sang trọng hơn mà còn giúp mang lại tài lộc, may mắn theo phong thủy. Đây là xu hướng ngày càng được nhiều người yêu thích', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/cay-thuy-sinh/13420_hong-mon-thuy-sinh.jpg', 50, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (290000, 13,'CÂY KHUYẾN MÃI - JOYFUL', 'Tiểu cảnh mini như một khu vườn thu nhỏ bao gồm sự kết hợp của nhiều loại cây với phụ kiện trang trí đa dạng, nổi bật dưới bàn tay của những người trồng đầy sức sáng tạo.', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/cay-khuyen-mai/10055_joyful.jpg', 47, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (195000, 14,'CÂY TÌNH YÊU - FITTONIA XANH GỖ NGHIÊNG', ' Lá May Mắn Fittonia xanh, chậu gỗ nghiêng mini 8cm', 5 , 'https://locat.com.vn/hinh-hoa-tuoi/cay-tinh-yeu/13413_fittonia-xanh-go-nghieng.jpg', 27, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (420000, 15,'CÂY TÌNH YÊU - HAPPINESS','Tiểu cảnh mini với những khu vườn, cỏ cây hoa lá, ngôi nhà và muôn thú,...ngày nay đã trở thành sản phẩm trang trí được yêu chuộng vì điểm nổi bật, thu hút và mang hiều tác dụng tốt cho người trồng.', 5,'https://locat.com.vn/hinh-hoa-tuoi/cay-tinh-yeu/10053_happiness.jpg', 62, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (550000, 16,'TIỂU CẢNH - KHU RỪNG NHỎ','Tiểu cảnh mini trong bình thủy tinh với những khung cảnh như trong chuyện cổ tích với khu vườn, cỏ cây hoa lá, ngôi nhà, sông suối và muôn thú,...', 5,'https://locat.com.vn/hinh-hoa-tuoi/tieu-canh/11239_khu-rung-nho.jpg', 22, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (300000, 17,'TIỂU CẢNH - NATURE AND LIFE','Tiểu cảnh mini như một khu vườn thu nhỏ bao gồm sự kết hợp của nhiều loại cây với phụ kiện trang trí đa dạng, nổi bật dưới bàn tay của những người trồng đầy sức sáng tạo.',5, 'https://locat.com.vn/hinh-hoa-tuoi/tieu-canh/8966_nature-and-life.jpg', 41, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (300000, 18,'TIỂU CẢNH - HAPPY DAY 5','Thay vì tìm kiếm người đặc biệt và dành thời phần lớn thời gian ở bên cạnh họ thì bạn hãy tự trở thành người đặc biệt của chính mình!',5, 'https://locat.com.vn/hinh-hoa-tuoi/tieu-canh/12750_happy-day-5.jpg', 33, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (6000000, 19,'LAN HỒ ĐIỆP - CHẬU HỒ ĐIỆP TÍM 20 CÀNH','20 cành hồ điệp tím',5, 'https://locat.com.vn/hinh-hoa-tuoi/lan-ho-diep/13973_chau-ho-diep-tim-20-canh.jpg', 7, 1, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (250000, 20,'CÂY ĐỂ BÀN - KIM PHÁT TÀI','Cây Kim Tiền là một trong những loại cây phong thủy biểu tượng của sự giàu sang và đẳng cấp khác biệt.',4, 'https://locat.com.vn/hinh-hoa-tuoi/cay-de-ban/11056_kim-phat-tai.jpg', 77, 1, '2022-12-26', '2022-12-26',1,0);

/*Large Type */ 
insert into `products` values (500000, 21,'CÂY VĂN PHÒNG - CÂY LAN TUYẾT','Cây Lan Tuyết (Cây giữ tiền)',5, 'https://locat.com.vn/hinh-hoa-tuoi/cay-van-phong/13432_cay-lan-tuyet.jpg', 14, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (1300000, 22,'CÂY VĂN PHÒNG - KIM NGÂN ĐẠI','Chiều cao chậu và cây: 70cm ',5, 'https://locat.com.vn/hinh-hoa-tuoi/cay-van-phong/10192_kim-ngan-dai.jpg', 11, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (1400000, 23,'CÂY VĂN PHÒNG - CHẬU CÂY VĂN PHÒNG MIX 2','Cây Ngọc Ngân, cây vạn lộc, trầu bà vàng, lưỡi hổ thái, chiều cao chậu và cây: 95 cm ',5, 'https://locat.com.vn/hinh-hoa-tuoi/cay-van-phong/11085_chau-cay-van-phong-mix-2.jpg', 8, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (950000, 24,'CÂY VĂN PHÒNG - ĐẠI PHÚ GIA','Cây đại phú gia có nguồn gốc từ các nước Đông Á. Mang ý nghĩa phong thủy là đem lại tiền tài, may mắn cho gia chủ.',5, 'https://locat.com.vn/hinh-hoa-tuoi/cay-van-phong/10868_dai-phu-gia.jpg', 18, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (550000, 25,'CÂY VĂN PHÒNG - TRẦU BÀ TỶ PHÚ MST22','Trầu bà tỷ phú có tên tiếng anh là Philodendron Burle Marx được đặt theo tên của vị kiến trúc sư Roberto Burle Marx',5, 'https://locat.com.vn/hinh-hoa-tuoi/cay-van-phong/13565_trau-ba-ty-phu-mst22.jpg', 23, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (770000, 26,'CÂY VĂN PHÒNG - HỒNG MÔN VP MST22','Nếu trồng Cây Hồng Môn trong nhà hoặc đặt trên bàn làm việc sẽ mang đến rất nhiều may mắn, thuận lợi và tiền tài cho gia chủ.',5, 'https://locat.com.vn/hinh-hoa-tuoi/cay-van-phong/8150_hong-mon-vp-mst22.jpg', 17, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (750000, 27,'CÂY VĂN PHÒNG - VẠN LỘC VĂN PHÒNG','Nếu trồng Cây Hồng Môn trong nhà hoặc đặt trên bàn làm việc sẽ mang đến rất nhiều may mắn, thuận lợi và tiền tài cho gia chủ.',4, 'https://locat.com.vn/hinh-hoa-tuoi/cay-van-phong/13433_van-loc-van-phong.jpg', 7, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (825000, 28,'LAN HỒ ĐIỆP - LỘC TRỜI','Chậu lan được thiết kế bởi 3 cành lan vàng, tạo cho người ngắm nhín cảm giác nhẹ dịu, ấm ấp như ánh nắng ban mai, và cũng như lời cầu chúc ấm no, thịnh vượng cho gia đình.',5, 'https://locat.com.vn/hinh-hoa-tuoi/lan-ho-diep/9415_loc-troi.jpg', 4, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (1960000, 29,'CÂY BÀNG SINGAPORE - BÀNG SINGAPORE CPS','Trang trí bàng Singapore trong nhà sẽ tạo không khí làm việc hòa thuận, vui vẻ hơn. Trong phong thủy sẽ giúp tài chính của gia chủ ngày càng dồi dào, vững vàng.', 5,'https://locat.com.vn/hinh-hoa-tuoi/cay-bang-singapore/11774_bang-singapore-cps.jpg', 2, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (1960000, 30,'CHẬU CÂY THÔNG MINH - NGỌC NGÂN CPS','Cây Ngọc Ngân hay còn có tên là cây Valentine, trong tình cảm nó được đại diện cho tình yêu, nó sẽ là một món quà ý nghĩa đối với các cặp đôi.',5, 'https://locat.com.vn/hinh-hoa-tuoi/chau-cay-thong-minh/11777_ngoc-ngan-cps.jpg', 3, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (2400000, 31,'CHẬU CÂY THÔNG MINH - MÃ ĐÁO THÀNH CÔNG','Chậu cây Mã Đáo Thành Công là cây Bạch Mã Hoàng Tử được trồng trong chậu Composite màu xám ghi mờ.',5, 'https://locat.com.vn/hinh-hoa-tuoi/chau-cay-thong-minh/9417_ma-dao-thanh-cong.jpg', 5, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (2500000, 32,'CHẬU CÂY THÔNG MINH - ĐẠI ĐẾ VƯƠNG','Chậu cây Composite đang dần trở thành xu thế của hiện đại bởi các tính năng nhẹ, bền và sang trọng', 4,'https://locat.com.vn/hinh-hoa-tuoi/chau-cay-thong-minh/9420_dai-de-vuong.jpg', 6, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (1900000, 33,'CHẬU CÂY THÔNG MINH - LƯỠI HỔ DẪN LỘC','Cây lưỡi hổ là loại cây cảnh không chỉ có tác dụng làm đẹp cho không gian nhà bạn mà còn có nhiều lợi ích với sức khỏe, lại dễ trồng và chăm sóc.',4, 'https://locat.com.vn/hinh-hoa-tuoi/chau-cay-thong-minh/9542_luoi-ho-dan-loc.jpg', 10, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (2100000, 34,'CHẬU CÂY THÔNG MINH - LƯỠI HỔ CHIÊU TÀI','Cây lưỡi hổ là loại cây cảnh không chỉ có tác dụng làm đẹp cho không gian nhà bạn mà còn có nhiều lợi ích với sức khỏe, lại dễ trồng và chăm sóc.', 5,'https://locat.com.vn/hinh-hoa-tuoi/chau-cay-thong-minh/9542_luoi-ho-dan-loc.jpg', 4, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (2100000, 35,'CHẬU CÂY THÔNG MINH - TRẦU BÀ ĐẾ VƯƠNG ĐỎ CPS','Trầu bà đế vương đỏ hay còn gọi là cây đại đế vương hoặc cây đại hoàng đế thuộc họ Ráy. Lá cây thường dạng hình tim, thuôn dài về phía đầu lá và lá non thường có màu đỏ tía, cuống lá dài màu đỏ đậm.',5, 'https://locat.com.vn/hinh-hoa-tuoi/chau-cay-thong-minh/11773_trau-ba-de-vuong-do-cps.jpg', 9, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (2500000, 36,'CHẬU CÂY THÔNG MINH - TRẦU BÀ CỘT CPS','Trầu bà leo với các tán lá màu xanh đậm bóng mượt, căng tràn sức sống là màu bản mệnh của mệnh Mộc.. Lá cây thường dạng hình tim, thuôn dài về phía đầu lá và lá non thường có màu đỏ tía, cuống lá dài màu đỏ đậm.',5, 'https://locat.com.vn/hinh-hoa-tuoi/chau-cay-thong-minh/11769_trau-ba-cot-cps.jpg', 8, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (590000, 37,'CÂY VĂN PHÒNG - LAN Ý NỘI THẤT MSP 30','Người ta hay gọi cây là Huệ “Hòa Bình” cũng là vì vậy. Ngoài ra, loài cây này lại mang đến may mắn và tiền tài cho người trồng.',5, 'https://locat.com.vn/hinh-hoa-tuoi/cay-van-phong/9550_lan-y-noi-that-msp-30.jpg', 11, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (650000, 38,'CÂY VĂN PHÒNG - ZZ PLANT MSP30','Cây Kim Tiền là một trong những loại cây phong thủy về may mắn, tài lộc hàng đầu, là biểu tượng của sự giàu sang, thịnh vượng, đẳng cấp khác biệt.',4, 'https://locat.com.vn/hinh-hoa-tuoi/cay-van-phong/9947_zz-plant-msp30.jpg', 3, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (650000, 39,'CÂY VĂN PHÒNG - VẠN LỘC MIX NGỌC NGÂN 1','Cây Ngọc Ngân, cây vạn lộc', 5,'https://locat.com.vn/hinh-hoa-tuoi/cay-van-phong/7992_van-loc-mix-ngoc-ngan-1.jpg', 2, 2, '2022-12-26', '2022-12-26',1,0);
insert into `products` values (600000, 40,'CÂY VĂN PHÒNG - BÀNG SINGAPORE 1M MSP30','Bàng Singapore hợp nhất với người mệnh Mộc. Trang trí bàng Singapore trong nhà sẽ tạo không khí làm việc hòa thuận, vui vẻ hơn.',4, 'https://locat.com.vn/hinh-hoa-tuoi/cay-van-phong/7827_bang-singapore-1m-msp30.jpg', 5, 2, '2022-12-26', '2022-12-26',1,0);

select * from products p , category c where p.cateID = c.cateId and p.cateid = 2;
select * from products;


