namespace NetCoreApi.Models
{
    public interface IFuncionariosDatabaseSettings
    {
        string FuncionariosCollectionName {get;set;}
        string ConnectionString {get;set;}
        string DatabaseName {get;set;}
    }
}