using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObject : ClickableObject
{
    private Spawner _spawner;

    public void Init(Spawner spawner)
    {
        _spawner = spawner;
    }

    private void OnDestroy()
    {
        _spawner.UnregisterCreated(this.gameObject);
    }

    protected override void Click()
    {
        base.Click();
        Destroy(gameObject);
    }
}
