namespace PatientsImporter.Core.Domain
{
  public class Patient
  {
    public string Name { get; protected set; }
    public string Surname { get; protected set; }
    public string TaxId { get; protected set; }
    public string Email { get; protected set; }

    public Patient(string name, string surname, string taxId, string email)
    {
      SetName(name);
      SetSurname(surname);
      SetTaxId(taxId);
      SetEmail(email);
    }

    public void SetEmail(string email)
    {
      Email = email;
    }

    public void SetTaxId(string taxId)
    {
      TaxId = taxId;
    }

    public void SetName(string name)
    {
      Name = name;
    }

    public void SetSurname(string surname)
    {
      Surname = surname;
    }
  }
}