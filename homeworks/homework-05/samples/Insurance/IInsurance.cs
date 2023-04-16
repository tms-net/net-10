namespace Homework_4.Insurance
{
    internal interface IInsurance
    {
        bool IsValid();
        decimal Reclaim();
    }

    public abstract class Insurance : IInsurance
    {
        public IActor Client { get; private set; }

        protected IActor Insurer { get; } // readonly

        protected Insurance(IActor insurer)
        {
            Insurer = insurer;
        }

        public virtual bool IsValid()
        {
            if (Client == null || Insurer == null)
            {
                return false;
            }

            return true;
        }

        public abstract decimal Reclaim();
    }

    public class AutoInsurance : Insurance
    {
        public AutoInsurance(IActor insurer) : base(insurer)
        {
        }

        public IAutomobile Automobile { get; set; }

        public override bool IsValid()
        {
            if (Automobile == null)
            {
                return false;
            }

            return base.IsValid();
        }

        public override decimal Reclaim()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IAutomobile
    {
    }

    public interface IActor
    {
    }

    // Record, object
}
