using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Camera c;
    Ball b;
    // Start is called before the first frame update
    void Start()
    {
        c = gameObject.GetComponent<Camera>();
        b = GameObject.FindObjectOfType<Ball>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (b==null)
            b = GameObject.FindObjectOfType<Ball>();
        else
        c.transform.LookAt(b.transform);
    }
}
