using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    //[SerializeField] float distance = 5f;
    Vector2 mouseDirection;
    Vector2 distanceDirection;
    Rigidbody2D rb;
    InputController inputController;
    [SerializeField] bool inMotion;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        inputController = GameObject.Find("Game Manager").GetComponent<InputController>();
        cam = Camera.main;
        inMotion = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputController.move && !inMotion)
        {
            mouseDirection = cam.ScreenToWorldPoint(inputController.mousePos);
            inMotion = true;
        }

        if (inMotion)
            Move();
    }

    void Move()
    {
       distanceDirection = mouseDirection - (Vector2)transform.position;
       transform.position = Vector2.Lerp(transform.position, mouseDirection, moveSpeed * Time.deltaTime);

        if (distanceDirection.magnitude <= 0.5)
            inMotion = false; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Boundary")
        {
            inMotion = false;
        }
    }
}
