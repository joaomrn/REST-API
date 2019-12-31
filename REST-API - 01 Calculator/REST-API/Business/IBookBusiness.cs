using RESTAPI.Model;
using System.Collections.Generic;

namespace RESTAPI.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(int id);
    }
}
