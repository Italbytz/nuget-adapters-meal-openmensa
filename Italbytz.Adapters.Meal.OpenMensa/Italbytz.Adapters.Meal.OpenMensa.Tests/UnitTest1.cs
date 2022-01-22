using System;
using System.Threading.Tasks;
using Italbytz.Infrastructure.OpenMensa;
using Italbytz.Ports.Meal;
using NUnit.Framework;

namespace Italbytz.Adapters.Meal.OpenMensa.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task TestService()
    {
        try
        {
            var service = new OpenMensaGetMealsService();
            var collections = await service.Execute(new MockMealQuery() { Mensa = 42, Date = DateTime.Now });
            Assert.True(collections.Count > 0);
        }
        catch (System.Exception ex)
        {
            Assert.True(ex is MensaClosedException || ex is NoMealsForDateException);
        }

    }
}

internal class MockMealQuery : IMealQuery
{
    public int Mensa { get; set; }
    public DateTime Date { get; set; }
}