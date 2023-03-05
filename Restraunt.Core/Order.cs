using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Core
{
    public class Order
    {
        public Guid Id { get; set; }
       // public Table Table { get; set; }
        public string Message { get; set; }
        public string TableName { get; set; }
        public User User { get; set; }
    }
}
