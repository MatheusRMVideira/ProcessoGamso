using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject projPrefab;
    public TrailRenderer Trail;
    public int numBounces = 3;
    public float projSpeed = 20f;
    private Vector2 currentVelocity;
    // Start is called before the first frame update
    void Start()
    {
        Trail = GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "isWall")
        {
            //When a wall is hit and numBounces > 0, reflect the object
            if (numBounces > 1)
            {
                //Calculate angle of collision
                Vector2 incomingVelocity = currentVelocity;
                Vector2 normal = other.contacts[0].normal;

                Vector2 reflectedVelocity = Vector2.Reflect(incomingVelocity, normal);
                gameObject.GetComponent<Rigidbody2D>().velocity = reflectedVelocity;

                float angle = Mathf.Atan2(reflectedVelocity.y, reflectedVelocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                numBounces--;
            }
            else
            {
                DestroyObject();
            }
        } else {
            DestroyObject();
        }

    }

    private void DestroyObject()
        {
            Destroy(gameObject);
            Trail.transform.parent = null;
            Trail = null;
        }
}
