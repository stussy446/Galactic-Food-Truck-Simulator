using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CustomerStateManager : MonoBehaviour
{
   /// <summary>
   /// Controls Customer State Machine
   /// </summary> 
   /// 

    public static CustomerStateManager instance;

    //[Header("References to Scriptable Objects")]
    //[SerializeField]
    //private List<ScriptableObject> customerScriptableObjects;
    //[SerializeField]
    //public CustomerScriptableObject customerSO;

    public Customer customer;

    
    [Header ("Audio")]
    public AudioSource customerAudioSource;

    [Header("Customer States")]
    public CustomerBaseState currentCustomerState;
    public  WaitingInLineState waitingInLineState = new WaitingInLineState();
    public  OrderingState orderingState = new OrderingState();
    public CustomerExitState customerExitState = new CustomerExitState();


    [Header ("Customer Character Variables")]
    [SerializeField]
    public GameObject alienCustomerPrefab;
    [SerializeField]
    public float customerSpeed = 5f;
    [SerializeField]
    public float customerCountdownStartTime = 5f;

    [Header("Location GameObjects")]
    [SerializeField]
    public GameObject customerResetLocation;
    [SerializeField]
    public GameObject orderingLocation;
    [SerializeField]
    public GameObject customerExitLocation;

    [Header("Customer Dependencies")]
    public BoxOpener buttonBox;
    public Light customerAlert;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        customer = GetComponent<Customer>();

        customerAudioSource = alienCustomerPrefab.GetComponent<AudioSource>();
       
        currentCustomerState = waitingInLineState;
        currentCustomerState.EnterState(this);
    }

    void Update()
    {
        currentCustomerState.UpdateState(this);
    }

    public void SwitchState (CustomerBaseState state)
    {
        currentCustomerState = state;
        state.EnterState(this);
    }

    public void OnCustomerEnter()
    {
        //TODO: set prefab model
        //set VO clips
        //set order
        alienCustomerPrefab.SetActive(true);
    }

    public void OnCharacterExit()
    {
        alienCustomerPrefab.SetActive(false);
    }

    private void OnEnable()
    {
        ActionList.OnCustomerOrdered += ToCustomerOrder;
    }


    //----------ONLY FOR VO TESTING---------------//
    public void VOCoroutine()
    {
        StartCoroutine(PlayCustomerVO());
    }


    public IEnumerator PlayCustomerVO()
    {
       
        yield return new WaitForSeconds(5);
        customerAudioSource.enabled = false;
    }

   void ToCustomerOrder(ActionType actionType)
    {
       // ActionList.OnCustomerOrdered?.Invoke(actionType);

        SwitchState(orderingState);

    }


}
