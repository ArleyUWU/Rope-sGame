using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlmirada : MonoBehaviour
{
    public float velocidad = 3f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimiento horizontal
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector3 movimiento = new Vector3(movimientoHorizontal * velocidad * Time.deltaTime, 0, 0);

        // Mueve el personaje
        transform.Translate(movimiento);

        // Gira el sprite según la dirección del movimiento
        if (movimientoHorizontal < 0)
        {
            // Si se mueve hacia la izquierda, gira el sprite hacia la izquierda
            spriteRenderer.flipX = true;
        }
        else if (movimientoHorizontal > 0)
        {
            // Si se mueve hacia la derecha, gira el sprite hacia la derecha
            spriteRenderer.flipX = false;
        }
    }
}