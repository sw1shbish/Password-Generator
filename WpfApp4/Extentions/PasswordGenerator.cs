namespace WpfApp4.Extentions;

public class PasswordGenerator
{
    private IList<char> _chars = new List<char>()
    {
        'q', 'w', 'r', 't', 'h', 'j', 'o', 'k'
    };

    private IList<int> _ints = new List<int>()
    {
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9
    };

    private IList<char> _signs = new List<char>
    {
        'Q', 'W', 'E', 'F', 'H', 'U', 'J', 'P'
    };

    public string GeneratePassword(DifPass difficult, int leinght)
    {
        switch (difficult)
        {
            case DifPass.Easy:
                return GenerateEasy(leinght);
            case DifPass.Medium:
                return GenerateMedium(leinght);
            case DifPass.Hard:
                return GenerateHard(leinght);
            default:
                throw new ArgumentOutOfRangeException(nameof(difficult), difficult, null);
        }

        return string.Empty;
    }

    private string GenerateEasy(int leinght)
    {
        string pwd = string.Empty;

        for (int i = 0; i < leinght; i++)
        {
            pwd += _ints[new Random().Next(0, _ints.Count)];
        }

        return pwd;
    }

    private string GenerateMedium(int leinght)
    {
        string pwd = string.Empty;

        for (int i = 0; i < leinght; i++)
        {
            pwd += _ints[new Random().Next(0, _ints.Count)];
            pwd += _chars[new Random().Next(0, _chars.Count)];
        }

        pwd = Shuffle(pwd);

        return pwd.Substring(leinght);
    }
    
    

    public string Shuffle(string str)
    {
        char[] array = str.ToCharArray();
        Random rng = new Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (array[k], array[n]) = (array[n], array[k]);
        }

        return new string(array);
    }

    private string GenerateHard(int leinght)
    {
        string pwd = string.Empty;

        for (int i = 0; i < leinght; i++)
        {
            pwd += _ints[new Random().Next(0, _ints.Count)];
            pwd += _chars[new Random().Next(0, _chars.Count)];
            pwd += _signs[new Random().Next(0, _chars.Count)];
        }
        return pwd;
    }
}

