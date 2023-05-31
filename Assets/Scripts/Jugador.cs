using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float fuerzaSalto;
    private Rigidbody2D ri;
    private Animator animator;
    public int puntos = 0; // Contador de puntos

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ri = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("estaSaltando", true);
            ri.AddForce(new Vector2(0, fuerzaSalto));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            Debug.Log("¡Has perdido!");
            animator.SetBool("estaSaltando", false);
        }

        if (collision.gameObject.tag == "obstaculo")
        {
            Debug.Log("¡Has perdido!");
            Application.Quit(); // Terminar el juego
        }

        if (collision.gameObject.tag == "monedas")
        {
            puntos += 100; // Incrementar los puntos en 100 cada vez que se colisiona con una moneda
            Debug.Log("Puntos: " + puntos); // Mostrar los puntos en la consola
            if (puntos >= 1000)
            {
                Debug.Log("¡Has ganado!");
                // Aquí puedes agregar cualquier lógica adicional para manejar el juego ganado
            }
        }
    }
}
