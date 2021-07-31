using UtopiaCity.Models.Sport;

namespace UtopiaCity.ViewModels.Sport
{
    /// <summary>
    /// Class to combine information about <see cref="SportComplex"/> and <see cref="SportEvent"/> for sending into View
    /// </summary>
    public class SportComplexEventViewModel
    {
        public SportComplex SportComplex { get; set; }
        public SportEvent SportEvent { get; set; }
    }
}
