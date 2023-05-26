using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace LigaPaulista.Core.Objects.Entidades
{
    [DataContract]
    [Table]
    public class Entidades
    {
        [DataMember]
        [Column(Name = "ID_ENTIDADE", IsPrimaryKey = true)]
        public int? IdEntidade { get; set; }
        
        [DataMember]
        [Column(Name = "ENTIDADE")]
        public string Entidade { get; set; }
        
        [DataMember]
        [Column(Name = "FILIADA")]
        public string Filiada { get; set; }
        
        [DataMember]
        [Column(Name = "CNPJ")]
        public string Cnpj { get; set; }
        
        [DataMember]
        [Column(Name = "ENDERECO")]
        public string Endereco { get; set; }
        
        [DataMember]
        [Column(Name = "NUMERO")]
        public string Numero { get; set; }
        
        [DataMember]
        [Column(Name = "COMPLEMENTO")]
        public string Complemento { get; set; }
        
        [DataMember]
        [Column(Name = "BAIRRO")]
        public string Bairro { get; set; }
        
        [DataMember]
        [Column(Name = "CIDADE")]
        public string Cidade { get; set; }
        
        [DataMember]
        [Column(Name = "ESTADO")]
        public string Estado { get; set; }
        
        [DataMember]
        [Column(Name = "CEP")]
        public string Cep { get; set; }
        
        [DataMember]
        [Column(Name = "TELEFONE")]
        public string Telefone { get; set; }
        
        [DataMember]
        [Column(Name = "CELULAR")]
        public string Celular { get; set; }
        
        [DataMember]
        [Column(Name = "SITE")]
        public string Site { get; set; }
        
        [DataMember]
        [Column(Name = "EMAIL")]
        public string Email { get; set; }
        
        [DataMember]
        [Column(Name = "Representante Legal")]
        public string RepresentanteLegal { get; set; }
        
        [DataMember]
        [Column(Name = "Telefone Legal")]
        public string TelefoneLegal { get; set; }
        
        [DataMember]
        [Column(Name = "Email Legal")]
        public string EmailLegal { get; set; }
        
        [DataMember]
        [Column(Name = "Representante 1")]
        public string Representante1 { get; set; }
        
        [DataMember]
        [Column(Name = "Telefone 1")]
        public string Telefone1 { get; set; }
        
        [DataMember]
        [Column(Name = "Email 1")]
        public string Email1 { get; set; }
        
        [DataMember]
        [Column(Name = "Representante 2")]
        public string Representante2 { get; set; }
        
        [DataMember]
        [Column(Name = "Telefone 2")]
        public string Telefone2 { get; set; }
        
        [DataMember]
        [Column(Name = "Email 2")]
        public string Email2 { get; set; }
        
        [DataMember]
        [Column(Name = "Representante 3")]
        public string Representante3 { get; set; }
        
        [DataMember]
        [Column(Name = "Telefone 3")]
        public string Telefone3 { get; set; }
        
        [DataMember]
        [Column(Name = "Email 3")]
        public string Email3 { get; set; }
        
        [DataMember]
        [Column(Name = "Titulo")]
        public string Senha { get; set; }
    }
}
