using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttributes : MonoBehaviour
{
    [Header("Managers")]
    public AttributesManager atm;
    public TaskManager taskManager;

    [Header("Enemy")]
    public bool Slime;
    public bool Rabbit;
    public bool GRabbit;
    public bool Cult;

    [Header("Enemy Attribute")]
    public float health;
    public float attack;
    private float EnemycurrentHealth;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject defeatPanel;

    void Start()
    {
        SetDifficultyHealth();
        EnemycurrentHealth = health;
        healthBar.SetMaxHealth(health);

        atm = GameObject.Find("Player").GetComponent<AttributesManager>();
        taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();

        if (Slime)
        {
            taskManager.totalSlimeNeeded++;
        }
        else if (Rabbit)
        {
            taskManager.totalRabbitNeeded++;
        }
        else if (GRabbit)
        {
            taskManager.totalGRabbitNeeded++;
        }
        else if (Cult)
        {
            taskManager.totalCultNeeded++;
        }
    }


    public void TakeDamage(float amount)
    {
        float TstartTime = Time.realtimeSinceStartup;
        EnemycurrentHealth -= amount;
        healthBar.SetHealth(EnemycurrentHealth);
        Vector3 randomness = new Vector3(Random.Range(0f, 0.25f), Random.Range(0f, 0.25f), Random.Range(0f, 0.25f));
        DamagePopUpGenerator.current.CreatePopUp(transform.position, amount.ToString(), Color.yellow);

        if (EnemycurrentHealth <= 0)
        {
            HandleDefeat();
        }
        float TendTime = Time.realtimeSinceStartup;
        float TexTime = (TendTime - TstartTime) * 1000f;
        Debug.Log("Taking damage exeTime:" + TexTime);
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

    private void HandleDefeat()
    {
        if (Slime == true)
        {
            taskManager.slimeNum += 1;
            taskManager.slimeText = true;
            Destroy(gameObject);
            atm.RecoverHealth(10);
        }

        if (Rabbit == true)
        {
            taskManager.rabbitNum += 1;
            taskManager.rabbitText = true;
            Destroy(gameObject);
            atm.RecoverHealth(15);
        }

        if (GRabbit == true)
        {
            taskManager.GrabbitNum += 1;
            taskManager.grabbitText = true;
            Destroy(gameObject);
            atm.RecoverHealth(15);
        }

        if (Cult == true)
        {
            taskManager.cultNum += 1;
            taskManager.cultText = true;
            Destroy(gameObject);
            atm.RecoverHealth(20);
        }

    }

    private void SetDifficultyHealth()
    {
        string difficulty = DifficultyManager.GetDifficulty();

        switch (difficulty)
        {
            case "Easy":
                health = 90;
                break;
            case "Medium":
                health = 150;
                break;
            case "Hard":
                health = 200;
                break;
            default:
                health = 150; // Default to Medium if something goes wrong
                break;
        }

        Debug.Log("Enemy health set to: " + health + " for difficulty: " + difficulty);
    }
}
