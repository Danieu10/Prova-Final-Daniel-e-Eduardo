using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour
{
    public int dano;
    public float tempoDeVida;
    public float distancia;
    public LayerMask layerInimigo;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroiProjetil",tempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.forward, distancia, layerInimigo);
        if (hitinfo.collider != null)
        {
            Debug.Log("hit");


            if (hitinfo.collider.CompareTag("inimigo"))
            {
                hitinfo.collider.GetComponent<vidainimigo>().TomaDano(dano);
            }
            DestroiProjetil();

        }
    }

    void DestroiProjetil()
    {
        Destroy(gameObject);
    }
}
