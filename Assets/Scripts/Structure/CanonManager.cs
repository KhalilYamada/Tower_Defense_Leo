using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonManager : MonoBehaviour
{
    public ScoreManager pontuacao;
    private bool canhaoVivo;

    [Header("Canhões")]
    public GameObject canhao;
    public Turrent turretScript;

    [Header("Qual tecla")]
    [SerializeField]    
    private KeyCode tecla;



    private void Start()
    {
        pontuacao = GameObject.FindWithTag("Score").GetComponent<ScoreManager>();
    }


    private void Update()
    {
        Canhao();
    }


    void Canhao()
    {
        if (Input.GetKeyDown(tecla) && pontuacao.score >= 300 && canhaoVivo == true && turretScript.FireRate <= 1f)
        {
            pontuacao.score -= 300;
            turretScript.FireRate += 0.1f;
        }

        if (Input.GetKeyDown(tecla) && pontuacao.score >= 200 && canhaoVivo == false)
        { 
            pontuacao.score -= 200;
            canhao.SetActive(true);
            canhaoVivo = true;
        }
    }    
}
