using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    Dictionary<MenuType, Menu> menus = new Dictionary<MenuType, Menu>();
    MenuType activeMenuType;

    public MenuType ActiveMenuType
    {
        get { return activeMenuType; }
    }

    public void Awake()
    {
        Instance = this;

        SetUpMenus();
        DeactivateAllMenus();
        ActivateMenu(MenuType.Start);
    }

    /// <summary>
    /// Creates dictionary of all available menus and starts the game with the Start menu activated 
    /// </summary>
    private void SetUpMenus()
    {
        Menu[] menusList = GetComponentsInChildren<Menu>();
        foreach (var menu in menusList)
        {
            menus.Add(menu.MenuType, menu);
        }

        activeMenuType = MenuType.Start;
    }

    /// <summary>
    /// Deactivates all menus 
    /// </summary>
    private void DeactivateAllMenus()
    {
        foreach (var key in menus.Keys)
        {
            menus[key].DeactivateMenu();
        }
    }

    /// <summary>
    /// Deactivates all other menus and then activates a specified menu based on the provided MenuType
    /// </summary>
    /// <param name="menuType">MenuType to be activated</param>
    public void ActivateMenu(MenuType menuType)
    {
        DeactivateAllMenus();
        menus[menuType].ActivateMenu();
        activeMenuType = menuType;
    }
}
