namespace BankSolution.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }

        public int DepartmentId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime JoiningDate { get; set; }

        public bool Ssc { get; set; }

        public bool Hsc { get; set; }

        public bool Bsc { get; set; }

        public bool Msc { get; set; }

        [Required]
        public string Picture { get; set; }

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }

        public DateTimeOffset Created { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTimeOffset? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public int Status { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual Department Department { get; set; }

        public virtual State State { get; set; }
    }
}
