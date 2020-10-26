using blazor_mysql2.Server;
using Microsoft.AspNetCore.Mvc;
using blazor_mysql2.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class PedidoController : Controller
{
    private readonly AppDbContext db;

    public PedidoController(AppDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> Get()
    {
        var detalhesPedidos = await db.DetalhePedido.ToListAsync();
        return Ok(detalhesPedidos);
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
    public async Task<ActionResult> Post([FromBody] PedidoDto dp)
    {
        try
        {
            var pedido = new Pedido{
                DataPedido = DateTime.Now,
                Usuario = null
            };

            var newDp = new DetalhePedido
            {
                Pedido = pedido,
                Produto = db.Products.FirstOrDefault(c => c.ProductId == Convert.ToInt32(dp.ProdutoId)),
                Quantidade = dp.Quantidade
            };

            db.Add(newDp);
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