using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;

namespace SEDC.Lamazon.PerformanceCheckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public ExternalController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("performance/getorder")]
        public ActionResult<long> GetUserOrderPerformance()
        {
            string userId = "1c23cdd6-8fbd-4782-b4a5-d79e364539f5";

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for(int i=0; i<10; i++)
            {
                _orderService.GetCurrentOrder(userId);
            }
            stopwatch.Stop();
            long time = stopwatch.ElapsedMilliseconds;
            return time;
        }

    }
}
