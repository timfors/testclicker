using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusContainerUI : MonoBehaviour
{
    [SerializeField] private SessionInfo _sessionInfo;
    [SerializeField] private List<Bonus> _allBonuses = new List<Bonus>();
    [SerializeField] private List<GameObject> _bonusPrefab = new List<GameObject>();
    private List<(GameObject, Bonus)> _createdBonuses = new List<(GameObject, Bonus)>();

    private void UnsetBonus(Bonus unnecesseryBonus)
    {
        var createdObj = _createdBonuses.Find(el => el.Item2 == unnecesseryBonus);
        Destroy(createdObj.Item1);
        _createdBonuses.Remove(createdObj);
    }

    public void SetBonus(Bonus newBonus)
    {
        if (_createdBonuses.FindIndex((el) => el.Item2 == newBonus) != -1)
            UnsetBonus(newBonus);
        int prefabIndex = _allBonuses.FindIndex(el => el == newBonus);
        GameObject bonusIcon = Instantiate(_bonusPrefab[prefabIndex], transform);
        _createdBonuses.Add((bonusIcon, newBonus));
    }

    private void CheckWaste()
    {
        foreach (var (_, bonus) in _createdBonuses.ToArray())
            if (!_sessionInfo.Bonuses.Contains(bonus))
                UnsetBonus(bonus);
    }

    private void Update()
    {
        CheckWaste();   
    }
}
