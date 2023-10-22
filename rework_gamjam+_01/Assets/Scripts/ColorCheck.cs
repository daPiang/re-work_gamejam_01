using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColorCheck : MonoBehaviour
{
    [SerializeField] private D2dDestructibleSprite desprite;
    [Range(0f, 1f)]
    public float threshold;

    [SerializeField] private Light2D light;
    [SerializeField] private ParticleSystem particles;

    [SerializeField] private Brush.ColorState colorState;
    public string clearsFlag;

    private void Start() {
        if(particles != null)
        {
            particles.Stop();
        }

        if(light != null)
        {
            light.enabled = false;
        }
    }

    private void Update() {
        if((float)desprite.AlphaCount/desprite.OriginalAlphaCount <= threshold)
        {
            Debug.Log("Threshold Reached");
            // desprite.AlphaCount = 0;
            GetComponent<SpriteRenderer>().enabled = false;
            FlagSystem.instance.SetFlag(clearsFlag, true);

            if(particles != null)
            {
                particles.Play();
            }

            if(light != null)
            {
                light.enabled = true;
            }
        }

        // Debug.Log(ColorMatch());
    }

    public bool ColorMatch()
    {
        return Brush.colorState == colorState;
    }
}
 