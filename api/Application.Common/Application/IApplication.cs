namespace App.Common.Application
{
    public interface IApplication
    {
        void OnApplicationStarted();
        void OnApplicationRequestStarted();
        void OnApplicationRequestEnded();
        void OnUnHandledError();
        void OnApplicationEnded();
    }
}