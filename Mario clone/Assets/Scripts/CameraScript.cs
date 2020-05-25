using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float resetSpeed = 0.5f;
    public float cameraSpeed = 0.5f;

    public Bounds cameraBounds;

    private float OffsetZ;
    private Vector3 lastTargetPos;
    private Vector3 currentVelocity;

    private bool PlayerFollow;

    private Transform target;

    private void Awake()
    {
        BoxCollider2D mybox = GetComponent<BoxCollider2D>();
        mybox.isTrigger = true;
        mybox.size = new Vector2(Camera.main.aspect * Camera.main.orthographicSize *2f, 15f);
             //Debug.Log("aspectCam = " + Camera.main.aspect );
             //Debug.Log("myBox size = " + mybox.size);
        cameraBounds = mybox.bounds;
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag(MyTags.TargetAhead_tag).transform;
        lastTargetPos = target.position;
        OffsetZ = (transform.position - target.position).z;
        //Debug.Log("transf pos = " + transform.position);
        //Debug.Log("target pos = " + target.position);
        //Debug.Log("Offset.z = " + OffsetZ);
        PlayerFollow = true;    
    }
    private void FixedUpdate()
    {
        if(PlayerFollow)
        {
            Vector3 aheadofTargetPos = target.position + Vector3.forward * OffsetZ  ;
            if(aheadofTargetPos.x >= transform.position.x)
            {
                Vector3 newCameraPos = Vector3.SmoothDamp(transform.position, aheadofTargetPos, ref currentVelocity, cameraSpeed);
                transform.position = new Vector3(newCameraPos.x,transform.position.y, transform.position.z);

                lastTargetPos = target.position;
            }
        }
    }
}
