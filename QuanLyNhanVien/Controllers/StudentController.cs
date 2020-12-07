using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanVien.Application.Interfaces;
using QuanLyNhanVien.Application.ViewModel.Student;
using QuanLyNhanVien.Data.Entitys;
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
        private IStudentServices _studentServices;
        private IMapper _mapper;
        public StudentController(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }
        //Get: API/student
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentServices.GetStudents();
            return Ok(students);
        }
        //Get: API/student/id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudentById(int id)
        {
            var student= await _studentServices.GetStudentById(id);
            return Ok(student);
        }
        //Get: APT/student/{index,sizepaging}
        [HttpGet("Paging")]
        public async Task<IActionResult> GetStudentPaging([FromQuery]int index,[FromQuery]int sizePage)
        {
            var students =await _studentServices.GetStudentPaging(index, sizePage);
            return Ok(students);
        }
        //Post: Api/student
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentViewModel entity)
        {
            await _studentServices.Add(entity);
            return Ok();
        }
        //Delete: API/student/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentServices.Remove(id);
            return Ok();
        }
        //Update :Api/student/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id,[FromBody] StudentViewModel entity)
        {
            await _studentServices.Update(id, entity);
            return Ok();

        }
    }
}
