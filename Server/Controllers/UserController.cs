using blazor_mysql2.Server;
using Microsoft.AspNetCore.Mvc;
using blazor_mysql2.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            await db.SaveChangesAsync();
            return Ok();
        }
        catch(Exception e)
        {
            return View(e);
        }
    }

    [HttpGet]
    [Route("Teste")]
    public async Task<ActionResult> PostTeste()
    {
        try
        {
            var user2 = new User();
            user2.Title = "Sr";
            user2.FirstName = "Asdrubal";
            user2.MiddleName = "A";
            user2.LastName = "Iohanson";
            user2.DateOfBirth = DateTime.Today;
            user2.Email = "teste1@mail.com";
            user2.Password = "123456";
            user2.ConfirmPassword = "123456";
            user2.AcceptTerms = true;

            db.Add(user2);
            await db.SaveChangesAsync();
            return Ok(await db.Users.ToListAsync());
        }
        catch
        {
            return null;
        }
    }


}