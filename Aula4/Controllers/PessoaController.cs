using Aula4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace Aula4.Controllers
{
    public class PessoaController : Controller
    {
        // GET: PessoaController
        public ActionResult Index()
        {
            var lista = LerLista();

            return View(lista);
        }

        private List<Pessoa> LerLista()
        {
            List<Pessoa> lista;
            string pessoas = HttpContext.Session.GetString("pessoas");

            if (String.IsNullOrEmpty(pessoas))
                lista = IniciarLista();
            else
            {
                lista = JsonConvert.DeserializeObject<List<Pessoa>>(pessoas);
                if (lista.Count == 0)
                    IniciarLista();
            }

            return lista;
        }

        private List<Pessoa> IniciarLista()
        {
            List<Pessoa> lista = Pessoa.Lista;
            AtualizarLista(lista);
            return lista;
        }

        private void AtualizarLista(List<Pessoa> lista)
        {
            string pessoas = JsonConvert.SerializeObject(lista);
            HttpContext.Session.SetString("pessoas", pessoas);
        }







        //public ActionResult Index()
        //{
        //    var lista = new List<Pessoa>();
        //    lista.Add(new Pessoa { Nome = "Renato", Idade=20 });
        //    lista.Add(new Pessoa { Nome = "Vinicius", Idade=21 });

        //    var json = JsonConvert.SerializeObject(lista);

        //    this.HttpContext.Session.SetString("lista", json);

        //    var meu_json = HttpContext.Session.GetString("lista");
        //    var lista2 = JsonConvert.DeserializeObject<List<Pessoa>>(meu_json);

        //    return View(lista2);
        //}

        // GET: PessoaController/Details/5
        public ActionResult Details(int index)
        {
            return View(Pessoa.Lista[index]);
        }

        // GET: PessoaController/Create
        public ActionResult Create()
        {
            return View(new Pessoa());
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            try
            {
                var lista = LerLista();
                lista.Add(pessoa);
                AtualizarLista(lista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaController/E-dit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pessoa pessoa)
        {
            try
            {
                var lista = LerLista();
                lista[id] = pessoa;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PessoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
