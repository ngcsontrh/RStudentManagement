# Tổng Quan Về Mẫu Thiết Kế Strategy (Chiến Lược)

## Định Nghĩa
Mẫu thiết kế Strategy là một mẫu thiết kế hành vi cho phép chọn thuật toán từ một họ các thuật toán tại thời điểm chạy. Strategy cho phép thuật toán thay đổi độc lập với các client sử dụng nó.

## Cấu Trúc Trong Dự Án RStudentManagement

### 1. Interface IExportStrategy
- Là interface định nghĩa phương thức chung `Export()` mà tất cả các chiến lược cụ thể phải triển khai.
- Cho phép tất cả các chiến lược xuất dữ liệu phải tuân theo một "hợp đồng" chung.

### 2. Các Lớp Chiến Lược Cụ Thể
- **CsvExportStrategy**: Triển khai việc xuất dữ liệu sinh viên sang định dạng CSV.
- **ExcelExportStrategy**: Triển khai việc xuất dữ liệu sinh viên sang định dạng Excel.

### 3. ExportContext
- Lớp ngữ cảnh chứa tham chiếu đến một chiến lược cụ thể.
- Cho phép thay đổi chiến lược tại thời điểm chạy thông qua phương thức `SetStrategy()`.
- Ủy quyền việc thực hiện xuất dữ liệu cho đối tượng chiến lược.

## Ý Nghĩa và Lợi Ích

1. **Tính Mở Rộng Cao**
   - Có thể dễ dàng thêm các chiến lược xuất dữ liệu mới (như PDF, XML...) mà không cần sửa đổi mã hiện có.
   - Tuân thủ nguyên tắc Open/Closed Principle: Mở cho việc mở rộng, đóng cho việc sửa đổi.

2. **Tách Biệt Các Thuật Toán**
   - Mỗi chiến lược xuất dữ liệu được đóng gói riêng biệt, dễ bảo trì và phát triển.
   - Các thuật toán xuất dữ liệu có thể được phát triển độc lập với nhau và với mã sử dụng chúng.

3. **Linh Hoạt Trong Thời Gian Chạy**
   - Người dùng có thể lựa chọn định dạng xuất dữ liệu tại thời điểm chạy (CSV hoặc Excel).
   - Chương trình có thể chuyển đổi giữa các chiến lược mà không cần khởi động lại.

4. **Tránh Câu Lệnh Điều Kiện Phức Tạp**
   - Thay vì sử dụng nhiều câu lệnh if-else để quyết định cách xuất dữ liệu, pattern này cho phép chọn đối tượng chiến lược phù hợp.

5. **Khả Năng Tái Sử Dụng**
   - Các chiến lược có thể được sử dụng lại trong các ngữ cảnh khác nhau của ứng dụng.

## Cách Sử Dụng Trong Ứng Dụng

```csharp
// Tạo chiến lược xuất CSV
var csvStrategy = new CsvExportStrategy();

// Tạo ngữ cảnh với chiến lược CSV
var exportContext = new ExportContext(csvStrategy);

// Xuất dữ liệu sử dụng chiến lược hiện tại
exportContext.Export(students, "students.csv");

// Chuyển đổi sang chiến lược Excel
exportContext.SetStrategy(new ExcelExportStrategy());

// Xuất dữ liệu sử dụng chiến lược Excel
exportContext.Export(students, "students.xlsx");
```

## Kết Luận

Mẫu thiết kế Strategy trong ứng dụng RStudentManagement đã được triển khai hiệu quả để xử lý việc xuất dữ liệu sinh viên sang các định dạng khác nhau. Điều này giúp code trở nên linh hoạt, dễ bảo trì và mở rộng trong tương lai. Khi cần thêm định dạng xuất mới, chỉ cần tạo một lớp chiến lược mới mà không làm ảnh hưởng đến code hiện có.
