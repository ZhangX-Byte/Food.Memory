using System;
using System.Threading.Tasks;
using FoodMemory.SharedKernel.Messaging;
using FoodMemory.UserDomain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace FoodMemory.Api.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public HomeController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpGet]
        public async Task Create()
        {
            try
            {
                await _commandBus.Send(new UserCreateCommand(Guid.NewGuid(), "张三", "zhangsan", "123456"));
            }
            catch (Exception ex)
            {
            }
        }
    }
}