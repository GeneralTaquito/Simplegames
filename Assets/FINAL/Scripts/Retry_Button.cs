using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry_Button : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Dog_Game");
    }
}
