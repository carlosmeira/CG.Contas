using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.Contas.API.Data;
using CG.Contas.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CG.Contas.API.Services.ContaService
{
    public class ContaService : IContaService
    {
        private readonly DataContext _context;
        public ContaService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Conta>> Add(Conta conta)
        {
            _context.Conta.Add(conta);
            await _context.SaveChangesAsync();
            return await _context.Conta.ToListAsync();
        }

        public Task<List<Conta>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Conta>> GetAll()
        {
            var conta = await _context.Conta.ToListAsync();
            return conta;
        }

        public async Task<Conta> GetById(Guid id)
        {
            var conta = await _context.Conta.FindAsync(id);
            return conta;

        }

        public Task<List<Conta>> Update(Guid id, Conta conta)
        {
            throw new NotImplementedException();
        }
    }
}