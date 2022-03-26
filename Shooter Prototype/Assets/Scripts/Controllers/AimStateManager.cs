//using Photon.Pun;
using UnityEngine;

public class AimStateManager : MonoBehaviour
{
    [SerializeField] float mouseSensity;
    float xAxis, yAxis;
    [SerializeField] Transform cameraPos;
    //public PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        //view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (view.IsMine)
        {
            xAxis += Input.GetAxisRaw("Mouse X") * mouseSensity;
            yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSensity;
            yAxis = Mathf.Clamp(yAxis, -80, 80);
        }
    }

    private void LateUpdate()
    {
        //if (view.IsMine)
        {
            cameraPos.localEulerAngles = new Vector3(yAxis, cameraPos.localEulerAngles.y, cameraPos.localEulerAngles.z);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
        }
    }

    public Transform GetCameraLookAtPos()
    {
        return cameraPos;
    }
}
