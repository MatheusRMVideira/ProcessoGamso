using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    public GameObject projPrefab;
    public Transform shootingPoint;
    public float projSpeed = 5f;
    public float shootCooldownMax = 10f;
    private float shootCooldown = 0;
    public float shootCounter = 10f;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = Random.Range(shootCooldownMax / 2f, shootCooldownMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCounter <= 0)
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
        GameObject projectile = Instantiate(projPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, -90));
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projSpeed, ForceMode2D.Impulse);

    }
}
