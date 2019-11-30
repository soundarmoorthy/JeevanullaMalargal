using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace API.Domain
{
    public class InMemoryFlowersRespository : LiteDBFlowerRepository
    {
        private InMemoryFlowersRespository()
            :base(new LiteDatabase(new MemoryStream()))
        {
        }

        private static IFlowersRepository instance;
        public static IFlowersRepository Instance()
        {
            if (instance == null)
                instance = new InMemoryFlowersRespository();
            return instance;
        }



    }
}
