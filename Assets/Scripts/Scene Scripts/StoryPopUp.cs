using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPopUp : MonoBehaviour
{
    public GameObject FloatingTextPrefab;

    private void OnTriggerEnter2D(Collider2D player)
    {
        StartCoroutine(popup());
    }

    IEnumerator popup()
    {
        var txt = Instantiate(FloatingTextPrefab, transform.position + new Vector3(-3, 3), Quaternion.identity, transform);
        yield return new WaitForSeconds(5);
        Destroy(txt);
    }
}
