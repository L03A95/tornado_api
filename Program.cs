using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MenuDb>(opt => opt.UseInMemoryDatabase("TornadoApi"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/menu", async (MenuDb db) => 
    await db.Menus.ToListAsync()
);

app.MapPost("/menu", async (Menu menu, MenuDb db) => {
    db.Menus.Add(menu);
    await db.SaveChangesAsync();

    return Results.Created($"/menu/{menu.Id}", menu);
});

app.MapDelete("/menu/{id}", async (int id, MenuDb db) => {
    var menu = await db.Menus.FindAsync(id);
    if (menu ==  null) {
        return Results.NotFound();
    }

    db.Menus.Remove(menu);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapPut("/menu/{id}", async (int id, Menu updatedMenu, MenuDb db) => {
    var menu = await db.Menus.FindAsync(id);
    if (menu == null) {
        return Results.NotFound();
    }

    if (updatedMenu.Name != null) {
        menu.Name = updatedMenu.Name;
    }
    if (updatedMenu.Description != null) {
        menu.Description = updatedMenu.Description;
    }
    if (updatedMenu.Image != null) {
        menu.Image = updatedMenu.Image;
    }
    if (updatedMenu.Price != 0) {
        menu.Price = updatedMenu.Price;
    }

    await db.SaveChangesAsync();
    return Results.Accepted();
});

app.Run();
