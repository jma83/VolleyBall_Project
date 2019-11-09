using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    AudioSource ballSound;
    float targetTime = 0;
    Vector3 initPos;
    Rigidbody rigidBody;
    Vector3 vecTemp;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        targetTime = 2;
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.GetPausedGame())
        {
            ResetPosition();
        }
        else {


            if (targetTime > 0)
            {
                targetTime -= Time.deltaTime;
            }
            else
            {

                if (vecTemp == transform.position)
                {

                    MatchManager m = GameObject.FindObjectOfType<MatchManager>();
                    if (transform.position.x > 0)
                    {
                        m.IncreasePoint(1);
                    }
                    else
                    {
                        m.IncreasePoint(2);
                    }
                    Debug.Log("Son iguales!");
                }
                targetTime = 2;
                vecTemp = transform.position;
            }
        }

        
    }

    public void ResetPosition()
    {
        ResetForce();
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        transform.position = initPos;
    }

    public void ResetForce()
    {
        if (rigidBody != null)
        {
            rigidBody.velocity = new Vector3(0f, 0f, 0f);
            rigidBody.angularVelocity = new Vector3(0f, 0f, 0f);
        }
    }
}
