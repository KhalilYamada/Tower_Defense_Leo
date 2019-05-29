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
    public Animator animPlayer;

    [SerializeField]
    public GameObject Obj;
    public Torre torre;
    private NavMeshAgent NavMesh;
    private bool PodeAtacar;

    public ScoreManager scoreScript;

    public int vidaMax = 100;
    public int vida;

    public float points = 100;

    public InimigoHealth inimigoVidaUpdate;


    void Start ()
    {
        inimigoVidaUpdate = GetComponent<InimigoHealth>();

        vida = vidaMax;

        PodeAtacar = true;
        Obj = GameObject.FindWithTag("Torre");

        torre = Obj.GetComponent<Torre>();

        animPlayer = GameObject.FindWithTag("Player").GetComponent<Animator>();
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
                    animPlayer.SetTrigger("Hit");
                    Player.vida -= 5;
                    break;
            }
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
            inimigoVidaUpdate.ModifyHealth(-5);
        }
        if (other.CompareTag("WeaponHitbox"))
        {
            inimigoVidaUpdate.ModifyHealth(-10);
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
                Debug.Log("atacandoTorre");
                break;


            case "ChamaInimigoToPlayer":
                NavMesh.destination = Player.transform.position;
                break;


            case "Player":
                NavMesh.isStopped = true;
                if (Player.vida >= 1)
                {
                    Atacar(other.tag);
                }                
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
