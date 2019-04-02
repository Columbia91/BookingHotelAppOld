using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotelApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
/*Standart - стандартный номер состоящий из одной комнаты.

Bedroom - номер со спальней. Номер состоит из двух комнат. В одной из них стоит кровать.

Luxe - номер из двух и более жилых комнат и полного санузла; рассчитан на проживание одного-двух человек.

 King Suite - роскошные номера отеля, состоящие из нескольких комнат, спален, туалетов.*/
