using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : ClickableObject
{
    private Spawner _spawner;
    private bool _isFreezed = false;
    
    public void Freeze()
    {
        _isFreezed = true;
    }

    public void UnFreeze()
    {
        _isFreezed = false;
    }

    protected override void Click()
    {
        base.Click();
        TryChangePos();
    }

    public void SetSpawner(Spawner newSpawner)
    {
        _spawner = newSpawner;
    }

    public void Scale(float scaleVal)
    {
        transform.localScale *= scaleVal;
    }

    public void Unscale(float scaleVal)
    {
        transform.localScale /= scaleVal;
    }

    public void TryChangePos()
    {
        if (!_isFreezed)
            transform.position = _spawner.GetPos();
    }

}
