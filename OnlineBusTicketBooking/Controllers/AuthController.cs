using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineBusTicketBooking.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineBusTicketBooking.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BusContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthController(BusContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(SignUpRequest request)
        {
            Response response = new Response();
            if (!request.Password.Equals(request.ConfirmPassword))
            {
                response.IsSuccess = false;
                response.Message = "Password & Confirm Password not Match";
            }
            Userdetails users = new Userdetails
            {
                UserName = request.UserName,
                Gender = request.Gender,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                Contact = request.Contact,
                Password = request.Password,
                Role = request.Role
            };
            try
            {
                //_logger.LogInformation($"SignUp Calling In AdminController.... Time : {DateTime.Now}");
                _dbContext.Userdetails.Add(users);
                await _dbContext.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                //_logger.LogError("Exception Occur In AuthController : Message : ", ex.Message);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            try
            {
                //_logger.LogInformation($"SignIn Calling In AdminController.... Time : {DateTime.Now}");
                var signin = await _dbContext.Userdetails.FirstOrDefaultAsync(x => x.UserName == request.UserName && x.Password == request.Password && x.Role == request.Role);
                if (signin == null)
                {
                    return NotFound();
                }
                else
                {
                    SignIn signIn = new SignIn
                    {
                        Role = request.Role,
                        UserId = signin.UserID != null ? signin.UserID : -1,
                        InsertionDate = signin.InsertionDate != null ? Convert.ToDateTime(signin.InsertionDate).ToString("dddd, dd-MM-yyyy, HH:mm tt") : string.Empty,
                        UserName = signin.UserName != null ? signin.UserName : string.Empty,
                        Gender = signin.Gender != null ? signin.Gender : string.Empty,
                        DateOfBirth = signin.DateOfBirth != null ? signin.DateOfBirth : string.Empty,
                        Email = signin.Email != null ? signin.Email : string.Empty,
                        Address = signin.Address != null ? signin.Address : string.Empty,
                        Contact = signin.Contact != null ? signin.Contact : string.Empty

                    };
                    response.data = signIn;
                    response.IsSuccess = true;
                    response.Message = "Login Successfully";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Login Unsuccessfully";
                //_logger.LogError("Exception Occur In AuthController : Message : ", ex.Message);

            }

            // token code
            if (response.IsSuccess)
            {
                string Type = string.Empty;
                if (response.data.Role.ToLower().Equals("admin"))
                {
                    Type = "Admin Login";
                }
                else
                {
                    Type = "User Login";
                }

                //response = await CreateToken(response, Type);
            }

            return Ok(response);
        }

        //Method to create JWT token
        //private Task<SignInResponse> CreateToken(SignInResponse request, string Type)
        //{
        //    try
        //    {
        //        var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //        var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

        //        var claims = new List<Claim>();
        //        claims.Add(new Claim(ClaimTypes.Role, request.data.Role));
        //        claims.Add(new Claim("EmailID", request.data.ToString()));
        //        claims.Add(new Claim("UserId", request.data.UserId.ToString()));
        //        claims.Add(new Claim("TokenType", Type));

        //        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
        //            _configuration["Jwt:Audiance"],
        //            claims,
        //            expires: DateTime.Now.AddHours(1),
        //            signingCredentials: signingCreds);
        //        request.data.Token = new JwtSecurityTokenHandler().WriteToken(token);

        //    }
        //    catch (Exception ex)
        //    {
        //        request.IsSuccess = false;
        //        request.Message = "Exception Occur In Token Creation : Message : " + ex.Message;
        //        //_logger.LogError("Exception Occur In Token Creation : Message : ", ex.Message);
        //    }
        //    return Task.FromResult(request);
        //}

    }
}
