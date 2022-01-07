using Cinemachine;
using UnityEngine;

[AddComponentMenu("")] // Hide in menu
[SaveDuringPlay]
public class FollowDistanceDeadZone : CinemachineExtension
{
    [Tooltip("Keep the Follow distance within this range")]
    public float MaxDistance = 10;

    CinemachineTransposer Transposer;

    protected override void OnEnable()
    {
        base.OnEnable();
        var vcam = VirtualCamera as CinemachineVirtualCamera;
        Transposer = vcam?.GetCinemachineComponent<CinemachineTransposer>();
    }

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Finalize)
        {
            var follow = vcam.Follow;
            if (follow != null && Transposer != null)
            {
                var targetPos = follow.position;
                var camPos = state.FinalPosition;
                targetPos.y = camPos.y = 0;
                var currentDistance = Vector3.Distance(camPos, targetPos);
                Transposer.m_FollowOffset.z = -Mathf.Min(currentDistance, MaxDistance);
            }
        }
    }
}