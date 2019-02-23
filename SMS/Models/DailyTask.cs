using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SMS.Models
{
    public enum SupportTeam
    {
        LIS, HIS

    }
    public class DailyTask
    {
        //ID,Date,SupportTeam,EmployeeID,ClientName,ClientID,CategoryID,Description,Notes,AssignedDate,DeliveryDate,Status
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        [MaxLength(50)]
        public string SupportTeam { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        [MaxLength(150)]
        public string ClientName { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [MaxLength(150)]
        public string Notes { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        //[DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]

        [DataType(DataType.DateTime)]

        public DateTime? AssignedDate { get; set; }


        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime DeliveryDate { get; set; }
        [Required]

        public int StatusID { get; set; }
        [MaxLength(50)]
        public string AssignedBy { get; set; }
        [MaxLength(50)]
        public string ReAssignedBy { get; set; }
        [MaxLength(50)]
        public string RefferredFrom { get; set; }
    }
}