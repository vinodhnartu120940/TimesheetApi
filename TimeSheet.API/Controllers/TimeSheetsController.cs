using TimeSheets.API.Data;
using TimeSheets.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TimeSheets.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeSheetsController:Controller
    {
        private readonly TimeSheetsDbContext timeSheetsDbContext;
        public TimeSheetsController(TimeSheetsDbContext TimeSheetsDbContext)
        {
            this.timeSheetsDbContext = TimeSheetsDbContext;
        }

        //Post TimeSheet
        [HttpPost]
        public async Task<IActionResult> PostTimeSheet(TimeSheet timeSheet)
        {
            //timeSheet.EmployeeID = timeSheet.EmployeeID;
            await timeSheetsDbContext.TimeSheets.AddAsync(timeSheet);
            await timeSheetsDbContext.SaveChangesAsync();
            return Ok(timeSheet);
        }

        //Get TimeSheet
        [HttpGet]
        [Route("{EmployeeID}")]
        public async Task<IActionResult> GetTimeSheet([FromRoute] string EmployeeID)
        {
            var timeSheet = await timeSheetsDbContext.TimeSheets.FirstOrDefaultAsync(x => x.EmployeeID == EmployeeID);
            if (timeSheet != null)
            {
                return Ok(timeSheet);
            }
            return NotFound("Card not found");
        }
    }
}
