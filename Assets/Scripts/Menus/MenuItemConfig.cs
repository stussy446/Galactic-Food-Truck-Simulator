using UnityEngine;

[CreateAssetMenu(fileName = "new Menu Config", menuName = "Configs/Menu Config", order = 0)]
public class MenuItemConfig : ScriptableObject
{
    public string itemName;
    public Sprite image;
    public int ID;
}
