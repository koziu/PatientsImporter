﻿namespace PatientsImporter.Infrastructure.ExtensionMethods
{
  public static class ValidatorExtensionMethods
  {
    internal static bool IsValidTaxId(this string input)
    {
      input = input.Replace("-", string.Empty).Trim();
      int[] weights = {6, 5, 7, 2, 3, 4, 5, 6, 7};
      var result = false;
      if (input.Length == 10)
      {
        var controlSum = CalculateControlSum(input, weights);
        var controlNum = controlSum % 11;
        if (controlNum == 10)
          controlNum = 0;
        var lastDigit = int.Parse(input[input.Length - 1].ToString());
        result = controlNum == lastDigit;
      }
      return result;
    }

    private static int CalculateControlSum(string input, int[] weights, int offset = 0)
    {
      var controlSum = 0;
      for (var i = 0; i < input.Length - 1; i++)
        controlSum += weights[i + offset] * int.Parse(input[i].ToString());
      return controlSum;
    }
  }
}