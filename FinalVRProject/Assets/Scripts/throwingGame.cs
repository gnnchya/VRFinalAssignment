using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class throwingGame : MonoBehaviour
{
    [SerializeField] GameObject instruction;
    [SerializeField] GameObject start_button;
    [SerializeField] GameObject token;

    //[SerializeField] GameObject checkpoint1;
    //[SerializeField] GameObject checkpoint2;
    //[SerializeField] GameObject checkpoint3;
    //[SerializeField] int checkCount = 0;

    //[SerializeField] GameObject[] redAppleArray;
    //[SerializeField] GameObject[] greenAppleArray;

    [SerializeField] AudioSource successSound;
    [SerializeField] AudioSource bgm;

    [SerializeField] int currentScore = 0;
    [SerializeField] TMPro.TextMeshProUGUI textScore;
    [SerializeField] TMPro.TextMeshProUGUI countdown;

    [SerializeField] float maxTime = 30f;
    [SerializeField] int winPoint = 10;

    //[SerializeField] GameObject redApplePrefabs;
    //[SerializeField] GameObject greenApplePrefabs;

    float timeLeft;
    private bool canRun = false;
    //public int levelIndex = 1;

    // Update is called once per frame
    void Update()
    {
        if (canRun)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                countdown.text = "Time : " + Mathf.Round(timeLeft);

            }
            else
            {
                Time.timeScale = 0;
                if (currentScore >= winPoint)
                {
                    bgm.Stop();
                    instruction.SetActive(false);
                    start_button.SetActive(false);
                    textScore.enabled = true;
                    countdown.text = "Congratulations";
                    Instantiate(token, new Vector3(24.7f , 3.9f, 49.5f ), this.transform.rotation);
                }
                else
                {
                    bgm.Stop();
                    instruction.SetActive(true);
                    start_button.SetActive(true);
                    textScore.enabled = false;
                    countdown.enabled = false;

                }

                canRun = false;
            }

        }

    }

    public void Run()
    {
        Time.timeScale = 1;
        bgm.Play();
        canRun = true;
        timeLeft = maxTime;
        textScore.enabled = true;
        countdown.enabled = true;
        countdown.text = "Time : " + Mathf.Round(maxTime);
        countdown.text = "Point : 0";

    }

    private void OnCollisionEnter(Collision collision)
    {

        // when collide
        if (collision.gameObject.tag == "redApple")
        {

            Debug.Log("red apple");

            // if coin is collected, make the coin disappear and increase the score
            successSound.Play();
            currentScore++;
            textScore.text = "Score : " + currentScore;

            StartCoroutine(Respawning(collision.gameObject));

        }
        else if (collision.gameObject.tag == "greenApple")
        {
            successSound.Play();
            Debug.Log("green apple");

            // if coin is collected, make the coin disappear and increase the score
            currentScore++;
            currentScore++;
            textScore.text = "Score : " + currentScore;

            StartCoroutine(Respawning(collision.gameObject));
        }
    }


    IEnumerator Respawning(GameObject apple)
    {
        apple.SetActive(false);
        int table = Random.Range(0, 1);
        float a = Random.Range(0f, 1f);
        float b = Random.Range(0f, 0.3f);
        if (table == 1)
        {
            apple.transform.position = new Vector3(24.3f + a, 3.9f, 49.1f + b);

        } else
        {
            apple.transform.position = new Vector3(25.7f + a, 3.9f, 49.6f + b);
        }
        yield return new WaitForSeconds(5);

        apple.SetActive(true);
    }

    //public void Checkpoint(GameObject checkpoint)
    //{
    //    checkpoint.SetActive(false);
    //    checkCount++;
    //}


}