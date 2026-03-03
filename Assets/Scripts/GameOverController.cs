using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI victoryPlayer;
    [SerializeField] GameObject pelota;

    void Update()
    {
        bool victory = false;
        string msg = "";
        if(GameManager.P1Score > 4)
        {
            msg = "Player 1 wins!!!!";
            victory = true;
        }
        if(GameManager.P2Score > 4)
        {
            msg = "Player 2 wins!!!!";
            victory = true;
        }
        //En la función se comprueba que no estamos en game over y si las vidas han llegado ya 0
        if (victory)
        {
            //Si se cumple se activa el texto "Game Over"
            victoryPlayer.text = msg;
            victoryPlayer.gameObject.SetActive(true);
            pelota.SetActive(false);
        }
        
        //Si el juego ya ha terminado y el usuario presiona cualquier tecla se reinicia el juego
        if (victory && Input.anyKeyDown)
        {
            GameManager.ResetGame();
        }
    }
}
