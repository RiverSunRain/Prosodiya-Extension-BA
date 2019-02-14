using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "WordList")]
    public class WordListItem : ScriptableObject
    {
        public List<Word> WordList;
    }
