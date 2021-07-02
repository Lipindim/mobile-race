using UnityEngine;


public abstract class BaseShowableView : MonoBehaviour, IShowable
{

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

}

