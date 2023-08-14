using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioListener;
    public bool inGame = true;
    public bool isPaused = false;
    public GameObject pausemenu;
    public void Stopgame()
    {
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1f;
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void manageVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (inGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) isPaused = !isPaused;
            if (isPaused) { Time.timeScale = 0f; }
            else { Time.timeScale = 1f; }
            pausemenu.SetActive(isPaused);
        }
    }
}
