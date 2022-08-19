static void EncodeText(string text)
{
    if (string.IsNullOrWhiteSpace(text))
    {
        return;
    }
    text = text.Replace(" ", null);
    var squareRoot = Math.Sqrt(text.Length);
    var ceiling = (int)Math.Ceiling(squareRoot);
    var chars = text.ToCharArray();
    var newText = string.Empty;
    for (var i = 0; i < chars.Length; i++)
    {
        if (i != 0 && i % ceiling == 0)
        {
            newText += $"{Environment.NewLine}{chars[i]}";
        }
        else
        {
            newText += $"{chars[i]}";
        }
    }
    var phrases = newText.Split(Environment.NewLine).ToList();
    var encodedText = string.Empty;
    var indexX = 0;
    var indexY = 0;
    while (indexY < phrases.Count)
    {
        if (phrases[indexY].Length > indexX)
        {
            encodedText += phrases[indexY++].Substring(indexX, 1);
        }
        else
        {
            indexY = 0;
            indexX++;
            encodedText += " ";
            if (indexX >= phrases.First().Length)
            {
                break;
            }
            continue;
        }
        if (indexY != phrases.Count)
        {
            continue;
        }
        indexY = 0;
        indexX++;
        encodedText += " ";
    }
    encodedText.TrimEnd(' ');
    Console.WriteLine(encodedText);
}
EncodeText("we the people of the united states in order to form a more perfect union etc");
EncodeText("cheating is not allowed");
EncodeText("the rocks");
Console.Read();