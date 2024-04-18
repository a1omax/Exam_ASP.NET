
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class GraduateWorkController : ControllerBase
{
	private readonly IGraduateWorkPricingService _pricingService;

	public GraduateWorkController()
	{
		_pricingService = new GraduateWorkPricingService();
	}

    [HttpPost]

    public IActionResult GetPrice(string discipline)
	{
		try
		{
			decimal price = _pricingService.GetPriceForDiscipline(discipline);
			return Ok(new { Discipline = discipline, Price = price });
		}
		catch (KeyNotFoundException ex)
		{
			return NotFound(ex.Message);
		}
		catch (Exception ex)
		{
			return StatusCode(500, ex.Message);
		}
	}
}
