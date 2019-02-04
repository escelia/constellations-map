using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStarMap2 : MonoBehaviour
{

    public TextAsset textFile;
    public TextAsset[] constellations;

    public GameObject template;
    public GameObject cylTemplate;

    // Start is called before the first frame update
    void Start()
    {
        string text = textFile.text;
        List<StarMapReader> starList = StarMapReader.stringToList(text);

        foreach(StarMapReader star in starList)
        {
            GameObject newObj = GameObject.Instantiate(template);

            float x = star.getX();
            float y = star.getY();
            float z = star.getZ();
            //float z = Random.Range(-10, 10);
            newObj.transform.position = new Vector3(x, y, z);
            newObj.transform.localScale += new Vector3(star.getMag()*0.001f, star.getMag()*0.001f, star.getMag()*0.001f);
        }

        foreach(TextAsset constellation in constellations)
        {
            string textCon = constellation.text;
            Constellation constel = Constellation.stringToList(textCon);

            for(int i = 0; i < constel.getNumberOfLines(); i++)
            {
                Vector3 pos1 = new Vector3(StarMapReader.getCoordsByName(constel.getEndpointAt(i).getStart(), starList).getX(),StarMapReader.getCoordsByName(constel.getEndpointAt(i).getStart(), starList).getY(), StarMapReader.getCoordsByName(constel.getEndpointAt(i).getStart(), starList).getZ());
                Vector3 pos2 = new Vector3(StarMapReader.getCoordsByName(constel.getEndpointAt(i).getEnd(), starList).getX(),StarMapReader.getCoordsByName(constel.getEndpointAt(i).getEnd(), starList).getY(), StarMapReader.getCoordsByName(constel.getEndpointAt(i).getEnd(), starList).getZ());
                Vector3 dir = pos2 - pos1;

                GameObject cylinderObj = GameObject.Instantiate(cylTemplate);
                cylinderObj.transform.position = 0.5f * (pos1 + pos2);
                cylinderObj.transform.rotation = Quaternion.LookRotation(dir) * Quaternion.Euler(90,0,0);

                Vector3 scale = cylinderObj.transform.localScale;
                scale.y = 0.5f * dir.magnitude;
                cylinderObj.transform.localScale = scale;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
