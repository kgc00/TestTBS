using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour
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

        //Must have a target to move...
        cameraData.storeTarget();
    }

    void FixedUpdate()
    {

        //Let's only do work if we absolutely have to
        if (!cameraData.shouldMoveLeft() && !cameraData.shouldMoveRight() && !cameraData.shouldMoveBack() && !cameraData.shouldMoveForward()) return;

        //First, make sure the Y of the target is above the terrain
        cameraData.target.transform.position = new Vector3(
            cameraData.target.transform.position.x,
            cameraData.target.transform.position.y,
            cameraData.target.transform.position.z
        );


        //Now handle panning left and right if necessary
        Vector3 newPosition = new Vector3(
            cameraData.target.transform.position.x,
            cameraData.target.transform.position.y,
            cameraData.target.transform.position.z
        );

        //Create movement vector, using normalization to account for camera rotation        
        if (cameraData.shouldMoveLeft())
        {
            newPosition.x += cameraData.panDistance * -transform.right.x;
            newPosition.y += cameraData.panDistance * transform.right.y;
        }
        else if (cameraData.shouldMoveRight())
        {
            newPosition.x += cameraData.panDistance * transform.right.x;
            newPosition.y += cameraData.panDistance * -transform.right.y;
        }

        if (cameraData.shouldMoveBack())
        {
            newPosition.x += cameraData.panDistance * -transform.forward.x;
            newPosition.y += cameraData.panDistance * transform.forward.y;
        }
        else if (cameraData.shouldMoveForward())
        {
            newPosition.x += cameraData.panDistance * transform.forward.x;
            newPosition.y += cameraData.panDistance * -transform.forward.y;
        }

        //Lerp towards the new position
        cameraData.target.transform.position = Vector3.Lerp(
            cameraData.target.transform.position,
            newPosition,
            cameraData.panSpeed * Time.deltaTime
        );
    }
}