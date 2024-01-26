using System.Collections.Generic;
using UnityEngine;

public class LevelsInfo : MonoBehaviour
{
    [SerializeField] List<Level> _levels;

    public int CountLevels => _levels.Count;

    private Level _currentLevel;

    public int GetMaxExperience(int numberLevel)
    {
        _currentLevel = GetCurrentLevel(numberLevel);

        return GetLevelValue(_currentLevel.RequiredExperience);
    }

    public int GetPointsSkill(int numberLevel)
    {
        _currentLevel = GetCurrentLevel(numberLevel);

        return GetLevelValue(_currentLevel.CountPointSkill);
    }

    private int GetLevelValue(int value)
    {
        if (_currentLevel != null)
            return value;
        else
            return 0;
    }

    private Level GetCurrentLevel(int numberLevel)
    {
        for (int i = 0; i < _levels.Count; i++)
        {
            if (numberLevel == _levels[i].Number)
                return _levels[i];
        }

        return null;
    }
}