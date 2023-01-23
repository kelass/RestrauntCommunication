using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Core.Dto
{
    public class TableDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public User? User { get; set; }
    }
}
