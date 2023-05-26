using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Eventos
{
    [DataContract]
    [Table]
    public class Eventos
    {
        [DataMember]
        [Column(Name = "IdEvento", IsPrimaryKey = true)]
        public int? IdEvento { get; set; }

        [DataMember]
        [Column(Name = "Titulo")]
        public string Titulo { get; set; }

        [DataMember]
        [Column(Name = "Descricao")]
        public string Descricao { get; set; }

        [DataMember]
        [Column(Name = "DataInicio")]
        public DateTime DataInicio { get; set; }

        [DataMember]
        [Column(Name = "DataFim")]
        public DateTime DataFim { get; set; }

        [DataMember]
        [Column(Name = "Local")]
        public string Local { get; set; }

        [DataMember]
        [Column(Name = "Valor")]
        public decimal Valor { get; set; }

        [DataMember]
        [Column(Name = "Andamento")]
        public int Andamento { get; set; }

        [DataMember]
        [Column(Name = "Aprovado")]
        public int Aprovado { get; set; }

        [DataMember]
        [Column(Name = "Cancelado")]
        public int Cancelado { get; set; }

        public List<EventosDocs> Docs { get; set; }
    }
}
