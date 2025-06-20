# Tổng Quan Về Mẫu Thiết Kế Facade (Mặt Tiền)

## Định Nghĩa
Mẫu thiết kế Facade là một mẫu thiết kế cấu trúc cung cấp một giao diện đơn giản hóa cho một hệ thống phức tạp gồm nhiều lớp, thư viện hoặc framework. Facade định nghĩa một giao diện cấp cao giúp che giấu sự phức tạp của hệ thống con và làm cho nó dễ sử dụng hơn.

## Cấu Trúc Trong Dự Án RStudentManagement

### 1. Interface IStudentFacade
- Định nghĩa giao diện đơn giản cho việc quản lý sinh viên
- Cung cấp các phương thức cơ bản: thêm, cập nhật, xóa và lấy danh sách sinh viên
- Che giấu sự phức tạp của các tương tác giữa nhiều hệ thống con

### 2. Lớp StudentFacade
- Triển khai giao diện IStudentFacade
- Phối hợp làm việc với nhiều hệ thống con:
  - StudentRepository (lưu trữ thông tin sinh viên)
  - EventLogRepository (ghi log sự kiện)
  - MailRepository (lưu trữ email)
  - MailService (gửi email)
  - FileLogger (ghi log file)

## Ý Nghĩa và Lợi Ích

1. **Đơn Giản Hóa Giao Diện**
   - Cung cấp một giao diện đơn giản cho một tập hợp các giao diện phức tạp trong hệ thống
   - Giảm sự phụ thuộc của client vào các hệ thống con
   - Code client trở nên gọn gàng và dễ đọc hơn

2. **Tăng Tính Trừu Tượng**
   - Tạo một lớp trừu tượng che giấu chi tiết triển khai của các hệ thống con
   - Người dùng không cần biết cách triển khai bên trong, chỉ cần sử dụng interface Facade

3. **Giảm Kết Nối**
   - Giảm sự phụ thuộc giữa client và các thành phần của hệ thống con
   - Khi thay đổi một hệ thống con, client không bị ảnh hưởng nếu giao diện facade không đổi

4. **Tạo Điểm Vào Duy Nhất**
   - Cung cấp một điểm vào duy nhất cho một nhóm các hệ thống con
   - Dễ dàng mở rộng hoặc thay đổi các hệ thống con mà không ảnh hưởng đến client

## Luồng Xử Lý Trong StudentFacade

### Thêm Sinh Viên
1. Lưu thông tin sinh viên vào cơ sở dữ liệu thông qua StudentRepository
2. Tạo sự kiện "StudentCreated" và lưu vào EventLogRepository
3. Gửi email chào mừng thông qua MailService
4. Lưu thông tin email đã gửi vào MailRepository
5. Ghi log thành công vào FileLogger

### Cập Nhật Sinh Viên
1. Cập nhật thông tin sinh viên vào cơ sở dữ liệu thông qua StudentRepository
2. Tạo sự kiện "StudentUpdated" và lưu vào EventLogRepository
3. Gửi email thông báo cập nhật thông qua MailService
4. Lưu thông tin email đã gửi vào MailRepository
5. Ghi log thành công vào FileLogger

### Xóa Sinh Viên
1. Lấy thông tin sinh viên từ StudentRepository
2. Xóa sinh viên khỏi cơ sở dữ liệu
3. Tạo sự kiện "StudentDeleted" và lưu vào EventLogRepository
4. Gửi email thông báo xóa tài khoản thông qua MailService
5. Lưu thông tin email đã gửi vào MailRepository
6. Ghi log thành công vào FileLogger

## Ví Dụ Cách Sử Dụng Trong Ứng Dụng

```csharp
// Tạo đối tượng facade
var studentFacade = new StudentFacade();

// Tạo sinh viên mới
var student = new StudentBuilder()
    .WithFullName("Nguyễn Văn A")
    .WithEmail("nguyenvana@example.com")
    .WithDateOfBirth(new DateTime(2000, 1, 1))
    .WithAddress("123 Đường ABC, Thành phố XYZ")
    .WithClass("CS2023A")
    .Build();

// Thêm sinh viên - Facade xử lý tất cả các tương tác với hệ thống con
await studentFacade.AddStudentAsync(student);

// Lấy danh sách tất cả sinh viên
var students = await studentFacade.GetAlStudentsAsync();

// Cập nhật sinh viên
student.Address = "456 Đường DEF, Thành phố XYZ";
await studentFacade.UpdateStudentAsync(student);

// Xóa sinh viên
await studentFacade.DeleteStudentAsync(student.Id);
```

## So Sánh Trước Và Sau Khi Sử Dụng Facade

### Trước Khi Sử Dụng Facade:
```csharp
// Client phải tương tác với nhiều hệ thống con
var studentRepo = new StudentRepository();
var eventLogRepo = new EventLogRepository();
var mailRepo = new MailRepository();
var mailService = new MailService();

// Thêm sinh viên
await studentRepo.AddAsync(student);

// Tạo và lưu sự kiện
var eventLog = new EventLogBuilder()
    .WithEventType("StudentCreated")
    .WithDescription($"Student {student.FullName} has been created")
    .Build();
await eventLogRepo.AddAsync(eventLog);

// Gửi email
await mailService.SendEmailAsync(student.Email, "Welcome to RStudentManagement", 
    $"Student {student.FullName} has been created");

// Lưu thông tin email
var mail = new MailBuilder()
    .WithEmail(student.Email)
    .WithTitle("Welcome to RStudentManagement")
    .WithBody($"Student {student.FullName} has been created")
    .Build();
await mailRepo.AddAsync(mail);

// Ghi log
FileLogger.Instance.LogInfo($"Student {student.FullName} has been added successfully.");
```

### Sau Khi Sử Dụng Facade:
```csharp
var studentFacade = new StudentFacade();

// Một dòng code duy nhất xử lý tất cả các tương tác phía sau
await studentFacade.AddStudentAsync(student);
```

## Kết Luận

Mẫu thiết kế Facade trong dự án RStudentManagement đã được triển khai hiệu quả để đơn giản hóa các tương tác phức tạp giữa nhiều hệ thống con. StudentFacade đóng vai trò là một điểm vào duy nhất, che giấu sự phức tạp và cung cấp một giao diện sạch, dễ sử dụng cho việc quản lý sinh viên.

Bằng cách phối hợp các hoạt động như lưu trữ dữ liệu, ghi log, gửi email và lưu lịch sử email, Facade giúp giảm sự phụ thuộc của code client vào các hệ thống con và làm cho ứng dụng dễ bảo trì và mở rộng hơn.
