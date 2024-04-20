using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Levels_Mr : MonoBehaviour
{
    public GameObject Window;

    void Start()
    {
        Window.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject != Window)
                {
                    CloseWindow();
                }
            }
        }
    }

    public void OpenWindow()
    {
        Window.SetActive(true);
    }

    public void CloseWindow()
    {
        Window.SetActive(false);
    }

}
