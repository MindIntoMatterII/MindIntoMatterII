using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void HasToQuit() {
        Debug.Log("Game Quit!");
        Application.Quit();
    }




}
