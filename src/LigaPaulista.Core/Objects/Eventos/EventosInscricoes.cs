using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Eventos
{
    [DataContract]
    [Table]
    public class EventosInscricoes
    {
        [DataMember]
        [Column(Name = "IdInscricao", IsPrimaryKey = true)]
        public int? IdInscricao { get; set; }

        [DataMember]
        [Column(Name = "IdEvento")]
        public int IdEvento { get; set; }

        [DataMember]
        [Column(Name = "IdCadastro")]
        public int IdCadastro { get; set; }

        [DataMember]
        [Column(Name = "DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [DataMember]
        [Column(Name = "Status")]
        public int Status { get; set; }

        [DataMember]
        [Column(Name = "CodigoPgto")]
        public string CodigoPgto { get; set; }

        [DataMember]
        [Column(Name = "Ano")]
        public int Ano { get; set; }

        [DataMember]
        [Column(Name = "Ativo")]
        public int Ativo { get; set; }

        public StatusObj ObjStatus { get; set; }
        public Eventos Evento { get; set; }
        public List<EventosInscricoesDocs> Docs { get; set; }

        public class StatusObj
        {
            public string Status { get; set; }
            public string Classe { get; set; }

        }

        public StatusObj GetStatus()
        {
            switch (Status)
            {
                case 1:
                    return new StatusObj() { Status = "Aguardando Validaçao", Classe = "" };
                case 2:
                    return new StatusObj() { Status = "Aguardando Documentos", Classe = "" };
                case 3:
                    return new StatusObj() { Status = "Documentos Confirmados", Classe = "" };
                case 4:
                    return new StatusObj() { Status = "Documentos Entregues", Classe = "" };
                case 5:
                    return new StatusObj() { Status = "Inscrição Cancelada", Classe = "" };
                default:
                    return new StatusObj() { Status = "Status N/D", Classe = "" };
            }
        }
    }
}
