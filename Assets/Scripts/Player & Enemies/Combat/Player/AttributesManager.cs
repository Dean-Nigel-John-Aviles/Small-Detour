using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    public float health;
    public float attack;
    private float currentHealth;
    private float InvinsibleAmt;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject defeatPanel; // Reference to the defeat panel

    void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }

    private void Update()
    {

        if (InvinsibleAmt > 0)
        {
            InvinsibleAmt -= Time.deltaTime;
        }
    }

    public void TakeDamage(float amount)
    {
        float TstartTime = Time.realtimeSinceStartup;
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
        Vector3 randomness = new Vector3(Random.Range(0f, 0.25f), Random.Range(0f, 0.25f), Random.Range(0f, 0.25f));
        DamagePopUpGenerator.current.CreatePopUp(transform.position, amount.ToString(), Color.yellow);

        if (currentHealth <= 0)
        {
            HandleDefeat();
        }
        float TendTime = Time.realtimeSinceStartup;
        float TexTime = (TendTime - TstartTime) * 1000f;
        Debug.Log("Taking damage exeTime:" + TexTime);
    }

    public void RecoverHealth(int amount)
    {
        currentHealth += amount;

        // Check if currentHealth exceeds maxHealth
        if (currentHealth > health)
        {
            currentHealth = health; // Set currentHealth to maxHealth
        }

        // Check if currentHealth is below zero
        if (currentHealth < 0)
        {
            currentHealth = 0; // Set currentHealth to zero
        }

        healthBar.SetHealth(currentHealth); // Update the health bar
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            atm.TakeDamage(attack);
            Debug.Log("Attack!");
        }
    }

    public void Invinsible(float delay, float invinsibleLength)
    {
        if (delay > 0)
        {
            StartCoroutine(StartInvinsible(delay, invinsibleLength));
        }
        else
        {
            InvinsibleAmt = invinsibleLength;
        }
    }

    IEnumerator StartInvinsible(float dly, float invsLength)
    {
        yield return new WaitForSeconds(dly);
        Debug.Log("Invinsible");
        InvinsibleAmt = invsLength;
    }

    private void HandleDefeat()
    {
        if (gameObject.CompareTag("Player") && defeatPanel != null)
        {
            // If the object is the player, and a defeatPanel is assigned, activate the panel
            defeatPanel.SetActive(true);
        }

        Destroy(gameObject);

        // Additional defeat handling logic can be added here
    }
}
