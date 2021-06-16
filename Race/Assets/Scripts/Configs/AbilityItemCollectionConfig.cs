using UnityEngine;


namespace Configs
{
    [CreateAssetMenu(fileName = "AbilityItemCollectionConfig", menuName = "Data/Ability collection")]
    public class AbilityItemCollectionConfig : ScriptableObject
    {
        public AbilityItemConfig[] Abilities;
    }
}
