using CrMall_Teste_Avaliacao.Context;
using CrMall_Teste_Avaliacao.Interface;
using CrMall_Teste_Avaliacao.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrMall_Teste_Avaliacao.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private CrMall_Teste_Avaliacao_Context db = new CrMall_Teste_Avaliacao_Context();

        public void Save()
        {
            db.SaveChanges();
        }

        public List<Clientes> GetAllClientes()
        {
            return db.Clientes.ToList();
        }

        public Clientes GetClientById(int? id)
        {
            return db.Clientes.Find(id);
        }

        public void AdicionarCliente(Clientes clientes)
        {
            db.Clientes.Add(clientes);
        }

        public void ClienteModificado(Clientes clientes)
        {
            db.Entry(clientes).State = EntityState.Modified;
        }

        public void DeletarCliente(Clientes clientes)
        {
            db.Clientes.Remove(clientes);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}