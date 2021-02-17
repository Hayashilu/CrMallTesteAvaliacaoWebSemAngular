using CrMall_Teste_Avaliacao.Models;
using CrMall_Teste_Avaliacao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrMall_Teste_Avaliacao.Interface
{
    interface IClientesRepository 
    {
        void Save();
        List<Clientes> GetAllClientes();
        Clientes GetClientById(int? id);
        void AdicionarCliente(Clientes clientes);
        void ClienteModificado(Clientes clientes);
        void DeletarCliente(Clientes clientes);
        void Dispose();
    }
}
