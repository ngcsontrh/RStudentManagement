using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Mementos
{
    /// <summary>
    /// Lớp Caretaker trong mẫu thiết kế Memento, quản lý và lưu trữ lịch sử các đối tượng Memento
    /// Cho phép thực hiện các thao tác undo và redo thông qua hai ngăn xếp riêng biệt
    /// </summary>
    public class StudentFormCaretaker
    {
        /// <summary>
        /// Ngăn xếp lưu trữ các trạng thái để hoàn tác (undo)
        /// </summary>
        private readonly Stack<StudentFormMemento> _undoStack = new();

        /// <summary>
        /// Ngăn xếp lưu trữ các trạng thái để làm lại (redo)
        /// </summary>
        private readonly Stack<StudentFormMemento> _redoStack = new();

        /// <summary>
        /// Lưu trạng thái hiện tại vào ngăn xếp undo và xóa ngăn xếp redo
        /// </summary>
        /// <param name="memento">Đối tượng Memento chứa trạng thái cần lưu</param>
        public void SaveState(StudentFormMemento memento)
        {
            _undoStack.Push(memento);
            _redoStack.Clear(); // clear redo stack on new operation
        }        /// <summary>
        /// Thực hiện hoàn tác (undo) bằng cách lấy trạng thái trước đó từ ngăn xếp undo
        /// </summary>
        /// <returns>Đối tượng Memento chứa trạng thái trước đó, hoặc null nếu không có trạng thái trước</returns>
        public StudentFormMemento? Undo()
        {
            if (_undoStack.Count > 1)
            {
                var current = _undoStack.Pop();
                _redoStack.Push(current);
                return _undoStack.Peek();
            }
            return null;
        }

        /// <summary>
        /// Thực hiện làm lại (redo) bằng cách lấy trạng thái đã hoàn tác từ ngăn xếp redo
        /// </summary>
        /// <returns>Đối tượng Memento chứa trạng thái cần làm lại, hoặc null nếu không có trạng thái nào để làm lại</returns>
        public StudentFormMemento? Redo()
        {
            if (_redoStack.Count > 0)
            {
                var memento = _redoStack.Pop();
                _undoStack.Push(memento);
                return memento;
            }
            return null;
        }

        /// <summary>
        /// Xóa tất cả lịch sử trạng thái, đặt lại cả hai ngăn xếp undo và redo
        /// </summary>
        public void Reset()
        {
            _undoStack.Clear();
            _redoStack.Clear();
        }
    }

}
