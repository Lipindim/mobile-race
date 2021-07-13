using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;


public class LocalizeTextView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private LocalizedString _stringReference;

    private void Start()
    {
        LocalizationSettings.SelectedLocaleChanged += OnChangeLocale;
        OnChangeLocale(null);
    }

    private void OnChangeLocale(Locale locale)
    {
        string localizedText = _stringReference.GetLocalizedString();
        _text.SetText(localizedText);
    }

    private void OnDestroy()
    {
        LocalizationSettings.SelectedLocaleChanged -= OnChangeLocale;
    }
}

