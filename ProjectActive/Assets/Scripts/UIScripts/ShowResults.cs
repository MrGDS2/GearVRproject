﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//George samuels II
public class ShowResults : MonoBehaviour
{
    //FIXME resetKeys doesn't really work * 12/11/16

      public Text ShowFinalAsteroids;
      public Text ShowFinalTime;
    public static ShowResults instance;
    // Use this for initialization
    void Start()
    {
        instance = this;

    

    }

    // Update is called once per frame
    void Update()
    {
        

        ShowFinalAsteroids.text = "Asteroids:"  + PlayerPrefs.GetString("player1Asteroids");

         ShowFinalTime.text =PlayerPrefs.GetString("player1");

       
    }

    public void resetKeys()
    {
        /** Deletes Player numbers with each restart or progression**/
        /**  PlayerPrefs.DeleteKey("player1");
      PlayerPrefs.DeleteKey("player1Asteroids"); **/

        // PlayerPrefs.DeleteAll();
     //   Debug.LogWarning("reset all KEYS*****>");





    }

}