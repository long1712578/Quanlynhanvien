using QuanLyNhanVien.Data.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace QuanLyNhanVien.Data.EF.Configuations
{
    public class StudentConfiguation : IEntityTypeConfiguration<Student>
    {
        public  void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.id).HasMaxLength(10).IsRequired();
            // etc.
        }
    }
}
