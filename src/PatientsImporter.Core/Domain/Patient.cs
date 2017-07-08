namespace PatientsImporter.Core.Domain
{
  public class Patient
  {
    public string Name { get; protected set; }
    public string Surname { get; protected set; }
    public string Pesel { get; protected set; }
    public string Email { get; protected set; }

    public Patient(string name, string surname, string pesel, string email)
    {
      SetName(name);
      SetSurname(surname);
      SetPesel(pesel);
      SetEmail(email);
    }

    public void SetEmail(string email)
    {
      Email = email;
    }

    public void SetPesel(string pesel)
    {
      Pesel = pesel;
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