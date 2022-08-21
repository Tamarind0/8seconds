using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Gameplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timerText;
    [SerializeField]
    private float currentTimer = 0f;
    private float startTime = 8.0f;
    // Start is called before the first frame update

    public void Start()
    {
        currentTimer = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();

        if (currentTimer <= 0)
        {
            GameOver();
        }
    }

    private void UpdateTimer()
    {
        currentTimer -= 1 * Time.deltaTime;
        timerText.text = currentTimer.ToString("0");
    }

    private void GameOver()
    {
        
    }
}
