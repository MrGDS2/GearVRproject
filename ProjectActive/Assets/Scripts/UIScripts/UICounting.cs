﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UICounting : MonoBehaviour {
    //public GameObject UICounter;
    public Text Count;
	// Use this for initialization
	void Start () {
     
       
    }

    // Update is called once per frame
    void Update () { 
        /**goals depending on level**/
        Scene scene = SceneManager.GetActiveScene();
 switch (scene.name)
        {
            case "AtmosphereEASY":


                Count.text = GazeExplosion.instance.Counting().ToString() + "/10";
                //     PlayerPrefs.SetString("player1Asteroids", AsteroidCounter.text);//saves player asteroids
                Debug.Log("saved asteroids" + "GazeExplosion=>LINE 79");

                break;
            case "AtmosphereModerate":
                Count.text = GazeExplosion.instance.Counting().ToString() + "/20";
                break;
            case "AtmosphereInsane":
                Count.text = GazeExplosion.instance.Counting().ToString() + "/30";
                break;
        }

        /*gets number from 
        counting method that 
        returns int and get's
        it string number*/


	}
}
