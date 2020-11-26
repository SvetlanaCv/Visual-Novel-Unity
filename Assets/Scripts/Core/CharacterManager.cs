using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Spawns characters
public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    public RectTransform characterPanel;

    public List<Character> characters = new List<Character>();

    public Dictionary<string, int> characterDictionary = new Dictionary<string, int>();

    void Awake()
    {
        instance = this;
    }

    public Character GetCharacter(string characterName, bool createChar = true, bool enable = true)
    {
        int index = -1;
        if(characterDictionary.TryGetValue(characterName, out index))
        {
            return characters[index];
        }
        else if(createChar)
        {
            return CreateCharacter(characterName, enable);
        }
        return null;
    }

    public Character CreateCharacter(string characterName, bool enable = true)
    {
        Character newChar = new Character(characterName, enable);

        characterDictionary.Add(characterName, characters.Count);
        characters.Add(newChar);

        return newChar;
    }

    public class characterPositions
    {
        public Vector2 bottomLeft = new Vector2(0,0);
        public Vector2 bottomRight = new Vector2(1,0);
        public Vector2 topLeft = new Vector2(0,1);
        public Vector2 topRight = new Vector2(1,1);
        public Vector2 center = new Vector2(0.5f, 0);
    }
}
