
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private Gradient gradient;
    [SerializeField]
    private Image fill;
    [SerializeField]
    private float smoothSecs = 0.2f;

    private Camera mainCamera;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        mainCamera = Camera.main;
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void HealthBarLookAtCamera()
    {
        slider.transform.LookAt(mainCamera.transform);
    }
}
