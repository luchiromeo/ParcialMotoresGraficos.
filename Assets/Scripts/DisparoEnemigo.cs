using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{   
    [SerializeField]
   
    private GameObject BalaEnemiga;
  
    [SerializeField]
    private float Time = 0.5f;
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
            GameObject pro = Instantiate(BalaEnemiga, transform.position, transform.rotation);
            pro.GetComponent<Rigidbody>().AddForce(transform.forward * 15, ForceMode.Impulse);
            yield return new WaitForSeconds(Time);
        }
        Debug.Log("Fin corountine");
    }
    

}
