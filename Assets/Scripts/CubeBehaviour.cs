using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    private Material material;
    private Material oldMat;
    private void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
    }

    //void DestroyCube()
    //{
    //    this.gameObject.SetActive(false);
    //}

}
