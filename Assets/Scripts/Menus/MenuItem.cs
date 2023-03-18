using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuItem : MonoBehaviour
{
    [SerializeField] MenuItemConfig config;
    [SerializeField] TMP_Text itemText;
    [SerializeField] Button itemButton;

    private string itemName;
    private Sprite itemImage;

    private void Awake()
    {
        itemName = config.itemName;
        itemImage = config.image;

        UpdateText();
        UpdateImage();
    }

    private void OnEnable()
    {
        itemButton.onClick.AddListener(PerformButtonAction);
    }

    private void OnDisable()
    {
        itemButton.onClick.RemoveAllListeners();
    }

    /// <summary>
    /// Updates text of the Menu Item
    /// </summary>
    private void UpdateText()
    {
        itemText.text = itemName;
    }

    /// <summary>
    /// Updates the image sprite of the Menu Item
    /// </summary>
    private void UpdateImage()
    {
        itemButton.image.sprite = itemImage;
    }

    /// <summary>
    /// will perform the action needed for each button, likely will just be sending over
    /// its data (and maybe ID) to wherever we are going to check for correct answers
    /// </summary>
    private void PerformButtonAction()
    {
        Debug.Log($"you've chose {itemName}, nice choice");
    }

}