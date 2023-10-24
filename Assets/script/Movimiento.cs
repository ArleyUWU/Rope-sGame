using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2D : MonoBehaviour
{
    public float velocidad = 7f;
    public float fuerzaDeSalto = 10f; // Aumenta la fuerza del salto para hacerlo más realista
    public float gravedad = 3f; // Ajusta la gravedad para un salto más realista
    public float velocidadMaxAscenso = 20f; // Establece una velocidad máxima de ascenso
    private Rigidbody2D rb;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravedad; // Aplica la gravedad configurada
    }

    void Update()
    {
        // Movimiento horizontal
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimientoHorizontal * velocidad, rb.velocity.y);

        // Limita la velocidad de ascenso
        if (rb.velocity.y > velocidadMaxAscenso)
        {
            rb.velocity = new Vector2(rb.velocity.x, velocidadMaxAscenso);
        }

        // Salto
        if (enSuelo && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, fuerzaDeSalto), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}
