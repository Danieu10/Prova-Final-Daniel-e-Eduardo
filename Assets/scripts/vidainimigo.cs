using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class vidainimigo : MonoBehaviour
{
    // Start is called before the first frame update
    public int vida;
    public GameObject barreira;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Invoke("DestroiInimigo",0.2f);
         
            if (barreira != null)
            {
                barreira.SetActive(false);
            }
            
        }

       
    }

    public void TomaDano(int dano)
    {
        vida -= dano;
        Debug.Log("oi");
    }

    void DestroiInimigo()
    {
        Destroy(gameObject);
    }
}
