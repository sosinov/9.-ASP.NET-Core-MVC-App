using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _9AspNetCoreWebAppMVC.Models;

namespace _9AspNetCoreWebAppMVC.Data
{
    public class _9AspNetCoreWebAppMVCContext : DbContext
    {
        public _9AspNetCoreWebAppMVCContext (DbContextOptions<_9AspNetCoreWebAppMVCContext> options)
            : base(options)
        {
        }

        public DbSet<_9AspNetCoreWebAppMVC.Models.Student> Student { get; set; } = default!;

        public DbSet<_9AspNetCoreWebAppMVC.Models.Group> Group { get; set; }

        public DbSet<_9AspNetCoreWebAppMVC.Models.Course> Course { get; set; }
    }
}
