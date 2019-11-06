using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    Player ply;

    // Start is called before the first frame update
    void Start()
    {
        ply = GameObject.FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool CheckHit()
    {
        // location of all 4 corners
        Vector3 size = ply.GetSize();
        Vector3 corner1 = transform.position + new Vector3(size.x / 2, -size.y / 2 + 0.01f, size.z / 2);
        Vector3 corner2 = transform.position + new Vector3(-size.x / 2, -size.y / 2 + 0.01f, size.z / 2);
        Vector3 corner3 = transform.position + new Vector3(size.x / 2, -size.y / 2 + 0.01f, -size.z / 2);
        Vector3 corner4 = transform.position + new Vector3(-size.x / 2, -size.y / 2 + 0.01f, -size.z / 2);

        // check if we are grounded
        bool grounded1 = Physics.Raycast(corner1, -Vector3.up, 0.01f);
        bool grounded2 = Physics.Raycast(corner2, -Vector3.up, 0.01f);
        bool grounded3 = Physics.Raycast(corner3, -Vector3.up, 0.01f);
        bool grounded4 = Physics.Raycast(corner4, -Vector3.up, 0.01f);

        return (grounded1 || grounded2 || grounded3 || grounded4);
    }

    Vector3 GetReflected(Vector3 volleyBallPos)
    {
        Vector3 v3 = new Vector3(2.6f, 0.05f, 0);
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
            other.GetComponent<Rigidbody>().AddForce(reflect, ForceMode.VelocityChange);



            // Play sound

            // Destroy coin
            // Destroy(other.gameObject);
        }

    }
}
