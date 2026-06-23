using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HammerAnimation : MonoBehaviour
{
    public float duration = 2f;
    public float swingAngle = 60f;

    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0, 0, swingAngle), duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}



