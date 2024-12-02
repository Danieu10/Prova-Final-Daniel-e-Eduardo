using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coletacherry : MonoBehaviour
{

    public Text scoreTxt;
    public int score;


    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreTxt.text=score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("cherry")==true)
        {
            score = score + 1;
            Destroy(col.gameObject);
        }
    }
}
