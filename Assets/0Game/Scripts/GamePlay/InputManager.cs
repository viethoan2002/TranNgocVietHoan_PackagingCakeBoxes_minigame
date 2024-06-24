using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Vector3 cur, next;
    [SerializeField] private bool slip;

    public static event Action<Direction> OnMove;

    void Update()
    {
        if (GameController.instance.onPlay)
        {
            if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject == null)
            {
                cur = GameController.instance.cam.ScreenToWorldPoint(Input.mousePosition);
                slip = true;
            }

            if (Input.GetMouseButton(0) && EventSystem.current.currentSelectedGameObject == null)
            {
                if (slip)
                {
                    next = GameController.instance.cam.ScreenToWorldPoint(Input.mousePosition);
                    var x = next.x - cur.x;
                    var y = next.y - cur.y;

                    if (Math.Abs(x) > 0.5f || Math.Abs(y) > 0.5f)
                    {
                        slip = false;

                        if (Math.Abs(x) >= Math.Abs(y))
                        {

                            if (x >= 0)
                                OnMove?.Invoke(Direction.Right);
                            else
                                OnMove?.Invoke(Direction.Left);
                        }
                        else
                        {
                            if (y >= 0)
                                OnMove?.Invoke(Direction.Up);
                            else
                                OnMove?.Invoke(Direction.Down);
                        }
                    }
                }
            }
        }
    }
}

public enum Direction
{
    Left,
    Right,
    Up,
    Down
}
