using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltotouch : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 600f;
    public bool ground;
    public LayerMask whatisground;
   public int salto = 0;
    public float velocidadenx = 10f;
    private Collider2D micolision;

    public float multiplicadorvelos;

    public float aumentadordevelocidad;
    private float acumuladordevelocidad;

    private Animator miAnimacion;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        micolision = GetComponent<Collider2D>();

        miAnimacion = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        ground = Physics2D.IsTouchingLayers(micolision, whatisground);

        if (velocidadenx < 22)
        {
            if (transform.position.x > acumuladordevelocidad)
            {
                acumuladordevelocidad += aumentadordevelocidad;
                velocidadenx = velocidadenx * multiplicadorvelos;
            }
        }

        rb.velocity = new Vector2(velocidadenx, rb.velocity.y);

        if (Input.touchCount > 0 && salto < 2 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
            salto++;

        }
        if (ground == true)
        {
            salto = 0;

        }
        miAnimacion.SetFloat("vSpeed", rb.velocity.y);
        miAnimacion.SetFloat("Speed", Mathf.Abs(velocidadenx));
        miAnimacion.SetBool("Ground", ground);
    }
}
