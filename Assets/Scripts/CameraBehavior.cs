using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] Toggle toggleButton;
    Camera myCamera;
        
    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleButton.isOn) {
            myCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("Red Platforms"));
            myCamera.cullingMask |= 1 << LayerMask.NameToLayer("Blue Platforms");
        } else {
            myCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("Blue Platforms"));
            myCamera.cullingMask |= 1 << LayerMask.NameToLayer("Red Platforms");
        }
    }
}
