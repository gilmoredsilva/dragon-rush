using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;
    public AudioClip hurtSound;
    public AudioClip dieSound;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0 && _damage != 0 && gameObject.tag != "RangedEnemy")
        {
            SoundManager.instance.PlaySound(hurtSound);
            anim.SetTrigger("hurt");
        }
        else if (currentHealth == 0)
        {
            if (!dead)
            {
                Debug.Log(gameObject.name + " died!");
                if (GetComponent<BossMechanics>() == null)
                {
                    anim.SetTrigger("die");
                }
                SoundManager.instance.PlaySound(dieSound);
                //Player
                if (GetComponent<Movement>() != null)
                {
                    GetComponent<Movement>().enabled = false;
                }

                //Enemy
                if (GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                }
                if (GetComponent<MeleeEnemy>() != null)
                {
                    GetComponent<MeleeEnemy>().enabled = false;
                }

                //Boss
                if (GetComponent<BossMechanics>() != null)
                {
                    gameObject.SetActive(false);
                    SceneManager.LoadScene(4);
                }

                dead = true;
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
        GetComponent<Movement>().enabled = true;
        dead = false;
    }

    public void Deactivate()
    {
        if (GetComponent<MeleeEnemy>() != null)
        {
            GetComponent<MeleeEnemy>().gameObject.SetActive(false);
        }
        if (GetComponent<RangedEnemy>() != null)
        {
            GetComponent<RangedEnemy>().gameObject.SetActive(false);
        }
    }
}
