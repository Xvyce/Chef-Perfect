using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject FloatingTextPrefab;

    private void OnTriggerEnter2D(Collider2D player)
    {
        StartCoroutine(popup());
    }
        IEnumerator popup()
    {
        var txt = Instantiate(FloatingTextPrefab, transform.position + new Vector3(-2.0f, 1.5f), Quaternion.identity, transform);
        yield return new WaitForSeconds(3);
        Destroy(txt);
    }
}
