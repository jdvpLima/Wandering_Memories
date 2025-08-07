using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneFade : MonoBehaviour
{
    private Image fadeImage;
    private void Awake()
    {
        fadeImage = GetComponent<Image>();

    }
    public IEnumerator FadeInCoroutine(float duration)
    {
        Color startColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1); // "Constroi" uma nova cor
        Color targetColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0); // Cor que queremos que fique
        yield return  FadeCoroutine(startColor, targetColor, duration);
        gameObject.SetActive(false); // Para não estar ativa
    }

    public IEnumerator FadeOutCoroutine(float duration) // Inverso da função acima
    {
        Color startColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0); 
        Color targetColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
        gameObject.SetActive(true); // Para não estar ativa
        yield return  FadeCoroutine(startColor, targetColor, duration);
       
    }
    private IEnumerator FadeCoroutine(Color startColor, Color targetColor, float duration)
    {
        float elapsedTime = 0; // Tempo de fadeout
        float elapsedPercentage = 0; // Percentagem para dar o fade out
        while(elapsedPercentage < 1)
        {
            elapsedPercentage = elapsedTime/duration; // calculo da percentagem 
            fadeImage.color = Color.Lerp(startColor, targetColor, elapsedPercentage); // mudança da cor da imagem
            yield return null; // Aguarda pelo proximo frame
            elapsedTime += Time.deltaTime; // Aumentamos o tempo
        }
    }
}
