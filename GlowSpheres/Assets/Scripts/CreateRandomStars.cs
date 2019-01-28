using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomStars : MonoBehaviour
{
    public GameObject template;
    public int numStars = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numStars; i++)
        {
            // compute a random position (x,y,z)
            float x = Random.Range(-10, 10);
            float y = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);

            // Create a copy of template
            GameObject newObj = GameObject.Instantiate(template);
            newObj.transform.position = new Vector3(x, y, z);
            newObj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
