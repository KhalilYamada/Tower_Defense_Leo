using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text pontuacao;

    public float score = 0;

    void Update()
    {
        AtualizaPontuacao();
    }


    void AtualizaPontuacao()
    {
        pontuacao.text = "Score: " + score;
    }
}
