using APIDomain.Interfaces.Services;
using APIDomain.Interfaces.Services.User;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Configuration;

namespace WebAPI.Controllers
{
    public class UsersController : MainController
    {
        //private readonly IUserService _userService;

        //public UsersController(IMapper mapper, IUserService userService, INotifierService notifier)
        //                            : base(mapper, notifier)
        //{
        //    _userService = userService;
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices]IUserService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await service.GetAll());
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
    }
}
