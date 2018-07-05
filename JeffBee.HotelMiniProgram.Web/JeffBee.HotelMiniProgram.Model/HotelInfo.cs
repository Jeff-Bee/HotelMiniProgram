using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffBee.HotelMiniProgram.Model
{
    public class HotelInfo:BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abstract { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

    }
}
