using NetCoreApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreApi.Services
{
    public class FuncionarioService
    {
        private readonly IMongoCollection<Funcionario> _funcionarios;

        public FuncionarioService(IFuncionariosDatabaseSettings settings)
        {
            var cliente = new MongoClient(settings.ConnectionString);
            var db = cliente.GetDatabase(settings.DatabaseName);

            _funcionarios = db.GetCollection<Funcionario>(settings.FuncionariosCollectionName);
        }

        public List<Funcionario> Get() {
            return _funcionarios.Find(funcionario => true).ToList();
        }

        public Funcionario Get(string id) {
            return _funcionarios.Find<Funcionario>(funcionario => funcionario.Id == id).FirstOrDefault();
        }            

        public Funcionario Create(Funcionario funcionario)
        {
            _funcionarios.InsertOne(funcionario);
            return funcionario;
        }

        public void Update(string id, Funcionario func){
            _funcionarios.ReplaceOne(funcionario => funcionario.Id == id, func);
        }

        public void Remove(Funcionario func) {
            _funcionarios.DeleteOne(funcionario => funcionario.Id == func.Id);
        }

        public void Remove(string id) {
            _funcionarios.DeleteOne(funcionario => funcionario.Id == id);
        }
    }
}