using System;
using System.Collections;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100f;
    [SerializeField] GameObject ExplosionObject;

    public event Action<float, float> OnHealthChange = delegate { };
    public event Action<float, float> OnHealthInit = delegate { };
    Vector3 LTPoint;
    Vector3 RTPoint;

    private float healthAmount;

    private void OnEnable()
    {
        healthAmount = MaxHealth;
        OnHealthInit(healthAmount, MaxHealth);
        SetQbjCorners();
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject gameObject = other.gameObject;

        if (gameObject.tag == "Bomb")
        {
            healthAmount -= gameObject.GetComponent<Bomb>().Damage;
            OnHealthChange(healthAmount, MaxHealth);
            checkHealth();
        }
    }

    private void checkHealth()
    {
        if (healthAmount <= 0)
        {
            startDestroySequence();
        }
    }


    void startDestroySequence()
    {
        StartCoroutine(DestroyAnim());
    }

    // Animation of destroying
    IEnumerator DestroyAnim()
    {
        for (int i = 0; i <= 2; i++)
        {
            Instantiate(ExplosionObject, GetRandomPoint(), transform.rotation);
            yield return new WaitForSeconds(1);
        }

        Instantiate(ExplosionObject, GetRandomPoint(), transform.rotation);

        DestroyTheObject();
    }

    void DestroyTheObject()
    {
        Destroy(this.gameObject);
    }

    void SetQbjCorners()
    {
        LTPoint = transform.position + transform.up * (transform.localScale.y / 2) + transform.forward * (transform.localScale.z / 2);
        RTPoint = transform.position + transform.up * (transform.localScale.y / 2) - transform.forward * (transform.localScale.z / 2);
    }

    Vector3 GetRandomPoint()
    {
        Vector3 RandomTop = getRandomVec3InRange(LTPoint, RTPoint);
        Vector3 Bottom = RandomTop - transform.up.normalized * transform.localScale.y;
        Vector3 RandomMiddlePoint = getRandomVec3InRange(RandomTop, Bottom);

        return RandomMiddlePoint;
    }

    Vector3 getRandomVec3InRange(Vector3 from, Vector3 to)
    {
        return new Vector3(UnityEngine.Random.Range(from.x, to.x), UnityEngine.Random.Range(from.y, to.y), UnityEngine.Random.Range(from.z, to.z));
    }

}
