using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain
{
    public class LiteDBFlowerRepository : IFlowersRepository
    {
        protected LiteDatabase database;
        protected LiteCollection<Flower> flowers;
        public IEnumerable<Flower> Values => flowers.FindAll();

        protected LiteDBFlowerRepository(LiteDatabase database)
        {
            this.database = database;
            flowers = database.GetCollection<Flower>();
        }


        public bool ContainsKey(int id)
        {
            return flowers.Exists((f) => f.Id == id);
        }

        public Flower Get(int id)
        {
            return flowers.FindOne((x) => x.Id == id);
        }

        public void Add(Flower flower)
        {
            flowers.Insert(flower);
        }

        public void Update(int id, Flower flower)
        {
            flowers.Update(flower);
        }

        public void Remove(int id)
        {
            flowers.Delete((x) => x.Id == id);
        }
    }
}
