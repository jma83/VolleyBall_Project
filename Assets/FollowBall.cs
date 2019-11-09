using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    Ball b;
    // Start is called before the first frame update
    void Start()
    {
        b = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(b.transform.position.x, gameObject.transform.position.y, b.transform.position.z);

        float f = b.transform.position.y;
        //Debug.Log("scale:" + f);

        f = f / 5;
        if (f > 1.5f) { f = 1.5f; }else if (f < 0) { f = 0; }
        transform.localScale = new Vector3(f, transform.localScale.y, f);
    }
}
