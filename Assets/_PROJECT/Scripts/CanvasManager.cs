using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject inGamePanel;
    [SerializeField] GameObject spawnField;

    [SerializeField] Text timerCounterText;
    [SerializeField] Text timerText;

    [HideInInspector] public List<Player> playerClasses = new List<Player>();

    private float timer = 5f;


    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (Player.onlinePlayers.Count == 1)
        {
            gameObject.SetActive(true);
            inGamePanel.SetActive(true);

            timer -= Time.deltaTime;
            int seconds = (int)(timer % 60);
            if (seconds >= 0)
            {
                timerCounterText.text = seconds.ToString();
            }
            if (seconds == 0)
            {
                spawnField.SetActive(false);
                timerCounterText.enabled = false;
                timerText.text = "RUN !";
            }
            else if (seconds == -3)
            {
                timerText.enabled = false;
            }
        }

    }
}
