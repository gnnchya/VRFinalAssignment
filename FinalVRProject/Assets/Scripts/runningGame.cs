using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class runningGame : MonoBehaviour
{
    [SerializeField] GameObject start_button;
    [SerializeField] float timeLeft = 40f;
    [SerializeField] GameObject umbrella; //object to grab
    [SerializeField] GameObject npm; //person at the zoo exit

    [SerializeField] TMPro.TextMeshProUGUI countdown;
    [SerializeField] AudioSource successSound;
    [SerializeField] AudioSource bgm;



    private bool canRun = false;



    // void Awake()
    // {
    //     XRSocketInteractor socket = gameObject.GetComponent<XRSocketInteractor>();
    //     socket.onSelectEnter.AddListener();
    //     socket.onSelectExit.AddListener()
    // }

    void Update()
    {
        if(canRun)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                countdown.text = "Time : " + Mathf.Round(timeLeft);
            }
            else
            {
                // time up fail!
                Time.timeScale = 0;
                canRun = false;
            }
        }
    }

    public void Run()
    {
        Time.timeScale = 1;
        bgm.Play();
        canRun = true;
        countdown.enabled = true;
        countdown.text = "Time : " + Mathf.Round(timeLeft);
    }

    //when the player hand umbrella to npm
    private void OnCollisionEnter(Collision collision)
    {   
        if(collision.gameObject.tag == "umbrella")
        {
            Debug.Log("Congratulations!");
            successSound.Play();
        }

    }

}