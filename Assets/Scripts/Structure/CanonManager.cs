using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanonManager : MonoBehaviour
{
    public ScoreManager pontuacao;
    private bool canhaoVivo;

    public TextMeshProUGUI textLevel;
    public TextMeshProUGUI textLevelUp;


    [Header("Canhões")]
    public GameObject canhao;
    public Turrent turretScript;

    [Header("Qual tecla")]
    [SerializeField]    
    private KeyCode tecla;

    [Header("Preços")]
    [SerializeField]
    private float criar = 300;
    [SerializeField]
    private float upar = 200;

    private void Start()
    {
        pontuacao = GameObject.FindWithTag("Score").GetComponent<ScoreManager>();
    }


    private void Update()
    {
        Canhao();
        LevelAtual();
    }


    void Canhao()
    {
        if (Input.GetKeyDown(tecla) && pontuacao.score >= upar && canhaoVivo == true && turretScript.FireRate <= 1f)
        {
            pontuacao.score -= upar;
            turretScript.FireRate += 0.1f;
            upar = upar + 30;
        }

        if (Input.GetKeyDown(tecla) && pontuacao.score >= criar && canhaoVivo == false)
        { 
            pontuacao.score -= criar;
            canhao.SetActive(true);
            canhaoVivo = true;
        }
    }    

    void LevelAtual()
    {
        if (turretScript.FireRate <= 0.9f && canhaoVivo == false)
        {
            textLevelUp.text = "Next Lv." + Mathf.RoundToInt(criar);
            textLevel.text = "Lv.0";
        }
        else if (turretScript.FireRate <= 0.99f)
        {
            textLevelUp.text = "Next Lv." + Mathf.RoundToInt(upar);
            textLevel.text = "Lv." + Mathf.RoundToInt(turretScript.FireRate * 10);
        }
        else
        {
            textLevelUp.text = "Next Lv.Max";
            textLevel.text = "Lv.Max";
        }

    }
}
