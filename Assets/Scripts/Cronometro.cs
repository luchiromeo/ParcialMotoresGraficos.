using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    float currentTime;
    public float startingTime = 60f;
    public TMPro.TMP_Text textoGameOver;
    public TMPro.TMP_Text PresioneH;
    [SerializeField] 
    TextMeshProUGUI countdownText;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime = currentTime - 1 * Time.deltaTime; 
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            textoGameOver.text = " GAME  OVER!!!! ";
            PresioneH.text = "Presione H para reiniciar";
            if (Input.GetKeyDown(KeyCode.H)) 
            {
              
                SceneManager.LoadScene(0);
            }

            
        }
    }
}