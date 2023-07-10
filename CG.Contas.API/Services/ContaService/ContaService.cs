using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.Contas.API.Models;

namespace CG.Contas.API.Services.ContaService
{
    public class ContaService : IContaService
    {
        public Task<List<Conta>> Add(Conta conta)
        {
            throw new NotImplementedException();
        }

        public Task<List<Conta>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Conta>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Conta> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Conta>> Update(Guid id, Conta conta)
        {
            throw new NotImplementedException();
        }
    }
}