using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : PopUpUI
{
    [SerializeField] private GlobalSettings _globalSettings;
    private Animator _animator;
    private bool IsSound;
    private bool IsMusic;

    private Animator animator
    {
        get
        {
            if (!_animator)
                _animator = GetComponent<Animator>();
            return _animator;
        }
    }

    private void Start()
    {
        SetSound(_globalSettings.IsSound);
        SetMusic(_globalSettings.IsMusic);
    }


    public void SetSound(bool state)
    {
        IsSound = state;
        animator.SetBool(nameof(IsSound), IsSound = state);
    }

    public void SetMusic(bool state)
    {
        IsMusic = state;
        animator.SetBool(nameof(IsMusic), IsMusic = state);
    }

    public void SwitchSound()
    {
        _globalSettings.IsSound = !IsSound;
        SetSound(!IsSound);
    }
    
    public void SwitchMusic()
    {
        _globalSettings.IsMusic = !IsMusic;
        SetMusic(!IsMusic);
    }
}
