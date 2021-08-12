using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    private const string PoisonKey = nameof(PoisonKey);
    private const string BookKey = nameof(BookKey);

    public static CurrencyView Insctance;

    [SerializeField]
    private TMP_Text _currentCountPoison;
    [SerializeField]
    private TMP_Text _currentCountBook;
    public int Poison
    {
        get => PlayerPrefs.GetInt(PoisonKey, 0);
        set => PlayerPrefs.SetInt(PoisonKey, value);

    }

    public int Book
    {
        get => PlayerPrefs.GetInt(BookKey, 0);
        set => PlayerPrefs.SetInt(BookKey, value);

    }

    private void Awake()
    {
        if (Insctance == null)
            Insctance = this;
    }

    private void Start()
    {
        RefrashText();
    }

    public void AddPoison(int value)
    {
        Poison += value;
        RefrashText();
    }

    public void AddBook(int value)
    {
        Book += value;
        RefrashText();
    }

    private void RefrashText()
    {
        _currentCountPoison.text = Poison.ToString();
        _currentCountBook.text = Book.ToString();
    }

    public void ResetText()
    {
        _currentCountBook.text = "0";
        _currentCountPoison.text = "0";
    }

}
