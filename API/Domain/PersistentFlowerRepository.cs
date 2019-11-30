using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain
{
    public class PersistentFlowerRepository : LiteDBFlowerRepository
    {
        private PersistentFlowerRepository()
            : base(new LiteDatabase(File()))
        {

        }

        private static FileStream File()
        {
            return System.IO.File.Open(
                            Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                typeof(Flower).FullName), System.IO.FileMode.OpenOrCreate);
        }

        private static IFlowersRepository instance;
        public static IFlowersRepository Instance()
        {
            if (instance == null)
                instance = new PersistentFlowerRepository();
            return instance;
        }
    }
}
