using blazor_mysql2.Server;
using Microsoft.AspNetCore.Mvc;
using blazor_mysql2.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class CategoriaController : Controller
{
    private readonly AppDbContext db;

    public CategoriaController(AppDbContext db)
    {
        this.db = db; //Injeção de Dependência!!!
    }

    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> Get()
    {
        var categorias = await db.Categories.ToListAsync();
        return Ok(categorias);
    }

    // [HttpGet]
    // [Route("GetById")]
    // public async Task<IActionResult> Get([FromQuery] string id)
    // {
    //     var product = await db.Products.SingleOrDefaultAsync(x => x.ProductId == Convert.ToInt32(id));
    //     return Ok(product);
    // }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Post([FromBody] Categoria categoria)
    {
        try
        {
            var newCategoria = new Categoria
            {
                Name = categoria.Name,
                Description = categoria.Description,
            };

            db.Add(newCategoria);
            await db.SaveChangesAsync();//INSERT INTO
            return Ok();
        }
        catch (Exception e)
        {
            return View(e);
        }
    }

    // [HttpPut]
    // [Route("Update")]
    // public async Task<IActionResult> Put([FromBody] Product product)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }

    //     db.Entry(product).State = EntityState.Modified;
    //     try
    //     {
    //         await db.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException ex)
    //     {
    //         throw (ex);
    //     }
    //     return NoContent();
    // }

    // [HttpDelete]
    // [Route("Delete/{id}")]
    // public async Task<ActionResult<User>> Delete(int id)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }
    //     var product = await db.Products.FindAsync(id);
    //     if (product == null)
    //     {
    //         return NotFound();
    //     }
    //     db.Products.Remove(product);
    //     await db.SaveChangesAsync();
    //     return Ok(product);
    // }


}