using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : EntityMethods
{
    public GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();

        InvokeRepeating("GoTowardsPlayer", 2.5f,2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targ = TopDownMovement.player.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;



        //targ.y = targ.y - objectPos.y;

        transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.rotation.eulerAngles), Quaternion.Euler(0, 0, angle), 0.1f);

        
    }
    void GoTowardsPlayer()
    {
        if (Vector2.Distance(transform.position,TopDownMovement.player.transform.position) < 80)
        {
          

          
        if (name.Contains("Clone"))
        {
            body.velocity = transform.right * Mathf.Lerp(0, speed, 0.5f);
            body.velocity = transform.right * Mathf.Lerp(speed, 0, 0.5f);
        }


        }
           
    }
}
