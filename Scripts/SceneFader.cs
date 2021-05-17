using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image Img_Balck;
    [SerializeField] private float alpha;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string _sceneName)
    {
        StartCoroutine(FadeOut(_sceneName));
    }

    IEnumerator FadeIn()
    {
        alpha = 1;

        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            Img_Balck.color = new Color(0,0,0,alpha);
            yield return null;
        }
    }

    IEnumerator FadeOut(string sceneName)
    {
        alpha = 0;

        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            Img_Balck.color = new Color(0,0,0,alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
