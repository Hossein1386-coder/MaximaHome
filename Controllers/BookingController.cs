using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaximaHome.Data;
using MaximaHome.Models;

namespace MaximaHome.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingRequest request)
        {
            var booking = new Booking
            {
                UserId = request.UserId,
                CarModel = request.CarModel,
                ServiceType = request.ServiceType,
                AppointmentDate = request.AppointmentDate,
                AppointmentTime = request.AppointmentTime,
                Description = request.Description
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(new { message = "رزرو با موفقیت ثبت شد" });
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserBookings(int userId)
        {
            var bookings = await _context.Bookings
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return Ok(bookings);
        }

        [HttpGet("admin")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _context.Bookings
                .Include(b => b.User)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return Ok(bookings);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateBookingStatus(int id, [FromBody] UpdateStatusRequest request)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return NotFound();

            booking.Status = request.Status;
            await _context.SaveChangesAsync();

            return Ok(new { message = "وضعیت رزرو با موفقیت بروزرسانی شد" });
        }
    }

    public class BookingRequest
    {
        public int UserId { get; set; }
        public string CarModel { get; set; }
        public string ServiceType { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Description { get; set; }
    }

    public class UpdateStatusRequest
    {
        public string Status { get; set; }
    }
} 