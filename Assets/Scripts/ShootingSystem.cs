using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ShootingSystem : MonoBehaviour
{
    [SerializeField] GameObject BulletObj;
    [SerializeField] Text AmmoAmountText;
    [SerializeField] AudioClip ShootSound;
    [SerializeField] AudioSource audioSource;

    [SerializeField] float BulletSpawnOffset = 4f;
    [SerializeField] float ShootForce = 10f;
    [SerializeField] float ShootingSpeed = 2f;
    [SerializeField] int AmmoAmount = 5;
    [SerializeField] int AmmoCreateCapacity = 10;

    bool isLoaded = true;


    GameManager GameManagerObj;


    private void Awake()
    {

        GameManagerObj = FindObjectOfType<GameManager>();
        AmmoAmountText.text = AmmoAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (GameManagerObj.IsPlayerAlive() && isLoaded && AmmoAmount > 0)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bomb = Instantiate(BulletObj, transform.position + transform.up * BulletSpawnOffset, transform.rotation);
        bomb.GetComponent<Rigidbody>().AddForce(transform.up * ShootForce, ForceMode.VelocityChange);
        
        AmmoAmount --;

        // Update ui
        AmmoAmountText.text = AmmoAmount.ToString();

        // Play shoot sound
        SoundManager.PlaySoundOnce(audioSource,ShootSound);

        isLoaded = false;
        Invoke("Reload", ShootingSpeed);
    }

    void Reload()
    {
        isLoaded = true;
    }

    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "AmmoCreate"){
            AmmoAmount += AmmoCreateCapacity;
            AmmoAmountText.text = AmmoAmount.ToString();
        } 
    }
}
