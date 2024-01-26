using UnityEngine;
using UnityEngine.Events;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField] private LevelsInfo _levelsInfo;
    [SerializeField] private int _level = 1;
    [SerializeField] private int _currentExperience;
    [SerializeField] private int _maxExperience;
    [SerializeField] private int _allExperience;

    public int AllEperience => _allExperience;

    private bool _isMaxLevel = false;

    public event UnityAction<int> ChangedCurrentExperience;
    public event UnityAction<int> ChangedMaxExperience;
    public event UnityAction<int> ChangedLevel;

    public void SetExperience()
    {
        _maxExperience = _levelsInfo.GetMaxExperience(_level);

        ChangedCurrentExperience?.Invoke(_currentExperience);
        ChangedMaxExperience?.Invoke(_maxExperience);
        ChangedLevel?.Invoke(_level);
    }

    public void GetExperience(int experience)
    {
        _currentExperience += experience;
        _allExperience += experience;

        TryIncreaseLevel();

        ChangedCurrentExperience?.Invoke(_currentExperience);
    }

    private void TryIncreaseLevel() 
    { 
        if(_currentExperience >= _maxExperience)
        {
            if(_isMaxLevel == true)
                _currentExperience = _maxExperience;
            else
                TryTakeNextLevel();
        }
    }

    private void TryTakeNextLevel()
    {
        if (_level != _levelsInfo.CountLevels)
            TakeNextLevel();
        else
            ReachedLimitLevel();
    }

    private void TakeNextLevel()
    {
        _level++;
        _currentExperience = _currentExperience - _maxExperience;
        _maxExperience = _levelsInfo.GetMaxExperience(_level);

        ChangedLevel?.Invoke(_level);
        ChangedMaxExperience?.Invoke(_maxExperience);
    }

    private void ReachedLimitLevel()
    {
        _isMaxLevel = true;
        _currentExperience = _maxExperience;
    }
}