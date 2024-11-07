using CalcApp.Server.Models;

namespace CalcApp.Server.Repositories
{
    public class OperationRepository
    {
        private static IDictionary<string, OperationModel> Operations = new Dictionary<string, OperationModel>();
        public void AddUser(OperationModel model)
        {
            Operations[model.Id.ToString()] = model;
        }
        public OperationModel? GetById(uint id)
        {
            return Operations.TryGetValue(id.ToString(), out var operation) ? operation : throw new Exception("This operation isn't exist");
        }
    }
}
