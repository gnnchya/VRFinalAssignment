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

    [SerializeField] GameObject screen;
    [SerializeField] TMPro.TextMeshProUGUI countdownScreen;
    [SerializeField] TMPro.TextMeshProUGUI pointScreen;

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
                countdownScreen.text = "Time : " + Mathf.Round(timeLeft);

            }
            else
            {
                if (currentScore >= winPoint)
                {
                    bgm.Stop();
                    instruction.SetActive(false);
                    start_button.SetActive(false);
                    screen.SetActive(false);
                    countdown.text = "Congrats";
                    Instantiate(token, new Vector3(24.7f , 3.9f, 49.5f ), this.transform.rotation);
                }
                else
                {
                    bgm.Stop();
                    instruction.SetActive(true);
                    start_button.SetActive(true);
                    screen.SetActive(false);
                    textScore.text = "";
                    countdown.text = "";
                    countdownScreen.text = "";
                    pointScreen.text = "";

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
        start_button.SetActive(false);
        screen.SetActive(true);
        currentScore = 0;
        countdown.text = "Time : " + Mathf.Round(maxTime);
        textScore.text = "Score : 0";
        countdownScreen.text = "Time: " + Mathf.Round(maxTime);
        pointScreen.text = "Score : 0";
    }

    private void OnCollisionEnter(Collision collision)
    {

        // when collide
        if (collision.gameObject.tag == "redApple")
        {

            Debug.Log("red apple");

            // if coin is collected, make the coin disappear and increase the score
            successSound.Play();
            currentScore += 2;

            textScore.text = "Score : " + currentScore;
            pointScreen.text = "Score : " + currentScore;

            StartCoroutine(Respawning(collision.gameObject));

        }
        else if (collision.gameObject.tag == "greenApple")
        {
            successSound.Play();
            Debug.Log("green apple");

            // if coin is collected, make the coin disappear and increase the score
            currentScore += 3;

            textScore.text = "Score : " + currentScore;
            pointScreen.text = "Score : " + currentScore;

            StartCoroutine(Respawning(collision.gameObject));
        }
    }


    IEnumerator Respawning(GameObject apple)
    {
        apple.SetActive(false);
        int table = Random.Range(0, 1);
        if (table == 1)
        {
            apple.transform.localPosition = (new Vector3(Random.Range(-0.2f, 1f), -6.169764f, Random.Range(-23f, -24f)));

        } else
        {
            apple.transform.localPosition = (new Vector3(Random.Range(2f, 3f), -6.169764f, Random.Range(-23f, -23.5f)));
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