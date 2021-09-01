using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    private Animator animator;

    public Image healthbar;
    void Awake()
    {
        currentHealth = maxHealth;
        if (healthbar != null)
            healthbar.fillAmount = 1.0f;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (this.transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void TakeDamage(float value)
    {
        FindObjectOfType<AudioManagerScript>().Play("Hit_Sound");

        currentHealth -= value;
        if (healthbar != null)
            healthbar.fillAmount = currentHealth / maxHealth;
        // Debug.Log(string.Format("{0}'s health is {1}/{2},gameObject.name,currentHealth,maxHealth"));
        Debug.Log("takeingdamage");
        animator.SetTrigger("isHit");
        if (currentHealth <= 0)
        {
            // Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}