using System.Collections;
using UnityEngine;

public class Movement_1 : MonoBehaviour
{
    private float speed = 10f;
    private float jumpForce = 8f;
    private float gravity = 30f;
    private Vector3 moveDir = Vector3.zero;
    private bool turnLeft;
    private bool turnRight;
    private float temp = 0f;
    private float rotationVal = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();
        if (controller.isGrounded) {
            moveDir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
            if (Input.GetButtonDown("Jump")) {
                moveDir.y = jumpForce;
            }
        }
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir*Time.deltaTime);

        if (Input.GetKey("q"))
        {
            turnLeft = true;
        }
        else if (Input.GetKey("e"))
        {
            turnRight = true;
            //transform.Rotate(0, 90, 0);
        }

    }

    void LateUpdate()
    {
        if (turnLeft)
        {
            if (temp > 89)
            {
                turnLeft = false;
                temp = 0f;
            }
            else
            {
                rotationVal = 2;//Mathf.Lerp(0f, 90f, Time.deltaTime);
                transform.Rotate(new Vector3(0, rotationVal, 0));
                temp += rotationVal;
            }

        }
        else if (turnRight)
        {
            if (temp < -89)
            {
                turnRight = false;
                temp = 0f;
            }
            else
            {
                rotationVal = -2;//Mathf.Lerp(0f, -90f, Time.deltaTime);
                transform.Rotate(new Vector3(0, rotationVal, 0));
                temp += rotationVal;
            }

        }
    }
}
