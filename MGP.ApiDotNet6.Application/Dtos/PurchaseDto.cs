using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGP.ApiDotNet6.Application.Dtos
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PersonId { get; set; }
        public DateTime Date { get; set; }
    }
}
