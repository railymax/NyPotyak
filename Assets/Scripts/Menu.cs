using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("mainGame");
    }
    
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Выход");
    }
}
