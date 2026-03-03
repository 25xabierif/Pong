using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PelotaController : MonoBehaviour
{

    private Rigidbody2D rb; 
    AudioSource sfx;
    [SerializeField] float force;
    [SerializeField] float delay;
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioClip sfxPaddle;  // Sonido al chocar con la pala
    [SerializeField] AudioClip sfxGoal;    // Sonido al salir por alguno de los laterales
    [SerializeField] AudioClip sfxBrick; //Usaremos este sonido al lanzar la pelota
    [SerializeField] GameObject pa1; //Instanciamos as pas
    [SerializeField] GameObject pa2; //Instanciamos as pas

    const float MIN_ANG = 25.0f; 
    const float MAX_ANG = 40.0f; 

    bool halved = false;
    int hitCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sfx = GetComponent<AudioSource>();
        //throwBall();
        //Invoke("throwBall", delay);
        transform.position = new Vector3(0,0,0); //Vector3.zero;
         
        int directionX = Random.Range(0, 2) == 0 ? -1 : 1; // El límite superior es exclusivo (el 2 quedaría fuera).
        StartCoroutine(throwBall(directionX));
    }

    IEnumerator throwBall(int directionX){

        transform.position = new Vector3(0,0,0); //Vector3.zero;
        rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(delay);    
        
        float angulo = Random.Range(MIN_ANG, MAX_ANG) * Mathf.Deg2Rad;
        int directionY = Random.Range(0,2) == 0 ?-1:1;

        float x = Mathf.Cos(angulo) * directionX;
        float y = Mathf.Sin(angulo) * directionY;
         
        rb.AddForce(new Vector2(x,y) * force, ForceMode2D.Impulse);  

        sfx.clip = sfxBrick;
        sfx.Play(); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        string tag = other.gameObject.tag;
        if(tag == "Pa1" || tag == "Pa2")
        {
            hitCounter++;
            sfx.clip = sfxPaddle;
            sfx.Play();
            if (hitCounter >= 16 && !halved)
            {
                HalvePaddle(true);
            }
        }
    }

   private void OnTriggerEnter2D(Collider2D collider){

        Debug.Log("Gol en " +collider.tag + "!!");
        if(collider.tag.Equals("GoalLeft")){
            if (halved)
            {
                HalvePaddle(false);
            }
            gameManager.AddPointP1();
            StartCoroutine(throwBall(1));
        }else if(collider.tag.Equals("GoalRigth")){
            if (halved)
            {
                HalvePaddle(false);
            }
            gameManager.AddPointP2();
            StartCoroutine(throwBall(-1));
        }
        hitCounter = 0;
        sfx.clip = sfxGoal;
        sfx.Play();

   }

   public void HalvePaddle(bool reducir){
        halved = reducir; 
        Vector3 escalaActual = pa1.transform.localScale;
        pa1.transform.localScale = reducir ? 
            new Vector3(escalaActual.x , escalaActual.y *0.5f, escalaActual.z):
            new Vector3(escalaActual.x, escalaActual.y *2f, escalaActual.z);
        Vector3 escalaActual2 = pa2.transform.localScale;
        pa2.transform.localScale = reducir ? 
            new Vector3(escalaActual.x, escalaActual.y* 0.5f, escalaActual.z):
            new Vector3(escalaActual.x, escalaActual.y * 2f, escalaActual.z);
    }
}
