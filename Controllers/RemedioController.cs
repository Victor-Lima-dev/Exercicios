using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Exercicios.Context;
using Exercicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Exercicios.Controllers
{
    [Route("[controller]")]
    public class RemedioController : Controller
    {
        private readonly ILogger<RemedioController> _logger;

        private readonly AppDbContext _context;

        public RemedioController(ILogger<RemedioController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }



        [HttpGet("Index")]
        public IActionResult Index(List<Remedio> remediosSelecionados)
        {
            var SinaisClinicos = _context.SinaisClinicoss.ToList();
            var remedios = _context.Remedioss.ToList();
            //criar a RemediosViewModel
            var remediosViewModel = new RemediosViewModel
            {
                //adicionar os remedios e os sinais clinicos
                TodosRemedios = remedios,
                TodosSinaisClinicos = SinaisClinicos
            };
            //verificar se a lista de remedios selecionados é nula
            if (remediosSelecionados.Count == 0)
            {
                remediosViewModel.RemediosSelecionados = remediosViewModel.TodosRemedios;
            }
            //adicionar os remedios selecionados
            else
            {
                remediosViewModel.RemediosSelecionados = remediosSelecionados;
            }

            return View(remediosViewModel);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            var remedio = new Remedio();
            return View(remedio);
        }

        [HttpPost("Create")]
        public IActionResult Create(Remedio remedio)
        {
            //adicionar ao banco de dados

            _context.Remedioss.Add(remedio);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var SinaisClinicos = _context.SinaisClinicoss.ToList();
            var remedio = _context.Remedioss.Find(id);
            return View(remedio);
        }

        [HttpPost("Edit/{id}")]

        public IActionResult Edit(Remedio remedio)
        {
            var sinais = remedio.SinaisClinicos.ToList();

            //procurar no banco de dados os sinais que possuem id do remedio enviado

            var sinaisDoBanco = _context.SinaisClinicoss.Where(x => x.RemedioId == remedio.RemedioId).ToList();

            //remover os sinais que não estão mais na lista

            foreach (var sinal in sinaisDoBanco)
            {
                if (!sinais.Contains(sinal))
                {
                    _context.SinaisClinicoss.Remove(sinal);
                }
            }

            _context.Remedioss.Update(remedio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var remedio = _context.Remedioss.Find(id);

            //verificar se o remedio é nulo

            if (remedio == null)
            {
                return NotFound();
            }

            _context.Remedioss.Remove(remedio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("Details/{id}")]
        public IActionResult Details(int id)
        {
            var sinais = _context.SinaisClinicoss.Where(x => x.RemedioId == id).ToList();
            var remedio = _context.Remedioss.Find(id);

            //verificar se o remedio é nulo

            if (remedio == null)
            {
                return NotFound();
            }

            return View(remedio);
        }

        //HTTp GET PROCURAR/valor/tipo

        [HttpGet("Procurar/{valor}/{tipo}")]
        public IActionResult Procurar(string valor, string tipo)
        {
            //fazer um switch case para verificar o tipo

            var remediosSelecionados = new List<Remedio>();

             var SinaisClinicos = _context.SinaisClinicoss.ToList();
            var remedios = _context.Remedioss.ToList();
            //criar a RemediosViewModel
            var remediosViewModel = new RemediosViewModel
            {
                //adicionar os remedios e os sinais clinicos
                TodosRemedios = remedios,
                TodosSinaisClinicos = SinaisClinicos
            };

            switch (tipo)
            {
                case "NomeComercial":
                     remediosSelecionados = _context.Remedioss.Where(x => x.NomeComercial.Contains(valor)).ToList();
                     remediosViewModel.RemediosSelecionados = remediosSelecionados;
                     return View("Index", remediosViewModel);
                case "PrincipioAtivo":
                     remediosSelecionados = _context.Remedioss.Where(x => x.PrincipioAtivo.Contains(valor)).ToList();
                     remediosViewModel.RemediosSelecionados = remediosSelecionados;
                     return View("Index", remediosViewModel);
                case "CategoriaFarmacologica":
                     remediosSelecionados = _context.Remedioss.Where(x => x.CategoriaFarmacologica.Contains(valor)).ToList();
                     remediosViewModel.RemediosSelecionados = remediosSelecionados;
                     return View("Index", remediosViewModel);
                default:
                    return RedirectToAction("Index");
            }



         

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}