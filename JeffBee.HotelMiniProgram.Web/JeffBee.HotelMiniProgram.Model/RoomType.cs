using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffBee.HotelMiniProgram.Model
{
    public class RoomType:BaseModel
    {
        public int RoomTypeId { get; set; }

        public string RoomTypeName { get; set; }

        public string RoomTypeCode { get; set; }

        public int ParendId { get; set; }

    }
}
