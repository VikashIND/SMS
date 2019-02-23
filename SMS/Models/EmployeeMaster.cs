using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SMS.Models
{

    public class EmployeeMaster
    {
        //Id, Name, SupportTeam, ReportingHeadID, LoginID, Password
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public ICollection<EmployeeType> EmployeeTypes { get; set; }
        [MaxLength(50)]
        public string SupportTeam { get; set; }
        [MaxLength(20)]
        public ICollection<EmployeeMaster> ReportingHeadID { get; set; }
        [MaxLength(100)]
        public string LoginID { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
    }
    public class AccessRight
    {
        //ID, EmployeeID, ReportingHeadID
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmployeeID { get; set; }
        [MaxLength(50)]
        public string ReportingHeadID { get; set; }
    }
    public class EmployeeType
    {
        //ID,Name
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}