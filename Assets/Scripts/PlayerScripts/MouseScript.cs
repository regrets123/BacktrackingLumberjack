using UnityEngine;
using System.Collections;
/*By Björn Andersson*/
public class MouseScript : MonoBehaviour
{
    public GameObject head, body;

    [SerializeField]
    float rotSpeed;

    bool paused = false;

    public bool Paused
    {
        get { return paused; }
        set { paused = value; }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!paused)
        {
            head.transform.Rotate(-Input.GetAxis("Mouse Y") * rotSpeed, 0f, 0f);
            body.transform.Rotate(0f, Input.GetAxis("Mouse X") * rotSpeed, 0f);
        }
    }
}