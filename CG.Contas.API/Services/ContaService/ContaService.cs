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

        public async Task<List<Conta>> Delete(Guid id)
        {
            var _conta = await _context.Conta.FindAsync(id);
            if (_conta is null) return null;

            _context.Conta.Remove(_conta);
            await _context.SaveChangesAsync();

            return await _context.Conta.ToListAsync();
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

        public async Task<List<Conta>> Update(Guid id, Conta conta)
        {
            var _conta = await _context.Conta.FindAsync(id);
            if (_conta is null) return null;

            _conta.Nome = conta.Nome;
            _conta.Descricao = conta.Descricao;

            await _context.SaveChangesAsync();

            return await _context.Conta.ToListAsync();
        }
    }
}