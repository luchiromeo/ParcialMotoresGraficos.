using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemigoLaterales : MonoBehaviour 
{
    bool Bajo = false;
    int rapidez = 10; 
    void Update() 
    { 
        if (transform.position.y >=8)
        {
            Bajo = true; 
        } else if (transform.position.y <=2) 
        {
          Bajo = false;
        }
        if (Bajo)
        { 
            Down();
        } else
        {
           Up();
        } 
    } 
    void Up() 
    {
        transform.position += transform.up * rapidez * Time.deltaTime; 
    } 
    void Down() 
    { 
        transform.position -= transform.up * rapidez * Time.deltaTime; 
    } 
}