using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilInimigo : MonoBehaviour
{
    public float tempodevida;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroiProjetil", tempodevida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TomaDano(1);

        }
    }
    void DestroiProjetil()
    {
        Destroy(gameObject);
    }
}
