﻿using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace RESTAPI.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Genero { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
