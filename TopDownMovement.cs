using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement: MonoBehaviour
{
    public float speed = 5;
    float horizontal;
    float vertical;
    public Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector3(horizontal * speed, vertical * speed);
    }
}
