using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float tiberium = 0;
    public int baseNumber;

    public TextMeshPro text;

    public GameObject fighterPrefab;
    public GameObject GameManager;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + Mathf.Round(tiberium);
        tiberium += 1 * Time.deltaTime;

        if (tiberium >= 10)
        {
            GameObject fighterClone;
            fighterClone = Instantiate(fighterPrefab, transform.position, Quaternion.identity);
            fighterClone.GetComponent<FighterController>().Parent = gameObject;
            fighterClone.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
            fighterClone.GetComponent<FighterController>().fighterColor = GetComponent<Renderer>().material.color;
            fighterClone.GetComponent<FighterController>().ParentInt = baseNumber;
            
            
            
            tiberium -= 10;
            
        }
    }
}
