using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Core.Dto
{
    public class BasketDto
    {
      public Guid TableId { get; set; }
      public List<Basket> BasketList { get; set; }
      public decimal Price { get; set; }
    }
}
