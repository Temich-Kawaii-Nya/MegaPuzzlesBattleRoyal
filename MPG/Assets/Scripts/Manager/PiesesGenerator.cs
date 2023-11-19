using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.UI.Image;

public class PiesesGenerator : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefub;
    private int countX = 5;
    private int countY = 5;

    public static event Action<GameObject> OnPieceCreated;
    public static event Action OnGenerationFinished;

    [SerializeField] Texture2D texture2d;
    private void Start()
    {
        StartCoroutine(CutPicture(texture2d));
    }

    public IEnumerator CutPicture(Texture2D picture)
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < countX; i++)
        {
            for (int j = 0; j < countY; j++)
            {
                Rect rect = new Rect(i * picture.width / countX, j * picture.height / countY, picture.width / countX, picture.height / countY);
                Sprite puzzlePieceSprite = Sprite.Create(picture, rect, new Vector2(0.5f, 0.5f));
                GameObject puzzlePieceObject = Instantiate(prefub, parent.transform);
                puzzlePieceObject.GetComponent<SpriteRenderer>().sprite = puzzlePieceSprite;
                puzzlePieceObject.GetComponent<BoxCollider2D>().size = Vector2.one;
                Vector2 S = puzzlePieceObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
                puzzlePieceObject.GetComponent<BoxCollider2D>().size = S;

                float offsetX = picture.width / 200f - (picture.width/countX)/200f;
                float offsetY = picture.height / 200f - (picture.height / countY) / 200f;

                puzzlePieceObject.transform.position = new Vector3((i * (picture.width / countX) / 100f) - offsetX, (j * (picture.height / countY) / 100f) - offsetY, 0);
                OnPieceCreated?.Invoke(puzzlePieceObject);
            }
        }
        OnGenerationFinished?.Invoke();

    }
}
