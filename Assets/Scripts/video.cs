using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    public GameObject img;
    public VideoPlayer videoplayer;
    public RenderTexture rendertexture;
    // Start is called before the first frame update
    void Start()
    {
        videoplayer.prepareCompleted += Playvideo;
        videoplayer.loopPointReached += End;
        videoplayer.Prepare();
    }

    private void Playvideo(VideoPlayer vp)
    {
        rendertexture.Release();
        img.SetActive(true);
        vp.Play();
    }

    private void End(VideoPlayer vp)
    {
        vp.Pause();
    }
}
