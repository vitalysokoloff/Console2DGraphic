namespace ConsoleGraphic
{
    public class Vector2
    {
        public float x { get; private set; }
        public float y { get; private set; }

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator + (Vector2 a, Vector2 b)
        {
            return new Vector2 { x = a.x + b.x, y = a.y + b.y };
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2 { x = a.x - b.x, y = a.y - b.y };
        }
    }
}
