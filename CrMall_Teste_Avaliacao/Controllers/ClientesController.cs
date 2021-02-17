using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrMall_Teste_Avaliacao.Context;
using CrMall_Teste_Avaliacao.Interface;
using CrMall_Teste_Avaliacao.Models;
using CrMall_Teste_Avaliacao.Repository;
using MySql.Data.MySqlClient;

namespace CrMall_Teste_Avaliacao.Controllers
{
    public class ClientesController : Controller
    {
        private IClientesRepository clientesRepository;

        public ClientesController()
        {
            this.clientesRepository = new ClientesRepository();
        }

        public ActionResult Index()
        {
            try
            {
                return View(clientesRepository.GetAllClientes());
            }
            catch (Exception ex)
            {
                TempData["Titulo"] = "Erro";
                TempData["mensagem"] = "Algo ocorreu errado, ocorreu o erro" + ex.Message;
                return View();
            }
        }

        public ActionResult Create()
        {

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Selecione o sexo que você se indentifica", Value = null, Selected = true });

            items.Add(new SelectListItem { Text = "Masculino", Value = "Masculino" });

            items.Add(new SelectListItem { Text = "Feminino", Value = "Feminino" });

            items.Add(new SelectListItem { Text = "Não Binario", Value = "Não Binario"});

            items.Add(new SelectListItem { Text = "Prefiro não dizer", Value = "Prefiro Não Dizer" });

            items.Add(new SelectListItem { Text = "Outros", Value = "Outros" });

            ViewBag.TipoSexo = items;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                clientesRepository.AdicionarCliente(cliente);
                clientesRepository.Save();
                TempData["Titulo"] = "Sucesso";
                TempData["mensagem"] = "Cliente cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Titulo"] = "Erro";
                TempData["mensagem"] = "Não foi possivel salvar o cliente, tente novamente";
                return View(cliente);
            }          
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["Titulo"] = "Erro";
                TempData["mensagem"] = "Algo deu errado, tente novamente!";
                return RedirectToAction("Index");
            }
            Clientes clientes = clientesRepository.GetClientById(id);
            if (clientes == null)
            {
                TempData["Titulo"] = "Erro";
                TempData["mensagem"] = "Cliente não encontrado!";
                return RedirectToAction("Index");
            }
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Selecione o sexo que você se indentifica", Value = null});

            items.Add(new SelectListItem { Text = "Masculino", Value = "Masculino" });

            items.Add(new SelectListItem { Text = "Feminino", Value = "Feminino" });

            items.Add(new SelectListItem { Text = "Não Binario", Value = "Não Binario" });

            items.Add(new SelectListItem { Text = "Prefiro não dizer", Value = "Prefiro Não Dizer" });

            items.Add(new SelectListItem { Text = "Outros", Value = "Outros" });

            ViewBag.TipoSexo = items;

            return View(clientes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                clientesRepository.ClienteModificado(clientes);
                clientesRepository.Save();
                TempData["Titulo"] = "Sucesso";
                TempData["mensagem"] = "Cliente editado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                TempData["Titulo"] = "Erro";
                TempData["mensagem"] = "Algo deu errado, tente novamente!";
                return RedirectToAction("Index");
            }
            Clientes clientes = clientesRepository.GetClientById(id);
            if (clientes == null)
            {
                TempData["Titulo"] = "Erro";
                TempData["mensagem"] = "Cliente não encontrado!";
                return RedirectToAction("Index");
            }
            clientesRepository.DeletarCliente(clientes);
            clientesRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                clientesRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
