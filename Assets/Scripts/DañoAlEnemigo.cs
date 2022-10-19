using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoAlEnemigo : MonoBehaviour
{
    private GameObject Jugador;
    
    private int hp;
  
    void Start()
    {
        hp = 100;
    }

   
    void Update()
    {
        
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
