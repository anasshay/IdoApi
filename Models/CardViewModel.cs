using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdoApi.Models
{
    public class CardViewModel : CardModel
    {
        public ImportanceModel? Importance { get; set; }
        public StateModel? State { get; set; }
    }
}