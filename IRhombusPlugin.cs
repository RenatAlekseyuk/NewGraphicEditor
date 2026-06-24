namespace ForeignRhombusPlugin
{
    public interface IRhombusPlugin
    {
        string GetName();
        int[] GetPoints();
        void SetPoints(int[] points);
        string GetDescription();
        void Render(object canvas);
    }
}