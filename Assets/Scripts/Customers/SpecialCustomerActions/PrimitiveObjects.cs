using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] family;
    private float pingpongMax = 0.15f;
    private List<float> delayTimer = new List<float>();
    private Vector3 randomPosition = new Vector3(0,0,0);
    private List<Vector3> originalPosition = new List<Vector3>();



    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject item in family)
        {
            Vector3 tempVector = item.transform.localPosition;
            originalPosition.Add(tempVector);
            float temp = Random.Range(0, 2f);
            delayTimer.Add(temp);
        }

    }

    // Update is called once per frame
    void Update()
    {
        

        for (int i = 0; i < family.Length; i++)
        {
            randomPosition.y = Mathf.PingPong(Time.time + delayTimer[i], pingpongMax);
            family[i].transform.localPosition = originalPosition[i] + randomPosition;
        }
    }
}
