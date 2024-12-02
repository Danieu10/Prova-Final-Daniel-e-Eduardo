using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinossauro : MonoBehaviour
{
    public float velocidadeinimigo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * velocidadeinimigo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
