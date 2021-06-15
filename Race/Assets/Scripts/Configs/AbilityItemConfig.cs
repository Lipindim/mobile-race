using Enums;
using UnityEngine;


namespace Configs
{
    [CreateAssetMenu(fileName = "AbilityItemConfig", menuName = "Data/Ability item")]
    public class AbilityItemConfig : ScriptableObject
    {
        public ItemConfig itemConfig;
        public GameObject view;
        public AbilityType type;
        public float value;
        public int Id => itemConfig.Id;
    }
}
