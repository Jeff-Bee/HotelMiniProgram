using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffBee.HotelMiniProgram.Model
{
    public class OrderInfo:BaseModel
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public int RoomId { get; set; }

        public double Price { get; set; }

        public DateTime InTime { get; set; }

        public DateTime LeaveTime { get; set; }

        public DateTime RealLeaveTime { get; set; }

    }
}
