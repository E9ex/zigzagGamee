using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 yon = Vector3.left;

    [SerializeField] float speed;
     public GroundSpawner groundSpawner;

    public static bool isdead = false;

    


    private void Update()
    {
        if (isdead)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (yon.x==0)//z ekseninde hareket ediyor demektir.
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.back;
            }
        }

        if (transform.position.y<0.1f)
        {
            isdead = true;
            Debug.Log("öldğm");
            Destroy(this.gameObject,3f);
        }
    }
    private void FixedUpdate()
    {
        Vector3 hareket = yon * speed * Time.deltaTime;//objemizin hareket değeri.
        transform.position += hareket;// hareket değerini sürekli pozisyonuma ekle
    }


    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Zemin"))
        {
            StartCoroutine(Yoket(collision.gameObject));
            groundSpawner.zeminOlustur();
        }
    }
    IEnumerator Yoket(GameObject zemin)
    {
        yield return new WaitForSeconds(0.2f);
        zemin.AddComponent<Rigidbody>();//default olarak graviity kapali geliyor.


        yield return new WaitForSeconds(0.4f);
        Destroy(zemin);

    }


}//Class

