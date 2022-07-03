using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image HealthImage;
    [SerializeField] float ChangeSpeed = .5f;


    private void OnEnable() {
        Destroyable parent = GetComponentInParent<Destroyable>();
        parent.OnHealthChange += handleChange;
        HealthImage.fillAmount = 1;
    }

    void handleChange(float healthAmount,float MaxHealth){
        float pct = healthAmount / MaxHealth;
        print("health change handle");
        StartCoroutine(healthChangeProcessor(pct));
    }

    IEnumerator healthChangeProcessor(float pct){
        float currentHealth = HealthImage.fillAmount;
        float t = 0f;

        while(pct < HealthImage.fillAmount){
            t += Time.deltaTime;
            HealthImage.fillAmount = Mathf.Lerp(currentHealth, pct, t / ChangeSpeed);

            if(HealthImage.fillAmount <= 0) StartCoroutine(removeBar());
            yield return null;
        }
    }

    IEnumerator removeBar(){
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
