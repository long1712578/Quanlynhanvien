using QuanLyNhanVien.Data.Entitys;
using QuanLyNhanVien.Data.IRepository;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuanLyNhanVien.Data.EF.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbStudentContext _context;
        public StudentRepository(DbStudentContext context)
        {
            _context = context;
        }

        public async Task Add(Student entity)
        {
            _context.Students.Add(entity);
             await _context.SaveChangesAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            return student;
        }

        public async Task<List<Student>> GetStudentPaging(int index, int sizePage)
        {
            var query = from st in _context.Students
                        select new { st };
            int totalRow = await query.CountAsync();
            var data = await query.Skip((index - 1) * sizePage)
                                   .Take(sizePage)
                                   .Select(x => new Student()
                                   {
                                       id = x.st.id,
                                       code = x.st.code,
                                       gender = x.st.gender,
                                       firstName = x.st.firstName,
                                       lastName = x.st.lastName,
                                       dob = x.st.dob,
                                       mail = x.st.mail,
                                       phone = x.st.phone,
                                       picture = x.st.picture,

                                   }).ToListAsync();
            return data;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var student =await GetStudentById(id);
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id,Student entity)
        {
            var student = await GetStudentById(id);
            student.id = entity.id;
            student.code = entity.code;
            student.gender = entity.gender;
            student.firstName = entity.firstName;
            student.lastName = entity.lastName;
            student.dob = entity.dob;
            student.mail = entity.mail;
            student.phone = entity.phone;
            student.picture = entity.picture;
            await _context.SaveChangesAsync();
        }
    }
}
