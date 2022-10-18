using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    private int hp;
    void Start() 
    { 
        hp = 100;
    }
    public void recibirDa�o() 
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
            recibirDa�o(); 
        } 
    }

}


