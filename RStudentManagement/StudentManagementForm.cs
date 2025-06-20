// Optimized and fixed version of StudentManagementForm
using RStudentManagement.Adapters;
using RStudentManagement.Data.Repositories;
using RStudentManagement.Entities;
using RStudentManagement.EntityBuilder;
using RStudentManagement.Facades;
using RStudentManagement.Mementos;
using RStudentManagement.Strategies;
using RStudentManagement.UIProvider;
using RStudentManagement.UIProvider.Factory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RStudentManagement
{
    public class StudentManagementForm : Form
    {
        private readonly IStudentFacade _facade;
        private readonly IStudentClassAdapter _classAdapter;
        private readonly StudentFormCaretaker _caretaker;
        private readonly ExportContext _exportContext;

        private IThemeFactory _themeFactory;
        private bool _isDarkTheme;

        private TextBox txtCode;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private DateTimePicker dtpDateOfBirth;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnChangeTheme;
        private DataGridView dgvStudents;
        private ComboBox cbClass;
        private Button btnUndo;
        private Button btnRedo;
        private Button btnExportCsv;
        private Button btnExportPdf;
        private Button btnExportExcel;


        private Student _selectedStudent;
        private List<Student> _students = new();

        public StudentManagementForm()
        {
            _isDarkTheme = false;
            _facade = new StudentFacade();
            _students = new List<Student>();
            _themeFactory = _isDarkTheme ? new DarkThemeFactory() : new LightThemeFactory();
            _classAdapter = new StudentClassAdapter(new StudentClassesAdaptee());
            _caretaker = new StudentFormCaretaker();
            _exportContext = new ExportContext(new ExcelExportStrategy());

            InitializeComponent();
            ApplyTheme();
            _ = LoadStudentsAsync();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Text = "Student Management";
            Size = new Size(1000, 600);
            StartPosition = FormStartPosition.CenterScreen;

            CreateControls();
            LoadClassComboBox();
            ConfigureDataGridView();
            SetupEventHandlers();

            ResumeLayout(false);
            PerformLayout();
        }

        private void CreateControls()
        {
            Label CreateLabel(string text, Point location)
            {
                var label = (Label)_themeFactory.CreateLabel().GetControl();
                label.Text = text;
                label.Location = location;
                label.Size = new Size(100, 20);
                Controls.Add(label);
                return label;
            }

            TextBox CreateTextBox(Point location)
            {
                var textBox = (TextBox)_themeFactory.CreateTextBox().GetControl();
                textBox.Location = location;
                textBox.Size = new Size(200, 20);
                Controls.Add(textBox);
                return textBox;
            }

            Button CreateButton(string text, Point location, Size size)
            {
                var button = (Button)_themeFactory.CreateButton().GetControl();
                button.Text = text;
                button.Location = location;
                button.Size = size;
                Controls.Add(button);
                return button;
            }

            var lblTitle = (Label)_themeFactory.CreateLabel().GetControl();
            lblTitle.Text = "STUDENT MANAGEMENT";
            lblTitle.Font = new Font(lblTitle.Font.FontFamily, 16, FontStyle.Bold);
            lblTitle.Location = new Point(350, 20);
            lblTitle.Size = new Size(450, 50);
            Controls.Add(lblTitle);

            btnChangeTheme = CreateButton("Change Theme", new Point(800, 20), new Size(150, 30));

            int startY = 80;
            int spacing = 30;

            CreateLabel("Code:", new Point(20, startY));
            CreateLabel("Full Name:", new Point(20, startY + spacing));
            CreateLabel("BirthDate:", new Point(20, startY + spacing * 2));
            CreateLabel("Email:", new Point(20, startY + spacing * 3));
            CreateLabel("Address:", new Point(20, startY + spacing * 4));
            CreateLabel("Class:", new Point(20, startY + spacing * 5));

            txtCode = CreateTextBox(new Point(130, startY));
            txtFullName = CreateTextBox(new Point(130, startY + spacing));
            dtpDateOfBirth = new DateTimePicker
            {
                Location = new Point(130, startY + spacing * 2),
                Size = new Size(200, 20),
                Format = DateTimePickerFormat.Short
            };
            Controls.Add(dtpDateOfBirth);

            txtEmail = CreateTextBox(new Point(130, startY + spacing * 3));
            txtAddress = CreateTextBox(new Point(130, startY + spacing * 4));
            cbClass = new ComboBox
            {
                Location = new Point(130, startY + spacing * 5),
                Size = new Size(200, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            Controls.Add(cbClass);

            int buttonY = startY + spacing * 6 + 10;
            btnAdd = CreateButton("Add", new Point(20, buttonY), new Size(80, 30));
            btnUpdate = CreateButton("Update", new Point(110, buttonY), new Size(80, 30));
            btnDelete = CreateButton("Delete", new Point(200, buttonY), new Size(80, 30));
            btnClear = CreateButton("Clear", new Point(290, buttonY), new Size(80, 30));
            btnUndo = CreateButton("Undo", new Point(380, buttonY), new Size(80, 30));
            btnRedo = CreateButton("Redo", new Point(470, buttonY), new Size(80, 30));
            btnExportCsv = CreateButton("Export CSV", new Point(560, buttonY), new Size(150, 30));
            btnExportExcel = CreateButton("Export Excel", new Point(720, buttonY), new Size(150, 30));

            dgvStudents = new DataGridView
            {
                Location = new Point(20, buttonY + 50),
                Size = new Size(940, 260),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            Controls.Add(dgvStudents);
        }


        private void ConfigureDataGridView()
        {
            dgvStudents.Columns.Clear();
            dgvStudents.Columns.Add("ID", "ID");
            dgvStudents.Columns["ID"].Visible = false;
            dgvStudents.Columns.Add("Code", "Code");
            dgvStudents.Columns.Add("FullName", "Full Name");
            dgvStudents.Columns.Add("DateOfBirth", "Date of Birth");
            dgvStudents.Columns.Add("Email", "Email");
            dgvStudents.Columns.Add("Address", "Address");
            dgvStudents.Columns.Add("Class", "Class");

            var editButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Action",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            dgvStudents.Columns.Add(editButtonColumn);
        }


        private void SetupEventHandlers()
        {
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += BtnClear_Click;
            btnChangeTheme.Click += BtnChangeTheme_Click;
            dgvStudents.CellContentClick += DgvStudents_CellContentClick;
            btnUndo.Click += BtnUndo_Click;
            btnRedo.Click += BtnRedo_Click;
            btnExportCsv.Click += (s, e) => ExportFile(new CsvExportStrategy(), "CSV files|*.csv");
            btnExportExcel.Click += (s, e) => ExportFile(new ExcelExportStrategy(), "Excel files|*.xlsx");
        }

        private async Task LoadStudentsAsync()
        {
            try
            {
                var students = await _facade.GetAlStudentsAsync();
                BindStudentsToGrid(students);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClassComboBox()
        {
            var classes = _classAdapter.GetStudentClasses();
            cbClass.DataSource = classes;
            cbClass.DisplayMember = "Name";
            cbClass.ValueMember = "Code";
        }


        private void BindStudentsToGrid(IEnumerable<Student> students)
        {
            _students = students.ToList();
            dgvStudents.Rows.Clear();
            foreach (var student in _students)
            {
                dgvStudents.Rows.Add(student.Id, student.Code, student.FullName,
                    student.DateOfBirth.ToShortDateString(), student.Email, student.Address, student.Class);
            }
        }


        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            var student = new StudentBuilder()
                .WithCode(txtCode.Text)
                .WithFullName(txtFullName.Text)
                .WithDateOfBirth(dtpDateOfBirth.Value)
                .WithEmail(txtEmail.Text)
                .WithAddress(txtAddress.Text)
                .WithClass(cbClass.SelectedValue?.ToString() ?? string.Empty)
                .Build();
            await AddStudentAsync(student);
        }

        private async Task AddStudentAsync(Student student)
        {
            try
            {
                _caretaker.SaveState(CreateMemento());
                await _facade.AddStudentAsync(student);
                MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadStudentsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            txtCode.Text = txtFullName.Text = txtEmail.Text = txtAddress.Text = string.Empty;
            dtpDateOfBirth.Value = DateTime.Now;
            _selectedStudent = null;

            _caretaker.SaveState(CreateMemento());
        }

        private void DgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Kiểm tra nếu cột là "Edit"
            if (dgvStudents.Columns[e.ColumnIndex].Name == "Edit")
            {
                var idStr = dgvStudents.Rows[e.RowIndex].Cells["ID"].Value?.ToString();
                if (Guid.TryParse(idStr, out var id))
                {
                    var found = _students.FirstOrDefault(s => s.Id == id);
                    if (found != null)
                    {
                        _selectedStudent = found.Copy();
                        DisplayStudentDetails(_selectedStudent);
                    }
                }
            }
        }


        private void DisplayStudentDetails(Student student)
        {
            _caretaker.SaveState(CreateMemento());
            txtCode.Text = student.Code;
            txtFullName.Text = student.FullName;
            txtEmail.Text = student.Email;
            txtAddress.Text = student.Address;
            dtpDateOfBirth.Value = student.DateOfBirth;
            cbClass.SelectedValue = student.Class;

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedStudent == null || !ValidateInput()) return;
            var updatedStudent = _selectedStudent.Copy();
            UpdateStudentFromForm(updatedStudent);
            _ = UpdateStudentAsync(updatedStudent);
        }

        private void UpdateStudentFromForm(Student student)
        {
            student.Code = txtCode.Text;
            student.FullName = txtFullName.Text;
            student.DateOfBirth = dtpDateOfBirth.Value;
            student.Email = txtEmail.Text;
            student.Address = txtAddress.Text;
            student.Class = cbClass.SelectedValue?.ToString() ?? string.Empty;
        }

        private async Task UpdateStudentAsync(Student student)
        {
            try
            {
                _caretaker.SaveState(CreateMemento());
                await _facade.UpdateStudentAsync(student);
                MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadStudentsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedStudent == null)
            {
                MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ = DeleteStudentAsync(_selectedStudent.Id);
            }
        }

        private async Task DeleteStudentAsync(Guid id)
        {
            try
            {
                _caretaker.SaveState(CreateMemento());
                await _facade.DeleteStudentAsync(id);
                MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                await LoadStudentsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnChangeTheme_Click(object sender, EventArgs e)
        {
            _isDarkTheme = !_isDarkTheme;
            _themeFactory = _isDarkTheme ? new DarkThemeFactory() : new LightThemeFactory();

            Controls.Clear();
            InitializeComponent();
            ApplyTheme();
            _ = LoadStudentsAsync();
        }

        private void ApplyTheme()
        {
            BackColor = _themeFactory is DarkThemeFactory ? Color.FromArgb(50, 50, 50) : Color.FromArgb(240, 240, 240);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Student Code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private StudentFormMemento CreateMemento()
        {
            return new StudentFormMemento(
                txtCode.Text,
                txtFullName.Text,
                dtpDateOfBirth.Value,
                txtEmail.Text,
                txtAddress.Text,
                cbClass.SelectedValue?.ToString() ?? string.Empty
            );
        }

        private void RestoreFromMemento(StudentFormMemento memento)
        {
            if (memento == null) return;
            txtCode.Text = memento.Code;
            txtFullName.Text = memento.FullName;
            dtpDateOfBirth.Value = memento.DateOfBirth;
            txtEmail.Text = memento.Email;
            txtAddress.Text = memento.Address;
            cbClass.SelectedValue = memento.ClassCode;
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            var previousState = _caretaker.Undo();
            RestoreFromMemento(previousState);
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            var nextState = _caretaker.Redo();
            RestoreFromMemento(nextState);
        }

        private void ExportFile(IExportStrategy strategy, string filter)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = filter,
                FileName = "students"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _exportContext.SetStrategy(strategy);
                    _exportContext.Export(_students, dialog.FileName);
                    MessageBox.Show("Export successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}