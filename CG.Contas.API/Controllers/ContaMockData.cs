using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.Contas.API.Models;

namespace CG.Contas.API.Controllers
{
    public class ContaMockData
    {
        public static List<Conta> GetAll()
        {
            return new List<Conta>()
            {
                new Conta() {
                    Id = new Guid("189ebae2-7e76-436d-a605-f8d31c9a6b1e"),
                    Nome = "Bruce Wayne",
                    Descricao = "Batman"
                },
                new Conta() {
                    Id = new Guid("cb095c30-7681-41c4-b9c8-9b0538aac416"),
                    Nome = "Carlos Meira",
                    Descricao = "Developer"
                },
                new Conta() {
                    Id = new Guid("41de124c-c932-4d83-9d99-41c585b656d3"),
                    Nome = "Bruce Banner",
                    Descricao = "Hulk"
                }
            };
        }

        public static Conta? GetById(Guid id) {
            return GetAll().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}