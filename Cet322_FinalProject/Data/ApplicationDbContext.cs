using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Cet322_FinalProject.Models;

namespace Cet322_FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Todo> Todo { get; set; }
        public DbSet<SubTodo> SubTodo { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
