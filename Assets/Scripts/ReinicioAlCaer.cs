using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;


public class ReinicioAlCaer : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Jugador"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       
    }
}
