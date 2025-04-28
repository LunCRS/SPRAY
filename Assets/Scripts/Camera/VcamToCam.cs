using Cinemachine;
using UnityEngine;

public class VirtualCameraToCamera: MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public Camera targetCamera;

    // 用于计算的隐藏Brain（不显示在场景中）
    private GameObject _hiddenBrainObj;
    private CinemachineBrain _hiddenBrain;

    void Start ()
    {
        // 创建隐藏的Brain对象
        _hiddenBrainObj = new GameObject( "HiddenBrain" );
        _hiddenBrainObj.hideFlags = HideFlags.HideInHierarchy;
        _hiddenBrain = _hiddenBrainObj.AddComponent<CinemachineBrain>();

        // 禁用Brain的自动更新（我们自己控制）
        _hiddenBrain.enabled = false;
    }

    void LateUpdate ()
    {
        // 手动触发虚拟相机计算
        _hiddenBrain.ManualUpdate();

        // 获取计算后的镜头状态
        CameraState state = vcam.State;

        // 应用到目标Camera
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