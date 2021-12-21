using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fallingApple : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {

            StartCoroutine(Respawning(collision.gameObject));
        
    }


    IEnumerator Respawning(GameObject apple)
    {
        apple.SetActive(false);

        apple.transform.localPosition = (new Vector3(Random.Range(-0.2f, 1f), -6.169764f, Random.Range(-23f, -24f)));
     
        yield return new WaitForSeconds(5);

        apple.SetActive(true);
    }


}