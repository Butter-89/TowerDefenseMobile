using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    Image target;

    bool blinking;

    public float BlinkingDuration = 2.0f;
    public float BlinkingSpeed = 5.0f;
    public bool StartHidden = true;

    float blinkingTime = 0.0f;

    private void Start()
    {
        target = gameObject.GetComponent<Image>();
        if (StartHidden)
            target.color = new Color(target.color.r, target.color.g, target.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (blinking)
        {
            target.color = new Color(
                target.color.r,
                target.color.g,
                target.color.b,
                Mathf.Abs(Mathf.Sin(blinkingTime * BlinkingSpeed))
            );
            blinkingTime += Time.deltaTime;
        }
    }

    public void StartBlinking()
    {
        blinking = true;
        Invoke("StopBlinking", BlinkingDuration);
    }

    void StopBlinking()
    {
        blinking = false;
        blinkingTime = 0;
        target.color = new Color(target.color.r, target.color.g, target.color.b, 0);
    }
}
