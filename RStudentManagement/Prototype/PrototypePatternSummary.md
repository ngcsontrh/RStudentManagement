# Tổng Quan Về Mẫu Thiết Kế Prototype (Nguyên Mẫu)

## Định Nghĩa
Mẫu thiết kế Prototype là một mẫu thiết kế sáng tạo cho phép sao chép các đối tượng hiện có mà không làm cho code phụ thuộc vào các lớp cụ thể của chúng. Prototype cho phép tạo ra các bản sao của đối tượng mà không cần biết chi tiết về cách tạo ra đối tượng đó.

## Cấu Trúc Trong Dự Án RStudentManagement

### 1. Interface ICloneable<T>
- Là interface định nghĩa phương thức chung `Clone()` mà tất cả các lớp muốn hỗ trợ khả năng sao chép phải triển khai.
- Generic type T cho phép mỗi lớp xác định kiểu trả về chính xác của phương thức Clone.
- Ràng buộc "where T : class" đảm bảo rằng T phải là một kiểu tham chiếu.

### 2. Các Lớp Cụ Thể Triển Khai ICloneable
- Các lớp cụ thể trong dự án triển khai interface ICloneable để hỗ trợ việc tạo bản sao của chúng.
- Mỗi lớp phải cung cấp cách thức sao chép riêng dựa trên cấu trúc dữ liệu của nó.

## Ý Nghĩa và Lợi Ích

1. **Tạo Đối Tượng Mới Từ Đối Tượng Có Sẵn**
   - Cho phép tạo bản sao của đối tượng đang tồn tại thay vì tạo mới từ đầu.
   - Hữu ích khi việc khởi tạo đối tượng tốn nhiều tài nguyên hơn so với sao chép.

2. **Giảm Sự Phụ Thuộc Vào Lớp Cụ Thể**
   - Client có thể tạo đối tượng mới mà không cần biết lớp cụ thể của đối tượng đó.
   - Giúp giảm sự phức tạp và sự phụ thuộc trong mã nguồn.

3. **Tạo Đối Tượng Phức Tạp Với Nhiều Trạng Thái**
   - Hữu ích khi cần tạo các đối tượng có nhiều trạng thái hoặc cấu hình khác nhau.
   - Cho phép tạo các biến thể của đối tượng bằng cách sao chép và sửa đổi một đối tượng gốc.

4. **Giảm Số Lượng Lớp Con**
   - Thay vì tạo nhiều lớp con với các cấu hình khác nhau, có thể sử dụng prototype để sao chép và điều chỉnh.

5. **Hỗ Trợ Cho Các Hoạt Động Hoàn Tác (Undo)**
   - Có thể lưu trữ trạng thái của đối tượng bằng cách tạo bản sao trước khi thay đổi.

## Cách Sử Dụng Trong Ứng Dụng

```csharp
// Định nghĩa lớp cụ thể triển khai ICloneable
public class Student : ICloneable<Student>
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    // Các thuộc tính khác...

    // Triển khai phương thức Clone
    public Student Clone()
    {
        return new Student
        {
            Name = this.Name,
            DateOfBirth = this.DateOfBirth,
            // Sao chép các thuộc tính khác...
        };
    }
}

// Sử dụng mẫu Prototype
Student originalStudent = new Student
{
    Name = "Nguyễn Văn A",
    DateOfBirth = new DateTime(2000, 1, 1)
};

// Tạo bản sao từ đối tượng gốc
Student clonedStudent = originalStudent.Clone();
// Giờ đây clonedStudent là bản sao độc lập của originalStudent
```

## Deep Clone vs Shallow Clone

1. **Shallow Clone (Sao Chép Nông)**
   - Chỉ tạo bản sao của đối tượng mà không sao chép các đối tượng mà nó tham chiếu đến.
   - Các tham chiếu trong đối tượng gốc và bản sao sẽ trỏ đến cùng một đối tượng.

2. **Deep Clone (Sao Chép Sâu)**
   - Tạo bản sao của đối tượng và sao chép tất cả các đối tượng mà nó tham chiếu đến.
   - Đối tượng gốc và bản sao hoàn toàn độc lập với nhau.
   - Triển khai thường phức tạp hơn shallow clone.

## Kết Luận

Mẫu thiết kế Prototype trong ứng dụng RStudentManagement cung cấp một cách linh hoạt để tạo bản sao của các đối tượng. Điều này đặc biệt hữu ích trong các trường hợp cần lưu trữ trạng thái, tạo đối tượng tạm thời, hoặc khi việc khởi tạo đối tượng mới từ đầu tốn nhiều tài nguyên. Thông qua interface ICloneable<T>, các lớp trong dự án có thể dễ dàng triển khai khả năng sao chép, giúp code trở nên linh hoạt và dễ bảo trì hơn.
