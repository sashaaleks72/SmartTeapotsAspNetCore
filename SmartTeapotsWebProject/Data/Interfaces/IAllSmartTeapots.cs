using SmartTeapotsWebProject.Data.Models;

namespace SmartTeapotsWebProject.Data.Interfaces
{
    public interface IAllSmartTeapots
    {
        IEnumerable<SmartTeapot> SmartTeapots { get; }

        SmartTeapot GetSmartTeapotById(int carId);
    }
}
