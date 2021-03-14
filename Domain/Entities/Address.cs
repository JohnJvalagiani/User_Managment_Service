using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using UserService.Core.Models;

namespace Service.Core.Data.Entities
{
    public  class Address : BaseEntity
    {

        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Street { get; set; }
        
        [ForeignKey("UserForeignKey")]
        public string UserForeignKey { get; set; }
        public AppUser User { get; set; }
    }
}
