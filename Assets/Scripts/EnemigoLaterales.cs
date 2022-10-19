using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemigoLaterales : MonoBehaviour 
{
    bool VoyIzquierda = false;
    int rapidez = 10; 
    void Update() 
    { 
        if (transform.position.y >= 8)
        {
            VoyIzquierda = true; 
        } 
        if (transform.position.y <= 0) 
        { VoyIzquierda = false;
        }
        if (VoyIzquierda)
        { 
            Izquierda();
        } else
        {
            Derecha();
        } 
    } 
    void Derecha() 
    {
        transform.position += transform.right * rapidez * Time.deltaTime; 
    } 
    void Izquierda() 
    { 
        transform.position -= transform.right * rapidez * Time.deltaTime; 
    } 
}