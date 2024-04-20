using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Low()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void Medium()
    {
        QualitySettings.SetQualityLevel(1);
    }
    public void High()
    {
        QualitySettings.SetQualityLevel(2);
    }
}
