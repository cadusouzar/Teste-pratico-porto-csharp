using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teste_Empresarial.Models;

namespace Teste_Empresarial.Controllers
{
    public class MovimentacaoDeContainersController : Controller
    {
        private readonly Teste_EmpresarialContext _context;

        public MovimentacaoDeContainersController(Teste_EmpresarialContext context)
        {
            _context = context;
        }

        // GET: MovimentacaoDeContainers
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovimentacaoDeContainers.ToListAsync());
        }

        // GET: MovimentacaoDeContainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacaoDeContainer = await _context.MovimentacaoDeContainers
                .FirstOrDefaultAsync(m => m.MovementID == id);
            if (movimentacaoDeContainer == null)
            {
                return NotFound();
            }

            return View(movimentacaoDeContainer);
        }

        // GET: MovimentacaoDeContainers/Create
        public IActionResult MovimentacaoCreateOrEdit(int id = 0)
        {
            var Model = new MovimentacaoDeContainer();
            if(id != 0)
            { Model = _context.MovimentacaoDeContainers.Find(id); }

            Model.Containers = new SelectList(_context.CadastroDeContainers.ToList(), "ContainerNumber", "ContainerNumber");
            return View(Model);
        }

        // POST: MovimentacaoDeContainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MovimentacaoCreateOrEdit([Bind("MovementID,ContainerNumber,TypeOfMovement,InitialDate,FinalDate")] MovimentacaoDeContainer movimentacaoDeContainer)
        {
            if (ModelState.IsValid)
            {
                var BuscaNoBanco = _context.CadastroDeContainers.FirstOrDefault(BuscaDeContainer => BuscaDeContainer.ContainerNumber == movimentacaoDeContainer.ContainerNumber);
                movimentacaoDeContainer.CadastroDeContainer = BuscaNoBanco;
                if(movimentacaoDeContainer.MovementID == 0)
                {
                    _context.Add(movimentacaoDeContainer);
                }
                else
                {
                    _context.Update(movimentacaoDeContainer);
                }
                _context.Add(movimentacaoDeContainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movimentacaoDeContainer);
        }

        // GET: MovimentacaoDeContainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var movimentacaoDeContainer = await _context.MovimentacaoDeContainers.FindAsync(id);
            _context.MovimentacaoDeContainers.Remove(movimentacaoDeContainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool MovimentacaoDeContainerExists(int id)
        {
            return _context.MovimentacaoDeContainers.Any(e => e.MovementID == id);
        }
    }
}
