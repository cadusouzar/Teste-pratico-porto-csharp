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
    public class CadastroDeContainersController : Controller
    {
        private readonly Teste_EmpresarialContext _context;

        public CadastroDeContainersController(Teste_EmpresarialContext context)
        {
            _context = context;
        }

        // GET: CadastroDeContainers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroDeContainers.ToListAsync());
        }

        // GET: CadastroDeContainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroDeContainer = await _context.CadastroDeContainers
                .FirstOrDefaultAsync(m => m.ContainerID == id);
            if (cadastroDeContainer == null)
            {
                return NotFound();
            }

            return View(cadastroDeContainer);
        }

        // GET: CadastroDeContainers/Create
        public IActionResult CadastroCreateOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new CadastroDeContainer());
            }
            else
            {
                return View(_context.CadastroDeContainers.Find(id));
            }
        }

        // POST: CadastroDeContainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroCreateOrEdit([Bind("ContainerID,FullName,ContainerNumber,Type,Status,Category")] CadastroDeContainer cadastroDeContainer)
        {
            if (ModelState.IsValid)
            {
                if(cadastroDeContainer.ContainerID == 0)
                {
                    _context.Add(cadastroDeContainer);
                }
                else
                {
                    _context.Update(cadastroDeContainer);
                }
                _context.Add(cadastroDeContainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(cadastroDeContainer);
        }

        // GET: CadastroDeContainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var cadastroDeContainer = await _context.CadastroDeContainers.FindAsync(id);
            _context.CadastroDeContainers.Remove(cadastroDeContainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CadastroDeContainerExists(int id)
        {
            return _context.CadastroDeContainers.Any(e => e.ContainerID == id);
        }
    }
}
