using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void ReloadScene()
    {
        
    }

    public IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Restart level!");
        SceneManager.LoadScene(0);

    }
}
