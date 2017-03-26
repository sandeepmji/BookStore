using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class BookDetailsDTO : BookDTO
    {
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
