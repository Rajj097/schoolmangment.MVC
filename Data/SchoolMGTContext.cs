using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using schoolmangment.MVC.Database;

    public class SchoolMGTContext : DbContext
    {
        public SchoolMGTContext (DbContextOptions<SchoolMGTContext> options)
            : base(options)
        {
        }

        public DbSet<schoolmangment.MVC.Database.Student> Student { get; set; } = default!;
    }
