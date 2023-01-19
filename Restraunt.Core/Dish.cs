using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Core
{
    public class Dish:EntityBase
    {
        public string Description { get; set; }

        public int Price { get; set; }
    }
}
