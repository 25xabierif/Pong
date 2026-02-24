using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int p1Score;
    int p2Score;

    [SerializeField] TMP_Text txtP1Score;
    [SerializeField] TMP_Text txtP2Score;

    void Update() {
        Debug.Log("p1 = " + p1Score + "; p2 = " + p2Score);
    }

    public void AddPointP1() 
    { 
        p1Score++;
        txtP1Score.text = p1Score.ToString();
    }
    public void AddPointP2()
    {
        p2Score++;
        txtP2Score.text = p2Score.ToString();
    }

}
