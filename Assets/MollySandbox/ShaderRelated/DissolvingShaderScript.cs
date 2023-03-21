using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolvingShaderScript : MonoBehaviour
{
    private Material shaderMaterial;


    // Start is called before the first frame update
    void Start()
    {
        shaderMaterial = GetComponent<MeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
       //TODO: get access to cutoffthreshold
    }
}
