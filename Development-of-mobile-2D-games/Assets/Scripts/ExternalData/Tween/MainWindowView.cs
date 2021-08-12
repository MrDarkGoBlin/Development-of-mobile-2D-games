using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainWindowView : MonoBehaviour
{
    [SerializeField]
    private Button _buttonOpenPopup;
    [SerializeField]
    private Button _buttonChangeText;
    [SerializeField]
    private PopupView _popupView;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private InputField _inputField;

    private void Start()
    {
        _buttonOpenPopup.onClick.AddListener(_popupView.ShowPopup);
        _buttonChangeText.onClick.AddListener(ChangeText);
        _inputField.text = "WWWWELCOM";
    }

    private void OnDestroy()
    {
        _buttonOpenPopup.onClick.RemoveAllListeners();
        _buttonChangeText.onClick.RemoveAllListeners();
    }

    private void ChangeText()
    {
        _text.DOText(_inputField.text, 1.0f).SetEase(Ease.Linear);
    }

}
