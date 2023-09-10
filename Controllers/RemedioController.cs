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
        public IActionResult Index()
        {
            var SinaisClinicos = _context.SinaisClinicoss.ToList();
            var remedios = _context.Remedioss.ToList();
            return View(remedios);
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




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}