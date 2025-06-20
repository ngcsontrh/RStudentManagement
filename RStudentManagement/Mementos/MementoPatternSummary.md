# Tổng Quan Về Mẫu Thiết Kế Memento (Kỷ Vật)

## Định Nghĩa
Mẫu thiết kế Memento là một mẫu thiết kế hành vi cho phép lưu trữ và khôi phục trạng thái bên trong của một đối tượng mà không vi phạm nguyên tắc đóng gói. Memento cho phép bạn tạo ảnh chụp (snapshot) của trạng thái đối tượng để có thể khôi phục lại sau này.

## Cấu Trúc Trong Dự Án RStudentManagement

### 1. StudentFormMemento (Memento)
- Lớp chứa trạng thái của form sinh viên tại một thời điểm cụ thể
- Lưu trữ tất cả các thông tin được nhập vào form: mã, họ tên, ngày sinh, email, địa chỉ, mã lớp
- Đối tượng này là bất biến (immutable) - các thuộc tính chỉ có thể đọc để đảm bảo trạng thái không bị thay đổi

### 2. StudentFormCaretaker (Người Giữ Kỷ Vật)
- Quản lý và lưu trữ lịch sử các đối tượng Memento
- Duy trì hai ngăn xếp (stack): một cho hoàn tác (undo) và một cho làm lại (redo)
- Cung cấp các phương thức Undo(), Redo(), SaveState() và Reset()
- Không biết hoặc không truy cập trực tiếp vào nội dung cụ thể của Memento

### 3. StudentManagementForm (Originator - Người Tạo)
- Form quản lý thông tin sinh viên, tạo ra các đối tượng Memento
- Có khả năng lưu trữ trạng thái hiện tại vào Memento thông qua phương thức CreateMemento()
- Có khả năng khôi phục trạng thái từ một Memento thông qua phương thức RestoreMemento()
- Tương tác với Caretaker để lưu trữ và khôi phục trạng thái form

## Ý Nghĩa và Lợi Ích

1. **Cải Thiện Trải Nghiệm Người Dùng**
   - Cung cấp chức năng hoàn tác (undo) và làm lại (redo) cho người dùng
   - Giúp người dùng khôi phục dữ liệu khi mắc lỗi hoặc thay đổi quyết định

2. **Bảo Vệ Tính Đóng Gói**
   - Lưu trữ trạng thái mà không vi phạm tính đóng gói của đối tượng gốc
   - Memento chỉ tiết lộ thông tin cho đối tượng gốc (Originator) đã tạo ra nó

3. **Tách Biệt Trách Nhiệm**
   - Phân tách rõ ràng trách nhiệm giữa các thành phần:
     - Originator: Tạo và sử dụng Memento
     - Memento: Lưu trữ trạng thái
     - Caretaker: Quản lý lịch sử các Memento

4. **Quản Lý Trạng Thái Hiệu Quả**
   - Sử dụng cấu trúc dữ liệu Stack để quản lý lịch sử trạng thái
   - Tối ưu hóa bộ nhớ với việc chỉ lưu trữ những thay đổi thực sự

5. **Dễ Mở Rộng**
   - Có thể dễ dàng mở rộng để lưu trữ thêm các trạng thái mới
   - Không cần thay đổi logic quản lý lịch sử khi thêm thuộc tính mới

## Luồng Hoạt Động Trong Form Quản Lý Sinh Viên

### Lưu Trữ Trạng Thái
1. Người dùng thực hiện thay đổi trên form (nhập hoặc sửa thông tin)
2. Form tạo một StudentFormMemento lưu trữ trạng thái hiện tại
3. Memento được truyền cho StudentFormCaretaker để lưu vào ngăn xếp undo
4. Ngăn xếp redo được xóa trống (vì đã có một hành động mới)

### Hoàn Tác (Undo)
1. Người dùng nhấn nút Undo
2. StudentFormCaretaker lấy memento hiện tại từ ngăn xếp undo và chuyển sang ngăn xếp redo
3. Caretaker trả về memento trước đó từ ngăn xếp undo
4. Form khôi phục trạng thái từ memento trả về
5. Giao diện người dùng được cập nhật với thông tin đã khôi phục

### Làm Lại (Redo)
1. Người dùng nhấn nút Redo
2. StudentFormCaretaker lấy memento gần nhất từ ngăn xếp redo
3. Memento này được đẩy lại vào ngăn xếp undo
4. Form khôi phục trạng thái từ memento trả về
5. Giao diện người dùng được cập nhật với thông tin đã khôi phục

## Ví Dụ Cách Sử Dụng

```csharp
// Trong StudentManagementForm

// Khởi tạo Caretaker
private readonly StudentFormCaretaker _caretaker = new StudentFormCaretaker();

// Tạo một Memento từ trạng thái hiện tại
private StudentFormMemento CreateMemento()
{
    return new StudentFormMemento(
        txtCode.Text,
        txtFullName.Text,
        dtpDateOfBirth.Value,
        txtEmail.Text,
        txtAddress.Text,
        cboClass.SelectedValue?.ToString()
    );
}

// Khôi phục trạng thái từ Memento
private void RestoreMemento(StudentFormMemento memento)
{
    if (memento != null)
    {
        txtCode.Text = memento.Code;
        txtFullName.Text = memento.FullName;
        dtpDateOfBirth.Value = memento.DateOfBirth;
        txtEmail.Text = memento.Email;
        txtAddress.Text = memento.Address;
        
        // Khôi phục lớp đã chọn
        if (!string.IsNullOrEmpty(memento.ClassCode))
        {
            for (int i = 0; i < cboClass.Items.Count; i++)
            {
                var item = cboClass.Items[i] as StudentClass;
                if (item != null && item.Code == memento.ClassCode)
                {
                    cboClass.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}

// Lưu trạng thái khi có thay đổi
private void SaveCurrentState()
{
    _caretaker.SaveState(CreateMemento());
}

// Xử lý sự kiện Undo
private void btnUndo_Click(object sender, EventArgs e)
{
    var memento = _caretaker.Undo();
    RestoreMemento(memento);
}

// Xử lý sự kiện Redo
private void btnRedo_Click(object sender, EventArgs e)
{
    var memento = _caretaker.Redo();
    RestoreMemento(memento);
}
```

## Kết Luận

Mẫu thiết kế Memento trong ứng dụng RStudentManagement đã được triển khai hiệu quả để cung cấp chức năng hoàn tác và làm lại cho form quản lý sinh viên. Điều này cải thiện đáng kể trải nghiệm người dùng, cho phép họ dễ dàng khôi phục các thao tác trước đó nếu cần.

Qua việc tách biệt rõ ràng trách nhiệm giữa Originator (Form), Memento và Caretaker, mẫu thiết kế này giúp code trở nên dễ bảo trì và mở rộng, đồng thời bảo vệ nguyên tắc đóng gói của dữ liệu.
