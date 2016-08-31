using UnityEngine;
using System.Collections;

public class CameraAdjustSelf : MonoBehaviour
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
        //Position the camera away from the origin
        Vector3 newPosition = new Vector3(
            cameraData.target.transform.position.x,
            cameraData.target.transform.position.y,
            cameraData.target.transform.position.z
        );

        newPosition.x += cameraData.xDistance;
        newPosition.y += cameraData.yDistance;
        newPosition.z += cameraData.zDistance;

        //If the camera is already where we want it, then there's nothing more to do
        if (transform.position == cameraData.target.transform.position) return;

        transform.position = Vector3.Lerp(transform.position, newPosition, cameraData.panSpeed * Time.deltaTime);

        transform.LookAt(cameraData.target.transform.position);
    }
}