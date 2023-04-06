using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] MenuType menuType;

    /// <summary>
    /// returns the type of menu the Menu object is representing 
    /// </summary>
    public MenuType MenuType
    {
        get { return menuType; }
    }

    /// <summary>
    /// Deactivates menu
    /// </summary>
    public void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// activates menu
    /// </summary>
    public void ActivateMenu()
    {
        gameObject.SetActive(true);
    }
}
