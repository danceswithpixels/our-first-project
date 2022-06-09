using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] Toggle toggleButton;
    Camera myCamera;

    const string PLATFORM1 = "Platform1";
    const string PLATFORM2 = "Platform2";
        
    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleButton.isOn) {
            myCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer(PLATFORM2));
            myCamera.cullingMask |= 1 << LayerMask.NameToLayer(PLATFORM1);
        } else {
            myCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer(PLATFORM1));
            myCamera.cullingMask |= 1 << LayerMask.NameToLayer(PLATFORM2);
        }
    }
}
