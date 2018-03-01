using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookLibrary.Entities;
using BookLibrary.BLL.BusinessImplementation;
using BookLibrary.API.Filters;


namespace BookLibrary.API.Controllers
{
    [RoutePrefix("api/books")]
    public class BookController : ApiController
    {
        private BookBLL bllBook = new BookBLL();

        [HttpGet]
        [Route("getById/{id}")]
        public IHttpActionResult GetById(string id)
        {
            return Ok<Book>(bllBook.GetById(id));
        }

        [HttpGet]
        [Route("remove/{id}")]
        public IHttpActionResult Remove(string id)
        {

            bllBook.Remove(id);
            return Ok<string>("successful");

        }


        [ExceptionHandlingFilter]
        [HttpPost]
        [Route("upsert")]
        public IHttpActionResult Create(Book book)
        {

            bllBook.Upsert(book);
            return Ok<Book>(book);

        }

        [ExceptionHandlingFilter]
        [HttpGet]
        [Route("all")]
        public IHttpActionResult All()
        {
            var result = bllBook.All();
            return Ok<IList<Book>>(result);

        }



    }
}