using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Campeonatos
{
    [DataContract]
    [Table]
    public class Entidades
    {
        [DataMember]
        [Column(Name = "ID_Entidade", IsPrimaryKey = true)]
        public int? IDEntidade { get; set; }

        [DataMember]
        [Column(Name = "Entidade")]
        public string Entidade { get; set; }
    }
}
