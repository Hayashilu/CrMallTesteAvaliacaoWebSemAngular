using CrMall_Teste_Avaliacao.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CrMall_Teste_Avaliacao.Context
{
    public class CrMall_Teste_Avaliacao_Context : DbContext
    {
        public CrMall_Teste_Avaliacao_Context() : base("name=InformacoesClientes")
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
    }
}
