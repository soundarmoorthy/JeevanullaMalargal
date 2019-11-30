using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace API.Domain
{
    public class Flower
    {
        public int Id { get; set; }
        public string EnglishName { get; set; }
        public string TamilName { get; set; }
        public string BotanicalName { get; set; }
        public string Colour { get; set; }
        public string PlantType { get; set; }
        public string[] Tags { get; set; }
        public string Significance { get; set; }
        public byte[] Image { get; set; }
        public int AddedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
