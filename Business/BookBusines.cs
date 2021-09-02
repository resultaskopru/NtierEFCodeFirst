using Data.Models;
using Data.Context;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Business
{
    public class BookBusines
    {
        public List<Book> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.BookAndWriterJoin();
            }
        }
        public List<Book> GetAllWithCondiction(string text)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.BookAndWriterJoin(text);
            }
        }
        public Book Get(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.BookAndWriterJoin(id);
            }
        }
        public string Add(Book book)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.GetRepository<Book>().Add(book);
                int save = unitOfWork.SaveChanges();
                if (save > 0)
                    return "successful";
                else
                    return "Failed";
            }
        }
        public string Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.GetRepository<Book>()
                    .Delete(unitOfWork.GetRepository<Book>().Get(id));
                int save = unitOfWork.SaveChanges();
                if (save > 0)
                    return "Successful";
                else
                    return "Failed";
            }
        }
        public string Update(Book book)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.GetRepository<Book>().Update(book);
                int save = unitOfWork.SaveChanges();
                if (save > 0)
                    return "Successful";
                else
                    return "Failed";
            }
        }
        



        
    }
}
