using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //variaveis andar
    public float velocidade = 5;
    //variaveis pulo
    public float forcapulo = 5;
    public Rigidbody2D corpo;
    float podepular = 0;
    int limitepulo;
    //variaveis dash
    public float forcadash = 5;
    float tempodash = 0.07f;
    bool podedardash=true;
    //variaveis virar
    float direcao;
    bool olhandopradireita =true;
    //variaveis atirar
    public Transform origemataque;
    public GameObject prefabprojetil;
    bool podedartiro = true;
    public float tempoentretiros;
    public float velocidadeprojetil;
    //variaveis atirar aprimorado
    public GameObject prefabprojetilaprimorado;
    //variaveis interação com inimigos
    int olhandonadirecao = 1;
    bool recuperando;
    public float tempoderecupeacao;
    bool podesemover = true;
    public int pontosdevida = 10;
    public LayerMask layerinimigos;
    float calculatemporecuperacao;
    bool tatomandodano;
    //variaveis animação
    public Animator animator;
    bool estanochao;
    //variaveis poderes
    public bool puloduploliberado;
    public bool ataqueliberado;
    public bool dashliberado;
    public bool ataqueaprimoradoliberado;
    public bool podersecretoliberado;

    // Start is called before the first frame update
    void Start()
    {
        if(puloduploliberado == false)
        {
            limitepulo = 1;
        }
        else
        {
            limitepulo = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (podesemover == true)
        { 
         Andar(); 
        }
        
        Pular();
        Virar();
        Recuperação();
       
        if (ataqueliberado && !ataqueaprimoradoliberado )
        {
          Atirar();
        }
        
        if(ataqueaprimoradoliberado)
        {
            AtirarAprimorado();
        }

        if (dashliberado)
        {
            Dash();
        }
        
    }
    private void FixedUpdate()
    {
        animator.SetFloat("velocidadex", Mathf.Abs(direcao));
        animator.SetBool("estanochao", estanochao);
        animator.SetFloat("velocidadey", corpo.velocity.y);
        animator.SetBool("dano",tatomandodano);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="chao")
        {
            podepular=0;
            estanochao=true;
        }
        if(collision.gameObject.tag=="fase2")
        {
            SceneManager.LoadScene("2fase");
        }
        else if (collision.gameObject.tag == "fase3")
        {
            SceneManager.LoadScene("3fase");
        }
        else if(collision.gameObject.tag == "fase4")
        {
            SceneManager.LoadScene("4fase");
        }
        else if (collision.gameObject.tag == "fase5")
        {
            SceneManager.LoadScene("5fase");
        }
        else if(collision.gameObject.tag == "vitoria")
        {
            SceneManager.LoadScene("telavitoria");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="chao")
        {
            estanochao = false;
        }
    }
    void Virar()
    {
        olhandonadirecao *= -1;
        direcao = Input.GetAxis("Horizontal");
        if (direcao < 0 && olhandopradireita || direcao>0 && !olhandopradireita)
        {
            olhandopradireita = !olhandopradireita;
            transform.Rotate(0, 180f, 0);
        }
    }
  
    void Andar()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * velocidade;

    }
    
    void Pular()
    {
        if (podepular < limitepulo)
        {
            if (Input.GetButtonDown("Jump"))
            {
                corpo.AddForce(new Vector2(0f, forcapulo), ForceMode2D.Impulse);
                podepular++;
            }
        }
    }

    void Atirar()
    {
        if (podedartiro == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject projetil = Instantiate(prefabprojetil, origemataque.position, transform.rotation);

                if (olhandopradireita)
                {
                    projetil.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeprojetil, 0);
                }
                else
                {
                    projetil.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeprojetil, 0);
                }
                podedartiro = false;
                Invoke("PermiteAtirar", tempoentretiros);
            }
        }
        
    }

    void PermiteAtirar()
    {
        podedartiro = true;
    }
    void AtirarAprimorado()
    {
        if (podedartiro == true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                GameObject projetill = Instantiate(prefabprojetilaprimorado, origemataque.position, transform.rotation);

                if (olhandopradireita)
                {
                    projetill.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeprojetil, 0);
                }
                else
                {
                    projetill.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeprojetil, 0);
                }
                podedartiro = false;
                Invoke("PermiteAtirar", tempoentretiros);
            }
        }
    }

    void Dash()
    {
        if(podedardash == true)
        {
            if (Input.GetKeyDown(KeyCode.V)) 
            {
                if (olhandopradireita)
                {
                    corpo.AddForce(new Vector2(forcadash, 0f), ForceMode2D.Impulse);
                }
                else
                {
                    corpo.AddForce(new Vector2(-forcadash, 0f), ForceMode2D.Impulse);
                }

                    podedardash = false;
                Invoke("PermiteDash",tempodash);
            }
        }
    }
    void PermiteDash()
    {
        podedardash = true;
    }
    void Knockback()
    {
        corpo.AddForce(new Vector2(2 * olhandonadirecao, 3), ForceMode2D.Impulse);

       
    }

    IEnumerator Congela()
    {
        podesemover = false;
        yield return new WaitForSeconds(0.5f);
        podesemover = true;
    }
    
    public void TomaDano(int dano)
    {
        tatomandodano = true;
        Knockback();
        pontosdevida -= dano;
        recuperando = true;
        if (pontosdevida<= 0)
        {
            Morte();
        }
        
    }
   
    void Morte()
    {
        Destroy(gameObject);
    }

    void Recuperação()
    {
        if (recuperando)
        {
            calculatemporecuperacao += Time.deltaTime;
            if (calculatemporecuperacao >= tempoderecupeacao)
            {
                calculatemporecuperacao = 0;
                recuperando = false;
                tatomandodano = false;
            }
        }
    }
}
