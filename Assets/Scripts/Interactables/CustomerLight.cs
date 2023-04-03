using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLight : MonoBehaviour
{
    public Light warningLight;

    // Start is called before the first frame update
    void Start()
    {
        warningLight.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check to see if warning light has been activated
        if (gameObject.activeInHierarchy)
        {
            transform.Rotate(5, 0, 0);
        }
    }
}