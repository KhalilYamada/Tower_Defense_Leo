using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text pontuacao;

    public float score = 0;

    private bool canhao_01_vivo;
    private bool canhao_02_vivo;
    private bool canhao_03_vivo;
    private bool canhao_04_vivo;

    public GameObject canhao_01;
    public GameObject canhao_02;
    public GameObject canhao_03;
    public GameObject canhao_04;

    public Turrent turretScript_canhao_01;
    public Turrent turretScript_canhao_02;
    public Turrent turretScript_canhao_03;
    public Turrent turretScript_canhao_04;



    private void Start()
    {
        turretScript_canhao_01 = canhao_01.GetComponent<Turrent>();
        turretScript_canhao_02 = canhao_02.GetComponent<Turrent>();
        turretScript_canhao_03 = canhao_03.GetComponent<Turrent>();
        turretScript_canhao_04 = canhao_04.GetComponent<Turrent>();
    }


    void Update()
    {



        Canhao(KeyCode.Alpha1, canhao_01, canhao_01_vivo, turretScript_canhao_01);
        Canhao(KeyCode.Alpha2, canhao_02, canhao_02_vivo, turretScript_canhao_02);
        Canhao(KeyCode.Alpha3, canhao_03, canhao_03_vivo, turretScript_canhao_03);
        Canhao(KeyCode.Alpha4, canhao_04, canhao_04_vivo, turretScript_canhao_04);



        AtualizaPontuacao();
    }


    void Canhao(KeyCode tecla, GameObject qualCanhao, bool canhaoVivo, Turrent qualScript)
    {
        if (Input.GetKeyDown(tecla) && score >= 300 && canhaoVivo == true)
        {
            score -= 300;
            qualScript.FireRate += 0.1f;
        }

        if (Input.GetKeyDown(tecla) && score >= 200 && canhaoVivo == false)
        {
            score -= 200;
            qualCanhao.SetActive(true);
            canhaoVivo = true;
        }
    }


    void AtualizaPontuacao()
    {
        pontuacao.text = "Score: " + score;
    }
}
