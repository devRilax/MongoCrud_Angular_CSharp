using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Entities;
using BookLibrary.BLL.Repositories;

namespace BookLibrary.BLL.BusinessImplementation
{
    public class BookBLL
    {
        private readonly BookRepository bookRepository = new BookRepository();

        public void Upsert(Book entity)
        {
            validateBook(entity);

            if (entity._id == null)
            {
                bookRepository.Create(entity);
            }
            else
            {
                bookRepository.Update(entity);
            }
        }

        public Book GetById(string id)
        {
            return bookRepository.FindById(id);
        }

        public void Remove(string id)
        {
            bookRepository.Remove(id);
        }

        public List<Book> All()
        {

            return bookRepository.All();
        }



        private void validateBook(Book entity)
        {
            if (string.IsNullOrEmpty(entity.Title))
            {
                throw new BLLException("Must enter a valid title");
            }

            if (string.IsNullOrEmpty(entity.Description))
            {
                throw new BLLException("Must enter a valid description");
            }

            if (entity.Year == 0)
            {
                throw new BLLException("Must enter a valid year");
            }

            if (entity.Authors.Count() == 0)
            {
                throw new BLLException("Must enter authors");
            }
        }
    }
}
