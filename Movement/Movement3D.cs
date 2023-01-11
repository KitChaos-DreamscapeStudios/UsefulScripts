using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement3D : MonoBehaviour
{
    //Make sure the player object has a camera as a child, an empty object as a child set as "Orient" a rigidbody with gravity off and all rotation directions locked, a collider, and a constant downwards force
    public Rigidbody body;
    public float speed;
    public LayerMask ground;
    public bool isOnGround;
    float LR;
    float FB;
    public bool sprinting;
    public GameObject Orient;
    
    #region Stolen Camera Script
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        DontDestroyOnLoad(this);
        Hit = GetComponent<AudioSource>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && body.velocity != new Vector3(0, 0, 0))
        {
            sprinting = true;
        }
        else
        {

            sprinting = false; 
        }
        if (sprinting)
        {
            speed = 40;
        }
        else
        {
            speed = 20;
        }
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(new Vector3(0, 25), ForceMode.VelocityChange);//Change "25" to adjust jump power
        }
        isOnGround = Physics.CheckBox(transform.position - new Vector3(0, transform.localScale.y,0), new Vector3(1,1,1),layerMask:ground,orientation:transform.rotation);
            #region Stolen Camera Script
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = Orient.transform.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            Camera.main.transform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
            Orient.transform.eulerAngles = new Vector3(0, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
        #endregion
        LR = Input.GetAxisRaw("Horizontal");
        FB = Input.GetAxisRaw("Vertical");
        body.angularVelocity = new Vector3(0, 0, 0);
        if(FB == 0 && LR == 0)
        {
            body.velocity = new Vector3(0, body.velocity.y, 0);
            if (isOnGround)
            {

            }
            
        }
    }
    private void FixedUpdate()
    {

        body.velocity =new Vector3((Orient.transform.forward * (FB * speed) + Orient.transform.right * (LR * speed)).x, body.velocity.y, (Orient.transform.forward * (FB * speed) + Orient.transform.right * (LR * speed)).z);
       
    }
   
}
