using Microsoft.AspNetCore.Mvc;
using dotenv.net;

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
            return NotFound();
        };

        return Ok(menu);
    }

    [HttpPost("/verify")]
    public bool VerifyUser([FromBody] UserCredentials credentials) {
        string truePass = "tornadito";
        string trueUser = "TORNADO";

        if (credentials.Username == trueUser && credentials.Password == truePass)
        {
            return true;
        }
        else
        {
            return false;
        }
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
            return NotFound();
            };
        
        menu.Id = id;
        var updatedMenu = await db.UpdateMenu(menu);

        if (updatedMenu == null) {
            return NotFound();
        }

        return Created("Updated", true);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenu(string id) {

        await db.DeleteMenu(id);

        return NoContent();
    }

}