using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;

[Route("/menu")]
[ApiController]
public class ProductController : Controller {
    private IMenuInterface db = new MenuCollection();

    [HttpGet]
    public async Task<IActionResult> GetAllMenus() {
        return Ok(await db.GetAllMenus());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMenuById(string id) {
        var menu = await db.GetMenuById(id);
        if (menu == null) {
            return BadRequest();
        };

        return Ok(menu);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Menu menu) {
        if (menu == null) return BadRequest();
        
        await db.PostMenu(menu);

        return Created("Created", true);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMenu([FromBody] Menu menu, string id) {
        if (menu == null) {
            return BadRequest();
            };
        
        menu.Id = id;
        await db.UpdateMenu(menu);

        return Created("Updated", true);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenu(string id) {

        await db.DeleteMenu(id);

        return NoContent();
    }

}