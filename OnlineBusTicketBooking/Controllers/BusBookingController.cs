using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OnlineBusTicketBooking.Models;
using System.Collections.Generic;

namespace OnlineBusTicketBooking.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BusBookingController : ControllerBase
    {
        private readonly BusContext _dbContext;

        public BusBookingController(BusContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> InsertSourceDestinationDetails(InsertSourceDestinationDetails request)
        {
            AddBusDetailsResponse response = new AddBusDetailsResponse();

            AddBusDetails userDetails = new AddBusDetails
            {
                BusNumber = request.BusNumber,
                BusName = request.BusName,
                Source = request.Source,
                Destination = request.Destination,
                TicketPrice = request.TicketPrice
        };

            try
            {
                _dbContext.AddBusDetails.Add(userDetails);
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


        [HttpPost]
        public async Task<ActionResult> GetSourceDestinationDetails(GetSourceDestinationDetailsRequest request)
        {
            AddBusDetailsResponse response = new AddBusDetailsResponse();

            try
            {
                var bus = await _dbContext.AddBusDetails.FirstOrDefaultAsync(x => x.Source == request.Source && x.Destination == request.Destination);
                if (bus == null)
                {
                    return NotFound();
                }
                response.data = await _dbContext.AddBusDetails.Where(x => x.Source == request.Source && x.Destination == request.Destination).ToListAsync();
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

        [HttpPatch]
        public async Task<ActionResult> UpdateSeatStatus(UpdateSeatStatusRequest request)
        {
            AddBusDetailsResponse response = new AddBusDetailsResponse();
            var busDetails = await _dbContext.AddBusDetails.FirstOrDefaultAsync(x => x.id == request.ID);
            if (busDetails != null)
            {
                if (request.SeatNo == 1)
                    busDetails.Seat1 = request.Status;
                else if (request.SeatNo == 2)
                    busDetails.Seat2 = request.Status;
                else if (request.SeatNo == 3)
                    busDetails.Seat3 = request.Status;
                else if (request.SeatNo == 4)
                    busDetails.Seat4 = request.Status;
                else if (request.SeatNo == 5)
                    busDetails.Seat5 = request.Status;
                else if (request.SeatNo == 6)
                    busDetails.Seat6 = request.Status;
                else if (request.SeatNo == 7)
                    busDetails.Seat7 = request.Status;
                else if (request.SeatNo == 8)
                    busDetails.Seat8 = request.Status;
                else if (request.SeatNo == 9)
                    busDetails.Seat9 = request.Status;
                else if (request.SeatNo == 10)
                    busDetails.Seat10 = request.Status;
            }
            else
            {
                return NotFound();
            }

            try
            {
                    _dbContext.Entry(busDetails).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    response.IsSuccess = true;
                    response.Message = "SUCCESS";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                //_logger.LogError("Exception Occur In BusBookingController : Message : ", ex.Message);
            }

            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult> InsertRefreshmentsDetails(AddRefreshmentRequest request)
        {
            Models.Response InsertRefreshmentsDetailsResponse = new Models.Response();
            RefreshmentsDetails resprestmentDetails = new RefreshmentsDetails
            {
                UserID = request.UserID,
                Item = request.Item,
                Quantity = request.Quantity,
                Price = request.Price,
                Total = request.Total
            };
            try
            {
                //_logger.LogInformation($"InsertRefreshmentsDetails Calling In AdminController.... Time : {DateTime.Now}");
                _dbContext.RefreshmentsDetails.Add(resprestmentDetails);
                await _dbContext.SaveChangesAsync();
                InsertRefreshmentsDetailsResponse.IsSuccess = true;
                InsertRefreshmentsDetailsResponse.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                InsertRefreshmentsDetailsResponse.IsSuccess = false;
                InsertRefreshmentsDetailsResponse.Message = ex.Message;
                //_logger.LogError("Exception Occur In BusBookingController : Message : ", ex.Message);
            }

            return Ok(InsertRefreshmentsDetailsResponse);
        }

        [HttpGet]
        public async Task<ActionResult> GetRefreshmentsDetails(int userID)
        {
            GetRefreshmentsDetailsResponse response = new GetRefreshmentsDetailsResponse();
            try
            {
                var refresh = await _dbContext.RefreshmentsDetails.FirstOrDefaultAsync(x => x.UserID == userID);
                if (refresh == null)
                {
                    return NotFound();
                }
                response.data = await _dbContext.RefreshmentsDetails.Where(x => x.UserID == userID).ToListAsync();
                response.IsSuccess = true;
                response.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                //_logger.LogError("Exception Occur In GetRefreshmentsDetails : Message : ", ex.Message);
            }

            return Ok(response);
        }
        
        
        [HttpDelete]
        public async Task<ActionResult> DeleteRefreshmentsItem( int ID)
        {
            Models.Response response = new Models.Response();
            try
            {
                var refresh = await _dbContext.RefreshmentsDetails.FindAsync(ID);
                if (refresh == null)
                {
                    return NotFound();
                }
                _dbContext.RefreshmentsDetails.Remove(refresh);
                await _dbContext.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                //_logger.LogError("Exception Occur In GetRefreshmentsDetails : Message : ", ex.Message);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> TicketConfirmation(TicketConfirmationRequest request)
        {
            Models.Response response = new Models.Response();
            TicketDetails ticketDetails = new TicketDetails
            {
                Name = request.Name,
                Contact = request.Contact,
                Email = request.Email,
                StartDateTime = request.StartDateTime,
                EndDateTime = request.EndDateTime,
                BusName = request.BusName,
                BusNumber = request.BusNumber,
                SeatNumber = request.SeatNumber,
                Value = request.Value,
                UserID = request.UserID,
                TotalAmount = request.TotalAmount,
                PaymentType = request.PaymentType,
                CardNumber = request.CardNumber,
                CVV = request.CVV,
                Expiry = request.Expiry
            };
            try
            {
                //_logger.LogInformation($"TicketConfirmation Calling In AdminController.... Time : {DateTime.Now}");
               _dbContext.TicketDetails.Add(ticketDetails);
                await _dbContext.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                //_logger.LogError("Exception Occur In TicketConfirmation : Message : ", ex.Message);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> GetUserTicketDetails(int userID)
        {
            GetUserTicketDetailsResponse response = new GetUserTicketDetailsResponse();
            try
            {
                //_logger.LogInformation($"GetUserTicketDetails Calling In AdminController.... Time : {DateTime.Now}");
                var user = await _dbContext.TicketDetails.FirstOrDefaultAsync(x => x.UserID == userID);
                if (user == null)
                {
                    return NotFound();
                }
                response.data = await _dbContext.TicketDetails.Where(x => x.UserID == userID).ToListAsync();
                response.IsSuccess = true;
                response.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                //_logger.LogError("Exception Occur In GetUserTicketDetails : Message : ", ex.Message);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CancelTicket(int ticketId)
        {
            Models.Response response = new Models.Response();
            try
            {
                //_logger.LogInformation($"CancelTicket Calling In AdminController.... Time : {DateTime.Now}");
                var userticket = await _dbContext.TicketDetails.FindAsync(ticketId);
                if (userticket == null)
                {
                    return NotFound();
                }
                _dbContext.TicketDetails.Remove(userticket);
                await _dbContext.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
               // _logger.LogError("Exception Occur In CancelTicket : Message : ", ex.Message);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> InsertFeedback(InsertFeedbackRequest request)
        {
            Models.Response response = new Models.Response();
            FeedDetails feedDetails = new FeedDetails
            {
                UserID = request.UserID,
                JourneyExperience = request.JourneyExperience,
                Comment = request.Comment,
                Rate = request.Rate
            };
            try
            {
                //_logger.LogInformation($"InsertFeedback Calling In AdminController.... Time : {DateTime.Now}");
                _dbContext.FeedDetails.Add(feedDetails);
                await _dbContext.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                //_logger.LogError("Exception Occur In InsertFeedback : Message : ", ex.Message);
            }

            return Ok(response);
        }


    }
}
