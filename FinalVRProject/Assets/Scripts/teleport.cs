using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public void Teleport_start()
    {
        Rig.transform.position = new Vector3(-4f, 5f, -1f);
    }

    public GameObject Rig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    

}

