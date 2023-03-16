using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] MenuType menuType;

    public MenuType MenuType
    {
        get { return menuType; }
    }

    public void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }

    public void ActivateMenu()
    {
        gameObject.SetActive(true);
    }
}
