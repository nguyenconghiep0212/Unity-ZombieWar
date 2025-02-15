﻿using System;
using System.Collections;
using UnityEngine;

public abstract class UIElement : MonoBehaviour
{
    private Action onHidden;
    public abstract bool ManualHide { get; }
    public abstract bool DestroyOnHide { get; }
    public abstract bool UseBehindPanel { get; }
    [SerializeField] protected GameObject holder;
    public virtual void Show(Action hidden)
    {
        onHidden = hidden;
        Show();
    }
    public virtual void Show()
    {
        GameUI.Instance.Submit(this);
        holder?.SetActive(true);
        transform.SetAsLastSibling();
    }
    public virtual void Hide()
    {
        GameUI.Instance.Unsubmit(this);
        onHidden?.Invoke();
        if (DestroyOnHide)
        {
            GameUI.Instance.Unregister(this);
            Destroy(gameObject);
        }
        else holder?.SetActive(false);
    }
    protected virtual void Awake()
    {
        GameUI.Instance.Register(this);
    }

 
}