using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAgent : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int index = 0;

    public GameObject objectToSpawn; // O GameObject que voc� quer instanciar

    [SerializeField] private Rigidbody2D rb;

    private float distancia = 0.3f;
    private float velocidade = 5;
    private Vector2 direcao;
    GameObject obj;
    Player pla;
    public float time;
    public GameObject[] SpawnItens;
    int random;

    private void Start()
    {
        StartCoroutine(SpawnObjectRepeatedly());
        obj = GameObject.Find("Player");
        pla = obj.GetComponent<Player>();
        
    }
    private void Update()
    {
        //contador de tempo
        time = time + Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Movimento();
    }

    private void Movimento()
    {
        //transform.up = waypoints[index].position - transform.position;
        //especifica a proxima direcao que o esgoto deve seguir
        direcao = ((Vector2)waypoints[index].position - rb.position).normalized;
        //movimenta o esgoto
        rb.MovePosition(rb.position + direcao * velocidade * Time.deltaTime);
        //atualiza a proxima direcao do esgoto
        if (Vector3.Distance(transform.position, waypoints[index].position) <= distancia && time > 4.3f)
        {
            index++;
            if (index >= waypoints.Length)
            {
                velocidade = 0;
            }
        }
    }
    
    IEnumerator SpawnObjectRepeatedly()
    {
        while (true)
        {
            // Instancia o GameObject
            random = Random.Range(0, SpawnItens.Length);
            GameObject temp = Instantiate(SpawnItens[random]);
            temp.transform.position = new Vector2(this.gameObject.transform.position.x , this.gameObject.transform.position.y);

            // Aguarda 2 segundos
            yield return new WaitForSeconds(1f);
        }
    }
}

   

    

    

