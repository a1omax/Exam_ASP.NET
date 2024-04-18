
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class PassDisciplineController : ControllerBase
{
    private readonly IPassDisciplineService _passDisciplineService;

    public PassDisciplineController()
    {
        _passDisciplineService= new PassDisciplineService();
    }

    [HttpPost]

    public IActionResult GetPriceForGrade(string grade)
    {
        try
        {
            decimal price = _passDisciplineService.GetPriceForGrade(grade);
            return Ok(new { Grade = grade, Price = price });
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
