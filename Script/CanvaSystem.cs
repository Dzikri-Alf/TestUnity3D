using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaSystem : MonoBehaviour
{
    public static CanvaSystem Instance {get; set;}

    public GameObject InventoryScreen;
    public GameObject HillScreen;
    public GameObject VAScreen;
    public GameObject PlayerCamera;
    private bool isOpen;
    private bool hillOpen;
    private bool VAOpen;
    private bool FPSOpen;

    [SerializeField] 
    private Rigidbody cameraRespawn;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        hillOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isOpen)
        {
            Debug.Log("i is pressed");
            InventoryScreen.SetActive(true);
            PlayerCamera.GetComponent<MouseLook>().enabled = false;
            cameraRespawn.GetComponent<StrafeMovement>().enabled = false;
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpen)
        {
            InventoryScreen.SetActive(false);
            PlayerCamera.GetComponent<MouseLook>().enabled = true;
            cameraRespawn.GetComponent<StrafeMovement>().enabled = true;
            isOpen = false;
        }
        else if(Input.GetKeyDown(KeyCode.U) && !hillOpen)
        {
            Debug.Log("u is pressed");
            HillScreen.SetActive(true);
            PlayerCamera.GetComponent<MouseLook>().enabled = false;
            cameraRespawn.GetComponent<StrafeMovement>().enabled = false;
            hillOpen = true;
        }
        else if(Input.GetKeyDown(KeyCode.U) && hillOpen)
        {
            HillScreen.SetActive(false);
            PlayerCamera.GetComponent<MouseLook>().enabled = true;
            cameraRespawn.GetComponent<StrafeMovement>().enabled = true;
            hillOpen = false;
        }
        else if(Input.GetKeyDown(KeyCode.O) && !VAOpen)
        {
            Debug.Log("o is pressed");
            VAScreen.SetActive(true);
            PlayerCamera.GetComponent<MouseLook>().enabled = false;
            cameraRespawn.GetComponent<StrafeMovement>().enabled = false;
            VAOpen = true;
        }
        else if(Input.GetKeyDown(KeyCode.O) && VAOpen)
        {
            VAScreen.SetActive(false);
            PlayerCamera.GetComponent<MouseLook>().enabled = true;
            cameraRespawn.GetComponent<StrafeMovement>().enabled = true;
            VAOpen = false;
        }
    }
}
