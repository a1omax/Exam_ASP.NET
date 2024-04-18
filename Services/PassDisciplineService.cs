
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public interface IPassDisciplineService
{
	decimal GetPriceForGrade(string grade);
}

public class PassDisciplineService : IPassDisciplineService
{
	// Приклад простої бази даних, де зберігаються ціни за дисципліни
	private readonly Dictionary<string, decimal> _disciplinePrices = new Dictionary<string, decimal>
{
	{ "A", 600 },
	{ "B", 500 },
	{ "C", 400 },
	{ "D", 300 },
    { "E", 279 },
};

	public decimal GetPriceForGrade(string grade)
	{
		// Перевірка, чи є дисципліна в базі даних цін
		if (_disciplinePrices.ContainsKey(grade))
		{
			return _disciplinePrices[grade];
		}
		else
		{
			throw new KeyNotFoundException("Оцінка не знайдена");
		}
	}
}