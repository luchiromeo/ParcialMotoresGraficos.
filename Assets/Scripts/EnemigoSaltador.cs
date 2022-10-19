using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSaltador : MonoBehaviour
{
    GameObject EnemigoSaltarin;

    bool descender = false;
    int rapidez = 10; 
    void Update() 
    {
        if (transform.position.y >= 8)
        {
            descender = true;
        } 
        if (transform.position.y <= 2)
        {
            descender = false;
        } 
        if (descender)
        {
            Bajar();
        } 
        else 
        { Subir();
        } 
    }
    void Subir()
    {
        transform.position += transform.up * rapidez * Time.deltaTime; 
    }
    void Bajar()
    {
        transform.position -= transform.up * rapidez * Time.deltaTime; 
    }

    private void OnColissionEnter(Collision other)
    {
       if (other.gameObject.CompareTag("Jugador") == true)
        {
           
        }
    }

}

