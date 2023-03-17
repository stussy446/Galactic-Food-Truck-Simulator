using System.Collections;
using System.Collections.Generic;
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

    private void UpdateText()
    {
        itemText.text = itemName;
    }

    private void UpdateImage()
    {
        itemButton.image.sprite = itemImage;
    }
}
