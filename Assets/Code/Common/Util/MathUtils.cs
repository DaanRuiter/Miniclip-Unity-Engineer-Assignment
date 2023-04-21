namespace Miniclip.Common.Util
{
    public static class MathUtils
    {
        public static int Mod(int a, int n)
        {
            return (a % n + n) % n;
        }
    }
}