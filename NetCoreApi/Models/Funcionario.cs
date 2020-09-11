using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetCoreApi.Models
{
    public class Funcionario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}
        [BsonElement("Nome")]
        public string Nome {get;set;}
        public string Empresa {get;set;}
        public string Endereco {get;set;}
        public string Cidade {get;set;}
        public string Estado {get;set;}
        public string CEP {get;set;}
        public string Pais{get;set;}
    }
}