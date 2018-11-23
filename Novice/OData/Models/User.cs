using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OData.Models
{
    [Table("User")]
    public class User
    {
        public Guid Id { get; set; }
    }
}