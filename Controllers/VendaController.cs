using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Final.Models;


namespace Projeto_Final.Controllers
{
    public class VendaController : Controller
    {
        private readonly Contexto _context;

        public VendaController(Contexto context)
        {
            _context = context;
        }

        // GET: Venda
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Venda.Include(v => v.cliente).Include(v => v.Pagamento).Include(v => v.Vendedor);
            return View(await contexto.ToListAsync());
        }

        // GET: Venda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.cliente)
                .Include(v => v.Pagamento)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);


            venda.ProdutoList = await _context.VendaHasProduto
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .Where(v => v.VendaId == id).ToListAsync();



            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Venda/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente");
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "Id", "FormaPagamento");
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "VendedorName");
            return View();
        }

        // POST: Venda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VendaId,VendaName,ClienteId,VendedorId,PagamentoId")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", venda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "Id", "FormaPagamento", venda.PagamentoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "VendedorName", venda.VendedorId);
            return View(venda);
        }

        // GET: Venda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", venda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "Id", "FormaPagamento", venda.PagamentoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "VendedorName", venda.VendedorId);
            return View(venda);
        }

        // POST: Venda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VendaId,VendaName,ClienteId,VendedorId,PagamentoId")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", venda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "Id", "FormaPagamento", venda.PagamentoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "VendedorName", venda.VendedorId);
            return View(venda);
        }

        // GET: Venda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.cliente)
                .Include(v => v.Pagamento)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Venda == null)
            {
                return Problem("Entity set 'Contexto.Venda'  is null.");
            }
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return (_context.Venda?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> ImpressaoVenda(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.cliente)
                .Include(v => v.Pagamento)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);


            venda.ProdutoList = await _context.VendaHasProduto
                .Include(v => v.Produto)
                .Where(v => v.VendaId == id)
                .GroupBy(v => new { v.ProdutoId })
                .Select(vp => vp.OrderByDescending(v => v.ProdutoId).First())
                .ToListAsync();


            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }
    }
}