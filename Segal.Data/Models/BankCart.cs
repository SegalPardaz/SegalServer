using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Segal.Data.Models
{
   public class BankCart:BaseEntity<string>
    {

        public BankCart()
        {
            Id = Guid.NewGuid().ToString();
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }

        [Required]
        public string BankName { get; set; }
        public string Shaba { get; set; }
        [Required]
        public string CartNumber { get; set; }
        [Required]
        public string ExpireDateMonth { get; set; }
        [Required]
        public string ExpireDateYear { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
