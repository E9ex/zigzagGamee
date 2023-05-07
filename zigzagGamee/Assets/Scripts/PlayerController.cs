using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    [Header("OUT component")]
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI scoreText, bestscoreText,bestScoreTextPlayGame;
    [SerializeField] GameObject restartPanel,PlayGamePanel;
    
    



    [Header("publicler olanlar")]
    public GroundSpawner groundSpawner;
    public static bool isdead = true;
    public float hizlanmaZorlugu=0.01f;


    Vector3 yon = Vector3.left;
    float artisMiktari = 1f;
    int bestscore = 0;
    float score = 0;
    
    
    private void Start()
    {
       
        bestScoreTextPlayGame.text = "BestScore: "+PlayerPrefs.GetInt("bestscore").ToString();
        if (RestartGame.isRestart)
        {
            isdead = false;
            PlayGamePanel.SetActive(false);
        }
        bestscore = PlayerPrefs.GetInt("bestscore");
        bestscoreText.text = "Best: "+bestscore.ToString();
    }

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

            if (bestscore<score)
            {
                bestscore = (int)score;
                PlayerPrefs.SetInt("bestscore", bestscore);
            }
            Debug.Log("öldğm");
            restartPanel.SetActive(true);
            Destroy(this.gameObject,3f);
        }
    }
    private void FixedUpdate()
    {

        if (isdead)
        {
            return;
        }
        Vector3 hareket = yon * speed * Time.deltaTime;//objemizin hareket değeri.
        speed += Time.deltaTime*hizlanmaZorlugu;
        transform.position += hareket;// hareket değerini sürekli pozisyonuma ekle

       // score += artisMiktari*speed*Time.deltaTime;
        scoreText.text = "Score: "+((int)score).ToString();//score değişkeni integer dönüştürdük
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 5;
            Destroy(other.gameObject);
            if (score % 30 == 0)
            {
                speed += .5f;
            }
        }
        
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
    public void playerGame()
    {
        isdead = false;
        PlayGamePanel.SetActive(false);
        
    }

}//Class

