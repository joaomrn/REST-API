using RESTAPI.Data.VO;
using System.Collections.Generic;

namespace RESTAPI.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(int id);
    }
}
