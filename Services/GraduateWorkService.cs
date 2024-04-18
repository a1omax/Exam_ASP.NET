
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public interface IGraduateWorkPricingService
{
	decimal GetPriceForDiscipline(string discipline);
}

public class GraduateWorkPricingService : IGraduateWorkPricingService
{
	// Приклад простої бази даних, де зберігаються ціни за дисципліни
	private readonly Dictionary<string, decimal> _disciplinePrices = new Dictionary<string, decimal>
{
	{ "Computer Science", 1000 },
	{ "Mathematics", 800 },
	{ "Physics", 900 },
};

	public decimal GetPriceForDiscipline(string discipline)
	{
		// Перевірка, чи є дисципліна в базі даних цін
		if (_disciplinePrices.ContainsKey(discipline))
		{
			return _disciplinePrices[discipline];
		}
		else
		{
			throw new KeyNotFoundException("Дисципліна не знайдена");
		}
	}
}