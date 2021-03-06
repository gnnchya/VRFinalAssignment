using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class runningGame : MonoBehaviour
{
    [SerializeField] GameObject start_button;
    [SerializeField] float timeLeft = 40f;

    [SerializeField] TMPro.TextMeshProUGUI countdown;
    [SerializeField] TMPro.TextMeshProUGUI countdownScreen;
    [SerializeField] GameObject screen;
    [SerializeField] GameObject congrats;


    [SerializeField] GameObject instruction;
    [SerializeField] AudioSource successSound;
    [SerializeField] AudioSource bgm;
    [SerializeField] GameObject token;




    private bool canRun = false;
    private bool won = false;


    void Update()
    {
        if(canRun)
        {
            if(timeLeft > 0 && (!won))
            {
                timeLeft -= Time.deltaTime;
                countdown.text = "Time : " + Mathf.Round(timeLeft);
                countdownScreen.text = "Time : " + Mathf.Round(timeLeft);
                if (won)
                {
                    timeLeft = 0f;
                }
            }
            else
            {

                if (won)
                {
                    Debug.Log("win");
                    bgm.Stop();
                    start_button.SetActive(false);
                    congrats.SetActive(true);
                    countdown.text = "Congratulations";
                    Instantiate(token, new Vector3(44.54f, 5.83f, 69.59f), this.transform.rotation);


                }
                else if (!won)
                {
                    Debug.Log("lose");
                    bgm.Stop();
                    start_button.SetActive(true);
                    countdown.text = "";

                }

                screen.SetActive(false);
                countdownScreen.text = "";
                canRun = false;
            }
            
        }
    }

    public void Run()
    {
        Time.timeScale = 1;
        bgm.Play();
        canRun = true;
        timeLeft = 40f;
        countdown.text = "Time : " + Mathf.Round(timeLeft); 
        countdownScreen.text = "Time : " + Mathf.Round(timeLeft);
        start_button.SetActive(false);
        screen.SetActive(true);
    }

    //when the player hand umbrella to npm
    public void win()
    {   
        Debug.Log("Congratulations!");
        successSound.Play();
        won = true;
    }


}