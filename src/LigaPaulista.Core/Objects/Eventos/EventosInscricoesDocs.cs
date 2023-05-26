using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Eventos
{
    [DataContract]
    [Table]
    public class EventosInscricoesDocs
    {
        [DataMember]
        [Column(Name = "IdDoc", IsPrimaryKey = true)]
        public int? IdDoc { get; set; }

        [DataMember]
        [Column(Name = "IdInscricao")]
        public int IdInscricao { get; set; }

        [DataMember]
        [Column(Name = "IdEventoDoc")]
        public int IdEventoDoc { get; set; }

        [DataMember]
        [Column(Name = "Arquivo")]
        public string Arquivo { get; set; }

        [DataMember]
        [Column(Name = "DataHora")]
        public DateTime DataHora { get; set; }

        [DataMember]
        [Column(Name = "Status")]
        public int Status { get; set; }
    }
}
