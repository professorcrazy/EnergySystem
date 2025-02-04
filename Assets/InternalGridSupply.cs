using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InternalGridSupply : MonoBehaviour
{
    [SerializeField] Sprite visualRepresentation;

    [SerializeField] float maxDelevery = 10000f;
    [SerializeField] float lossOverDistance = 0.01f;
    
    [Range(0f,100f)]
    [SerializeField] float currentDelevery = 100f;
    float kWSent = 0f;

    public UnityEvent effectorMethod;

    [SerializeField] List<City> cityList = new List<City>();

    // FixedUpdate is called once per physics update (standard 50 frames per second)
    void FixedUpdate()
    {
        kWSent = maxDelevery * currentDelevery;
        float kWperCity = kWSent/cityList.Count;
        foreach (City city in cityList) {
            city.KWRecieved(kWperCity);
        }
    }
}
