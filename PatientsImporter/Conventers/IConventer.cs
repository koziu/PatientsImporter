namespace PatientsImporter.Conventers
{
  public interface IConventer<in TSource, out TResult> 
  {
    TResult Convert(TSource source);
  }
}