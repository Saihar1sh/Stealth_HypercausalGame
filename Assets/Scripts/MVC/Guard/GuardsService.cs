using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardsService : MonoSingletonGeneric<GuardsService>
{

    public List<GuardView> guards;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AlertedPhase(float time, float speedMult)
    {
        foreach (GuardView guard in guards)
        {
            guard.IncreaseGuardSpeedFor(time, speedMult);

        }
        float timer = 0;
        timer += Time.deltaTime;
        if (timer <= time)
        {
            // alarms

        }
    }
}
