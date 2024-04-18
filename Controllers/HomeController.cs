using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
	private readonly IGraduateWorkPricingService _pricingService;


    public HomeController()
	{
		_pricingService = new GraduateWorkPricingService();

	}

	public IActionResult Index()
	{
		return View();
	}

	[HttpPost]
	public IActionResult GetPrice(string discipline)
	{
		try
		{
			decimal price = _pricingService.GetPriceForDiscipline(discipline);
			ViewBag.Price = price;
		}
		catch (KeyNotFoundException)
		{
			ViewBag.ErrorMessage = "Дисципліна не знайдена";
		}
		catch (Exception ex)
		{
			ViewBag.ErrorMessage = ex.Message;
		}

		return View("PriceResult");
	}


    [HttpPost]
    public IActionResult GetPassDisciplinePrice(string discipline)
    {
        try
        {
            decimal price = _pricingService.GetPriceForDiscipline(discipline);
            ViewBag.Price = price;
        }
        catch (KeyNotFoundException)
        {
            ViewBag.ErrorMessage = "Дисципліна не знайдена";
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
        }

        return View("PriceResult");
    }

}
