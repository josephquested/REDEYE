using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeText : MonoBehaviour {
    public float speed;
    public bool fadeOnAwake;

    void Awake ()
    {
      if (!fadeOnAwake)
      {
        VanishText(GetComponent<Text>());
      }
      else	
      {
        VanishText(GetComponent<Text>());
        StartCoroutine(InandOut());
      }
    }

    IEnumerator InandOut ()
    {
      yield return new WaitForSeconds(5f);
      FadeIn();
      yield return new WaitForSeconds(6f);
      FadeOut();
    }

    public void FadeIn ()
    {
      StartCoroutine(FadeTextToFullAlpha(speed, GetComponent<Text>()));
    }

    public void FadeOut ()
    {
      StartCoroutine(FadeTextToZeroAlpha(speed, GetComponent<Text>()));
    }

    void VanishText (Text i)
    {

      i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
