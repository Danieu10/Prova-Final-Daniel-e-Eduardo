using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportaCrystal : MonoBehaviour
{
    public GameObject troll;
    public GameObject crystalposicao;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (troll == null)
        {
            transform.position= crystalposicao.transform.position ;
                
        }
    }
}
