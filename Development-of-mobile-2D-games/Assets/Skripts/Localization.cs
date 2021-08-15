using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Localization 
{
    [SerializeField]
    private Button _rusButton;
    [SerializeField]
    private Button _engButton;

    public Localization(Button rusButton, Button engButton)
    {
        _rusButton = rusButton;
        _engButton = engButton;
    }
    public void Start()
    {
        _rusButton.onClick.AddListener(() => ChangeLocail(0));
        _engButton.onClick.AddListener(() => ChangeLocail(1));
    }
    public void OnDestroy()
    {
        _rusButton.onClick.RemoveAllListeners();
        _engButton.onClick.RemoveAllListeners();
    }

    private void ChangeLocail(int indexLocale)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[indexLocale];
    }
}
