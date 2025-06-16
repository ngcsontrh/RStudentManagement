using RStudentManagement.Core;
using RStudentManagement.Entities;
using RStudentManagement.Services.Implements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RStudentManagement
{
    public partial class StudentForm : Form
    {
        private readonly DatabaseManager _databaseManager;
        private readonly StudentLogService _studentLogService;
        private List<Student> students = new List<Student>();

        public StudentForm()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager(AppConfig.DbConnectionString);
            _studentLogService = new StudentLogService(_databaseManager);
            sidebarControl1.SidebarItemClicked += SidebarControl1_SidebarItemClicked;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            button1.Click += button1_Click;
        }

        private void SidebarControl1_SidebarItemClicked(object? sender, SidebarItem e)
        {
            NavigationManager.Instance.NavigateTo(e, this);
        }

        private async void StudentForm_Load(object sender, EventArgs e)
        {
            await LoadStudents();
        }

        private async Task LoadStudents()
        {
            var studentsList = await _studentLogService.GetAllStudentsAsync();
            students = studentsList.ToList();
            dataGridView1.DataSource = students;
            AddActionColumns();

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Code"].HeaderText = "Mã sinh viên";
            dataGridView1.Columns["FirstName"].HeaderText = "Họ";
            dataGridView1.Columns["LastName"].HeaderText = "Tên";
            dataGridView1.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
            dataGridView1.Columns["PlaceOfBirth"].HeaderText = "Nơi sinh";
            dataGridView1.Columns["Gender"].HeaderText = "Giới tính";
            dataGridView1.Columns["Email"].HeaderText = "Email";
            dataGridView1.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
        }

        private void AddActionColumns()
        {
            // Cột sửa
            var editColumn = new DataGridViewButtonColumn();
            editColumn.Name = "Edit";
            editColumn.HeaderText = "Sửa";
            editColumn.Text = "📝";
            editColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editColumn);

            // Cột xóa
            var deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.Name = "Delete";
            deleteColumn.HeaderText = "Xóa";
            deleteColumn.Text = "🗑️";
            deleteColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteColumn);
        }

        private async void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                var student = students[e.RowIndex];
                MessageBox.Show($"Sửa sinh viên: {student.Code} - {student.FirstName} {student.LastName}");
                // TODO: Mở form sửa, cập nhật dữ liệu
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                var student = students[e.RowIndex];
                var result = MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {student.Code}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Xóa tất cả log của sinh viên trước
                        string deleteLogsQuery = "DELETE FROM StudentLogs WHERE StudentId = @StudentId";
                        _databaseManager.ExecuteNonQuery(deleteLogsQuery, new Microsoft.Data.SqlClient.SqlParameter[] {
                            new Microsoft.Data.SqlClient.SqlParameter("@StudentId", student.Id)
                        });

                        // Sau đó xóa sinh viên
                        bool deleted = await _studentLogService.DeleteStudentAsync(student);
                        if (deleted)
                        {
                            // Ghi log xóa (nếu cần)
                            // _studentLogService.LogStudentActivity(student, $"Xóa sinh viên {student.Code}");
                            await LoadStudents(); // Tải lại danh sách sau khi xóa
                            MessageBox.Show("Xóa sinh viên thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa sinh viên. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    Code = textBox1.Text,
                    FirstName = textBox3.Text,
                    LastName = textBox5.Text,
                    DateOfBirth = DateTime.TryParse(dateTimePicker1.Text, out var dob) ? dob : DateTime.Now,
                    PlaceOfBirth = textBox4.Text,
                    Gender = textBox6.Text,
                    PhoneNumber = textBox7.Text,
                    Email = textBox8.Text,
                    CreatedAt = DateTime.UtcNow
                };

                bool result = await _studentLogService.AddStudentAsync(student);
                if (result)
                {
                    MessageBox.Show("Thêm sinh viên thành công!");
                    await LoadStudents();
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
