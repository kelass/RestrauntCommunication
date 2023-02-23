using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Core
{
    public class Table:EntityBase
    {
       public string? Link { get; set; }
       public User? User { get; set; }
    }
}
