using RESTAPI.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace RESTAPI.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO PersonVO);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        List<PersonVO> FindByName(string fristName, string lastName);
        PersonVO Update(PersonVO PersonVO);
        void Delete(int id);
        PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
