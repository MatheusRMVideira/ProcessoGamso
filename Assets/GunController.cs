using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject projPrefab;
    public Transform shootingPoint;
    public float projSpeed = 20f;
    public float shootCooldown = .2f;
    public float shootCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            Atirar();
            shootCounter = shootCooldown;
        }

        if (shootCounter > 0)
        {
            shootCounter -= Time.deltaTime;
        }
    }

    void Atirar()
    {
        GameObject projectile = Instantiate(projPrefab, shootingPoint.position, shootingPoint.rotation * Quaternion.Euler(0, 0, -90));
        projectile.GetComponent<Rigidbody2D>().AddForce(shootingPoint.up * projSpeed, ForceMode2D.Impulse);

    }
}
