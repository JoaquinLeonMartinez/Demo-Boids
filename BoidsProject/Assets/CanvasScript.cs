using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    Camera mainCamera;
    Camera extraCamera;
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        extraCamera = GameObject.Find("ExtraCamera").GetComponent<Camera>();

        Debug.Log("Se ha encontrado la camara: " + mainCamera.name);
        Debug.Log("Se ha encontrado la camara: " + extraCamera.name);

        extraCamera.enabled = false;
        mainCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void changeCamera()
    {
        extraCamera.enabled = !extraCamera.enabled;
        mainCamera.enabled = !mainCamera.enabled;
    }
}
