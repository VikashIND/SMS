using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models
{


    public class ClientMaster
    {
        //ID, ClientName, Address, City, State, Country,ContactDetails,Email,RemoteSoftware,RsID,RSPassword,
        //URL,StaticIp,Port,ServerID,ServerPassword,Comments
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(150)]
        public string ClientName { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string State { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        public string ContactDetails { get; set; }
        public string Email { get; set; }
        public string RemoteSoftware { get; set; }
        public string RSID { get; set; }
        public string RSPassword { get; set; }
        public string URL { get; set; }
        public string StaticIp { get; set; }
        public string Port { get; set; }
        public string ServerID { get; set; }
        public string ServerPassword { get; set; }
        public string Comments { get; set; }

    }


}