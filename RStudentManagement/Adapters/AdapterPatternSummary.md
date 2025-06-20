# Tổng Quan Về Mẫu Thiết Kế Adapter (Bộ Điều Hợp)

## Định Nghĩa
Mẫu thiết kế Adapter là một mẫu thiết kế cấu trúc cho phép các đối tượng với giao diện không tương thích làm việc cùng nhau. Adapter hoạt động như một cầu nối, chuyển đổi giao diện của một đối tượng thành giao diện khác mà client mong đợi.

## Cấu Trúc Trong Dự Án RStudentManagement

### 1. Target (Mục Tiêu)
- **IStudentClassAdapter**: Định nghĩa giao diện mà client sẽ sử dụng để làm việc với dữ liệu lớp học

### 2. Adapter (Bộ Điều Hợp)
- **StudentClassAdapter**: Triển khai giao diện IStudentClassAdapter và chuyển đổi dữ liệu từ Adaptee sang định dạng mà client có thể sử dụng

### 3. Adaptee (Đối Tượng Cần Điều Hợp)
- **StudentClassesAdaptee**: Lớp hiện có cung cấp dữ liệu lớp học nhưng với định dạng không tương thích trực tiếp với nhu cầu của client

### 4. Client
- Sử dụng giao diện IStudentClassAdapter để làm việc với dữ liệu lớp học

## Ý Nghĩa và Lợi Ích

1. **Tái Sử Dụng Mã Nguồn Hiện Có**
   - Cho phép sử dụng lại các lớp hiện có mà không cần sửa đổi mã nguồn gốc
   - Đặc biệt hữu ích khi làm việc với các thư viện hoặc hệ thống bên ngoài không thể sửa đổi

2. **Tăng Tính Tương Thích**
   - Cho phép các lớp hoặc hệ thống không tương thích có thể làm việc cùng nhau
   - Giúp kết nối các hệ thống độc lập mà không cần thay đổi cấu trúc của chúng

3. **Tăng Tính Mở Rộng**
   - Có thể thêm mới các adapter mà không ảnh hưởng đến mã nguồn hiện có
   - Tuân thủ nguyên tắc Open/Closed Principle

4. **Sự Trong Suốt Đối Với Client**
   - Client không cần biết về quá trình chuyển đổi phức tạp bên trong adapter
   - Client chỉ làm việc với giao diện quen thuộc và dễ sử dụng

## Luồng Chuyển Đổi Trong StudentClassAdapter

### Dữ Liệu Gốc (từ StudentClassesAdaptee)
```
"M101 - Mathematics 101"
"CS102 - Computer Science 102"
"M103 - Mathematics 103"
"CS104 - Computer Science 104"
"PHY105 - Physics 105"
```

### Quá Trình Chuyển Đổi
1. StudentClassAdapter nhận dữ liệu dạng chuỗi từ StudentClassesAdaptee
2. Tách mỗi chuỗi thành mã lớp (Code) và tên lớp (Name) dựa vào dấu phân cách " - "
3. Tạo đối tượng StudentClass mới với các thuộc tính Code và Name
4. Trả về danh sách các đối tượng StudentClass cho client

### Dữ Liệu Sau Khi Chuyển Đổi
```csharp
[
    { Code: "M101", Name: "Mathematics 101" },
    { Code: "CS102", Name: "Computer Science 102" },
    { Code: "M103", Name: "Mathematics 103" },
    { Code: "CS104", Name: "Computer Science 104" },
    { Code: "PHY105", Name: "Physics 105" }
]
```

## So Sánh: Trước và Sau Khi Sử Dụng Adapter

### Trước Khi Sử Dụng Adapter:
```csharp
// Client phải làm việc trực tiếp với định dạng không phù hợp
var adaptee = new StudentClassesAdaptee();
var rawClasses = adaptee.GetAvailableClasses();

var studentClasses = new List<StudentClass>();
foreach (var studentClass in rawClasses)
{
    var classParts = studentClass.Split(" - ");
    if (classParts.Length == 2)
    {
        studentClasses.Add(new StudentClass
        {
            Code = classParts[0],
            Name = classParts[1]
        });
    }
}

// Sử dụng studentClasses
```

### Sau Khi Sử Dụng Adapter:
```csharp
// Client làm việc với giao diện thân thiện và phù hợp
var adaptee = new StudentClassesAdaptee();
IStudentClassAdapter adapter = new StudentClassAdapter(adaptee);
var studentClasses = adapter.GetStudentClasses();

// Sử dụng studentClasses
```

## Ví Dụ Sử Dụng Trong Ứng Dụng

```csharp
// Khởi tạo
var adaptee = new StudentClassesAdaptee();
IStudentClassAdapter adapter = new StudentClassAdapter(adaptee);

// Lấy danh sách lớp học đã được chuyển đổi
var studentClasses = adapter.GetStudentClasses();

// Hiển thị danh sách lớp học trong ComboBox
comboBoxClasses.DataSource = studentClasses;
comboBoxClasses.DisplayMember = "Name";
comboBoxClasses.ValueMember = "Code";

// Khi người dùng chọn một lớp
string selectedClassCode = comboBoxClasses.SelectedValue.ToString();
```

## Các Loại Adapter

### 1. Object Adapter (Sử dụng Composition)
- Đây là cách triển khai được sử dụng trong dự án RStudentManagement
- Adapter chứa một tham chiếu đến đối tượng Adaptee
- Linh hoạt hơn vì có thể thích ứng với bất kỳ lớp con nào của Adaptee

### 2. Class Adapter (Sử dụng Inheritance)
- Adapter kế thừa từ cả Target và Adaptee
- Không thể sử dụng khi cả Target và Adaptee là các lớp cụ thể (trong C# không hỗ trợ đa thừa kế lớp)
- Cho phép ghi đè hành vi của Adaptee

## Kết Luận

Mẫu thiết kế Adapter trong dự án RStudentManagement đã được triển khai hiệu quả để chuyển đổi định dạng dữ liệu lớp học từ chuỗi đơn giản sang đối tượng StudentClass có cấu trúc. 

Điều này cho phép hệ thống làm việc với một nguồn dữ liệu hiện có (Adaptee) mà không cần sửa đổi mã nguồn gốc, đồng thời cung cấp một giao diện sạch và dễ sử dụng cho client. Qua đó, mẫu Adapter giúp tăng khả năng tái sử dụng mã nguồn, giảm sự phụ thuộc giữa các thành phần và làm cho hệ thống dễ bảo trì và mở rộng hơn.
