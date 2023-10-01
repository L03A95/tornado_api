var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// var client = new MongoClient("mongodb://localhost:27017");
// var database = client.GetDatabase("tornadodb");

// var menuDB = database.GetCollection<Menu>("menu");

var app = builder.Build();

// app.MapGet("/menu", async () => {
//     return await menuDB.FindAsync(new BsonDocument()).Result.ToListAsync();
// });

// app.MapGet("/menu/{id}", async (string id) => {
//     return await menuDB.FindAsync(
//         new BsonDocument { {"_id", new ObjectId(id) }}
//     ).Result.FirstAsync();
// });

// app.MapPost("/menu", async (Menu newMenu) => {
//     await menuDB.InsertOneAsync(newMenu);
// });

// app.MapDelete("/menu/{id}", async (string id) => {
//     var filter = Builders<Menu>.Filter.Eq(s => s.Id, id);

//     await menuDB.DeleteOneAsync(filter);
// });

// app.MapPut("/menu", async (Menu updatedMenu) => {
//     var filter = Builders<Menu>.Filter.Eq(s => s.Id, updatedMenu.Id);

//     await menuDB.ReplaceOneAsync(filter, updatedMenu);
// });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
