using System;

namespace ConsoleGraphic
{
    class ConsoleGraphic
    {
        static void Main()
        {
            Graphics graphics = new Graphics(80, 50, 2);
            Shape[] shapes = new Shape[16];
            shapes[0] = new SolidRectangle(new Vector2(-2.5f, 0.5f), new Vector2(5, 0.5f), new char[] { '/' });
            shapes[1] = new SolidRectangle(new Vector2(-0.2f, 0.4f), new Vector2(0.4f, 0.5f), new char[] { 'o' });
            shapes[2] = new Line(new Vector2(-0.7f, 0.4f), new Vector2(-0.2f, -0.2f), new char[] { '/' });
            shapes[3] = new Line(new Vector2(0.2f, -0.2f), new Vector2(0.7f, 0.4f), new char[] { '\\' });
            shapes[4] = new Line(new Vector2(-0.7f, 0.4f), new Vector2(0.7f, 0.4f), new char[] { '=' });
            shapes[5] = new Line(new Vector2(-0.45f, -0.25f), new Vector2(-0.1f, -0.7f), new char[] { '/' });
            shapes[6] = new Line(new Vector2(0.1f, -0.7f), new Vector2(0.45f, -0.25f), new char[] { '\\' });
            shapes[7] = new Line(new Vector2(-0.45f, -0.25f), new Vector2(0.45f, -0.25f), new char[] { '=' });
            shapes[8] = new Line(new Vector2(-0.3f, -0.7f), new Vector2(0, -1.1f), new char[] { '/' });
            shapes[9] = new Line(new Vector2(0, -1.1f), new Vector2(0.3f, -0.7f), new char[] { '\\' });
            shapes[10] = new Line(new Vector2(-0.3f, -0.7f), new Vector2(0.3f, -0.7f), new char[] { '=' });
            shapes[11] = new Circle(new Vector2(-0.3f, 0), 0.02f, new char[] { '.', ':', 'a', '@' });
            shapes[12] = new Circle(new Vector2(0.4f, 0.2f), 0.02f, new char[] { '.', ':', 'a', '@' });
            shapes[13] = new Circle(new Vector2(0.1f, -0.2f), 0.02f, new char[] { '.', ':', 'a', '@' });
            shapes[14] = new Circle(new Vector2(-0.1f, -0.5f), 0.02f, new char[] { '.', ':', 'a', '@' });
            shapes[15] = new Circle(new Vector2(0f, -1.1f), 0.05f, new char[] { '.', ':', 'a', '@' });

            Shape[] snowflakes = new Circle[20];
            Random rnd = new Random();
            for (int i = 0; i < snowflakes.Length; i++)
                snowflakes[i] = new Circle(new Vector2(-1.5f + (float)rnd.Next(0,450) / 100, -1f - (float)rnd.Next(0, 200) / 100), 0.002f, new char[] { '*', '*', '*', '*' });

            Console.ReadKey();

            while (true)
            {
                graphics.Begin();
                foreach (Shape s in shapes)
                    graphics.Draw(s);
                foreach (Shape s in snowflakes)
                {
                    graphics.Draw(s);
                    s.Move(new Vector2(-0.005f, 0.01f));
                    if (s.GetPosition().y > 1)
                        s.SetPosition(new Vector2(-1.5f + (float)rnd.Next(0, 450) / 100, -1f - (float)rnd.Next(0, 200) / 100));

                }
                graphics.End();
            }
        }
    }
}
