using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject sonzemin;



    private void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            zeminOlustur();
        }
    }

    void zeminOlustur()
    {
        sonzemin = Instantiate(sonzemin, sonzemin.transform.position + Vector3.back,sonzemin.transform.rotation);

    }

    
}//claass
