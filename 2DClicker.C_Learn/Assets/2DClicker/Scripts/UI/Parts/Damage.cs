using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public TextMeshProUGUI textPro;

    private Coroutine coroutine;

    private void OnEnable()
    {
        if(coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(CoTimer());
    }

    private IEnumerator CoTimer()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        StopCoroutine(coroutine);
        coroutine = null;
    }
}
