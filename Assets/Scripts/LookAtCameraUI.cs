using UnityEngine;

public class LookAtCameraUI : MonoBehaviour
{
    private Camera _mainCam;

    private void Awake()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        var lookAtTransform = _mainCam.transform;
        transform.LookAt(lookAtTransform);
    }
}
