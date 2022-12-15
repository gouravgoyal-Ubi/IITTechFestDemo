using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private void Start()
    {
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7) // player layer
        {
            //this.gameObject.SetActive(false);
            Invoke("DestroyCube", 0.5f);
        }
    }

    void DestroyCube()
    {
        Destroy(this.gameObject);
    }

}
