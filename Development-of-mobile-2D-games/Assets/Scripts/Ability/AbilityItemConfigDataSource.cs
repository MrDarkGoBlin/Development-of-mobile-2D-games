using UnityEngine;


[CreateAssetMenu(fileName = "AbilityItemConfigDataSource", menuName = "AbilityItemConfigDataSource")]
public class AbilityItemConfigDataSource : ScriptableObject
{
    [SerializeField]
    private AbilityItemConfig[] _itemConfigs;

    public AbilityItemConfig[] ItemConfigs => _itemConfigs;
}