

using MongoDB.Driver;

public class MongoDBConection {
    public MongoClient client;

    public IMongoDatabase db;

    public MongoDBConection() {
        client = new MongoClient("mongodb://localhost:27017");

        db = client.GetDatabase("tornadodb");
    }
}