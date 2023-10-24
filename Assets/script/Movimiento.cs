using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaDeSalto = 10f;
    private bool enSuelo;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask whatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verificar si el personaje está en el suelo
        enSuelo = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // Movimiento horizontal
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimientoHorizontal * velocidad, rb.velocity.y);

        // Salto
        if (enSuelo && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, fuerzaDeSalto), ForceMode2D.Impulse);
        }
    }
}
