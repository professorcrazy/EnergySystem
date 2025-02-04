using Unity.VisualScripting;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField] int inhabitants = 40000;
    [SerializeField] float usagePerHourPerInhapitant = 0.18f;
    float cityUsagePerHour = 0f;
    float recievedFromInternalGrid = 0f;
    float recievedFromExternalGrid = 0f;
    float timeOfDayModifyer = 1f;
    float electricityCostNowInternal = 0f;
    float electricityCostNowExternal = 0f;

    [SerializeField] float moneySpendToday = 0f;

    [Range(0f, 100f)]
    [SerializeField] float allowedUsage = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = Vector3.one * inhabitants/1000000f;
        cityUsagePerHour = inhabitants * usagePerHourPerInhapitant;
    }

    void CalculateSpending()
    {
        float tempBalance = cityUsagePerHour - recievedFromInternalGrid;
        moneySpendToday += recievedFromInternalGrid * electricityCostNowInternal;
        if(tempBalance > 0) {
            recievedFromExternalGrid -= tempBalance;
            moneySpendToday += recievedFromExternalGrid * electricityCostNowExternal;
        }
    }

    public void KWRecieved(float recieved) {
        recievedFromInternalGrid = recieved;
        CalculateSpending();
    }

}
