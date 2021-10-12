using UnityEngine;

public class EnemyLifeScript : MonoBehaviour
{
    private int _live = 1;    
    public int live;
    
    private void Start(){
        live = _live;
    }
    
    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Bullet"){
            live--;
            CheckLife();
        }
    }

    private void CheckLife(){
        if(live <= 0){
            ExplosionTrigger();
        }
    }

    private void ExplosionTrigger(){
        //TODO Explodir o inimigo ao morrer
        Destroy(gameObject);
    }

    private void OnDestroy(){
        Leaderboard.LeaderboardUpdater(20);
    }
}
