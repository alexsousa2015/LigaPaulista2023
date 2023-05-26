using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Campeonatos
{
    [DataContract]
    [Table]
    public class Localidades
    {
        [DataMember]
        [Column(Name = "ID_LOCALIDADE", IsPrimaryKey = true)]
        public int? IDLocalidade { get; set; }

        [DataMember]
        [Column(Name = "LOCALILDADE")]
        public string Localidade { get; set; }
    }
}
