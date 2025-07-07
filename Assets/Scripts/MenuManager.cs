using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Game Scene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
