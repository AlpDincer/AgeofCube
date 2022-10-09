using UnityEngine;
using System.Collections;

public class CameraSettings : MonoBehaviour
{
    //This is Main Camera in the Scene
    Camera Player1Cam;
    //This is the second Camera and is assigned in inspector
    public Camera Player2Cam;
    public GameObject tempObject1;
    public GameObject tempObject2;
    //public Canvas Player1Canvas;
    //public Canvas Player2Canvas;

    void Start()
    {
        //This gets the Main Camera from the Scene
        Player1Cam = Camera.main;
        //This enables Main Camera
        Player1Cam.enabled = true;
        //Use this to disable secondary Camera
        Player2Cam.enabled = false;

        tempObject1 = GameObject.Find("Player1Canvas");
        tempObject2 = GameObject.Find("Player2Canvas");

        tempObject1.SetActive(true);
        tempObject2.SetActive(false);

    }

    void Update()
    {
        //Press the L Button to switch cameras
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Check that the Main Camera is enabled in the Scene, then switch to the other Camera on a key press
            if (Player1Cam.enabled)
            {
                //Enable the second Camera
                Player2Cam.enabled = true;

                tempObject1.SetActive(false);
                tempObject2.SetActive(true);

                //The Main first Camera is disabled
                Player1Cam.enabled = false;

                
            }
            //Otherwise, if the Main Camera is not enabled, switch back to the Main Camera on a key press
            else if (!Player1Cam.enabled)
            {
                //Disable the second camera
                Player2Cam.enabled = false;

                tempObject1.SetActive(true);
                tempObject2.SetActive(false);

                //Enable the Main Camera
                Player1Cam.enabled = true;
            }
        }
    }
}