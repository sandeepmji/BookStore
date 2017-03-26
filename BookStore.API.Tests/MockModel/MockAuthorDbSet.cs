using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.API.Tests.MockModel
{
    public class MockAuthorDbSet: MockDbSet<Author>
    {
        public override Author Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.AuthorId == (int)keyValues.SingleOrDefault());
        }
    }
}
