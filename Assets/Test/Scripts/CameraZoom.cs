using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
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

    void FixedUpdate()
    {
        cameraData.zoom += Input.GetAxis("Mouse ScrollWheel");

        if (cameraData.zoom > cameraData.maxZoom) Camera.main.orthographicSize = cameraData.zoom+ 1;        
        if (cameraData.zoom < cameraData.minZoom) Camera.main.orthographicSize = cameraData.zoom- 1;
    }
}