public class CannonBall : Mover {

    public int cannonBallIndex;

    private void Start()
    {
        this.speed = GetComponent<Mover>().speed;
    }
}
