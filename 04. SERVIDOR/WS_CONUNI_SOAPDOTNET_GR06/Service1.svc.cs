using ec.edu.monster.modelo;

namespace ec.edu.monster.servicio
{
    public class Service1 : IService1
    {
        public double Convert(string category, string fromUnit, string toUnit, double value)
        {
            return UnitConverter.Convert(category, fromUnit, toUnit, value);
        }
    }
}
