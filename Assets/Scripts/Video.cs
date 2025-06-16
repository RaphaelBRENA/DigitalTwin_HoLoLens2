using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public bool isPlaying = false;

    public void Start()
    {
        videoPlayer.Pause();
    }
    public void Play()
    {
        if (videoPlayer != null && isPlaying == false)
        {
            videoPlayer.Play();
            isPlaying = true;
        }
        else if (videoPlayer != null && isPlaying == true)
        {
            videoPlayer.Pause();
            isPlaying = false;
        }
    }
}
