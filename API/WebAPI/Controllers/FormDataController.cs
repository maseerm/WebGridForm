using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormDataController : ControllerBase
    {
        private readonly IFormServices _formService;
        public FormDataController(IFormServices formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFormData(int formId)
        {
            try
            {
                var formData = await _formService.GetFormData(formId);
                if (formData == null)
                {
                    return NotFound();
                }

                return Ok(formData);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddFormData([FromBody] FormData formData)
        {
            try
            {
                var availableformDataList = await _formService.GetFormData(formData.FormId);
                if (availableformDataList.Count < 50)
                {
                    var formDataId = await _formService.AddFormData(formData);
                    if (formDataId > 0)
                    {

                        return CreatedAtAction("AddFormData", formDataId);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else {
                    return BadRequest();
                }
            }
            catch (Exception )
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateFormData([FromBody] FormData formData)
        {
            int result;
            try
            {
                result = await _formService.UpdateFormData(formData);
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

        [HttpDelete]
        public async Task<IActionResult> DeleteFormData(int formDataId)
        {
            int result;
            try
            {
                result = await _formService.DeleteFormData(formDataId);
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
