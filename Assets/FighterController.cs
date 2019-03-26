using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FighterController : MonoBehaviour
{

    public GameObject Parent;
    public int ParentInt;
    private MeshRenderer MRinChild;

    public Color fighterColor;
    public Collider baseCollider;
    public GameObject targetBase;
    private bool targetFound = false;
    public GameObject GM;
    private bool DistCalcStarted = false;
    float currentBaseDistance;
    private float prevBaseDistance;
    private float smallestDist;
    private int smallestBase;

    public GameObject Bullet;

    public float[] BasesDistances;
    
    // Start is called before the first frame update
    void Start()
    {
        MRinChild = GetComponentInChildren<MeshRenderer>();
        MRinChild.material.color = fighterColor;
        //baseCollider = GetComponentInChildren<SphereCollider>();
        GM = GameObject.FindWithTag("GameManager");
        StartCoroutine(shoot());

        FindTargetBase();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetFound)
        {
            GetComponent<Arrive>().enabled = true;
            GetComponent<Arrive>().targetGameObject = targetBase;
            
            
        }
        
        
    }

    IEnumerator shoot()
    {
        while (targetFound)
        {
            yield return new WaitForSeconds(1f);
            GameObject temp = Instantiate(Bullet, transform.position, Quaternion.identity);
            temp.GetComponent<Bullet>().target = targetBase;
        }
    }

    private void FindTargetBase()
    {
        print("No Target Base");
        if (targetFound == false )
        {
            int Ran = Random.Range(0, GM.GetComponent<GameManager>().Bases.Length );
            if (Ran != ParentInt)
            {
                targetBase = GM.GetComponent<GameManager>().Bases[Ran];
                targetFound = true;
            }
          
        }

        for (int i = 0; i < GM.GetComponent<GameManager>().Bases.Length; i++)
        {
            
            
            
            
            /*if (DistCalcStarted)
            {
                currentBaseDistance = prevBaseDistance;
            }
            GameObject tempBase = GM.GetComponent<GameManager>().Bases[i];
           
            currentBaseDistance = Vector3.Distance(transform.position, tempBase.transform.position);
            if (DistCalcStarted)
            {
                if (prevBaseDistance <= 0.1f)
                {
                    prevBaseDistance = 500f;
                }
                if (currentBaseDistance < prevBaseDistance )
                {
                    //smallestDist = currentBaseDistance;
                    smallestBase++;
                }
                else
                {
                    //smallestDist = prevBaseDistance;
                }

               

                /*if (currentBaseDistance <= 0.1f)
                {
                    currentBaseDistance = prevBaseDistance;
                }
            }
            DistCalcStarted = true;*/



        }

        //targetBase = GM.GetComponent<GameManager>().Bases[smallestBase];
        print(smallestBase);
        





    }
    
    

    /*private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Base") == true && col.gameObject != Parent)
        {
            targetBase = col.gameObject;
            tempBool = true;
        }
    }*/
}
