using BincomAssignmentFour.Data;
using BincomAssignmentFour.Models;
using BincomAssignmentFour.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BincomAssignmentFour.Controllers
{
    //localhost:xxxxx/api/pictures
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PictureController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllPictures()
        {
            return Ok(dbContext.Pictures.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetPictureById(Guid id)
        {
            var picture = dbContext.Pictures.Find(id);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(picture);
        }

        [HttpPost]
        public IActionResult AddPicture(Picture addPictureIfy)
        {
            var pictureEntity = new Picture()
            {
                FirstName = addPictureIfy.FirstName,
                LastName = addPictureIfy.LastName,
                PhoneNumber = addPictureIfy.PhoneNumber,
                Email = addPictureIfy.Email
 
            };

            dbContext.Pictures.Add(pictureEntity);
            dbContext.SaveChanges();

            return Ok(pictureEntity);
        }

        [HttpPut]
        [Route("id:guid")]
        public IActionResult UploadPicture(Guid id, UploadPicture uploadPicture)
        {
            var picture = dbContext.Pictures.Find(id);
            if (picture is null)
            {
                return NotFound();
            }

            picture.FirstName = uploadPicture.FirstName;
            picture.LastName = uploadPicture.LastName;
            picture.PhoneNumber = uploadPicture.PhoneNumber;
            picture.Email = uploadPicture.Email;

            dbContext.SaveChanges();

            return Ok(picture);
        }

        [HttpDelete]
        [Route("id:guid")]
        public IActionResult DeletePicture(Guid id)
        {
            var picture = dbContext.Pictures.Find(id);
            if(picture is null)
            {
                return NotFound();
            }

            dbContext.Pictures.Remove(picture);
            dbContext.SaveChanges();

            return Ok();
             
        }
    }
}
