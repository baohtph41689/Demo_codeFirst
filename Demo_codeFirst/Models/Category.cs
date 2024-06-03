using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EF
{
    public class Category 
    {

            [Key]
            public int CategoryId { get; set; }
            [Required]
            [StringLength(50)]
            public string CategoryName { get; set;}
            public ICollection<product> Products { get; set; }
    }
}