using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsMenu : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clicFx;

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }
    public void ClicSound()
    {
        myFx.PlayOneShot(clicFx);
    }

}
