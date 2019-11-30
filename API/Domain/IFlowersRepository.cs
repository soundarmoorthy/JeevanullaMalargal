using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Domain
{
    public interface IFlowersRepository
    {
        IEnumerable<Flower> Values { get; }

        bool ContainsKey(int id);
        Flower Get(int id);
        void Add(Flower flower);
        void Update(int id, Flower flower);
        void Remove(int id);
    }
}
