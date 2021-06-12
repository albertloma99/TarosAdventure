using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DefaultNamespace;
using UnityEngine;

public class Instanciator : MonoBehaviour
{
    public GameObject toInstanciate;

    public Transform Destination;

    public int SpawnTimeMilis;

    private bool destroyed = false;
    async void Start()
    {
        await Spawn();
    }

    private async Task Spawn()
    {
        while (!destroyed)
        {
            await Task.Delay(SpawnTimeMilis);
            var gm = Instantiate(toInstanciate,this.transform.position, this.transform.rotation);
            gm.GetComponent<PlataformasQueSubenYMueren>().target = Destination.position;
        }
    }

    private void OnDestroy()
    {
        destroyed = true;
    }
}
