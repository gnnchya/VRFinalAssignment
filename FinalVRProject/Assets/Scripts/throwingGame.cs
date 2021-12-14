using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Script : MonoBehaviour
{
    [SerializeField] GameObject instruction;
    [SerializeField] GameObject start_button;

    [SerializeField] AudioSource successSound;
    [SerializeField] int currentScore = 0;
    [SerializeField] TMPro.TextMeshProUGUI textScore;
    [SerializeField] TMPro.TextMeshProUGUI countdown;

    [SerializeField] float maxTime = 30f;
    float timeLeft;
    private bool canRun = false;
    public int levelIndex = 1;

    // Update is called once per frame
    void Update()
    {
        if (canRun)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                countdown.text = "Time : " + (int) timeLeft;

            }
            else
            {
                Time.timeScale = 0;
                if (currentScore >= 15)
                {
                    instruction.SetActive(false);
                    start_button.SetActive(false);
                    textScore.enabled = true;
                    countdown.text = "Congratulations";
                }
                else
                {
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
        canRun = true;
        timeLeft = maxTime;
        textScore.enabled = true;
        countdown.enabled = true;

        StartCoroutine(StartSpawning());
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (timeLeft > 0)
        {
            if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
            {
                if (hit.transform.name == "trex(Clone)")
                {
                    if (!dieSound.isPlaying)
                    {
                        dieSound.Play();
                    }
                    hit.transform.gameObject.SetActive(false);
                    float a = Random.Range(-5f, 5f);
                    float b = Random.Range(-5f, 5f);
                    hit.transform.position = new Vector3(a, b, 0f);
                    hit.transform.gameObject.SetActive(true);
                    currentScore = currentScore + 1;
                    textScore.text = "Score : " + currentScore;
                }
            }
        }
    }


    IEnumerator StartSpawning()
    {

        yield return new WaitForSeconds(1);

        for (int i = 0; i < 3; i++)
        {
            float a = Random.Range(-5f, 5f);
            float b = Random.Range(-5f, 5f);
            Instantiate(Dinosaurs, new Vector3(a, 0f, b), Quaternion.identity);
        }

    }

    private void UpdateStar(int _starsNum)
    {
        if (_starsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _starsNum);
        }

    }



}