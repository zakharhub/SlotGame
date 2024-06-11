using UnityEngine;
using UnityEngine.UI;

public class NotEnoughEnergy : MonoBehaviour
{
    public GameObject notEnoughEnergyImage;
    public Button button;
    public float popupDuration = 3f;
    //private SlotMachine slotMachine; 
    private bool isPopupShowing = false;
    private float popupTimer = 0f;

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClick);

    }

    private void Start()
    {
        //slotMachine = FindObjectOfType<SlotMachine>(); 
        HideNotEnoughEnergyImage();
    }

    private void Update()
    {

        if (isPopupShowing)
        {
            popupTimer += Time.deltaTime;

            if (popupTimer >= popupDuration)
            {
                HideNotEnoughEnergyImage();
                isPopupShowing = false;
                popupTimer = 0f;
            }
        }
    }

    void OnButtonClick()
    {

        // if (slotMachine != null && slotMachine.energe < 20)
        //{
        ShowNotEnoughEnergyImage();
        isPopupShowing = true;
        //}
    }

    void ShowNotEnoughEnergyImage()
    {
        if (notEnoughEnergyImage != null)
        {
            notEnoughEnergyImage.SetActive(true);
        }
    }

    void HideNotEnoughEnergyImage()
    {
        if (notEnoughEnergyImage != null)
        {
            notEnoughEnergyImage.SetActive(false);
        }
    }
}
