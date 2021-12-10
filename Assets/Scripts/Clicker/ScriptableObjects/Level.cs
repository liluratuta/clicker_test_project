using UnityEngine;

namespace Clicker.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level", menuName = "Clicker/Level")]
    public class Level : ScriptableObject
    {
        public int ID => _id;
        public string LevelName => _levelName;

        public int GoalClickCount => _goalClickCount;

        public Sprite BackgroundSprite => _backgroundSprite;

        public Sprite ButtonSprite => _buttonSprite;

        public Sprite BonusSprite => _bonusSprite;

        public int Stars
        {
            get => _stars;
            set => _stars = value;
        }

        [SerializeField, Min(0)] private int _id;
        [SerializeField] private string _levelName;
        [SerializeField, Min(0)] private int _goalClickCount;
        [SerializeField, Range(0, 5)] private int _stars;
        [SerializeField] private Sprite _backgroundSprite;
        [SerializeField] private Sprite _buttonSprite;
        [SerializeField] private Sprite _bonusSprite;
    }
}
