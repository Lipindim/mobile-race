using UnityEngine;


namespace Configs
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "Data/Item Config")]
    public class ItemConfig : ScriptableObject
    {
        public int Id;
        public string Title;
    }
}
