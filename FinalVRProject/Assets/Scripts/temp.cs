// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerControl : MonoBehaviour
// {
//     Vector3 StartPos;

//     public Transform player_spark_left;
//     public Transform player_spark_right;

//     public Rigidbody rigid;
//     public int currentScore = 0;
//     public float currentTimer = 15f;

//     public int numOfCoins = 2;
//     public GameObject[] coinArray;

//     public TMPro.TextMeshProUGUI textScore;
//     public TMPro.TextMeshProUGUI textTimer;
//     public TMPro.TextMeshProUGUI textRestart;

//     public AudioSource coinSound;
//     public AudioSource coinRes;
//     public AudioSource finishSound;
//     public AudioSource fallSound;
//     public AudioSource jumpingSound;

//     public GameObject p2;
//     private static cub box;

//     public GameObject coinPrefab;

//     public bool canMove = true;
//     public bool canPlay = true;

//     private bool jumping = false;
//     private bool isOnGround = false;

//     // Start is called before the first frame update
//     void Start()
//     {
//         StartPos = rigid.transform.position;
//         coinArray = new GameObject[numOfCoins];

//         for (int i = 0; i < numOfCoins; i++)
//         {

//             // create new coins as the game start
//             coinArray[i] = Instantiate(coinPrefab, new Vector3(Random.Range(-5f, 5f), 3f, 0f), this.transform.rotation);
//             coinRes.Play();
//         }

//         StartCoroutine(Sparkle(player_spark_left));
//         StartCoroutine(Sparkle(player_spark_right));
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         //for (int i = 0; i < numOfCoins; i++)
//         //{
//         //    box = p2.GetComponentInChildren<cub>();
//         //    Vector3 p = Camera.main.WorldToScreenPoint(box.transform.position);
//         //    float dep = p.z;
//         //    coinArray[i].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Camera.main.pixelWidth), Camera.main.pixelHeight, dep));
//         //}
//         currentTimer -= Time.deltaTime;

//         textScore.text = currentScore + " - Score";
//         textTimer.text = "Timer: " + Mathf.Round(currentTimer);

//         // if falls
//         if (rigid.transform.position.y <= -1)
//         {
//             fallSound.Play();
//             rigid.transform.position = StartPos;
//             rigid.velocity = Vector3.zero;
//             StartCoroutine(Sparkle(player_spark_left));
//             StartCoroutine(Sparkle(player_spark_right));
//         }

//         if (currentTimer <= 0f)
//         {

//             // when time's up
//             currentTimer = 0f;
//             canMove = false;
//             textRestart.text = "Score: " + currentScore + "\n\nPress SPACE to restart";

//             if (canPlay)
//             {

//                 finishSound.Play();
//                 canPlay = false;
//             }

//             if (Input.GetKey(KeyCode.Space))
//             {

//                 // if Space is pressed, reset
//                 finishSound.Stop();
//                 canPlay = true;
//                 currentTimer = 15f;
//                 currentScore = 0;
//                 canMove = true;
//                 textRestart.text = "";
//                 rigid.transform.position = StartPos;
//                 StartCoroutine(Sparkle(player_spark_left));
//                 StartCoroutine(Sparkle(player_spark_right));
//             }
//         }

//         if (canMove)
//         {
//             var body = p2.GetComponent<Rigidbody>();
//             if (Input.GetKey(KeyCode.A))
//             {

//                 // if A is pressed, then move left
//                 rigid.AddForce(new Vector3(-1f, 0f, 0f), ForceMode.Impulse);
//                 //body.AddForce(new Vector3(-1f, 0f, 0f), ForceMode.Impulse);
//             }
//             if (Input.GetKey(KeyCode.D))
//             {

//                 // if D is pressed, then move right
//                 rigid.AddForce(new Vector3(1f, 0f, 0f), ForceMode.Impulse);
//                 //body.AddForce(new Vector3(1f, 0f, 0f), ForceMode.Impulse);
//             }
//             if (Input.GetKey(KeyCode.W))
//             {

//                 // if D is pressed, then move right
//                 rigid.AddForce(new Vector3(0f, 0f, 1f), ForceMode.Impulse);
//                 //body.AddForce(new Vector3(0f, 0f, 1f), ForceMode.Impulse);
//             }
//             if (Input.GetKey(KeyCode.S))
//             {

//                 // if D is pressed, then move right
//                 rigid.AddForce(new Vector3(0f, 0f, -1f), ForceMode.Impulse);
//                 //body.AddForce(new Vector3(0f, 0f, -1f), ForceMode.Impulse);
//             }
//             if (Input.GetKey(KeyCode.Space) && isOnGround)
//             {

//                 // if Space is pressed, then jump
//                 rigid.AddForce(new Vector3(0f, 10f, 0f), ForceMode.Impulse);
//                 isOnGround = false;

//                 if (!jumping)
//                 {
//                     jumping = true;
//                     jumpingSound.Play();
//                 }

//             }
//         }
//     }

//     private void OnCollisionStay(Collision collision)
//     {
//         if (collision.gameObject.tag == "Floor")
//         {

//             isOnGround = true;
//         }
//     }

//     private void OnCollisionEnter(Collision collision)
//     {

//         if (collision.gameObject.tag == "Floor")
//         {

//             jumping = false;
//         }

//         // when collide
//         if (collision.gameObject.tag == "Coin")
//         {

//             Debug.Log("coin collected");

//             // if coin is collected, make the coin disappear and increase the score
//             currentScore++;
//             coinRes.Play();
//             Debug.Log("YAY");
//             StartCoroutine(RespwawnCoin(collision.gameObject));
//         }
//     }

//     IEnumerator RespwawnCoin(GameObject coin)
//     {

//         coinSound.Play();
//         coin.SetActive(false);
//         var coinBody = coin.GetComponent<Rigidbody>();
//         coinBody.velocity = Vector3.zero;

//         yield return new WaitForSeconds(3f);

//         coinRes.Play();
//         coin.transform.position = (new Vector3(Random.Range(-5f, 5f), 3f, 0f));
//         coin.SetActive(true);
//     }

//     IEnumerator Sparkle(Transform mat)
//     {
//         var sp = mat.GetComponent<ParticleSystem>().emission;
//         sp.enabled = true;

//         yield return new WaitForSeconds(1f);

//         sp.enabled = false;

//     }
// }