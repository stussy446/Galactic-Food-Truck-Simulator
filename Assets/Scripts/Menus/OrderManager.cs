using UnityEngine;

public class OrderManager : MonoBehaviour
{
    MenuItem menuItem;
    Customer customer; 
    AudioSource audioSource;

    [Header("Audio clip Configs")]
    [SerializeField] AudioClip incorrectChoiceClip;
    [SerializeField] AudioClip correctChoiceClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Receives MenuItem chosen by player and compares the item's ID with the currently active customer's ID. Handles logic based on if answer is 
    /// correct or not
    /// </summary>
    /// <param name="item">MenuItem choen by player in the replicator</param>
    public void ReceiveOrderItems(MenuItem item)
    {
        menuItem = item;
        FindCustomer();

        if (IsCorrectChoice())
        {
            ResetOrder();
            PlayAudioClip(correctChoiceClip);
            ActionList.OnDoneReplicatingFood?.Invoke(ActionType.DoneReplicatingFood);
        }
        else
        {
            menuItem.ShowIncorrectChoice();
            if (!audioSource.isPlaying)
            {
                PlayAudioClip(incorrectChoiceClip);
            }
        }
    }

    /// <summary>
    /// Finds and returns the current customer in the scene
    /// </summary>
    /// <returns>Customer representing the currently active customer</returns>
    private Customer FindCustomer()
    {
        customer = FindObjectOfType<Customer>();
        if (customer == null)
        {
            Debug.Log("No customer was found");
            return null;
        }
        else
        {
            return customer;
        }

    }

    /// <summary>
    /// Resets the menuItem and customer to null in preparation of receiving the next order
    /// </summary>
    private void ResetOrder()
    {
        menuItem = null;
        customer = null;
    }

    /// <summary>
    /// Checks if the item and customer IDs are ready to be compared, if not returns false 
    /// </summary>
    /// <returns>bool representing if comparison is ready or not</returns>
    private bool ChoiceNotReady()
    {
        if(menuItem == null || customer == null)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Compares the MenuItem ID and the Customer ID, returns true if they match and false otherwise
    /// </summary>
    /// <returns>bool representing if player chose correctly or not</returns>
    private bool IsCorrectChoice()
    {
        if (ChoiceNotReady())
        {
            return false;
        }

        return menuItem.ItemID == customer.OrderID;
    }

    /// <summary>
    /// Receives an audioclip and plays the clip with the OrderManager's AudioSource
    /// </summary>
    /// <param name="clip">Audioclip representing the clip to be played</param>
    private void PlayAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
