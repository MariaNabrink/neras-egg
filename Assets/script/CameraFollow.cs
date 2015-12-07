using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject targetObject;
    public Transform boundaryRight;
    public Transform boundaryLeft;
    private float cameraWidth;
    private float distanceToTarget;


	void Start () {
        distanceToTarget = transform.position.x - targetObject.transform.position.x;
        cameraWidth = GetCameraWidth();
	}

    // Check the width of the camera
    private float GetCameraWidth()
    {
        Vector3 camBoundaryLeft = camera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 camBoundaryRight = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f));

        return camBoundaryRight.x - camBoundaryLeft.x;
    }
	

	void Update () {
        float targetObjectX = targetObject.transform.position.x;

        Vector3 newCameraPosition = transform.position;
        newCameraPosition.x = targetObjectX + distanceToTarget;

        transform.position = newCameraPosition;

        CheckCameraBoundary();
	}


    void CheckCameraBoundary()
    {
        Vector3 newCameraPosition = transform.position;
        float distanceToCameraCenter = cameraWidth / 2;

        float maxPositionX = boundaryRight.position.x - distanceToCameraCenter;
        float minPositionX = boundaryLeft.position.x + distanceToCameraCenter;

        if (transform.position.x >= maxPositionX)
        {
            newCameraPosition.x = maxPositionX;
        }
        else if (transform.position.x <= minPositionX)
        {
            newCameraPosition.x = minPositionX;
        }

        transform.position = newCameraPosition;
    }

}
