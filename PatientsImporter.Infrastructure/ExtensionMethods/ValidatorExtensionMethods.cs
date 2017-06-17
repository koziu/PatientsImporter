using System;
using System.Collections.Generic;

namespace PatientsImporter.Infrastructure.ExtensionMethods
{
  public static class ValidatorExtensionMethods
  {
    public static bool IsValidPesel(this string pesel)
    {
      var toRet = false;
      try
      {
        if (pesel.Length == 11)
          toRet = CountSum(pesel).Equals(pesel[10].ToString());
      }
      catch (Exception)
      {
        toRet = false;
      }
      return toRet;
    }

    public static DateTime GetBirthday(this string pesel)
    {
      if (string.IsNullOrEmpty(pesel))
        return DateTime.MinValue;

      if (!pesel.IsValidPesel())
        return DateTime.MinValue;

      var peselIntList = ParseToList(pesel);

      var year = 1900 + (peselIntList[0] * 10) + peselIntList[1];
      if (peselIntList[2] >= 2 && peselIntList[2] < 8)
      {
        var a = peselIntList[2] / 2.0;
        year += (int)(Math.Floor(a) * 100);
      }
      if (peselIntList[2] >= 8)
        year -= 100;

      var month = (peselIntList[2] % 2) * 10 + peselIntList[3];
      var day = peselIntList[4] * 10 + peselIntList[5];

      return new DateTime(year, month, day);
    }

    public static string GetGender(this string pesel)
    {
      if (string.IsNullOrEmpty(pesel))
        return string.Empty;

      if (!pesel.IsValidPesel())
        return string.Empty;

      var peselIntList = ParseToList(pesel);

      return (peselIntList[9] % 2 == 1) ? "Mężczyzna" : "Kobieta";
    }

    private static List<int> ParseToList(string pesel)
    {
      var result = new List<int>();

      foreach (var character in pesel)
      {
        var numberChar = Int32.Parse(character.ToString());
        result.Add(numberChar);
      }

      return result;
    }

    private static string CountSum(string pesel)
    {
      int[] weights = {1, 3, 7, 9, 1, 3, 7, 9, 1, 3};
      var sum = 0;
      for (var i = 0; i < weights.Length; i++)
        sum += weights[i] * int.Parse(pesel[i].ToString());

      var reszta = sum % 10;
      return reszta == 0 ? reszta.ToString() : (10 - reszta).ToString();
    }
  }
}