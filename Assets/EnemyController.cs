using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector2 currentVelocity;
    public TrailRenderer Trail;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Trail = GetComponentInChildren<TrailRenderer>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "isBullet")
        {
            DestroyObject();
            return;
        }
            Vector2 incomingVelocity = currentVelocity;
        Vector2 normal = other.contacts[0].normal;

        Vector2 reflectedVelocity = Vector2.Reflect(incomingVelocity, normal);
        gameObject.GetComponent<Rigidbody2D>().velocity = reflectedVelocity;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
        Trail.transform.parent = null;
        Trail = null;
    }
}
