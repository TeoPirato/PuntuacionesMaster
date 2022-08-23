using UnityEngine;

public class AddMatch : MonoBehaviour
{
    [SerializeField] GameObject matchPrefab;

    public void AddNewMatch()
    {
        RectTransform match = (RectTransform)Instantiate(matchPrefab, transform.parent).transform;
        match.transform.SetSiblingIndex(1);
    }
}
