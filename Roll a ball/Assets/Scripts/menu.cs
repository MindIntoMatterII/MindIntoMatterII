using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public bool isGamePaused;
    public GameObject playerGo;
    public GameObject pickupGo1;
    public GameObject winGo;
    public GameObject countGo;
    //private GameObject[] textGos = GameObject.FindGameObjectsWithTag("Shown text");

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(textGos.ToString());



        PauseGame();
        playerGo.SetActive(false);
        pickupGo1.SetActive(false);
        winGo.SetActive(false);
        countGo.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
    }




    private void FixedUpdate()
    {
        
    }

    void OnGUI()
    {
        if (!isGamePaused)
            return;    //自动布局，按照区域

        GUILayout.BeginArea(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 100, 200));

        ///横向

        GUILayout.BeginVertical();

        if (isGamePaused)
        {
            if (GUILayout.Button("Begin", GUILayout.Height(50)))
            {
                StartGame();
            }
        }

        if (GUILayout.Button("Exit", GUILayout.Height(50)))

        {

            Application.Quit();

        }

        GUILayout.Button("About us", GUILayout.Height(50));

        GUILayout.EndVertical();

        GUILayout.EndArea();

    }

    void StartGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        playerGo.SetActive(true);
        pickupGo1.SetActive(true);
        winGo.SetActive(true);
        countGo.SetActive(true);
    }

    void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
    }

}
