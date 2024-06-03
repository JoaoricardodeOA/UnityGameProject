using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;

    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public Player player;
    public Button playButtonB;
    public GameObject background;
    public int scenary = 0;
    public Material nightBackground;
    public Material dayBackground;
    public Material sandBackground;
    public GameObject gameName;
    public Spawner spawner;




    public void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }
    public void Play()
    {
        score = 0;
        scoreText.text = "score: " + score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        gameName.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0;i<pipes.Length;i++)
        {
            Destroy(pipes[i].gameObject);
                
        }
        spawner.acceleration = 0;
        spawner.spawnRate = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;  
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        gameName.SetActive(true);
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = "score: " + score.ToString(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        playButtonB.onClick.AddListener(Play);
    }

    // Update is called once per frame
    void Update()
    {
        if (score % 31 == 0 && scenary != 0)
        {
            MeshRenderer render = background.GetComponent<MeshRenderer>();
            render.material = nightBackground;
            scenary = 0;
        }
        if (score % 31 == 10 && scenary != 1)
        {
            MeshRenderer render = background.GetComponent<MeshRenderer>();
            render.material = dayBackground;
            scenary = 1;
        }
        if (score % 31 == 20 && scenary != 2)
        {
            MeshRenderer render = background.GetComponent<MeshRenderer>();
            render.material = sandBackground;
            scenary = 2;
        }
    }
}
