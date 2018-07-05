using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffBee.HotelMiniProgram.Model
{
    public class RoomInfo:BaseModel
    {


        public int RoomId { get; set; }

        public int HotelId { get; set; }

        public int RoomType { get; set; }

        public string RoomTitle { get; set; }

        public string RoomAbstract { get; set; }

        public double Price { get; set; }

        public string HeaderPic { get; set; }

        public string Discount { get; set; }

        public int Stock { get; set; }

    }
}
