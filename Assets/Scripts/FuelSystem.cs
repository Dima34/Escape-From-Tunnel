using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    [SerializeField] float TankCapacity;
    [SerializeField] float FuelConsumtion;
    [SerializeField] Text FuelText;
    [SerializeField] int SecondsToRestart = 3;
    [SerializeField] AudioClip OutOfFuelSound;
    [SerializeField] int CanisterCapacity = 50;

    float fuelAmount;
    Movement movementHandler;
    AudioSource AudioSource;
    
    GameManager GameManagerObj;


    // Start is called before the first frame update
    void Start()
    {
        fuelAmount = TankCapacity;
        movementHandler = GetComponent<Movement>();
        AudioSource = GetComponent<AudioSource>();
        GameManagerObj = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        HandleFuelUI();

        if(GameManagerObj.IsPlayerAlive()){
            if(
                Input.GetAxisRaw("Horizontal") == -1 ||
                Input.GetAxisRaw("Horizontal") == 1 ||
                Input.GetAxisRaw("Jump") == 1
            ){
                cosumeFuel();
            }

            if(!isTankFull()){
                StartOutOfFuelSequence();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Fuel"){
            Destroy(other.gameObject);
            fuelAmount += CanisterCapacity;
        }
    }
 
    public void HandleFuelUI(){
        FuelText.text = ((int)fuelAmount).ToString();
    }

    public void cosumeFuel(){
        if(isTankFull()){
            fuelAmount -= FuelConsumtion * Time.deltaTime;
        }
    }

    public bool isTankFull(){
        if(fuelAmount <= 0){
            return false;
        }

        return true;
    }


    public void StartOutOfFuelSequence(){
        AudioSource.Stop();
        AudioSource.PlayOneShot(OutOfFuelSound);
        GameManagerObj.StartReloadSequence();
    }

}
