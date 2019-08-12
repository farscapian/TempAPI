using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempApi.Models;
using TempApi.Services;

namespace TempApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        private readonly TempService _tempService;

        public TempController(TempService tempService)
        {
            _tempService = tempService;
        }

        [HttpGet]
        public ActionResult<List<TempItem>> Get() => _tempService.Get();


        [HttpGet("{id:length(24)}", Name = "GetTemp")]
        public ActionResult<TempItem> Get(string id)
        {
            var temp = _tempService.Get(id);

            if (temp == null)
            {
                return NotFound();
            }

            return temp;
        }

        [HttpPost]
        public ActionResult<TempItem> Create(TempItem temp)
        {
            _tempService.Create(temp);

            return CreatedAtRoute("GetTemp", new { id = temp.Id.ToString() }, temp);
        }


        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, TempItem tempIn)
        {
            var temp = _tempService.Get(id);

            if (temp == null)
            {
                return NotFound();
            }

            _tempService.Update(id, tempIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var temp = _tempService.Get(id);

            if (temp == null)
            {
                return NotFound();
            }

            _tempService.Remove(temp.Id);

            return NoContent();
        }
    }
}
