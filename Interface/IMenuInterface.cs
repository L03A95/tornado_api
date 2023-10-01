


public interface IMenuInterface {
    Task<List<Menu>> GetAllMenus();

    Task<Menu> GetMenuById(string id);

    Task PostMenu(Menu menu);

    Task UpdateMenu(Menu menu);

    Task DeleteMenu(string id);
}