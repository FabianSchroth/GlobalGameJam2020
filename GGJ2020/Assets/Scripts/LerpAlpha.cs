using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpAlpha : MonoBehaviour
{
    [SerializeField]
    Image m_Sprite;

    private void Start()
    {
        LerpThatAlpha(2,true, () => Debug.Log("MiddleOfFade"));
    }

    public void LerpThatAlpha(float _duration, bool _toBlack, Action _action)
    {
        StartCoroutine(LerpingAlpha(_duration, _toBlack, _action));
    }

    IEnumerator LerpingAlpha(float _duration, bool _toBlack, Action _action)
    {
        float counter = 0;
        while (counter < _duration /2)
        {
            m_Sprite.material.SetFloat("Vector1_7A0A30C4", Mathf.Lerp(0, 1, counter / (_duration/2)));
            yield return new WaitForEndOfFrame();
            counter += Time.deltaTime;
        }

        _action();

        counter = 0;
        while (counter < _duration /2)
        {
            m_Sprite.material.SetFloat("Vector1_7A0A30C4", Mathf.Lerp(1, 0, counter / (_duration/2)));
            yield return new WaitForEndOfFrame();
            counter += Time.deltaTime;
        }
    }
}
