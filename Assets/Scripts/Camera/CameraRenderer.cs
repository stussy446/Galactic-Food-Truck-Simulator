using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRenderer : MonoBehaviour
{
    [SerializeField] private float fps = 10f;
    private float totalTime = 0f;
    private Camera choppyCam;


    // Start is called before the first frame update
    void Start()
    {
        choppyCam = GetComponent<Camera>();
        choppyCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;

        if(totalTime < 1 / fps)
        {
            return;
        }

        totalTime = 0f;
        choppyCam.Render();
    }
}
