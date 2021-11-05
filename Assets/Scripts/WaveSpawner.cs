using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState{SPAWNING, WAITING, COUNTING};
    
    [System.Serializable]
    public class Wave{
        public string name;
        public Transform enemy;//TODO Adicionar mais de um tipo de inimigo
        public int count;
        public float rate;
    }
    
    public Wave[] waves;
    public int nextWave = 0;
    
    public Transform[] spawnPoints;
    
    public float timeBetweenWaves = 5f;
    private float _waveCountdown;
    
    private float _searchCountdown = 1f;
    
    public static SpawnState spawnState = SpawnState.COUNTING;
    
    void Start(){
        if(spawnPoints.Length == 0){
            Debug.LogError("No SPAWN points referenced");
        }
        if(waves.Length == 0){
            Debug.LogError("No WAVE points referenced");
        }
        _waveCountdown = timeBetweenWaves;
    }
    
    void Update(){
        if(spawnState == SpawnState.WAITING){
            if(!EnemyIsAlive()){
                //Begin a new wave
                WaveCompleted();
            }
            else{
                return;
            }
        }
        
        if(_waveCountdown <= 0){
            if(spawnState != SpawnState.SPAWNING){
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else{
            _waveCountdown -= Time.deltaTime;
        }
    }
    
    void WaveCompleted(){
        //TODO Adicionar feedback visual que a wave acabou
        //TODO spawnar munição quando a wave acabar
        //Debug.Log("Wave done");
        spawnState = SpawnState.COUNTING;
        _waveCountdown = timeBetweenWaves;
        
        if (nextWave+1 > waves.Length -1){
            nextWave = 0;
            //Debug.Log("All waves complete! Looping...");
        }
        else{
            nextWave++;
        }
        
    }
    
    bool EnemyIsAlive(){
        _searchCountdown -= Time.deltaTime;
        if(_searchCountdown <= 0f){
            _searchCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("IA") == null){
                return false;
            }
        }
        return true;
    }
    
    IEnumerator SpawnWave(Wave _wave){
        //Debug.Log("Spawning wave " + _wave.name);
        spawnState = SpawnState.SPAWNING;
        
        for(int i = 0; i <_wave.count; i++){
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }
        
        spawnState = SpawnState.WAITING;
        
        yield break;
    }
    
    void SpawnEnemy(Transform _enemy){
        //Debug.Log("Spawning enemy: " + _enemy.name);        
        
        Transform _spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
    }
}
