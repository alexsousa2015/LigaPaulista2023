using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Campeonatos
{
    [DataContract]
    [Table]
    public class Periodos
    {
        [DataMember]
        [Column(Name = "ID_Periodo", IsPrimaryKey = true)]
        public int? IDPeriodo { get; set; }

        [DataMember]
        [Column(Name = "Ano")]
        public int Ano { get; set; }

        [DataMember]
        [Column(Name = "Periodo")]
        public string Periodo { get; set; }
    }
}
