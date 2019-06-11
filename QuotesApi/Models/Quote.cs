using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi.Models
{
    public class Quote
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [StringLength(10)]
        public string Type { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
    }
}
