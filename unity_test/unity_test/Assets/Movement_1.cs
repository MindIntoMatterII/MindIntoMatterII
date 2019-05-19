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



    private void OnCollisionEnter(Collision collision)
    {

        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.otherCollider.tag == "Platform" )
            {
                Vector3 touching = contact.point;
            }
        }

    }




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

        if (Input.GetKeyDown("q"))
        {
            turnLeft = true;
        }
        else if (Input.GetKeyDown("e"))
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
                crunchCollidersToPlayer();
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
                crunchCollidersToPlayer();
            }
            else
            {
                rotationVal = -2;//Mathf.Lerp(0f, -90f, Time.deltaTime);
                transform.Rotate(new Vector3(0, rotationVal, 0));
                temp += rotationVal;
            }

        }
    }

    public void crunchCollidersToPlayer()
    {
        Transform playerTrans = transform;
        GameObject[] allPlatforms = GameObject.FindGameObjectsWithTag("Platform");
        int numPlatforms = allPlatforms.Length;
        for (int i = 0; i < numPlatforms; i++)
        {
            GameObject platform = allPlatforms[i];
            BoxCollider collider = platform.GetComponentInChildren<BoxCollider>();
            collider.center = Vector3.zero;

            //convert pos vec into world space
            Vector3 colliderPos = collider.transform.TransformPoint(collider.center);

            Vector3 playerPos = playerTrans.position;
            Vector3 newColliderPos;

            //move platform collider depending on what side the camera is facing 
            Vector3 normalCam = Camera.current.transform.position.normalized;
            if (Mathf.Abs(Mathf.Round(normalCam.x)) == 1.0f)
                newColliderPos = new Vector3(playerPos.x, colliderPos.y, colliderPos.z);
            else
                newColliderPos = new Vector3(colliderPos.x, colliderPos.y, playerPos.z);

            //converts back into local space
            newColliderPos = collider.transform.InverseTransformPoint(newColliderPos);

            collider.center = newColliderPos;
        }
    }

 
}
