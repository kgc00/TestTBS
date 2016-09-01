using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour
{

    private CameraData cameraData;

    // Use this for initialization
    void Start()
    {
        //Need the data container
        cameraData = GetComponent<CameraData>();

        if (cameraData == null)
        {
            cameraData = gameObject.AddComponent<CameraData>();
        }

        //Need the target in order to position relatively
        cameraData.storeTarget();
    }

//    void FixedUpdate()
//    {
//        if (cameraData.shouldRotateLeft())
//        {
//            cameraData.rotation = cameraData.rotation - 1;
//        }
//        else if (cameraData.shouldRotateRight())
//        {
//            cameraData.rotation = cameraData.rotation + 1;
//        }
//    }
}