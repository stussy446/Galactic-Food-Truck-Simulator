using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public List<CustomerScriptableObject> customerData;

    private AudioSource customerAudioSource;
    private int orderID;
    private GameObject model;
    private AudioClip orderAudio;
    private AudioClip thankyouAudio;
    private int language;
    private CustomerScriptableObject currentCustomerSO;

    [Header("Customer Setup Configs")]
    [SerializeField] private float customerSpeed = 5f;
    [SerializeField] private float customerCountdownStartTime = 5f;

    [Header("Customer base prefab")]
    [SerializeField] private GameObject customerPrefab;

    #region public fields
    public AudioClip OrderAudio { get { return orderAudio; } }

    public int OrderID { get { return orderID; }  }
    public AudioSource CustomerAudioSource { get { return customerAudioSource; } }
    public GameObject CustomerPrefab { get { return customerPrefab; } }

    public float CustomerSpeed { get { return customerSpeed; } }
    public float CustomerCountdownStartTime { get { return customerCountdownStartTime; } }
    #endregion

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

    /// <summary>
    /// Returns the current customer Scriptable Object
    /// </summary>
    /// <returns>CustomerScriptableObject</returns>
    public CustomerScriptableObject GetCurrentCustomer()
    {
        return currentCustomerSO;
    }

    /// <summary>
    /// Destroys the active model of the customer
    /// </summary>
    public void DestroyModel()
    {
        Destroy(model);
    }

    /// <summary>
    /// Plays order audio and sets the current customer's model to active
    /// </summary>
    public void OnCustomerEnter()
    {
        customerAudioSource.clip = orderAudio;
        customerAudioSource.enabled = true;
        model.SetActive(true);
    }

    /// <summary>
    /// deactivates the currently active model on the customer 
    /// </summary>
    public void OnCharacterExit()
    {
        model.SetActive(false);
    }

    #region VO methods
    public void VOCoroutine()
    {
        StartCoroutine(PlayCustomerVo());
    }

    public IEnumerator PlayCustomerVo()
    {
        yield return new WaitForSeconds(5f);
    }
    #endregion
}
