# PETFTMS - PET Friendly Training Management System
![PETFTMS](https://github.com/aguedu/PETFTMS/raw/refs/heads/master/Source/PETFTMS_2.0dev-sql/PETFTMS/Icons/PETFTMS.ico)

PETFTMS là tên viết tắt cho cụm từ **PET Friendly Training Management System** một phần mềm sử dụng cho trung tâm huấn luyện thú nuôi

## Nguồn gốc ý tưởng
PETFTMS là một sản phẩm phần mềm được tạo ra trong quá trình tác giả học tập và thực hành đồ án môn **Lập trình quản lý**

## Mục đích
PETFTMS được chia sẻ **Công khai** nhằm mục đích lưu trữ nội dung được học; chia sẻ mã nguồn để trao đổi kiến thức, học tập kỹ năng lập trình quản lý.

## Nội dung

[/Database/PETFTMS-SQLSERVER.SQL](/Database/PETFTMS-SQLSERVER.SQL) - Mã nguồn xây dựng cơ sở dữ liệu

[/Model/StarUML](/Model/StarUML) - Sơ đồ thiết kế mô hình của hệ thống phần mềm

[/Source/PETFTMS_2.0dev-sql](/Source/PETFTMS_2.0dev-sql) - Mã nguồn chính của hệ thống phần mềm.

Mã nguồn chính của phần mềm được thiết kế theo kiến trúc phân lớp như mô hình MVC, chia tách rõ ràng vai trò chức năng của các lớp được xây dựng; nhằm giúp cho hệ thống phần mềm dễ hiểu, dễ vận hành và bảo trì phát triển. Trong đó bao gồm:

1. [BUS](/Source/PETFTMS_2.0dev-sql/PETFTMS/BUS) - Cung cấp các lớp vận chuyển dữ liệu

2. [DAT](/Source/PETFTMS_2.0dev-sql/PETFTMS/DAT) - Cung cấp các lớp xử lý dữ liệu

3. [INF](/Source/PETFTMS_2.0dev-sql/PETFTMS/INF) - Cung cấp các lớp cấu trúc mẫu của dữ liệu

4. [GUI](/Source/PETFTMS_2.0dev-sql/PETFTMS/GUI) - Cung cấp các lớp giao diện người dùng

5. [Icons](/Source/PETFTMS_2.0dev-sql/PETFTMS/Icons) - Cung cấp các biểu tượng (tham khảo) cho ứng dụng

6. [Images](/Source/PETFTMS_2.0dev-sql/PETFTMS/Images) - Cung cấp các tài nguyên đồ hoạ (hình ảnh) cho ứng dụng

## Tác giả
Nguyễn Hoàng Anh Khoa

## Thông tin kỹ thuật
* Ngôn ngữ: C#, SQL
* Công nghệ: Windows Forms
* Kiến trúc: MVC
* Thời điểm thực hiện: tháng 10 năm 2019
