﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// George samuels II 
/// 
/// 
/// FIx ME:11/22/2016  * FIXED
/// 
/// 
/// 
/// 
/// 
/// 
/// FIXME: 12/11/16 Counter to text is broken =>prefab?
/// </summary>



public class GazeExplosion : MonoBehaviour
{

    public GameObject explosionPrefab;
    public GameObject asteroid;
    public double lookingTime = 0.5;
    public Text AsteroidCounter;
    public static int Counter = 0;
    public static GazeExplosion instance;
    public AudioClip[] AsteroidSounds;

    private AudioSource audio {  get { return GetComponent<AudioSource>(); } }

    /**Initialize BAng **/
    void Start()
    {
        instance = this;

        /**sound for asteroids explosion**/
        gameObject.AddComponent<AudioSource>();//initialize Audio Source / creates on an object
       


    }




    void Update()
    {     
    }


    /**Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
         if (Physics.Raycast(ray, out hit, 2))
             Debug.DrawLine(ray.origin, hit.point);**/
    void BOOM()
    {
        // UpdateAsteroidCount();

        RaycastHit hit;

        if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.rotation * Vector3.forward), out hit, 500.0f)) //adjust the raycast  FIXME:11/22/16
        {
            /**time of gaze**/
            lookingTime--;
            print("GAZE TIME ==>" + lookingTime);
            
           
            asteroid.GetComponent<MeshRenderer>().enabled = false; 
            PlayClip();
            Destroy(asteroid,1f); //gives time for destroying object
            Instantiate(explosionPrefab, asteroid.transform.position, asteroid.transform.rotation);
      //   //hides mess to play sound longer
          
            // 1/ 14/17
            Debug.Log(asteroid.name + "===> has been Blown up" + "Asteroids: " + Counter++);
          //  Debug.Break();
            Counting();
    



            /**goals depending on level**/
            Scene scene = SceneManager.GetActiveScene();
            switch (scene.name)
            {
                case "AtmosphereEASY":
                    AsteroidCounter.text = Counter.ToString() + "/5";
                    //     PlayerPrefs.SetString("player1Asteroids", AsteroidCounter.text);//saves player asteroids
                    Debug.Log("saved asteroids" + "GazeExplosion=>LINE 79");

                    break;
                case "AtmosphereModerate":
                    AsteroidCounter.text = Counter.ToString() + "/10";
                    break;
                case "AtmosphereInsane":
                    AsteroidCounter.text = Counter.ToString() + "/15";
                    break;
            }





        }

 
  

    }
    


    void PlayClip()
    {

        /**Plays Random sound on explosion**/
        int clip;

        clip = Random.Range(0, 2);
        audio.clip = AsteroidSounds[clip];
        audio.Play();
        Debug.Log(clip + "sound");
     //   Debug.Break();

    }

    public int Counting()
    {
        //temp to fix counting issue 12/11/16
        //TODO:FIXME
        Debug.Log("Counting LINE 95" + "===> " + Counter);

        //resets asteroid counter 
        //to zero for new levels after playerpref deleted.



        return Counter;
    }

    /***Counts only on Gaze **/
    public void GazeOn()
    {
        InvokeRepeating("BOOM", 1, 1);


    }


    /***Resets off Gaze **/
    public void Gazeoff()
    {
        CancelInvoke();
        //  lookingTime =0.5;

    }




    /** void UpdateAsteroidTracker(string update)
     {
         AsteroidCounter.text =update;
     }**/
}







