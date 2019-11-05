using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    AudioSource ballSound;
    float targetTime = 0;
    Vector3 ini_pos;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        ini_pos = transform.position;
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTime > 0)
            targetTime -= Time.deltaTime;
        

        //Debug.Log(targetTime);
    }

    private void ResetPosition()
    {
        if (rigidBody != null)
        {
            rigidBody.velocity = new Vector3(0f, 0f, 0f);
            rigidBody.angularVelocity = new Vector3(0f, 0f, 0f);
        }
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        transform.position = ini_pos;
    }
}
