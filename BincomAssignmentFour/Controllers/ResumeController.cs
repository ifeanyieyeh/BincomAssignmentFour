using BincomAssignmentFour.Data;
using BincomAssignmentFour.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BincomAssignmentFour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ResumeController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllResume()
        {
            return Ok(dbContext.Resumes.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetResumeById(Guid id) 
        {
            var resume = dbContext.Resumes.Find(id);
            if (resume == null) 
            {
                return NotFound();
            }
            return Ok(resume);
        }

        [HttpPost]
        public IActionResult AddResume(AddResumeDto addResume)
        {
            var resumeEntity = new Resume()
            {
                FirstName = addResume.FirstName,
                LastName = addResume.LastName,
                Email = addResume.Email,
                PhoneNumber = addResume.PhoneNumber,
                ExecutiveSummary = addResume.ExecutiveSummary,
                WorkExperience = addResume.WorkExperience,
                Projects = addResume.Projects,
            };

            dbContext.Resumes.Add(resumeEntity);
            dbContext.SaveChanges();

            return Ok(resumeEntity);
        }
    }
}
