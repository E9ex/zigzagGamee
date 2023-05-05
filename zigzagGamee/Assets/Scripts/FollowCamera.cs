using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject target;

    Vector3 distance;


    private void Start()
    {
        distance = transform.position-target.transform.position;//kamera ile player arasındaki mesafe.
    }
    private void LateUpdate()
    {
        if (PlayerController.isdead)//isdead true ise aşağıdaki kodları çalıştırma.
        {
            return;
        }
        transform.position = target.transform.position + distance; 
    }

}//class
