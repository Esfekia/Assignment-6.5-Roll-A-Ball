using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform targetPlayer;


    // Container variable for sensitivity
    public Vector2 sensitivity;

    // How much behind the target the camera should follow
    public Vector3 cameraOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - targetPlayer.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
                
        Vector3 updatedPosition = targetPlayer.transform.position + cameraOffset;
        // Tried this to make the camera follow smoother but did not work:
        // Vector3 updatedPosition = Vector3.Lerp(transform.position, (targetPlayer.transform.position + cameraOffset), 5.0f);
        transform.position = updatedPosition;
        transform.LookAt(targetPlayer.transform);
    }

}

