using API_REST.Models;
using Microsoft.AspNetCore.Mvc;
using API_REST.Data;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace API_REST.Controllers
{
    // Declaramos isso como uma ApiController.
    // Lembre-se que esse controlador é uma API por esse motivo devemos herdar de ControllerBase
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly Context context;

        public UserController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await context.User.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await context.User.FindAsync(id);

            return model == null ? NotFound() : Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(User model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
            };

            await context.User.AddAsync(result);
            await context.SaveChangesAsync();

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User model)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var result = await context.User.FindAsync(id);


            if (result == null)
                return NotFound();

            Console.WriteLine($"ID: {result.Id} | Nome: {result.UserName} | Preço: {result.Email} | Senha {result.Password}");

            try
            {
                result.UserName = model.UserName;
                result.Email = model.Email;
                result.Password = model.Password;

                context.User.Update(result);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await context.User.FindAsync(id);

            if (result == null)
                return NotFound();

            try
            {
                context.User.Remove(result);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}