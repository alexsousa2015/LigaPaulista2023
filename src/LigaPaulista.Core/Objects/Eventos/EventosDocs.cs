using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Eventos
{
    [DataContract]
    [Table]
    public class EventosDocs
    {
        [DataMember]
        [Column(Name = "IdEventoDoc", IsPrimaryKey = true)]
        public int? IdEventoDoc { get; set; }

        [DataMember]
        [Column(Name = "IdEvento")]
        public int IdEvento { get; set; }

        [DataMember]
        [Column(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}
