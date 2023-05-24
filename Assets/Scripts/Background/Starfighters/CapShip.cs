using UnityEngine;

public class CapShip : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePoint;
    private float fireRate;
    private float fireAngle;

    private void Awake()
    {
        fireRate = Random.Range(5f, 7f);
    }

    private void Start()
    {
        InvokeRepeating("FireZeLaser", fireRate, fireRate);
    }

    /// <summary>
    /// Fires laser projectile at a random angle
    /// </summary>
    private void FireZeLaser()
    {
        fireAngle = Random.Range(-0.05f, 0.05f);
        var firingLine = transform.rotation;
        firingLine.x += fireAngle;

        projectile.transform.rotation = firingLine;
        projectile.SetActive(true);
 
    }
}
