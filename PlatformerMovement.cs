using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//To Add this script, create a C# file, and name it PlatformerMovement(Exaclty that) and then paste this entire script in, from start to end.
//Alternatively, if you wish to name your file something else, only paste in the content below line 7.
public class PlatformerMovement: MonoBehaviour
{
    public Rigidbody2D body;
    public float horizontal;
    public float jumpPower = 5;
    public bool isOnGround;
    public LayerMask ground;
    public float moveSpeed;
    // Start is called before the first frame update
    
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround == true)
        {
            body.velocity = new Vector2(body.velocity.x, 1 * jumpPower);

        }
        isOnGround = Physics2D.OverlapBox(transform.position, new Vector2(1, 1), 0, ground);
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector3(horizontal * moveSpeed, body.velocity.y);
    }
}
