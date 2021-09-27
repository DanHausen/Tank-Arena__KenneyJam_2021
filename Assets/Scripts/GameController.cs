using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int qtdeDeBalas = 3;
    
    [SerializeField] private GameObject bullet_Spawn_Point;
    [SerializeField] private GameObject bullet;
    
    
    //TODO Criar mecanica para spawnar inimigos neste script e tambem evoluir na dificuldade
    //TODO Aqui tambem vai o temporizador e leaderboard
    
    //TODO seria bacana adicionar power ups
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    
    public void FiredBullet(){
        if (qtdeDeBalas > 0){
            GameObject temporary_Rigidbody2D;
            temporary_Rigidbody2D = Instantiate(bullet, bullet_Spawn_Point.transform.position, bullet_Spawn_Point.transform.rotation);
        }
    }
}
