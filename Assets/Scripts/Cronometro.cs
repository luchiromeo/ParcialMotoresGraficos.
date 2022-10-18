using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    float currentTime;
    public float startingTime = 60f; 

    [SerializeField] TextMeshProUGUI countdownText;
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

            
            SceneManager.LoadScene(0);
        }
    }
}