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
        LerpThatAlpha();
    }

    public void LerpThatAlpha()
    {
        StartCoroutine(LerpingAlpha(5));
    }

    IEnumerator LerpingAlpha(float _duration)
    {
        float counter = 0;
        while (counter < _duration)
        {
            m_Sprite.material.SetFloat("Vector1_7A0A30C4", Mathf.Lerp(0,1,counter /_duration));
            yield return new WaitForEndOfFrame();
            counter += Time.deltaTime;
        }
    }
}
