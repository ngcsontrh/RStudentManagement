using OfficeOpenXml;
using OfficeOpenXml.Style;
using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Strategies
{
    public class ExcelExportStrategy : IExportStrategy
    {
        public void Export(IEnumerable<Student> students, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Students");

            // Header
            worksheet.Cells[1, 1].Value = "Code";
            worksheet.Cells[1, 2].Value = "Full Name";
            worksheet.Cells[1, 3].Value = "Date of Birth";
            worksheet.Cells[1, 4].Value = "Email";
            worksheet.Cells[1, 5].Value = "Address";
            worksheet.Cells[1, 6].Value = "Class";

            using (var range = worksheet.Cells[1, 1, 1, 6])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            }

            // Data
            var studentsList = students.ToList();
            for (int i = 0; i < studentsList.Count; i++)
            {
                var s = studentsList[i];
                worksheet.Cells[i + 2, 1].Value = s.Code;
                worksheet.Cells[i + 2, 2].Value = s.FullName;
                worksheet.Cells[i + 2, 3].Value = s.DateOfBirth.ToShortDateString();
                worksheet.Cells[i + 2, 4].Value = s.Email;
                worksheet.Cells[i + 2, 5].Value = s.Address;
                worksheet.Cells[i + 2, 6].Value = s.Class;
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            package.SaveAs(new FileInfo(filePath));
        }
    }
}
