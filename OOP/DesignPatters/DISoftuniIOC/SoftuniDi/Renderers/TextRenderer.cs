using SoftuniDi.Renderers.Contracts;

namespace SoftuniDi.Renderers;
public class TextRenderer : IRenderer
{
    private string path = "../../../output.txt";
    public void Write(string text)
    {
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.Write(text);
        }
    }

    public void WriteLine(string text)
    {
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(text);
        }
    }
}
