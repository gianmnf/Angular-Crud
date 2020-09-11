namespace NetCoreApi.Models
{
    public class FuncionariosDatabaseSettings:IFuncionariosDatabaseSettings
    {
        public string FuncionariosCollectionName {get;set;}
        public string ConnectionString {get;set;}
        public string DatabaseName {get;set;}
    }       
}