using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    float horizontal;
    float vertical;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(horizontal / 4, vertical / 4);
        Camera.main.orthographicSize -= Input.mouseScrollDelta.y;
        if(Camera.main.orthographicSize < 5)
        {
            Camera.main.orthographicSize = 5;
        }
        //Uncomment these lines if you want to have the camera have a max size
        //if (Camera.main.orthographicSize > 100)
        //{
        //    Camera.main.orthographicSize = 100;
        //}
    }
}
