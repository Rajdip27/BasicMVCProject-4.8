namespace BankSolution.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            Employees = new HashSet<Employee>();
            States = new HashSet<State>();
        }

        public int Id { get; set; }

        [Required]
        public string CountryName { get; set; }

        public DateTimeOffset Created { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTimeOffset? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public int Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<State> States { get; set; }
    }
}
