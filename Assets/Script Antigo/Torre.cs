using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    public int vida = 100;
	
	void Awake ()
    {
        transform.tag = "Torre";
	}	

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Inimigo")
        {
            Debug.Log("Colidiu com inimigo");
        }
    }

}
