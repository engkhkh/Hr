using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hr.Models
{
    [Keyless]
    [NotMapped]
    public class MailExpire
    {
        public DateTime CH { get; set; }= Convert.ToDateTime("04-01-2023");
        
    }
}
