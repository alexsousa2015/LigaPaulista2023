using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LigaPaulista.Core.Objects.Entidades
{
    [DataContract]
    [Table]
    public class Carteirinhas
    {
        [DataMember]
        [Column(Name = "IDPEDIDO", IsPrimaryKey = true)]
        public int? IdPedido { get; set; }

        [DataMember]
        [Column(Name = "ID_ENTIDADE")]
        public int IdEntidade { get; set; }

        [DataMember]
        [Column(Name = "DataPedido")]
        public DateTime DataPedido { get; set; }

        [DataMember]
        [Column(Name = "DataLiberacao")]
        public DateTime DataLiberacao { get; set; }

        [DataMember]
        [Column(Name = "Status")]
        public int Status { get; set; }

        [DataMember]
        [Column(Name = "Representante")]
        public string Representate { get; set; }

        [DataMember]
        [Column(Name = "ValorTotal")]
        public decimal ValorTotal { get; set; }

        [DataMember]
        [Column(Name = "Observacoes")]
        public string Observacoes { get; set; }

        [DataMember]
        [Column(Name = "ConferidaPor")]
        public string ConferidaPor { get; set; }

        [DataMember]
        [Column(Name = "RetiradaPor")]
        public string RetiradaPor { get; set; }

        [DataMember]
        [Column(Name = "RetiradaEm")]
        public DateTime RetiradaEm { get; set; }

        public List<Atletas> ListAtletas { get; set; }
        
        [DataContract]
        [Table]
        public class Atletas
        {
            [DataMember]
            [Column(Name = "IDPEDIDO")]
            public int? IdPedido { get; set; }

            [DataMember]
            [Column(Name = "ID_CADASTRO")]
            public int IdCadastro { get; set; }

            [DataMember]
            [Column(Name = "Atleta")]
            public int Atleta { get; set; }

            [DataMember]
            [Column(Name = "Federado")]
            public int Federado { get; set; }

            [DataMember]
            [Column(Name = "Dirigente")]
            public int Dirigente { get; set; }

            [DataMember]
            [Column(Name = "DataPedido")]
            public DateTime DataPedido { get; set; }

            [DataMember]
            [Column(Name = "Status")]
            public int Status { get; set; }

            [DataMember]
            [Column(Name = "Cref")]
            public string Cref { get; set; }
        }
    }
}
