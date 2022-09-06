using UnityEngine;

public class GameCycle : MonoBehaviour
{
    [SerializeField] private ShipInteracterObservable _shipInteracter;
    [SerializeField] private BoxDetector _boxDetector;

    private void GameOver(Box box, Ship ship)
    {
        if (box.GetSize() < ship.GetSize())
        {
            Debug.Log("The box is not on center!");
            return;
        }

        Debug.Log("box was " + box.GetSize() + " but ship was just " + ship.GetSize());
    }

    private void GameOver(Box box)
    {
        Debug.Log("Box Missed!");
    }

    private void OnEnable()
    {
        _shipInteracter.OnFailed += GameOver;
        _boxDetector.OnBoxMissed += GameOver;
    }

    private void OnDisable()
    {
        _shipInteracter.OnFailed -= GameOver;
        _boxDetector.OnBoxMissed += GameOver;
    }
}
