using MobilyaETicaret.Repository;

namespace MobilyaETicaret.UnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExixtsStoredProcedure createSP = new ExixtsStoredProcedure();
            //string result = createSP.Sp_AdresMusteriIl();
            string result = createSP.Sp_MusteriBilgileri();
            Console.WriteLine(result);
            Console.Read();
        }
        
    }
}
