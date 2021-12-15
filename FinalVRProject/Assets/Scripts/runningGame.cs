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
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                countdown.text = "Time : " + Mathf.Round(timeLeft);
                if (won)
                {
                    timeLeft = 0f;
                }
            }
            else
            {
                Time.timeScale = 0;
                canRun = false;

                if (won)
                {
                    bgm.Stop();
                    instruction.SetActive(false);
                    start_button.SetActive(false);
                    countdown.text = "Congratulations";
                    Instantiate(token, new Vector3(24.7f, 3.9f, 49.5f), this.transform.rotation);


                }
                else if (!won)
                {
                    bgm.Stop();
                    instruction.SetActive(true);
                    start_button.SetActive(true);
                    countdown.enabled = false;
                }
                
            }
        }
    }

    public void Run()
    {
        Time.timeScale = 1;
        bgm.Play();
        canRun = true;
        countdown.enabled = true;
        start_button.SetActive(false);
        countdown.text = "Time : " + Mathf.Round(timeLeft);
    }

    //when the player hand umbrella to npm
    private void OnCollisionEnter(Collision collision)
    {   
        if(collision.gameObject.tag == "umbrella")
        {
            Debug.Log("Congratulations!");
            successSound.Play();
            won = true;
        }

    }

}