﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.OpenMensa
{
    public class OpenMensaGetMealsService : IGetMealsService
    {
        public OpenMensaGetMealsService()
        {
        }

        public async Task<List<IMealCollection>> Execute(IMealQuery inDTO)
        {
            var dataSource = new OpenMensaMealDataSource(inDTO.Mensa, inDTO.Date);
            var meals = await dataSource.RetrieveAll();
            var collectionsList = new List<IMealCollection>();
            var collections = meals.GroupBy(meal => meal.Category);
            foreach (var collection in collections)
            {
                var mealCollection = new OpenMensaMealCollection()
                {
                    Category = collection.Key
                };
                foreach (var meal in collection)
                {
                    mealCollection.Meals.Add(meal);
                }
                collectionsList.Add(mealCollection);
            }

            return collectionsList;
        }
    }
}

