using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState{SPAWNING, WAITING, COUNTING};
    
    [System.Serializable]
    public class Wave{
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    
    public Wave[] waves;
    public int nextWave = 0;
    
    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    
    private SpawnState state = SpawnState.COUNTING;
    
    void Start(){
        waveCountdown = timeBetweenWaves;
    }
    
    void Update(){
        if(waveCountdown <= 0){
            if(state != SpawnState.SPAWNING){
                // Spawn wave
            }
        }
        else{
            waveCountdown -= Time.deltaTime;
        }
    }
}
