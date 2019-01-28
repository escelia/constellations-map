using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : MonoBehaviour
{
    public GameObject s1;
    public GameObject s2;
    public GameObject cylinder;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos1 = s1.transform.position;
        Vector3 pos2 = s2.transform.position;
        Vector3 dir = pos2 - pos1;
        cylinder.transform.position = 0.5f * (pos2 + pos1); 
        cylinder.transform.localScale = new Vector3(0.3f, 0.5f * dir.magnitude, 0.3f);
        cylinder.transform.rotation = Quaternion.LookRotation(dir) * Quaternion.Euler(90,0,0);
        
    }
}
