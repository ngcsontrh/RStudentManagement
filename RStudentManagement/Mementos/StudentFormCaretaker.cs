using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Mementos
{
    public class StudentFormCaretaker
    {
        private readonly Stack<StudentFormMemento> _undoStack = new();
        private readonly Stack<StudentFormMemento> _redoStack = new();

        public void SaveState(StudentFormMemento memento)
        {
            _undoStack.Push(memento);
            _redoStack.Clear(); // clear redo stack on new operation
        }

        public StudentFormMemento Undo()
        {
            if (_undoStack.Count > 1)
            {
                var current = _undoStack.Pop();
                _redoStack.Push(current);
                return _undoStack.Peek();
            }
            return null;
        }

        public StudentFormMemento Redo()
        {
            if (_redoStack.Count > 0)
            {
                var memento = _redoStack.Pop();
                _undoStack.Push(memento);
                return memento;
            }
            return null;
        }

        public void Reset()
        {
            _undoStack.Clear();
            _redoStack.Clear();
        }
    }

}
