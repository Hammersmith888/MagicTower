
using UnityEngine;

public static class ProfileIDGenerator
{
    public static string GenerateID()
    {
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        for (int i = 0; i < 12; i++)
        {
            int charIndex = Random.Range(48, 84);
            if (charIndex > 57)
            {
                charIndex += 7;
            }
            stringBuilder.Append((char)charIndex);
        }
        return stringBuilder.ToString();
    }
}
