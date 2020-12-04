using QuanLyNhanVien.Application.Interfaces;
using QuanLyNhanVien.Data.Entitys;
using QuanLyNhanVien.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien.Application.Implements
{
    public class StudentServices: IStudentServices
    {
        private readonly IStudentRepository _repository;

        public StudentServices(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(Student entity)
        {
            await _repository.Add(entity);
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _repository.GetStudentById(id);
        }

        public async Task<List<Student>> GetStudentPaging(int index, int sizePage)
        {
            return await _repository.GetStudentPaging(index, sizePage);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _repository.GetStudents();
        }

        public async Task Remove(int id)
        {
            await _repository.Remove(id);
        }

        public async Task Update(int id, Student entity)
        {
            await _repository.Update(id, entity);
        }
    }
}
