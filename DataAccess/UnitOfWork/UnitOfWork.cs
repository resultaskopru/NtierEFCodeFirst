using Data.Context;
using Data.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {

        }
        public void Dispose()
        {

        }
        private DbContext _context { get; set; }
        public DbContext Context
        {
            get
            {
                if (_context == null)
                    _context = new MasterContext();
                return _context;
            }
        }

        public Repository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(Context);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
        public List<Book> BookAndWriterJoin()
        {
            var result = from p in GetRepository<Book>().GetAll()
                         join c in GetRepository<Writer>().GetAll()
                         on p.WriterId equals c.WriterId
                         select new Book()
                         {
                             BookId = p.BookId,
                             BookName = p.BookName,
                             BookShelf = p.BookShelf,
                             WriterId = p.WriterId,
                             Writer = new Writer
                             {
                                 WriterId = c.WriterId,
                                 WriterName = c.WriterName,
                                 WriterLastName = c.WriterLastName
                             }
                         };
            return result.ToList();

        }
        public Book BookAndWriterJoin(int id)
        {
            Book book = new Book();
            book = GetRepository<Book>().Get(id);
            book.Writer = GetRepository<Writer>().Get(book.WriterId);

            return book;
        }
        public List<Book> BookAndWriterJoin(string text)
        {
            var result = from p in GetRepository<Book>().GetAll(x => x.BookName.Contains(text)).OrderBy(x => x.BookId)
                         join c in GetRepository<Writer>().GetAll()
                         on p.WriterId equals c.WriterId
                         select new Book()
                         {
                             BookId = p.BookId,
                             BookName = p.BookName,
                             BookShelf = p.BookShelf,
                             WriterId = p.WriterId,
                             Writer = new Writer
                             {
                                 WriterId = c.WriterId,
                                 WriterName = c.WriterName,
                                 WriterLastName = c.WriterLastName
                             }
                         };
            return result.ToList();
            //MasterContext master = new MasterContext(); //Kenan abi böyle istiyor

            //var temp = master.Book.Include("Writer").Select(x => new Book()
            //{
            // BookId = x.BookId,
            // BookName = x.BookName,
            // BookShelf = x.BookShelf,
            // WriterId = x.WriterId,
            // Writer = new Writer()
            // {
            // WriterId = x.Writer.WriterId,
            // WriterName = x.Writer.WriterName
            // }
            //}).SingleOrDefault(y => y.BookId == id);

            //return temp;


        }
    }
}
