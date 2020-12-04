using Microsoft.AspNetCore.Mvc;
using QuanLyNhanVien.Application.Interfaces;
using QuanLyNhanVien.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanVien.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        //Get: API/get
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentRepository.GetStudents();
            return Ok(students);
        }
    }
}
