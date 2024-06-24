using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeCtrl : MonoBehaviour
{
    public float speed;
    public GameObject box;

    public LayerMask defaultMask;
    public LayerMask targetMask;

    private void OnEnable()
    {
        InputManager.OnMove += Move;
    }

    private void OnDisable()
    {
        InputManager.OnMove -= Move;

        transform.DOKill();
    }

    private void Update()
    {
        Debug.DrawLine((Vector2)transform.position + Vector2.up * 0.5f, (Vector2)transform.position + Vector2.up * 5, Color.green);
        Debug.DrawLine((Vector2)transform.position - Vector2.up * 0.5f, (Vector2)transform.position - Vector2.up * 5, Color.green);
        Debug.DrawLine((Vector2)transform.position + Vector2.right * 0.5f, (Vector2)transform.position + Vector2.right * 5, Color.green);
        Debug.DrawLine((Vector2)transform.position - Vector2.right * 0.5f, (Vector2)transform.position - Vector2.right * 5, Color.green);
    }

    private void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Right:
                MoveRayCast(Vector2.right);
                break;
            case Direction.Left:
                MoveRayCast(-Vector2.right);
                break;
            case Direction.Up:
                MoveRayCast(Vector2.up);
                break;
            case Direction.Down:
                RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position - 0.5f * Vector2.up, -Vector2.up, 10, targetMask);
                if (hit.collider != null && Vector2.Distance(transform.position, hit.point) > .55f)
                {
                    transform.DOMove(hit.point + 0.55f * Vector2.up, speed).SetSpeedBased(true).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        if (box!=null)
                        {
                            GameController.instance.onPlay = false;
                            box.GetComponent<BoxCtrl>().effect.Play();
                            gameObject.SetActive(false);
                            Invoke("Win", 1.25f);
                        }
                    });
                }
                else
                    MoveRayCast(-Vector2.up);
                break;
        }
    }

    public void MoveRayCast(Vector2 direction)
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll((Vector2)transform.position, direction, 10, defaultMask);
        int index = 0;
        Vector2 pos = Vector2.zero;
        for (int i = hit.Length - 1; i >= 0; i--)
        {
            if (hit[i].collider.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                pos = (Vector2)hit[i].point - 0.55f * direction;
                index = 0;
            }
            else
            {
                if (Vector2.Distance(hit[i].transform.position, pos) > 0.55f)
                {
                    hit[i].collider.transform.DOMove(pos - index * direction, speed).SetSpeedBased(true).SetEase(Ease.Linear);
                }

                index += 1;
            }
        }
    }

    public void Win()
    {
        GameController.instance.CheckWin();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
            box = collision.gameObject;
        }
    }
}
