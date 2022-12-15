using System.Collections.Generic;
using UnityEngine;

public class CubeGenerateor : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private int cubeCount;
    [SerializeField] private float radius;
    [SerializeField] private float interval;

    private List<Rigidbody> cubePool = new List<Rigidbody>();
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        //InstantiateCircle();

    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > interval)
        {
            time = 0;
            GenerateCubes();

        }

    }

    void GenerateCubes()
    {
        Rigidbody cube = null;
        Vector3 pos = new Vector3(0, 10, 0);
        Quaternion rot = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad, 0);
        if (cubePool.Count <= cubeCount)
        {
            GameObject obj = Instantiate(cubePrefab, pos, rot) as GameObject;
            cubePool.Add(obj.GetComponent<Rigidbody>());
        }
        else
        {
            foreach (var item in cubePool)
            {
                if (!item.gameObject.activeSelf)
                {
                    cube = item;
                    cube.transform.position = pos;
                    cube.rotation = rot;
                    cube.gameObject.SetActive(true);
                    break;
                }
            }
        }
        if (cube != null)
        { 
            cube.AddForce(Vector3.up * 2f, ForceMode.Impulse);
        }
    }


    void InstantiateCircle()
    {
        float angle = 360f / (float)cubeCount;
        for (int i = 0; i < cubeCount; i++)
        {
            Quaternion rotation = Quaternion.AngleAxis(i * angle, Vector3.up);
            Vector3 direction = rotation * Vector3.forward;

            Vector3 position = new Vector3(0, 10, 0) + (direction * radius);
            Instantiate(cubePrefab, position, rotation);
        }
    }
}
