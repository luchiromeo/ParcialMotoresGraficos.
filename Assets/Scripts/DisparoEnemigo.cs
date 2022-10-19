using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{   
    [SerializeField]
   
    private GameObject Balas;
  
    [SerializeField]
    private float Time = 2f;
    private int maximoContador = 25;
    private int contador;
  
   
    void Start()
    {
        StartCoroutine(ProyectilEnemigo());
   
       
    }

   
    void Update()
    {
       
    }
    IEnumerator ProyectilEnemigo()
    {
        Debug.Log("InicioCoroutine");
        for (int i = 0; i < maximoContador; i++)
        {
            contador++;
            Instantiate(Balas, transform.position, transform.rotation);
            yield return new WaitForSeconds(Time);
        }
        Debug.Log("Fin corountine");
    }
    

}
