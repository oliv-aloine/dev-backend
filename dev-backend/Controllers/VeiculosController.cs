using dev_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dev_backend.Controllers;

[Authorize]
public class VeiculosController : Controller
{
    private readonly AppDbContext _context;

    public VeiculosController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var dados = await _context.Veiculos.ToListAsync();

        return View(dados);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Veiculo veiculo)
    {
        if (ModelState.IsValid)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        return View();
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var veiculo = await _context.Veiculos.FindAsync(id);

        if (veiculo == null)
            return NotFound();

        return View(veiculo);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Veiculo veiculo)
    {
        if (id != veiculo.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        return View();
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var veiculo = await _context.Veiculos.FindAsync(id);

        if (veiculo == null)
            return NotFound();

        return View(veiculo);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var veiculo = await _context.Veiculos.FindAsync(id);

        if (veiculo == null)
            return NotFound();

        return View(veiculo);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id == null)
            return NotFound();

        var veiculo = await _context.Veiculos.FindAsync(id);

        if (veiculo == null)
            return NotFound();

        _context.Veiculos.Remove(veiculo);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Relatorio(int? id)
    {
        if (id == null)
            return NotFound();

        var veiculo = await _context.Veiculos.FindAsync(id);

        if (veiculo == null)
            return NotFound();

        var consumos = await _context.Consumos
            .Where(c => c.VeiculoId == veiculo.Id)
            .OrderByDescending(c => c.Data)
            .ToListAsync();

        var total = consumos.Sum(c => c.Valor);

        ViewBag.Veiculo = veiculo;
        ViewBag.Total = total;

        return View(consumos);
    }
}