using blazor_mysql2.Server;
using Microsoft.AspNetCore.Mvc;
using blazor_mysql2.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly AppDbContext db;

    public UserController(AppDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> Get()
    {
        var users = await db.Users.ToListAsync();
        return Ok(users);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> Get([FromQuery] string id)
    {
        var user = await db.Users.SingleOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
        return Ok(user);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Post([FromBody] User user)
    {
        try
        {
            var newUser = new User
            {
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,
                AcceptTerms = user.AcceptTerms
            };

            db.Add(newUser);
            await db.SaveChangesAsync();//INSERT INTO
            return Ok();
        }
        catch (Exception e)
        {
            return View(e);
        }
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Put([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        db.Entry(user).State = EntityState.Modified;
        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw (ex);
        }
        return NoContent();
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<ActionResult<User>> Delete(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = await db.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        db.Users.Remove(user);
        await db.SaveChangesAsync();
        return user;
    }

    private bool UserExists(int id)
    {
        return db.Users.Any(e => e.Id == id);
    }

}