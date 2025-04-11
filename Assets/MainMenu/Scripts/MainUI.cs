using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public GameObject mainGO;
    public GameObject settingGO;
    bool isCloseSound;
    public GameObject loadingGO;
    public VideoPlayer vp;

    void Start()
    {
        vp.loopPointReached += Vp_loopPointReached;
    }

    private void Vp_loopPointReached(VideoPlayer source)
    {
        EndLoading();
    }

    public void StartClick()
    {
        loadingGO.SetActive(true);
        SceneManager.LoadScene("Slideshow");
    }

    void EndLoading()
    {
        loadingGO.SetActive(false);
        vp.Stop();
    }

    public void Setting()
    {
        mainGO.SetActive(false);
        settingGO.SetActive(true);
    }

    public void Music()
    {
        isCloseSound = !isCloseSound;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
