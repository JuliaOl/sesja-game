using UnityEngine;
using UnityEngine.UI;


public class VRInput : MonoBehaviour {
    private Camera fpsCam;
    public float sightRange = 100f;
    public Button selected;

    // Use this for initialization
    void Start () {
        fpsCam = GetComponentInParent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {

        // Create a vector at the center of our camera's viewport
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        // Draw a line in the Scene View  from the point lineOrigin in the direction of fpsCam.transform.forward * weaponRange, using the color green
        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * sightRange, Color.green);

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit seen;
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out seen, sightRange))
            {
                if (seen.collider.tag == "Button")
                {
                    GameObject obj =  seen.transform.gameObject;
                    selected = obj.GetComponent<Button>();
                    selected.onClick.Invoke();
                }
            }
        }  
    }

}
