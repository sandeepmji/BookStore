using BookStore.API.Controllers;
using BookStore.Models;
using BookStore.Service;
using NUnit.Framework;
using System;
using BookStore.API.Tests.MockModel;

namespace BookStore.API.Tests
{
    [TestFixture]
    public class BooksControllerTest
    {
        private BooksController _booksController;

        [SetUp]
        public void TestSetup()
        {
            MockBookStoreDataContext mockBookStoreDataContext = new MockBookStoreDataContext();
            mockBookStoreDataContext.Books = new MockBookDbSet() { new Book() { AuthorId = 3, BookId = 1 } };
            _booksController = new BooksController(new BookService(mockBookStoreDataContext));
        }

        [TestCase]
        public void TestMethod1()
        {
            Book book = _booksController.GetBook(1);

            //Assert
            Assert.AreEqual("1", book.Author);
        }
    }
}
