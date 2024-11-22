using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadingIcon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(Vector3.forward * 360f, 3f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
