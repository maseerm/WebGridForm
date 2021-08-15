using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly IFormServices _formService;
        public FormsController(IFormServices formService)
        {
            _formService = formService;
        }

        [HttpPost]
        public async Task<IActionResult> AddForm([FromBody] Form form)
        {
            try
            {
                var formId = await _formService.AddForm(form);
                if (formId > 0)
                {

                    return CreatedAtAction("AddForm", formId);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetForms()
        {
            try
            {
                var forms = await _formService.GetForms();
                if (forms == null)
                {
                    return NotFound();
                }

                return Ok(forms);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteForm(int formId)
        {
            int result;
            try
            {
                result = await _formService.DeleteForm(formId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
