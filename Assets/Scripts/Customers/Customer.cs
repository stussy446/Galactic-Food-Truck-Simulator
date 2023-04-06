using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I think we can refactor stuff out of the CustomerStateManager into this customer script
// so that we arent having that script do too much. Basically anything that doesnt 
// have to do with the State logic could come in here
public class Customer : MonoBehaviour
{
    public List<CustomerScriptableObject> customerData;

    [SerializeField] private int orderID;
    [SerializeField] private GameObject modelPrefab;
    [SerializeField] private AudioClip orderAudio;
    [SerializeField] private AudioClip thankyouAudio;
    [SerializeField] private int language;
    [SerializeField] private CustomerScriptableObject currentCustomerSO;

    public AudioClip OrderAudio { get { return orderAudio; } }

    public int OrderID { get { return orderID; }  }


    private void Awake()
    {
        // assigns all values that come from the Scriptable Object 
        //SetUpCustomer(GetRandomCustomer());
    }

    /// <summary>
    /// Assigns all values that come from the Scriptable Object 
    /// </summary>
    /// <param name="config"></param>
    public void SetUpCustomer(CustomerScriptableObject config)
    {
        orderID = config.orderId;
        modelPrefab = config.modelPrefab;
        orderAudio = config.orderAudio;
        thankyouAudio = config.thankyouAudio;
        language = config.language;
        Instantiate(modelPrefab, transform);
        currentCustomerSO = config;
    }

    /// <summary>
    /// Returns a random customer from the list of customer data
    /// </summary>
    /// <returns></returns>
    public CustomerScriptableObject GetRandomCustomer()
    {
        int randomIndex = Random.Range(0, customerData.Count);
        CustomerScriptableObject customer = customerData[randomIndex];
        return customer;
    }

    public CustomerScriptableObject GetCurrentCustomer()
    {
        return currentCustomerSO;
    }

    /// <summary>
    /// Destroys the prefab of the customer
    /// </summary>
    public void DestroyModel()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
