using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : EntityBase
    {
        public string Code { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string? Ethnicity { get; set; }
        public string? Religion { get; set; }
        public string? IdentificationNumber { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public string? PlaceOfIssue { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
