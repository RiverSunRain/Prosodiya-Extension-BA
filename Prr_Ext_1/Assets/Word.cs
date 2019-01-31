using UnityEngine;

    [CreateAssetMenu(fileName = "Word")]
    public class Word : ScriptableObject
    {
        public string WordString;
        public bool Distractor;
        public int Difficutly;
    }
