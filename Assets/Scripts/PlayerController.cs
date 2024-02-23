using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        UpdatePuyoLateralPosition();
    }

    private void UpdatePuyoLateralPosition()
    {
        int inputDirection = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) inputDirection--;
        if (Input.GetKeyDown(KeyCode.RightArrow)) inputDirection++;

        if (inputDirection == 0) return;
        if (MainGame.Instance.IsXOutOfBounds(MainGame.Instance.CurrentPuyo.GridPosition.x + inputDirection)) return;

        MainGame.Instance.CurrentPuyo.MoveX(inputDirection);
    }
}
