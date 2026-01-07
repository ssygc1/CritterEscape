using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class DamageEffect : MonoBehaviour
{
    public static DamageEffect Instance;
    public float intensity;

    public Volume volume;
    private Vignette vignette;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        volume.profile.TryGet<Vignette>(out vignette);
        vignette.active = false;
    }

    public void TakeDamageEffect()
    {
        StartCoroutine(TakeDamageEffectRoutine());
    }

    public IEnumerator TakeDamageEffectRoutine()
    {
        intensity = 0.8f;

        vignette.active = true;
        vignette.intensity.Override(0.8f);

        yield return new WaitForSeconds(0.5f);

        while (intensity > 0)
        {
            intensity -= 0.04f;

            if (intensity < 0) intensity = 0;

            vignette.intensity.Override(intensity);

            yield return new WaitForSeconds(0.1f);
        }

        vignette.active = false;
        yield break;
    }

}
