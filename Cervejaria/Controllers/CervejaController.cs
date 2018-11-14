using Cervejaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cervejaria.Controllers
{
    public class CervejaController : Controller
    {

        // ------ Início --------

        // Cria uma lista de cervejas sem instanciar
        IList<Cerveja> cervejas;

        // Método construtor
        public CervejaController()
        {
            // Chama o método lerSessao() para pegar
            // a lista da sessão. Se não houver nada,
            // Retornará nulo.
            cervejas = lerSessao();
            // Caso retorne nulo, execute a rotina abaixo
            if (cervejas == null)
            {
                // Instancia a lista de Cerveja
                cervejas = new List<Cerveja>();


                // Cria alguns objetos do tipo Cerveja
                Cerveja c1 = new Cerveja(1, "TalerBier", "Quadrupel", 17.17);
                Cerveja c2 = new Cerveja(2, "Guinness", "Stout", 27.17);
                Cerveja c3 = new Cerveja(3, "Murphy's", "Stout", 27.17);
                Cerveja c4 = new Cerveja(4, "New Castle", "Brown Ale", 30.17);
                Cerveja c5 = new Cerveja(5, "Heineken", "Premium Lager", 4.17);


                // Insere na lista
                cervejas.Add(c1);
                cervejas.Add(c2);
                cervejas.Add(c3);
                cervejas.Add(c4);
                cervejas.Add(c5);

                // Chama o método salvarSessao passando 
                // como parâmetro a lista de cervejas criada
                // e instanciada acima. O método irá salvar
                // na sessão e, então, poderemos simular
                salvarSessao(cervejas);
            }

        }

        // Método que efetua a leitura de uma variável
        // na sessão - no nosso caso o objeto IList<Cerveja>
        public IList<Cerveja> lerSessao()
        {
            // Cria a lista "nula"
            IList<Cerveja> temp = null;
            // Se houver a variável na sessão, traga-a.
            if (System.Web.HttpContext.Current.Session != null &&
                System.Web.HttpContext.Current.Session["listaCervejas"] != null)
            {
                // Trazendo a variável da sessão e fazendo uma
                // conversão de tipo (parsing) para a instância
                // concreta List<Cerveja>
                temp = (List<Cerveja>)System.Web.HttpContext.Current.Session["listaCervejas"];

            }
            // Retorna a lista, se houver, ou nulo, se não
            // houver nada na sessão sobre...
            return temp;
        }

        // Armazena a lista na sessão
        public void salvarSessao(IList<Cerveja> cervejas)
        {
            System.Web.HttpContext.Current.Session["listaCervejas"] = cervejas;
        }


        // ------- Fim ----------

        // GET: Cerveja
        public ActionResult Index()
        {
            IList<Cerveja> lista = lerSessao();

            return View("Index" , (IEnumerable<Cerveja>) lista);
        }

        // GET: Cerveja/Details/5
        public ActionResult Details(int id)
        {
            IList<Cerveja> lista = lerSessao();
            Cerveja cerveja = lista.Where(objeto => objeto.Id == id).FirstOrDefault();

            return View("Details" , cerveja);
        }

        // GET: Cerveja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cerveja/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                IList<Cerveja> lista = lerSessao();

                Cerveja nova = new Cerveja();

                nova.Id = int.Parse(collection["Id"]);
                nova.Marca = collection["Marca"];
                nova.Estilo = collection["Estilo"];
                nova.Preco = double.Parse(collection["Preco"]);

                lista.Add(nova);

                salvarSessao(lista);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Cerveja/Edit/5
        public ActionResult Edit(int id)
        {
            IList<Cerveja> lista = lerSessao();
            Cerveja cerveja = lista.Where(objeto => objeto.Id == id).FirstOrDefault();

            return View("Edit", cerveja);
        }

        // POST: Cerveja/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                IList<Cerveja> lista = lerSessao();
                Cerveja cerveja = lista.Where(objeto => objeto.Id == id).FirstOrDefault();

                lista.Remove(cerveja);

                cerveja.Marca = collection["Marca"];
                cerveja.Estilo = collection["Estilo"];
                cerveja.Preco = double.Parse(collection["Preco"]);

                lista.Add(cerveja);

                salvarSessao(lista);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cerveja/Delete/5
        public ActionResult Delete(int id)
        {
            IList<Cerveja> lista = lerSessao();
            Cerveja cerveja = lista.Where(objeto => objeto.Id == id).FirstOrDefault();

            return View("Delete" , cerveja);
        }

        // POST: Cerveja/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                IList<Cerveja> lista = lerSessao();
                Cerveja cerveja = lista.Where(objeto => objeto.Id == id).FirstOrDefault();

                lista.Remove(cerveja);

                salvarSessao(lista);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
