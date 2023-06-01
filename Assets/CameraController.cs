using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float maxX = 100f;
    public float maxY = 100f;
    public float minX = -100f;
    public float minY = -100f;
    public float smoothTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPosition = transform.position;

        //Clamps the camera in the map
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );

        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
