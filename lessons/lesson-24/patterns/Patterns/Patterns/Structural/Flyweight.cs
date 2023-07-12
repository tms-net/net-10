namespace TradingApp.Patterns
{

    class Program
    {
        public void Main()
        {
            var p1 = new Pixel { Color = ColorPool.GetColor(0, 0, 0) };
            var p2 = new Pixel { Color = ColorPool.GetColor(0, 0, 0) };

            p1.Green = ColorPool.GetColor(0, 255, 0);
        }
    }

    public class Pixel
    {
        public Color Color { get; set; }
    }

    public class Color
    {
        int Red { get; }
        int Green { get; }
        int Blue { get; }
    }

    public class ColorPool
    {
        public static Color GetColor(int red, int green, int blue)
        {
            var key = red + green + blue;
            var color = _cache.Get(key);
            if (color == null)
            {
                _cache.Add(key, new Color(red, green, blue));
            }

            return _cache.Get(key);
        }
    }
}
