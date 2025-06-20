using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Strategies
{
    public class ExportContext
    {
        private IExportStrategy _strategy;

        public ExportContext(IExportStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IExportStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Export(IEnumerable<Student> students, string filePath)
        {
            _strategy.Export(students, filePath);
        }
    }

}
