using System.Collections;
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

    private void SetUpMenus()
    {
        Menu[] menusList = GetComponentsInChildren<Menu>();
        foreach (var menu in menusList)
        {
            menus.Add(menu.MenuType, menu);
        }

        activeMenuType = MenuType.Start;
    }

    private void DeactivateAllMenus()
    {
        foreach (var key in menus.Keys)
        {
            menus[key].DeactivateMenu();
        }
    }

    public void ActivateMenu(MenuType menuType)
    {
        DeactivateAllMenus();
        menus[menuType].ActivateMenu();
        activeMenuType = menuType;
    }
}
