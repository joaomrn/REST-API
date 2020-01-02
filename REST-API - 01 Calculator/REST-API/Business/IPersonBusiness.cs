using RESTAPI.Data.VO;
using System.Collections.Generic;

namespace RESTAPI.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO PersonVO);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO PersonVO);
        void Delete(int id);
    }
}
