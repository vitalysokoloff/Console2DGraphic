using System;

namespace ConsoleGraphic
{
    public class Graphics
    {
        public int width { get; }
        public int height { get; }
        public float aspect { get; }
        public float pixelAspect { get; }
        public float multiplier { get; }
        public char[] buffer { get; private set; }

        public Graphics(int width, int height, float multiplier)
        {
            this.width = width;
            this.height = height;
            this.multiplier = multiplier;
            aspect = (float)width / height;
            pixelAspect = 8.0f / 12.0f;
            buffer = new char[width * height];
        }

        private void Reset() // Заполняет буффер пробелами
        {
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    buffer[i + j * width] = ' ';
        }

        public void Begin() // обнуляет буффер и положение курсора в консоли
        {
            Reset();
            Console.SetCursorPosition(0, 0);
        }

        public void Draw(Shape shape) // Добавляет форму в буффер
        {
            // дроу у шейп должно возвращать изменёный массив чаров где добавилась форма
            char[] shapeBuffer = shape.Draw(this);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    if (shapeBuffer[i + j * width] != 0)
                    buffer[i + j * width] = shapeBuffer[i + j * width];
                }
        }

        public void End() // Выводит буфер в консоль. Может показаться не логичным, но всё ок.
        {
            Console.WriteLine(buffer);
        }
    }
}
