using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    int playerIDFloor;

    // Start is called before the first frame update
    void Start()
    {
        playerIDFloor = 0;
        if (transform.position.x < 0)
        {
            playerIDFloor = 2;
        }
        else
        {
            playerIDFloor = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerIDFloor(int i)
    {
        playerIDFloor = i;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {

            Ball b = other.gameObject.GetComponent<Ball>();
            MatchManager m = GameObject.FindObjectOfType<MatchManager>();
            m.IncreasePoint(playerIDFloor);
            b.ResetPosition();

        }
    }
}
