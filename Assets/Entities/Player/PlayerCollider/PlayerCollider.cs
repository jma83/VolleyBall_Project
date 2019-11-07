using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] Player ply;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GetReflected(Vector3 volleyBallPos)
    {
        Vector3 v3 = new Vector3(0, 0, 0);
        if (ply != null) {
            if (ply.playerID == 1)
                v3 = new Vector3(-2.6f, 0.05f, 0);
            else
                v3 = new Vector3(2.6f, 0.05f, 0);
        }
        Vector3 volleyballVector = transform.position - volleyBallPos;
        Vector3 planeTangent = Vector3.Cross(volleyballVector, v3);
        Vector3 planeNormal = Vector3.Cross(planeTangent, volleyballVector);
        Vector3 reflected = Vector3.Reflect(v3, planeNormal);

        return reflected;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 volleyBallPos = other.transform.position;
            Vector3 reflect = GetReflected(volleyBallPos);
            // Increase our score
            //


            Debug.Log("Player HIT!: " + reflect);
            {
                other.GetComponent<Rigidbody>().AddForce(reflect, ForceMode.VelocityChange);

            }

            // Play sound

            // Destroy coin
            // Destroy(other.gameObject);
        }

    }
}
