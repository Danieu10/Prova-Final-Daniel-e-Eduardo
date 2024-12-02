using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueDragão : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inimigo;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float tempoentreinimigos;
    float tempospawn;
    // Update is called once per frame
    void Update()
    {
        if (Time.time > tempospawn)
        {
            Spawn();
            tempospawn = Time.time + tempoentreinimigos;
        }

    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(inimigo, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
