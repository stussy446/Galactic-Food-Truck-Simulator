using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship2 : MonoBehaviour
{
    [SerializeField] private float xAmplitude;
    [SerializeField] private float yAmplitude;
    [SerializeField] private float zAmplitude;
    [SerializeField] private float xspeed, yspeed, zspeed;

    private Vector3 lookDirection;
    private Vector3 oldPosition;
    private float fireRate;


    private void Awake()
    {
        xAmplitude = Random.Range(0.5f, 1.5f);
        yAmplitude = Random.Range(0.5f, 1f);
        zAmplitude = Random.Range(0.5f, 2f);
        xspeed = Random.Range(1f, 3f);
        yspeed = Random.Range(1f, 3f);
        zspeed = Random.Range(1f, 3f);
        fireRate = Random.Range(1f, 3f);

    }
    void Start()
    {
        oldPosition = transform.position;

        InvokeRepeating("FireExplosion", fireRate, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        var x = xAmplitude * Mathf.Cos(xspeed * Time.timeSinceLevelLoad);
        var y = yAmplitude * Mathf.Sin(yspeed * Time.timeSinceLevelLoad);
        var z = zAmplitude * Mathf.Cos(zspeed * Time.timeSinceLevelLoad);


        transform.position += new Vector3(x, y, z);
        lookDirection = transform.position - oldPosition;
        transform.rotation = Quaternion.LookRotation(lookDirection);

        oldPosition = transform.position;

    }

    void FireExplosion()
    {
        GameObject explosion = ObjectPool.SharedInstance.GetObject("explosion");
        if (explosion != null)
        {
            explosion.transform.position = transform.position + lookDirection.normalized;
            explosion.SetActive(true);
            explosion.GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}
