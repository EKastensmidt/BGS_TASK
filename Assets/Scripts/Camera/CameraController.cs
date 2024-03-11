using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float transitionSpeed;

    private void OnEnable()
    {
        MoveCameraTrigger.OnEnter += MoveCameraPosition;
    }
    private void OnDisable()
    {
        MoveCameraTrigger.OnEnter -= MoveCameraPosition;
    }

    public void MoveCameraPosition(Transform newpos)
    {
        transform.DOMove(new Vector3(newpos.position.x, newpos.position.y, transform.position.z), transitionSpeed);
    }
}
