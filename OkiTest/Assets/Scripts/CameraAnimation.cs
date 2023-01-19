using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform endPointCamera;

    public void FinalAnimation()
    {
        cameraTransform.DOMove(endPointCamera.position, 1f);
        cameraTransform.DORotate(endPointCamera.transform.eulerAngles, 1f);
    }
}
