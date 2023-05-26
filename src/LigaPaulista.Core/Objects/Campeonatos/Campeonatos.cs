using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Campeonatos
{
    [DataContract]
    [Table]
    public class Campeonatos
    {
        [DataMember]
        [Column(Name = "ID_CAMPEONATO", IsPrimaryKey = true)]
        public int? IDCampeonato { get; set; }

        [DataMember]
        [Column(Name = "ID_MODALIDADE")]
        public int? IDModalidade { get; set; }

        [DataMember]
        [Column(Name = "CAM_ID_CAMPEONATO")]
        public int? CamIdCampeonato { get; set; }

        [DataMember]
        [Column(Name = "Nome")]
        public string Nome { get; set; }

        [DataMember]
        [Column(Name = "Data")]
        public DateTime Data { get; set; }

        public List<Grupos> Grupos { get; set; }
        public Modalidades Modalidade { get; set; }

    }
}
