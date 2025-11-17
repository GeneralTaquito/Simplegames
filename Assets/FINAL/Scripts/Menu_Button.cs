using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Button : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Dog_Game");
    }
}
