using UnityEngine;
using UnityEngine.XR;


public class camraRotation : MonoBehaviour {

    /*public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;*/

    GameObject[] eyes = new GameObject[2];
    string[] eyeAnchorNames = { "LeftEyeAnchor", "RightEyeAnchor" };

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        /*yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);*/
        for (int i = 0; i < 2; ++i)
        {
            // If the eye anchor is no longer a child of us, don't use it
            if (eyes[i] != null && eyes[i].transform.parent != transform)
            {
                eyes[i] = null;
            }

            // If we don't have an eye anchor, try to find one or create one
            if (eyes[i] == null)
            {
                Transform t = transform.Find(eyeAnchorNames[i]);
                if (t)
                    eyes[i] = t.gameObject;

                if (eyes[i] == null)
                {
                    eyes[i] = new GameObject(eyeAnchorNames[i]);
                    eyes[i].transform.parent = gameObject.transform;
                }
            }

            // Update the eye transform
            eyes[i].transform.localPosition = InputTracking.GetLocalPosition((XRNode)i);
            eyes[i].transform.localRotation = InputTracking.GetLocalRotation((XRNode)i);
        }

    }
}
