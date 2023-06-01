using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D player;
    public float movSpeed = 500.0f;
    public int health = 10;

    private Vector2 input;
    private GameObject healthSlider;

    public GameObject screenPrefab;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        //Get player object
        player = GetComponent<Rigidbody2D>();
        healthSlider = GameObject.Find("Canvas/HealthSlider");
        dead = false;
    }

    void FixedUpdate()
    {
        player.velocity = input * movSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - player.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        player.rotation = angle;

        
    }

    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "isWall")
        {
            player.velocity = Vector2.zero;
        } else
        {
            health -= 1;
            healthSlider.GetComponent<Slider>().value = health;
        }

        if(health <= 0)
        {
            if(!dead)
            {
                dead = true;
                Instantiate(screenPrefab);
            }
        }
    }
}
