using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Campeonatos
{
    [DataContract]
    [Table]
    public class Artilharia
    {
        [DataMember]
        [Column(Name = "ID_Artilheiro", IsPrimaryKey = true)]
        public int? IDArtilheiro { get; set; }

        [DataMember]
        [Column(Name = "ID_Categoria")]
        public int IDCategoria { get; set; }

        [DataMember]
        [Column(Name = "ID_Entidade")]
        public int IDEntidade { get; set; }

        [DataMember]
        [Column(Name = "Nome")]
        public string Nome { get; set; }

        [DataMember]
        [Column(Name = "Gols")]
        public int Gols { get; set; }

        public Categorias Categoria { get; set; }

        public Periodos Periodo { get; set; }
        
        public Entidades Entidade { get; set; }

        [DataContract]
        [Table]
        public class Categorias
        {
            [DataMember]
            [Column(Name = "ID_Categoria", IsPrimaryKey = true)]
            public int? IDCategoria { get; set; }

            [DataMember]
            [Column(Name = "ID_Periodo")]
            public int IDPeriodo { get; set; }

            [DataMember]
            [Column(Name = "Categoria")]
            public string Categoria { get; set; }

            public Periodos Periodo { get; set; }
        }
    }
}
