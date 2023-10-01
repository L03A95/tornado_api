


public interface IMenuInterface {
    Task<List<Menu>> GetAllMenus();

    Task<Menu> GetMenuById(string id);

    Task PostMenu(Menu menu);

    Task<Menu> UpdateMenu(Menu menu);

    Task DeleteMenu(string id);
}