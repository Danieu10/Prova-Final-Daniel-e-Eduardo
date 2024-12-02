using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaOgro : MonoBehaviour
{
    public float velocidadeinimigos = 2;
    public float tempo = 0;
    public bool olhando = false;
    public Rigidbody2D corpo;
    public float forcapulo =1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tempo += 1 * Time.deltaTime;
        if (tempo <6)
        {

            transform.position += new Vector3(-1, 0, 0) * velocidadeinimigos;
            olhando = false;
        }
        else if (tempo == 5)
        {

        }
        else if (tempo > 6 && tempo < 12)
        {
            transform.position += new Vector3(1, 0, 0) * velocidadeinimigos;

        }
        else if (tempo >= 12)
        {
            Virar();
            tempo = 0;


        }

        if (olhando == false && tempo >= 6 || olhando == true && tempo >= 12)
        {
            olhando = true;
            Virar();
            corpo.AddForce(new Vector2(0f, forcapulo), ForceMode2D.Impulse);
        }
    }
    void Virar()
    {

        transform.Rotate(0, 180f, 0);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TomaDano(5);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "vira")
        {
            Virar();
        }
    }


}
