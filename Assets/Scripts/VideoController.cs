using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void PararVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }
    }
}
