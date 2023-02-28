using MS.Shared.Entities;

namespace MS.Services
{
    public interface IMSClient
    {
        Task<IEnumerable<Machine>?> GetAllAsync();
        Task<Machine> GetAsync(string id);
        Task<Machine?> PostAsync(CreateMachine createMachine);
        Task<bool> PutAsync(Machine machine);
        Task<bool> RemoveAsync(string id);
    }
}