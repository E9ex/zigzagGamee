using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject startground;
    [SerializeField]  GameObject[] grounds;
    public static GroundSpawner instance;
    
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 1; i < 20; i++)
        {
            zeminOlustur();
        }
    }

    public void zeminOlustur()
    {
        Vector3 yon;

        if (Random.Range(0, 2) == 0) // randomly select 0 or 1
        {
            yon = Vector3.left;
        }
        else
        {
            yon = Vector3.back;
        }
        int randomIndex = Random.Range(0, 2); 
        GameObject newGround = Instantiate(grounds[randomIndex], startground.transform.position + yon,
            startground.transform.rotation); 
        startground = newGround; 

    }

}//claass
