using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Menu Config", menuName = "Configs/Menu Config", order = 0)]
public class MenuItemConfig : ScriptableObject
{
    public string itemName;
    public Image image;
    // maybe id as well? will need to get that from a different source later to make sure its always incremented by one.
    // initial thoughts: MenuManager can be static and tell the configs their id based on how many menuitems already exist in its list
    
}
