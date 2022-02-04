using APIDomain.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        //protected readonly IMapper _mapper;
        //protected readonly INotifierService _notifier;

        //protected MainController(IMapper mapper, INotifierService notifier)
        //{
        //    _mapper = mapper;
        //    _notifier = notifier;
        //}

        //protected bool ValidOperation()
        //{
        //    if (_notifier.HasError())
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
