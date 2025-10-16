using dev_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dev_backend.Controllers;

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
}