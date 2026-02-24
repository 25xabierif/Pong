using UnityEngine;
using System.Collections;

public class PelotaController : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] float delay;
    const float MIN_ANG = 25.0f;
    const float MAX_ANG = 40.0f;
    const float MAX_Y = 2.5f;
    const float MIN_Y = -2.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int direccionX = Random.Range(0, 2) == 0 ? -1 : 1;
        StartCoroutine(LanzarPelota(direccionX));
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        
        if (tag.Equals("Pa1"))
            Debug.Log("Colisión con Pala 1!");
        else if (tag.Equals("Pa2"))
            Debug.Log("Colisión con Pala 2!");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Gol en " + other.tag + "!!");
    }
    IEnumerator LanzarPelota(int direccionX)
    {
        yield return new WaitForSeconds(delay);

        float posY = Random.Range(MIN_Y,MAX_Y);
        transform.position = new Vector3(0,posY,0);
        // Definimos el ángulo en radianes usando Range, especificando el mínimo y máximo.
        float angulo = Random.Range(MIN_ANG, MAX_ANG) * Mathf.Deg2Rad;
        float x = Mathf.Cos(angulo) * direccionX;

        // Determinamos si nos movemos hacia la derecha o izquierda.
        // Si el valor devuelto es 0, la dirección en Y será negativa; si es 1, será positiva.
        int direccionY = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Mathf.Sin(angulo) * direccionY;

        Vector2 impulso = new Vector2(x, y);
        rb.AddForce(impulso * force, ForceMode2D.Impulse);
    }
// ...
}
