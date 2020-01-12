using RESTAPI.Data.Converters;
using RESTAPI.Data.VO;
using RESTAPI.Model;
using RESTAPI.Repository.Generic;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace RESTAPI.Business.Implementattions
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO PersonVO)
        {
            var personEntity = _converter.Parse(PersonVO);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }
        public List<PersonVO> FindByName(string fristName, string lastName)
        {
            return _converter.ParseList(_repository.FindByName(fristName, lastName));
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO PersonVO)
        {
            var personEntity = _converter.Parse(PersonVO);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;
            string query = @"SELECT * FROM persons p WHERE 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) query = query + $" AND p.Nome LIKE '%{name}%'";
            query = query + $" ORDER BY p.Nome {sortDirection} LIMIT {pageSize} OFFSET {page}";

            string coutQuery = @"SELECT count(*) FROM persons p WHERE 1 = 1";
            if (!string.IsNullOrEmpty(name)) coutQuery = coutQuery + $" AND p.nome LIKE '%{name}%'";

            var persons = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(coutQuery);

            return new PagedSearchDTO<PersonVO>
            {
                CurrentPage = page,
                List = _converter.ParseList(persons),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }
    }
}
