using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    MenuItem menuItem;
    Customer customer; 
    List<MenuItem> changedMenuItems = new List<MenuItem>();
    AudioSource audioSource;

    [Header("Audio clip Configs")]
    [SerializeField] AudioClip incorrectChoiceClip;
    [SerializeField] AudioClip correctChoiceClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReceiveOrderItems(MenuItem item)
    {
        menuItem = item;
        FindCustomer();

        if (IsCorrectChoice())
        {
            ResetOrder();
            ResetAllItems();
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

    private void ResetOrder()
    {
        menuItem = null;
        customer = null;
    }

    private bool ChoiceNotReady()
    {
        if(menuItem == null || customer == null)
        {
            return true;
        }

        return false;
    }

    private bool IsCorrectChoice()
    {
        if (ChoiceNotReady())
        {
            return false;
        }

        return menuItem.ItemID == customer.OrderID;
    }

    private void ResetAllItems()
    {
        foreach (var item in changedMenuItems)
        {
            item.ShowOriginalColor();
        }
    }

    private void PlayAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

}
