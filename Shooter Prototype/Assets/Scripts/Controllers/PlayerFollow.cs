using UnityEngine;
using Cinemachine;

public class PlayerFollow : MonoBehaviour
{
    // Start is called before the first frame update
     CinemachineVirtualCamera vcam;

    void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public void SetCameraFollow(Transform cameraPos)
    {
        vcam.LookAt = cameraPos;
        vcam.Follow = cameraPos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
