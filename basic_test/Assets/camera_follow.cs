using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    //摄像机跟离角色有多远
    public float distanceAway;
    //摄像机在角色上方多高
    public float distanceUp;
    //摄像机移动的速度
    public float smooth;
    //目标位置
    private Vector3 targetPosition;
    //摄像机所跟随的对象的位置,此处是角色物体的位置


    public float rotationSpeed = 10;

    Transform follow;
    // Use this for initialization
    void Start()
    {
        //得到要跟随的物体对象的位置
        follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("q"))
        //    print ("q key was pressed");
        //    transform.Rotate(Vector3.up * 90 * rotationSpeed);
        //if (Input.GetKey("e"))
        //    print ("e key was pressed");
        //    transform.Rotate(Vector3.down * 90 * rotationSpeed);

        //得到摄像机要移动的目标位置
        targetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;
        //摄像机从当前位置移动到目标位置
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
        //摄像机要看向角色物体
        transform.LookAt(follow);


    }
}
