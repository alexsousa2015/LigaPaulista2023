using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Campeonatos
{
    [DataContract]
    [Table]
    public class Modalidades
    {
        [DataMember]
        [Column(Name = "ID_MODALIDADE", IsPrimaryKey = true)]
        public int? IDModalidade { get; set; }

        [DataMember]
        [Column(Name = "Modalidade")]
        public string Modalidade { get; set; }

        [DataMember]
        [Column(Name = "Imagem")]
        public string Imagem { get; set; }
    }
}
