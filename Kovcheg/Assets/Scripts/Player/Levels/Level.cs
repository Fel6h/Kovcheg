using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Level", menuName = "Level/Create new Level", order = 51)]

public class Level : ScriptableObject
{
    [SerializeField] private int _number;
    [SerializeField] private int _countPointSkill;
    [SerializeField] private int _requiredExperience;

    public int Number => _number;
    public int CountPointSkill => _countPointSkill;
    public int RequiredExperience => _requiredExperience;
}
