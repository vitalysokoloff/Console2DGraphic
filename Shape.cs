namespace ConsoleGraphic
{
    public class Shape
    {
        protected Vector2 position;
        protected char[] texture;        

        public Shape(Vector2 position, char[] texture)
        {
            this.position = position;
            this.texture = texture;
        }

        public virtual char[] Draw(Graphics graphics)
        {
            return new char[graphics.width * graphics.height];
        }

        public void Move(Vector2 direction)
        {
            position += direction;
        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
    }

    public class Circle : Shape
    {
        protected float size;

        /// <summary>
        /// Круг с градиентом
        /// </summary>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <param name="texture">принмает массив из 4х символов</param>
        public Circle(Vector2 position, float size, char[] texture) : base(position, texture)
        {
            this.size = size;
        }

        override public char[] Draw(Graphics graphics)
        {
            char[] buffer = new char[graphics.buffer.Length];
            for (int i = 0; i < graphics.width; i++)
                for (int j = 0; j < graphics.height; j++)
                {
                    float x = (float)i / graphics.width * 2.0f * graphics.multiplier - 1.0f * graphics.multiplier;
                    float y = (float)j / graphics.height * 2.0f * graphics.multiplier - 1.0f * graphics.multiplier;
                    x *= graphics.aspect * graphics.pixelAspect;
                    float f = (x - position.x) * (x - position.x) + (y - position.y) * (y - position.y);

                    char pixel;

                    if (f < size)
                    {
                        if (f < size / 8)
                            pixel = texture[3];
                        else if (f < size / 3)
                            pixel = texture[2];
                        else if (f < size / 1.5f)
                            pixel = texture[1];
                        else
                            pixel = texture[0];

                        buffer[i + j * graphics.width] = pixel;
                    }
                }
            return buffer;
        }
    }

    public class SolidRectangle : Shape
    {
        protected Vector2 size;

        /// <summary>
        /// одноцветный прямоугольник 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <param name="texture">принмает массив из 1го символа</param>
        public SolidRectangle(Vector2 position, Vector2 size, char[] texture) : base(position, texture)
        {
            this.size = size;
        }

        override public char[] Draw(Graphics graphics)
        {
            char[] buffer = graphics.buffer;
            for (int i = 0; i < graphics.width; i++)
                for (int j = 0; j < graphics.height; j++)
                {
                    float x = (float)i / graphics.width * 2.0f * graphics.multiplier - 1.0f * graphics.multiplier;
                    float y = (float)j / graphics.height * 2.0f * graphics.multiplier - 1.0f * graphics.multiplier;
                    x *= graphics.aspect * graphics.pixelAspect;
                    if (x > position.x && x < position.x + size.x && y > position.y && y < position.y + size.y)
                        buffer[i + j * graphics.width] = texture[0];

                }
            return buffer;
        }
    }

    public class Line: Shape
    {
        protected Vector2 endPosition;
        protected float k;
        protected float a;

        public Line(Vector2 position, Vector2 endPosition, char[] texture) : base(position, texture)
        {
            this.endPosition = endPosition;
            k = (endPosition.y - position.y) / (endPosition.x - position.x);
            a = position.y - position.x * k;
        }

        override public char[] Draw(Graphics graphics)
        {
            char[] buffer = graphics.buffer;
            for (int i = 0; i < graphics.width; i++)
                for (int j = 0; j < graphics.height; j++)
                {
                    float x = (float)i / graphics.width * 2.0f * graphics.multiplier - 1.0f * graphics.multiplier;
                    float y = (float)j / graphics.height * 2.0f * graphics.multiplier - 1.0f * graphics.multiplier;
                    x *= graphics.aspect * graphics.pixelAspect;
                    float f = k * x + a;
                    if (y > f - 0.05f && y < f + 0.05f && x > position.x && x < endPosition.x)
                        buffer[i + j * graphics.width] = texture[0];
                }
            return buffer;
        }
    }
}
