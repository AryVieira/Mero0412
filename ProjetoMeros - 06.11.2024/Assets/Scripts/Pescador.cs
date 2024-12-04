using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pescador : MonoBehaviour
{
    public GameObject player, ponto;
    public float speed;
    private bool seguiu;
    
    GameObject obj;
    Player pla;
    private Animator anim;

    void Start()
    {
        player = GameObject.Find("Player");
        speed = 10;
        seguiu = false;
        anim = GetComponent<Animator>();
        obj = GameObject.Find("Player");
        pla = obj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!seguiu)
        {
            transform.position = Vector2.MoveTowards(transform.position, ponto.transform.position, speed * Time.deltaTime);
            
        }
    }
    private void Seguir()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&seguiu)
        {
            Seguir();
            
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            seguiu = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            seguiu = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pla.PerdeVida(-1);
        }
    }
    
}
    


