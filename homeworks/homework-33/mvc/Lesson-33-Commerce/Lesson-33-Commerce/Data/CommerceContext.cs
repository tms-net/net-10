using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lesson_33_Commerce.Models.Data;

    public class CommerceContext : DbContext
    {
        public CommerceContext (DbContextOptions<CommerceContext> options)
            : base(options)
        {
        }

        public DbSet<Lesson_33_Commerce.Models.Data.Product> Product { get; set; } = default!;
    }
