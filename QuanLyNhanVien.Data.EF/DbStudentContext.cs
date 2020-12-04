using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QuanLyNhanVien.Data.EF.Configuations;
using QuanLyNhanVien.Data.Entitys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuanLyNhanVien.Data.EF
{
    public class DbStudentContext:DbContext
    {
        public DbStudentContext(DbContextOptions options) : base(options)
        {

        }
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguation());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DbStudentContext>
        {
            public DbStudentContext CreateDbContext(string[] args)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
                var builder = new DbContextOptionsBuilder<DbStudentContext>();
                var connectionString = configuration.GetConnectionString("StudentDatabase");
                builder.UseSqlServer(connectionString);
                return new DbStudentContext(builder.Options);
            }
        }
    }
}
