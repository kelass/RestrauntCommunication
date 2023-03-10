using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Core.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        
        public string Message { get; set; }
        public string TableName { get; set; }
        public Guid UserId { get; set; }
    }
}
