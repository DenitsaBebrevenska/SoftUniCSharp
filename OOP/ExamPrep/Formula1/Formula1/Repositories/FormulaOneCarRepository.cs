﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;
        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => models.AsReadOnly();
        public void Add(IFormulaOneCar model)
            => models.Add(model);

        public bool Remove(IFormulaOneCar model)
            => models.Remove(model);

        public IFormulaOneCar FindByName(string name)
            => models.FirstOrDefault(c => c.Model == name);
    }
}
