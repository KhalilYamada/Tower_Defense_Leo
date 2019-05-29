using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Torre : MonoBehaviour
{
    public int vida = 100;

    public ScoreManager pontuacao;

    [Header("Torre")]
    public int qualTorre = 1;

    public GameObject[] hudTorre;

    public GameObject torre_01;
    public GameObject torre_02;
    public GameObject torre_03;


    void Awake ()
    {
        transform.tag = "Torre";
	}

    private void Update()
    {
        TorreAtiva();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Inimigo")
        {
            Debug.Log("Colidiu com inimigo");
        }
    }

    void TorreAtiva()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5) && pontuacao.score >= 2000 && qualTorre <= 2)
        {
            qualTorre++;
            pontuacao.score -= 2000;
        }

        switch (qualTorre)
        {
            case 1:
                hudTorre[0].SetActive(true);
                hudTorre[1].SetActive(false);
                hudTorre[2].SetActive(false);
                torre_01.SetActive(true);
                torre_02.SetActive(false);
                torre_03.SetActive(false);
                break;

            case 2:
                hudTorre[0].SetActive(false);
                hudTorre[1].SetActive(true);
                hudTorre[2].SetActive(false);
                torre_01.SetActive(false);
                torre_02.SetActive(true);
                torre_03.SetActive(false);
                break;

            case 3:
                hudTorre[0].SetActive(false);
                hudTorre[1].SetActive(false);
                hudTorre[2].SetActive(true);
                torre_01.SetActive(false);
                torre_02.SetActive(false);
                torre_03.SetActive(true);
                break;
        }
    }
}
