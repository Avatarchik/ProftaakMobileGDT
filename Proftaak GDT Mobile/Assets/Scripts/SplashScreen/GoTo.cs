using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoTo : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Countdown");
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(8);
        //SceneManager.LoadScene("MainMenu");
        Application.LoadLevel(1);
    }

    public void Buttens()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
