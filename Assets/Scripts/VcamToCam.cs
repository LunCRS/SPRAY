using Cinemachine;
using UnityEngine;

public class VirtualCameraToCamera: MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public Camera targetCamera;
    private GameObject _hiddenBrainObj;
    private CinemachineBrain _hiddenBrain;

    void Start ()
    {
        _hiddenBrainObj = new GameObject( "HiddenBrain" );
        _hiddenBrainObj.hideFlags = HideFlags.HideInHierarchy;
        _hiddenBrain = _hiddenBrainObj.AddComponent<CinemachineBrain>();

        _hiddenBrain.enabled = false;
    }

    void LateUpdate ()
    {
        _hiddenBrain.ManualUpdate();

        CameraState state = vcam.State;

        targetCamera.transform.SetPositionAndRotation(
            state.FinalPosition,
            state.FinalOrientation );
        targetCamera.fieldOfView = state.Lens.FieldOfView;
    }

    void OnDestroy ()
    {
        if( _hiddenBrainObj != null )
            Destroy( _hiddenBrainObj );
    }
}