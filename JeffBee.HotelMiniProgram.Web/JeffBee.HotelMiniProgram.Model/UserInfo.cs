using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffBee.HotelMiniProgram.Model
{
    public class UserInfo:BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public string Phone { get; set; }

        public string IdCard { get; set; }
    }
}
