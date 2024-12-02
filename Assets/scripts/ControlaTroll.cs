using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaTroll : MonoBehaviour
{
    public float velocidadeinimigos = 2;
    public float tempo = 0;
    public bool olhando = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tempo += 1 * Time.deltaTime;
        if (tempo < 5)
        {

            transform.position += new Vector3(-1, 0, 0) * velocidadeinimigos;
            olhando = false;
        }
        else if (tempo == 5)
        {

        }
        else if (tempo > 5 && tempo < 10)
        {
            transform.position += new Vector3(1, 0, 0) * velocidadeinimigos;

        }
        else if (tempo >= 10)
        {
            Virar();
            tempo = 0;


        }

        if (olhando == false && tempo >= 5 || olhando == true && tempo >= 10)
        {
            olhando = true;
            Virar();
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
}
