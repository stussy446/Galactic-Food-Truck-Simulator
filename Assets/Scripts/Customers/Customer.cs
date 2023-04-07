using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I think we can refactor stuff out of the CustomerStateManager into this customer script
// so that we arent having that script do too much. Basically anything that doesnt 
// have to do with the State logic could come in here
public class Customer : MonoBehaviour
{
    public List<CustomerScriptableObject> customerData;

    private AudioSource customerAudioSource;

    [Header("Customer Setup Configs")]
    [SerializeField] private int orderID;
    [SerializeField] private GameObject model;
    [SerializeField] private AudioClip orderAudio;
    [SerializeField] private AudioClip thankyouAudio;
    [SerializeField] private int language;
    [SerializeField] private CustomerScriptableObject currentCustomerSO;
    [SerializeField] private float customerSpeed = 5f;
    [SerializeField] private float customerCountdownStartTime = 5f;

    [Header("Customer base prefab")]
    [SerializeField] private GameObject customerPrefab;

    public AudioClip OrderAudio { get { return orderAudio; } }

    public int OrderID { get { return orderID; }  }
    public AudioSource CustomerAudioSource { get { return customerAudioSource; } }
    public GameObject CustomerPrefab { get { return customerPrefab; } }

    public float CustomerSpeed { get { return customerSpeed; } }
    public float CustomerCountdownStartTime { get { return customerCountdownStartTime; } }


    private void Awake()
    {
        customerAudioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Assigns all values that come from the Scriptable Object 
    /// </summary>
    /// <param name="config"></param>
    public void SetUpCustomer(CustomerScriptableObject config)
    {
        orderID = config.orderId;
        model = Instantiate(config.modelPrefab, transform);
        orderAudio = config.orderAudio;
        thankyouAudio = config.thankyouAudio;
        language = config.language;
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
        Destroy(model);
    }

    public void OnCustomerEnter()
    {
        customerAudioSource.clip = orderAudio;
        customerAudioSource.enabled = true;
        model.SetActive(true);
    }

    public void VOCoroutine()
    {
        StartCoroutine(PlayCustomerVo());
    }

    public IEnumerator PlayCustomerVo()
    {
        yield return new WaitForSeconds(5f);
    }

    public void OnCharacterExit()
    {
        model.SetActive(false);
    }
}
