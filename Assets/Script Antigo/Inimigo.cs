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
    private Torre Torre;
    private NavMeshAgent NavMesh;
    private bool PodeAtacar;

    ScoreManager scoreScript;

    public int vida = 100;

    public float points = 100;

    void Start ()
    {
        PodeAtacar = true;
        Torre = GameObject.FindWithTag("Torre").GetComponent<Torre>();
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        NavMesh = GetComponent<NavMeshAgent>();
        NavMesh.destination = Torre.transform.position;
    }
	

    void Atacar(string alvo)
    {
        if (PodeAtacar == true)
        {
            StartCoroutine("TempoDeAtaque");
            switch (alvo)
            {
                default:
                    Torre.vida -= 5;
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
            Debug.Log("recebeuDano");
            vida -= 5;
            if(vida <= 0)
            {
                scoreScript.score += points;
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Torre"))
        {
            Atacar(other.tag);
            Debug.Log("atacando");
        }

        if (other.CompareTag("ChamaInimigoToPlayer"))
        {
            NavMesh.destination = Player.transform.position;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        NavMesh.destination = Torre.transform.position;
    }
}
