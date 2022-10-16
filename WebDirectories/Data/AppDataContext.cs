using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WebDirectories.Entities;

namespace WebDirectories.Data
{
    public class AppDataContext:DbContext
    {
        public AppDataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Folder> Folders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<Folder>().HasData(
              new Folder()
              {
                  Id = 1,
                  FullName="Creating Digital Images",
                  ParentId = null,
              },
              new Folder()
              {
                  Id = 2,
                  FullName = "Resources",
                  ParentId = 1,
              },
              new Folder()
              {
                  Id = 3,
                  FullName = "Evidence",
                  ParentId = 1,
              },
              new Folder()
              {
                  Id = 4,
                  FullName = "Graphic Product",
                  ParentId = 1,
              }
              ,
              new Folder()
              {
                  Id = 5,
                  FullName = "Primary",
                  ParentId = 2,
              },
              new Folder()
              {
                  Id = 6,
                  FullName = "Secondary",
                  ParentId = 2,
              }

              );*/
        }
    }
}
