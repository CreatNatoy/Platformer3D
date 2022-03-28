using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renders;
    [SerializeField] private float _speedBlink = 30f;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    public IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            for (int i = 0; i < _renders.Length; i++)
            {
                for (int j = 0; j < _renders[i].materials.Length; j++)
                {
                    _renders[i].materials[j].SetColor("_EmissionColor", new Color(Mathf.Sin(t * _speedBlink) * 0.5f + 0.5f, 0, 0, 0));
                }
            }
            yield return null;
        }
    }

}
