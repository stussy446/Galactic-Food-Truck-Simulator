using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I think we can refactor stuff out of the CustomerStateManager into this customer script
// so that we arent having that script do too much. Basically anything that doesnt 
// have to do with the State logic could come in here
public class Customer : MonoBehaviour
{
    [SerializeField] private CustomerScriptableObject customerConfig;

    private int orderID;
    private Mesh mesh;
    private Material material;
    private AudioClip orderAudio;
    private AudioClip thankyouAudio;
    private int language;

    public int OrderID { get { return orderID; }  }


    private void Awake()
    {
        // assigns all values that come from the Scriptable Object 
        orderID = customerConfig.orderId;
        mesh = customerConfig.mesh;
        material = customerConfig.material;
        orderAudio = customerConfig.orderAudio;
        thankyouAudio = customerConfig.thankyouAudio;   
        language = customerConfig.language;
    }

    // TODO: add other logic if we decide to use this script as well 
}
