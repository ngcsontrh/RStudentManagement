using RStudentManagement.Core;
using RStudentManagement.Entities;
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
        private List<Student> students = new List<Student>();

        public StudentForm()
        {
            InitializeComponent();
            sidebarControl1.SidebarItemClicked += SidebarControl1_SidebarItemClicked;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void SidebarControl1_SidebarItemClicked(object? sender, SidebarItem e)
        {
            NavigationManager.Instance.NavigateTo(e, this);
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            students = new List<Student>
            {
                new Student
                {
                    Id = Guid.NewGuid(),
                    Code = "S001",
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    PlaceOfBirth = "New York",
                    Gender = "Male",
                    Email = "edwi@mail.com",
                    PhoneNumber = "112313",
                    CreatedAt = DateTime.UtcNow
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    Code = "S002",
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(2001, 2, 2),
                    PlaceOfBirth = "Los Angeles",
                    Gender = "Male",
                    Email = "edwi@mail.com",
                    PhoneNumber = "112313",
                    CreatedAt = DateTime.UtcNow
                }
            };

            dataGridView1.DataSource = students;
            AddActionColumns();

            dataGridView1.Columns["Id"].Visible = false; // Hide the Id column
            dataGridView1.Columns["CreatedAt"].Visible = false; // Hide the CreatedAt column
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
            editColumn.UseColumnTextForButtonValue = true; // Hiển thị text trên button
            dataGridView1.Columns.Add(editColumn);

            // Cột xóa
            var deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.Name = "Delete";
            deleteColumn.HeaderText = "Xóa";
            deleteColumn.Text = "🗑️";
            deleteColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteColumn);
        }


        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua click header hoặc ngoài vùng dữ liệu
            if (e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                // Xử lý sửa sinh viên
                var student = students[e.RowIndex];
                MessageBox.Show($"Sửa sinh viên: {student.Id} - {student.FirstName} {student.LastName}");
                // TODO: Mở form sửa, cập nhật dữ liệu
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                // Xử lý xóa sinh viên
                var student = students[e.RowIndex];
                var result = MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {student.Code}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    students.RemoveAt(e.RowIndex);
                }
            }
        }

    }
}
