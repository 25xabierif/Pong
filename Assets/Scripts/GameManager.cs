using UnityEngine;
using TMPro;
using System.Security.AccessControl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int P1Score;
    public static int P2Score;

    bool running = false;

    [SerializeField] TMP_Text txtP1Score;
    [SerializeField] TMP_Text txtP2Score;

    [SerializeField] GameObject pelota;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update() 
    {
        Debug.Log("p1 = " + P1Score + "; p2 = " + P2Score);

        if(!running && Input.GetKeyDown(KeyCode.Space)){
            // Activamos la pelota 
            pelota.SetActive(true);
            // Indicamos que el juego ha comenzado
            running = true; 
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public void AddPointP1() 
    { 
        P1Score++;
        txtP1Score.text = P1Score.ToString();
    }
    public void AddPointP2()
    {
        P2Score++;
        txtP2Score.text = P2Score.ToString();
    }

    public static void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

}
