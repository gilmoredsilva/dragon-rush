using UnityEngine;

public class Attack : MonoBehaviour
{
    public float cooldown;
    private Animator anim;
    private Movement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    public AudioClip fireballSound;
    public AudioClip watershotSound;
    public AudioClip electrosparkSound;
    public Transform firePoint;
    public GameObject[] fireballs;
    public GameObject[] watershots;
    public GameObject[] electrosparks;
    public GameObject[] dendroshots;
    public PlayerElement elem;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && cooldownTimer > cooldown && playerMovement.canAttack() && elem.type != 3)
        {
            Shoot();
        }
        else if (Input.GetMouseButtonDown(0) && cooldownTimer > cooldown + 3f && playerMovement.canAttack() && elem.type == 3)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        if (elem.type == 0)
        {
            SoundManager.instance.PlaySound(fireballSound);
            fireballs[FindFireball()].transform.position = firePoint.position;
            fireballs[FindFireball()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
        }
        else if (elem.type == 1)
        {
            SoundManager.instance.PlaySound(watershotSound);
            watershots[FindWaterShots()].transform.position = firePoint.position;
            watershots[FindWaterShots()].GetComponent<WaterProjectile>().setDirection(Mathf.Sign(transform.localScale.x));
        }
        else if (elem.type == 2)
        {
            SoundManager.instance.PlaySound(electrosparkSound);
            electrosparks[FindElectroSparks()].transform.position = firePoint.position;
            electrosparks[FindElectroSparks()].GetComponent<ElectroSparkProjectile>().setDirection(Mathf.Sign(transform.localScale.x));
        }
        else if (elem.type == 3)
        {
            dendroshots[FindDendroShots()].transform.position = firePoint.position;
            dendroshots[FindDendroShots()].GetComponent<DendroProjectile>().setDirection(Mathf.Sign(transform.localScale.x));
        }
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private int FindWaterShots()
    {
        for (int i = 0; i < watershots.Length; i++)
        {
            if (!watershots[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private int FindElectroSparks()
    {
        for (int i = 0; i < electrosparks.Length; i++)
        {
            if (!electrosparks[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private int FindDendroShots()
    {
        for (int i = 0; i < dendroshots.Length; i++)
        {
            if (!dendroshots[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
