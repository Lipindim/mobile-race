using System.Globalization;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;


public class ChangeLocalizationView : MonoBehaviour
{
    [SerializeField]
    private Button _russianButton;

    [SerializeField]
    private Button _englishButton;

    [SerializeField]
    private Button _frenchButton;

    private LocaleIdentifier _english = new LocaleIdentifier(CultureInfo.GetCultureInfo("en"));
    private LocaleIdentifier _franch = new LocaleIdentifier(CultureInfo.GetCultureInfo("fr-FR"));
    private LocaleIdentifier _russian = new LocaleIdentifier(CultureInfo.GetCultureInfo("ru"));

    private void Start()
    {
        _russianButton.onClick.AddListener(() => ChangeLanguage(_russian));
        _frenchButton.onClick.AddListener(() => ChangeLanguage(_franch));
        _englishButton.onClick.AddListener(() => ChangeLanguage(_english));
    }

    private void OnDestroy()
    {
        _russianButton.onClick.RemoveAllListeners();
        _frenchButton.onClick.RemoveAllListeners();
        _englishButton.onClick.RemoveAllListeners();
    }

    private void ChangeLanguage(LocaleIdentifier localeIdentifier)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(localeIdentifier);
    }
}
