using TMPro;
using UnityEngine;

public class CoinViewer : MonoBehaviour
{
    private TMP_Text _counterText;

    private void OnEnable()
    {
        PlayerCounter.OnCountChange += UpdateText;
    }

    private void OnDisable()
    {
        PlayerCounter.OnCountChange += UpdateText;
    }

    private void Awake()
    {
        _counterText = GetComponent<TMP_Text>();
    }

    private void UpdateText(int count)
    {
        _counterText.text = "Coins: " + count;
    }
}
