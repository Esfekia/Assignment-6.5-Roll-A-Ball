using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extender : MonoBehaviour
{
    public Vector3 scaleChange = new Vector3(-0.01f, 0f, -0.01f);
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.localScale += scaleChange;
        if (platform.transform.localScale.x < 1.0f || platform.transform.localScale.x > 5.0f)
        {
            scaleChange = -scaleChange;
        }
    }
}

