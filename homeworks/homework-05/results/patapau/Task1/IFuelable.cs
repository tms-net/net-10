namespace patapau.Task1
{
    public interface IFuelable
    {
        void RefuelHalfTank();// заправка пол бака
        void RefuelFullTank();// заправка до полного бака
        string GetLastRefuelInfo();//Получаем информацию о последней заправке
        double GetCurrentFuelLevel();//определяет текущее кол-во топлива в баке
    }
}
