using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWinController : MonoBehaviour
{
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject WinPanel;
    void Start()
    {
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
    }

    public void Lose()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void NextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
    public void Win()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    
}
