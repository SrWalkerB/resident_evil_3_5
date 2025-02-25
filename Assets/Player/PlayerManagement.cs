using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static PlayerManagement instance;

    [SerializeField] PlayerStatus playerStatus;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerStatus GetPlayerStatus(){
        return playerStatus;
    }
}
