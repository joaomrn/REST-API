using System.Collections.Generic;

namespace RESTAPI.Data.Converter
{
    //O => Objeto de origem
    //D => Objeto de destino
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}
