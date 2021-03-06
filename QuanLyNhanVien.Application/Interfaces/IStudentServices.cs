﻿using QuanLyNhanVien.Data.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien.Application.Interfaces
{
    public interface IStudentServices
    {
        Task Add(Student entity);
        Task Remove(int id);
        Task Update(int id, Student entity);
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<List<Student>> GetStudentPaging(int index, int sizePage);
    }
}
