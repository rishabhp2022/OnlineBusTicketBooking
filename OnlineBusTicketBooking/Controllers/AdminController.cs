using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBusTicketBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace OnlineBusTicketBooking.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AdminController : ControllerBase

    {
        private readonly BusContext _dbContext;

        public AdminController(BusContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> AddBusDetails(AddBusDetailsRequest request)
        {
            AddBusDetailsResponse response = new AddBusDetailsResponse();
            AddBusDetails busDetails = new AddBusDetails
            {
                BusNumber = request.BusNumber,
                BusName = request.BusName,
                Source = request.Source,
                Destination = request.Destination,
                ScheduleDate = request.ScheduleDate,
                ScheduleTime = request.ScheduleTime
            };

            try
            {
                _dbContext.AddBusDetails.Add(busDetails);
                await _dbContext.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = "SUCCESS";
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            
            return Ok(response);
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateBusDetails(AddBusDetailsRequest request)
        {
            AddBusDetailsResponse response = new AddBusDetailsResponse();
            AddBusDetails updateDetails = new AddBusDetails
            {
                BusNumber = request.BusNumber,
                BusName = request.BusName,
                Source = request.Source,
                Destination = request.Destination,
                ScheduleDate = request.ScheduleDate,
                ScheduleTime = request.ScheduleTime
            };

            _dbContext.Entry(updateDetails).State = EntityState.Modified;
             try
                {
                    await _dbContext.SaveChangesAsync();
                    response.IsSuccess = true;
                    response.Message = "SUCCESS";
                }
             catch (DbUpdateConcurrencyException ex)
                {
                    if (!BusAvailable(request.BusName))
                    {
                        return NotFound();
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                    }

                }
                return Ok(response);
        }

       private bool BusAvailable(String name)
        {
            return (_dbContext.AddBusDetails?.Any(x => x.BusName == name)).GetValueOrDefault();
        }


       [HttpDelete("{name}")]
       public async Task<ActionResult> DeleteBusDetails(String busname)
       {
            AddBusDetailsResponse response = new AddBusDetailsResponse();
            try
            {
                if (_dbContext.AddBusDetails == null)
                {
                    return NotFound();

                }
                var bus = await _dbContext.AddBusDetails.FindAsync(busname);
                if (bus == null)
                {
                    return NotFound();
                }
                _dbContext.AddBusDetails.Remove(bus);
                await _dbContext.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
       }

    }
}
