using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowControl : MonoBehaviour
{
    public float speedRotate;
    public Transform Target, Player;
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }
    private void LateUpdate()
    {
        ControlCamera();
    }
    void ControlCamera()
    {
        mouseX += Input.GetAxis("Mouse X") * speedRotate;
        mouseY -= Input.GetAxis("Mouse Y") * speedRotate;

        //Clamp on Y-Rotation
        mouseY = Mathf.Clamp(mouseY, -90, 90);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        //Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
