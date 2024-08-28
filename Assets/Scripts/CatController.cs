using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatController : MonoBehaviour {
    [SerializeField] Sprite[] cats;
    [SerializeField] Image image;
    private void Start() {
        int random = Random.Range(0, cats.Length);
        image.sprite = cats[random];
    }
}
