using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDestroyLine : MonoBehaviour
{
    private UIManagerGame _ui;
    private GameManager _gm;
    private GameObject _player;
    public void Start()
    {
        _ui = GameObject.Find("UIManagerGame").GetComponent<UIManagerGame>();
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _player = GameObject.Find("Player");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "defence")
        {
            
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == this.gameObject.GetComponent<SpriteRenderer>().color)
            {
                _player.GetComponent<PlayerController>().PlaySoundDestroyWall();
                collision.gameObject.SetActive(false);
                _player.GetComponent<PlayerController>().PlayEffect(this.gameObject.GetComponent<SpriteRenderer>().color);

                Destroy(this.gameObject);
            }
            else
            {
                _ui.EndGameStart();
            }
        }
        else if(collision.tag == "Player")
        {
            _ui.EndGameStart();
        }

    }
}
