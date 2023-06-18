using Domain_Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
        }
        public virtual DbSet<categoryresponse> Categoryresponses { get; set; }

        public virtual DbSet<CategoryQuestion> Categories { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<MultipleOptionsResponse> MultipleOptions { get; set; }
    }
}
