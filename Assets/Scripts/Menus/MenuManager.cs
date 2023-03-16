using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    Dictionary<MenuType, Menu> menus = new Dictionary<MenuType, Menu>();

    public void Awake()
    {
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
        menus[menuType].ActivateMenu();
    }
}
