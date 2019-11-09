using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] Text pointsPlayer1;
    [SerializeField] Text pointsPlayer2;
    [SerializeField] Text counter;
    MatchManager m;
    // Start is called before the first frame update
    void Start()
    {
        m = GameObject.FindObjectOfType<MatchManager>();
        counter.text = "";
        pointsPlayer2.text = "";
        pointsPlayer1.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (m != null)
        {
            if (m.GetTimer() <= 0)
            {
                counter.text = "";
            }
            else
            {
                if (m == null)
                    Debug.Log("oye! m es null");
                if (counter == null)
                    Debug.Log("oye! counter es null");
                counter.text = m.GetTimer().ToString();

            }

            int[] points = m.GetAllPlayerPoints();

            if (points.Length == 2)
            {
                pointsPlayer1.text = points[0].ToString();
                pointsPlayer2.text = points[1].ToString();
            }
            else
            {
                Debug.Log("No hay 2 jugadores!");
            }
        }
        else
        {
            m = GameObject.FindObjectOfType<MatchManager>();
        }
    }
}
