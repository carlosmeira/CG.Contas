using CG.Contas.API.Models;

namespace CG.Contas.API.Services.ContaService;

public interface IContaService
{
    public Task<List<Conta>> GetAll();

    public Task<Conta> GetById(Guid id);

    public Task<List<Conta>> Add(Conta conta);

    public Task<List<Conta>> Update(Guid id, Conta conta);

    public Task<List<Conta>> Delete(Guid id);

}
