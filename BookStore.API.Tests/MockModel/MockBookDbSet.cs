using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.API.Tests.MockModel
{
    public class MockBookDbSet: MockDbSet<Book>
    {
        public override Book Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.BookId == (int)keyValues.SingleOrDefault());
        }
    }
}
