using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public static bool isRestart = false;
    public void restartgame()
    {
        //ıjhha
        isRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }//efhuwgufwh

    public void ExitGame()
    {
        Application.Quit();//zort
    }


}//class
