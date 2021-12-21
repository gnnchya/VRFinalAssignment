using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiding : MonoBehaviour
{
    [SerializeField] AudioSource successSound;
    [SerializeField] GameObject token;

    [SerializeField] TMPro.TextMeshProUGUI foundText;
    [SerializeField] GameObject start_button;

    // Start is called before the first frame update
    public void Run()
    {
        
        successSound.Play();
        Instantiate(token, new Vector3(29.35f, 4.362f, 57.131f), this.transform.rotation);
        start_button.SetActive(false);
        foundText.text = "You found it!";

    }


}
