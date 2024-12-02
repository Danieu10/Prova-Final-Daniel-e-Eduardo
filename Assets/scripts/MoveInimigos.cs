using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInimigos : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidade = -10.0f;

    void Update()
    {
        transform.position = transform.position + new Vector3(1, 0, 0) * velocidade * Time.deltaTime;
    }
}
