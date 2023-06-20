using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startTime = 300f; 
    private float currentTime; 
    private Text timerText;

    private bool isTimerRunning = true; // Flag to control whether the timer should run or not

    private void Awake()
    {
       
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentTime = startTime;
        timerText = GetComponent<Text>();

        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    private void Update()
    {
        if (!isTimerRunning)
            return; 

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            
            SceneManager.LoadScene("GameOver Screen");
            isTimerRunning = false; 
        }

        
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level 1" || scene.name == "Level 2")
        {
            isTimerRunning = true; 
        }
        else if (scene.name == "Finish Screen" || scene.name == "GameOver Screen")
        {
            isTimerRunning = false; 
        }
    }
}


