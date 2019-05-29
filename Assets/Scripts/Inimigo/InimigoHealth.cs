using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InimigoHealth : MonoBehaviour
{
    public Inimigo inimigoScritp;

    public event Action<float> OnHealthPctChanged = delegate { };


    private void OnEnable()
    {
        inimigoScritp = GetComponent<Inimigo>();
    }

    public void ModifyHealth(int amount)
    {
        inimigoScritp.vida += amount;

        float currentHealthPct = (float)inimigoScritp.vida / (float)inimigoScritp.vidaMax;
        OnHealthPctChanged(currentHealthPct);
    }
}
