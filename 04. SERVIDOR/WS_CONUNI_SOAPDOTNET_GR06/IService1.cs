using System.ServiceModel;

namespace ec.edu.monster.servicio
{
    [ServiceContract(Namespace = "http://ec.edu.monster/servicio")]
    public interface IService1
    {
        [OperationContract]
        double Convert(string category, string fromUnit, string toUnit, double value);
    }
}
