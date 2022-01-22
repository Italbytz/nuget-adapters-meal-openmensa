﻿using System;
using System.Collections.Generic;
using Italbytz.Ports.Meal;

namespace Italbytz.Adapters.Meal.OpenMensa
{
    public class OpenMensaMealCollection : IMealCollection
    {
        public OpenMensaMealCollection()
        {
        }

        public Category Category { get; set; }
        public List<IMeal> Meals { get; set; }
    }
}
