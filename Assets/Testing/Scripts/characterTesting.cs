using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterTesting : MonoBehaviour
{
    public Character Char1;
    // Start is called before the first frame update
    void Start()
    {
        Char1 = CharacterManager.instance.GetCharacter("Char1", enable : true);
        Char1.GetSprite("body");
    }

    public string[] speech = new string[]
    {
        "Hi",
        "How are you?",
        "This is my dialogue!"
    };
    int i = 0;

    public Vector2 moveTarget;
    public float moveSpeed;
    public bool smooth;

    public string exprName = "frown";
    public string bodyName = "body2";
    public float speed = 5f;
    public bool smoothTransitions = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (i < speech.Length)
            {
                Char1.Say(speech[i]);
            }
            else
            {
                DialogueSystem.instance.Close();
            }
            i++;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Char1.MoveTo(moveTarget, moveSpeed, smooth);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Char1.StopMoving(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(Input.GetKey(KeyCode.T))
                Char1.TransitionExpression(Char1.GetSprite(exprName), speed, smoothTransitions);
            else
                Char1.SetExpression(exprName);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Input.GetKey(KeyCode.G))
                Char1.TransitionBody(Char1.GetSprite(bodyName), speed, smoothTransitions);
            else
                Char1.SetBody(exprName);
        }
    }
}
