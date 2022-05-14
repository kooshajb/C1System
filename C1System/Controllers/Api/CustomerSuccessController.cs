using C1System.Data.CustomerSuccess;
using C1System.Dtos.CustomerSuccess;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api
{
    public class CustomerSuccessController : Controller
    {
        private readonly ICustomerSuccessRepository _customerSuccessRepository;
        public CustomerSuccessController(ICustomerSuccessRepository customerSuccessRepository)
        {
            _customerSuccessRepository = customerSuccessRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<GenericResponse<IEnumerable<GetCustomerSuccessDto>>>> GetCustomerSuccess()
        {
            var customerSuccess = await _customerSuccessRepository.Get();
            return Ok(customerSuccess.Result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomerSuccess([FromBody] AddUpdateCustomerSuccessDto dto)
        {
            if (dto == null) return BadRequest();
            var createdNewsletter = await _customerSuccessRepository.Add(dto);
            return CreatedAtAction(nameof(GetCustomerSuccess), new { id = createdNewsletter.Id }, createdNewsletter.Result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetCustomerSuccessDto>> GetCustomerSuccess(Guid id)
        {
            var CustomerSuccess = await _customerSuccessRepository.GetById(id);

            if (CustomerSuccess == null) return NotFound();

            return Ok(CustomerSuccess.Result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<GetCustomerSuccessDto>> UpdateCustomerSuccess([FromBody] AddUpdateCustomerSuccessDto dto, Guid id)
        {
            var customerSuccess = await _customerSuccessRepository.Update(id, dto);
            return Ok(customerSuccess.Result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCustomerSuccess(Guid id)
        {
            await _customerSuccessRepository.Delete(id);
            return NoContent();
        }
    }
}
