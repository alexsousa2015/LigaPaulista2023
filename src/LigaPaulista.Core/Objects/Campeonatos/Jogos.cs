using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Campeonatos
{
    [DataContract]
    [Table]
    public class Jogos
    {
        [DataMember]
        [Column(Name = "ID_JOGO", IsPrimaryKey = true)]
        public int? IDJogo { get; set; }

        [DataMember]
        [Column(Name = "Data")]
        public DateTime Data { get; set; }

        [DataMember]
        [Column(Name = "Hora")]
        public string Hora { get; set; }

        [DataMember]
        [Column(Name = "Time1")]
        public int Time1 { get; set; }

        [DataMember]
        [Column(Name = "PLACAR_TIME1")]
        public int PlacarTime1 { get; set; }

        [DataMember]
        [Column(Name = "PLACAR_TIME2")]
        public int PlacarTime2 { get; set; }

        [DataMember]
        [Column(Name = "Time2")]
        public int Time2 { get; set; }

        [DataMember]
        [Column(Name = "ID_LOCALIDADE")]
        public int IDLocalidade { get; set; }

        [DataMember]
        [Column(Name = "ID_GRUPO")]
        public int IDGrupo { get; set; }

        [DataMember]
        [Column(Name = "ID_MODALIDADE")]
        public int IDModalidade { get; set; }

        [DataMember]
        [Column(Name = "ID_CAMPEONATO")]
        public int IDCampeonato { get; set; }

        [DataMember]
        [Column(Name = "Observacoes")]
        public string Observacoes { get; set; }

        public Entidades TimeCasa { get; set; }
        public Entidades TimeVisitante { get; set; }

        public Localidades Local { get; set; }

        public Modalidades Modalidade { get; set; }

        public Grupos Grupo { get; set; }

        public Campeonatos Campeonato { get; set; }

    }
}
