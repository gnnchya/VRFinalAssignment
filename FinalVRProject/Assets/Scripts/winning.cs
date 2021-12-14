using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winning : MonoBehaviour
{
    // Start is called before the first frame update
    private bool token1check = false;
    private bool token2check = false;
    private bool token3check = false;
    private bool won = false;

    [SerializeField] AudioSource successSound;

    [SerializeField] GameObject trophy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (token1check && token2check && token3check)
        {
            if (!won)
            {
                successSound.Play();
                Instantiate(trophy, new Vector3(-5.6f, 4.75f, 0.174f), this.transform.rotation);
                won = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        // when collide
        if (collision.gameObject.tag == "token1")
        {

            Debug.Log("token1");

            // if coin is collected, make the coin disappear and increase the score
            token1check = true;

        }
        else if (collision.gameObject.tag == "token2")
        {

            Debug.Log("token2");

            // if coin is collected, make the coin disappear and increase the score
            token2check = true;

        }
        else if (collision.gameObject.tag == "token3")
        {

            Debug.Log("token3");

            // if coin is collected, make the coin disappear and increase the score
            token3check = true;

        }
    }

    private void OnCollisionStay(Collision collision)
    {

        // when collide
        if (collision.gameObject.tag == "token1")
        {

            Debug.Log("token1");

            // if coin is collected, make the coin disappear and increase the score
            token1check = true;

        }
        else if (collision.gameObject.tag == "token2")
        {

            Debug.Log("token2");

            // if coin is collected, make the coin disappear and increase the score
            token2check = true;

        }
        else if (collision.gameObject.tag == "token3")
        {

            Debug.Log("token3");

            // if coin is collected, make the coin disappear and increase the score
            token3check = true;

        }
    }


    private void OnCollisionExit(Collision collision)
    {

        // when collide
        if (collision.gameObject.tag == "token1")
        {

            Debug.Log("token1");

            // if coin is collected, make the coin disappear and increase the score
            token1check = false;

        }
        else if (collision.gameObject.tag == "token2")
        {

            Debug.Log("token2");

            // if coin is collected, make the coin disappear and increase the score
            token2check = false;

        }
        else if (collision.gameObject.tag == "token3")
        {

            Debug.Log("token3");

            // if coin is collected, make the coin disappear and increase the score
            token3check = false;

        }
    }
}
