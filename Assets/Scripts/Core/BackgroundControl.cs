using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundControl : MonoBehaviour
{
    public Sprite background;
    public Image backgroundLayer;
    // Start is called before the first frame update
    void Start()
    {
          backgroundLayer.sprite = background;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space))
      {
          StartCoroutine(LoadNextBG(0.5f));
      }
    }

    IEnumerator LoadNextBG(float speed)
    {
      CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
		  while (canvasGroup.alpha>0){
			       canvasGroup.alpha -= Time.deltaTime /speed;
             yield return null;
           }
  		canvasGroup.interactable = false;

      backgroundLayer.sprite = Resources.Load<Sprite>("Images/unknown");

		  while (canvasGroup.alpha<1){
			       canvasGroup.alpha += Time.deltaTime / speed;
             yield return null;
           }
  		canvasGroup.interactable = false;
  		yield return null;


    }

}
