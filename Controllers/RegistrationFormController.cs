using fullStackTask.Models;
using FullStackTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationFormController : ControllerBase
    {

        public readonly RegistrationFormContext _context;

        public RegistrationFormController(RegistrationFormContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<RegistrationForm>>> GetAllRegistrationDetails()
        {
            if(_context.registrationForm == null)
            {
                return NotFound();
            }
            return await _context.registrationForm.ToListAsync();
        }

 
       [HttpGet("{id}")]

        public async Task<ActionResult<IEnumerable<RegistrationForm>>> GetRegistrationDetailsById(int id)
        {
            if (_context.registrationForm == null)
            {
                return NotFound();
            }

            var registrationForm = await _context.registrationForm.FindAsync(id);
            if(registrationForm == null)
            {
                return NotFound();
            }
            return Ok( registrationForm);
        }


        [HttpPost]

        public async Task<ActionResult<IEnumerable<RegistrationForm>>> PostRegistrationDetails(RegistrationForm registrationForm)
        {
            
            if (_context.registrationForm == null)
            {
                return NotFound();
            }

             var email = registrationForm.Email;

            var duplicate = (from d in _context.registrationForm
                            where d.Email == email 
                             select d).ToList();

            if (duplicate.Count >= 1)
            {
               var warning = "Duplicate Email Found !!";
               throw new InvalidOperationException(warning);


            }


            _context.registrationForm.Add(registrationForm);
            await _context.SaveChangesAsync();
            return Ok(registrationForm);
        }

     


        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<RegistrationForm>>> UpdateForm(int id, RegistrationForm updated_form)
        {
            var _form = _context.registrationForm.Find(id);
            if (_form == null)
            {
                return NotFound();
            }

            var existemail = updated_form.Email;

            var email = updated_form.Email;

            var duplicate = (from d in _context.registrationForm
                             where d.Email != _form.Email && d.Email  == existemail
                             select d).ToList();

            if (duplicate.Count >= 1)
            {
                var warning = "Duplicate Email Found !!";
                throw new InvalidOperationException(warning);


            }



            _form.Name = updated_form.Name;
            _form.FName = updated_form.FName;
            _form.Email = updated_form.Email;
            _form.Phone_no = updated_form.Phone_no;
            _form.Age = updated_form.Age;
            _form.Gender = updated_form.Gender;
            _form.Category = updated_form.Category;
            _form.Occupation = updated_form.Occupation;
            _form.Experience = updated_form.Experience;
            _form.CTC = updated_form.CTC;
            _form.No_of_employee = updated_form.No_of_employee;
            _form.Type = updated_form.Type;





            _context.SaveChanges();
            return Ok(_form);
            // return Ok(_class);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<IEnumerable<RegistrationForm>>> DeleteForm(int id)
        {
            var _form = _context.registrationForm.Find(id);
            if (_form == null)
            {
                return NotFound();

            }
          

            _context.registrationForm.Remove(_form);
            _context.SaveChanges();
            return NoContent();


        }
    }
}
