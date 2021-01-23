using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character : MonoBehaviour
{
    public Sprite sprite1Body;
    public Sprite sprite1Face;
    public Sprite sprite2Body;
    public Sprite sprite2Face;
    public Sprite sprite3Body;
    public Sprite sprite3Face;

    public Image spriteLayer1Body;
    public Image spriteLayer1Face;
    public Image spriteLayer2Body;
    public Image spriteLayer2Face;
    public Image spriteLayer3Body;
    public Image spriteLayer3Face;

    void Start(){
        spriteLayer1Body.sprite = sprite1Body;
        spriteLayer1Face.sprite = sprite1Face;
        spriteLayer2Body.sprite = sprite2Body;
        spriteLayer2Face.sprite = sprite2Face;
        spriteLayer3Body.sprite = sprite3Body;
        spriteLayer3Face.sprite = sprite3Face;
    }

    void Update(){
      if(Input.GetKeyDown(KeyCode.A))
      {
        spriteLayer1Body.sprite = Resources.Load<Sprite>("Images/unknown");
        StartCoroutine(LerpPosition(new Vector2(1000,1000), 2));
      }

        IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = spriteLayer2Body.transform.position;

        while (time < duration)
        {
            spriteLayer2Body.transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        spriteLayer2Body.transform.position = targetPosition;
      }
    }

}
