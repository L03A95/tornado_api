using MongoDB.Bson;
using MongoDB.Driver;

public class MenuCollection : IMenuInterface
{   
    internal MongoDBConection _conection = new MongoDBConection();

    private IMongoCollection<Menu> Collection;

    public MenuCollection() {
        Collection = _conection.db.GetCollection<Menu>("menu");
    }

    public async Task DeleteMenu(string id)
    {
        var filter = Builders<Menu>.Filter.Eq(menu => menu.Id, id);

        await Collection.DeleteOneAsync(filter);
    }

    public async Task<List<Menu>> GetAllMenus()
    {
        return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
    }

    public async Task<Menu> GetMenuById(string id)
    {
        return await Collection.FindAsync(
        new BsonDocument { {"_id", new ObjectId(id) }}
        ).Result.FirstAsync();
    }

    public async Task PostMenu(Menu menu)
    {
        await Collection.InsertOneAsync(menu);
    }

    public async Task UpdateMenu(Menu menu)
    {
        var filter = Builders<Menu>.Filter.Eq(s => s.Id, menu.Id);

        await Collection.ReplaceOneAsync(filter, menu);
    }
}