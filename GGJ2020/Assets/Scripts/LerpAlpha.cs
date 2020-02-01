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
            m_Sprite.color = new Color(0,0,0,Mathf.Lerp(0,2,counter / _duration));
            yield return new WaitForEndOfFrame();
            counter += Time.deltaTime;
        }
    }
}
