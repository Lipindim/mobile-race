using Enums;
using UnityEngine;


namespace Configs
{
    [CreateAssetMenu(fileName = "AbilityItemConfig", menuName = "Data/Ability item")]
    public class AbilityItemConfig : ScriptableObject
    {
        public ItemConfig ItemConfig;
        public GameObject View;
        public AbilityType Type;
        public float Value;
        public int Id => ItemConfig.Id;
    }
}
