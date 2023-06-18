using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Models
{
    public class categoryresponse
    {
        [Key]
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? Responseid { get; set; }
        [ForeignKey(nameof(Responseid))]
        public Response response { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public CategoryQuestion CategoryQuestion { get; set; }
    }
}
