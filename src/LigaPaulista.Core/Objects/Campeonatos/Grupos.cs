using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Campeonatos
{
    [DataContract]
    [Table]
    public class Grupos
    {
        [DataMember]
        [Column(Name = "ID_GRUPO", IsPrimaryKey = true)]
        public int? IDGrupo { get; set; }

        [DataMember]
        [Column(Name = "Grupo")]
        public string Grupo { get; set; }

        public List<Entidades> Entidades { get; set; }
    }
}
