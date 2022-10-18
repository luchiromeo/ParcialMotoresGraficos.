using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigoUno : MonoBehaviour
{
    private int hp; 
    private GameObject Jugador;
    public int rapidez;

    void Start()
    {
        hp = 100;
        Jugador = GameObject.Find("Jugador");
    }

    private void Update() 
    { 
        transform.LookAt(Jugador.transform);
        transform.Translate(rapidez * Vector3.forward * Time.deltaTime); 
    }
    public void recibirDaño()
    {
        hp = hp - 25; if (hp <= 0) 
        { 
            this.desaparecer(); 
        } 
    }
    private void desaparecer()
    { 
        Destroy(gameObject); 
    }
    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Bala"))
        { 
            recibirDaño();
        } 
    }
}




