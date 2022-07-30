using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdoApi.Models
{
    public class CardViewModel : Card
    {
        public Importance? Importance { get; set; }
        public State? State { get; set; }
    }
}