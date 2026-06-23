using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BladeAnimation : MonoBehaviour
{
    public float duration = 2;

    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), duration, RotateMode.FastBeyond360)
            .SetLoops(-1)
            .SetEase(Ease.Linear);
    }
}
