using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]


public class Inimigo : MonoBehaviour
{
    private PlayerStats Player;
    [SerializeField]
    public GameObject Obj;
    public Torre torre;
    private NavMeshAgent NavMesh;
    private bool PodeAtacar;

    public ScoreManager scoreScript;

    public int vida = 100;

    public float points = 100;

    void Start ()
    {
        PodeAtacar = true;
        Obj = GameObject.FindWithTag("Torre");

        torre = Obj.GetComponent<Torre>();


        Player = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        scoreScript = GameObject.FindWithTag("Score").GetComponent<ScoreManager>();
        NavMesh = GetComponent<NavMeshAgent>();
        NavMesh.destination = torre.transform.position;
    }


    private void Update()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
            scoreScript.score += points;
        }
    }


    void Atacar(string alvo)
    {
        if (PodeAtacar == true)
        {
            StartCoroutine("TempoDeAtaque");
            switch (alvo)
            {
                default:
                    torre.vida -= 5;
                    break;

                case "Player":
                    Player.vida -= 5;
                    break;
            }
                NavMesh.isStopped = true;
        }
    }

    IEnumerator TempoDeAtaque()
    {
        PodeAtacar = false;
        yield return new WaitForSeconds (3);
        PodeAtacar = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            vida -= 5;
        }
        if (other.CompareTag("WeaponHitbox"))
        {
            vida -= 10;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        /*
        if (other.CompareTag("Torre"))
        {
            Atacar(other.tag);
            Debug.Log("atacando");
        }

        if (other.CompareTag("ChamaInimigoToPlayer"))
        {
            NavMesh.destination = Player.transform.position;
        }
        else
        {
            NavMesh.destination = Torre.transform.position;
        }

        if (other.CompareTag("Player"))
        {
            Atacar(other.tag);
        }
        */
        
        
        switch (other.tag)
        {
            case "Torre":
                Atacar(other.tag);
                Debug.Log("atacando");
                break;


            case "ChamaInimigoToPlayer":
                NavMesh.destination = Player.transform.position;
                break;


            case "Player":
                Player.vida -= 5;
                break;

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NavMesh.isStopped = false;
        }
    }
}
