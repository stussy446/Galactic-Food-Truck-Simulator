using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    Dictionary<MenuType, Menu> menus = new Dictionary<MenuType, Menu>();

    public void Awake()
    {
        Menu[] menusList = GetComponentsInChildren<Menu>();
        foreach (var menu in menusList)
        {
            menus.Add(menu.MenuType, menu);
        }
    }

    public void ActivateMenu()
    {

    }
}
