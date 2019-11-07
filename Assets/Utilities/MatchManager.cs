using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{

    int maxPoints;
    int numPlayers;
    int[] playerPoints;

    // Start is called before the first frame update
    void Start()
    {
        numPlayers = GameObject.FindObjectsOfType<Player>().Length;
        playerPoints = new int[numPlayers];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IncreasePoint(int playerID)
    {
        if (playerID >= numPlayers || playerID < 0)
            return false;

        playerPoints[playerID]++;
        CheckWin(playerID);
        return true;
    }

    public bool DecreasePoint(int playerID)
    {
        if (playerID >= numPlayers || playerID < 0)
            return false;

        playerPoints[playerID]++;
        return true;
    }

    public void SetMaxPoints(int points)
    {
        maxPoints = points;
    }

    void CheckWin(int i)
    {
        if (playerPoints[i] >= maxPoints)
        {
            WindowAlert.Instance.CreateSelectWindow("¡GANA EL JUGADOR " + playerPoints[i] + "!\n",
                                                    true,
                                                    SceneManagerVolley.Instance.GoMatch,
                                                    SceneManagerVolley.Instance.GoMenu
                                                    );
        }
    }

    
    

}
