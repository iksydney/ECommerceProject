using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregates
{
    public class DeliveryMethod : BaseEntity<int>
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string DeliveryTime { get; set; }
    }
}
