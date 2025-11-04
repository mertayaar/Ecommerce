using Ecommerce.Review.Context;
using Ecommerce.Review.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Review.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewContext _context;

        public ReviewsController(ReviewContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ReviewList()
        {
            var values = _context.UserReviews.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateReview(UserReview userReview)
        {
            _context.UserReviews.Add(userReview);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteReview(int id)
        {
            var value = _context.UserReviews.Find(id);
            _context.UserReviews.Remove(value);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateReview(UserReview userReview)
        {
            _context.UserReviews.Update(userReview);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetReview(int id)
        {
            var value = _context.UserReviews.Find(id);
            return Ok(value);
        }


    }
}
