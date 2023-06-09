using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MenuItem : MonoBehaviour
{
    [Header("Object Configs")]
    [SerializeField] MenuItemConfig config;

    [Header("UI Configs")]
    [SerializeField] TMP_Text itemText;
    [SerializeField] Button itemButton;
    [SerializeField] Color originalBackgroundColor;
    [SerializeField] Color incorrectBackgroundColor;

    [Tooltip("Number of seconds incorrect color displays before returning to normal color")][SerializeField] float incorrectDelay;

    private string itemName;
    private Sprite itemImage;
    private int itemID;

    private OrderManager orderManager;
    private Image backgroundImage;

    public int ItemID { get { return itemID; } }

    private void Awake()
    {
        itemName = config.itemName;
        itemImage = config.image;
        itemID = config.ID;

        orderManager = FindObjectOfType<OrderManager>();
        backgroundImage = GetComponent<Image>();

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
        orderManager.ReceiveOrderItems(this);
    }

    /// <summary>
    /// Temporarily turns background color of item to incorrect color if player makes wrong choice 
    /// </summary>
    public void ShowIncorrectChoice()
    {
        backgroundImage.color = incorrectBackgroundColor;
        StartCoroutine(ShowOriginalColor());
    }

    /// <summary>
    /// Delays for a configurable amount of seconds and then returns the background color to its original color
    /// </summary>
    /// <returns>Ienumerator yielding for a configurable amount of seconds</returns>
    public IEnumerator ShowOriginalColor()
    {
        yield return new WaitForSeconds(incorrectDelay);
        backgroundImage.color = originalBackgroundColor;
    }

}
